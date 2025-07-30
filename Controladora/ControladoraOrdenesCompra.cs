using Entidades.Compras;
using Entidades.Patrones;
using Entidades.Validaciones;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraOrdenesCompra
    {
        private Context context;
        private static ControladoraOrdenesCompra instancia;

        public static ControladoraOrdenesCompra Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraOrdenesCompra();
                return instancia;
            }
        }

        private ControladoraOrdenesCompra()
        {
            context = new Context();
        }

        public ReadOnlyCollection<OrdenCompra> RecuperarOrdenesCompra()
        {
            return context.OrdenesCompra
                .Include(o => o.Proveedor)
                .Include(o => o.Detalles)
                .ThenInclude(d => d.Producto)
                .ToList().AsReadOnly();
        }

        public void CrearOrdenCompra(int proveedorId, List<DetalleOrdenCompra> detalles, string observaciones = "")
        {
            var orden = new OrdenCompra
            {
                Numero = GenerarNumeroOrden(),
                FechaCreacion = DateTime.Now,
                Estado = OrdenCompra.EstadoOrden.Pendiente,
                ProveedorId = proveedorId,
                Detalles = detalles,
                Observaciones = observaciones,
                Total = detalles.Sum(d => d.Subtotal)
            };

            foreach (var detalle in detalles)
            {
                detalle.Subtotal = detalle.Cantidad * detalle.PrecioUnitario;
            }

            context.OrdenesCompra.Add(orden);
            context.SaveChanges();

            // AUDITORÍA: Registrar creación
            ServicioAuditoria.Instancia.AuditarCreacion(orden, $"Orden creada con {detalles.Count} productos");

            NotificadorOrdenesCompra.Instancia.NotifyObservers("ORDEN_CREADA", orden);
        }

        public void CambiarEstadoOrden(int ordenId, OrdenCompra.EstadoOrden nuevoEstado)
        {
            var orden = context.OrdenesCompra.Find(ordenId);
            if (orden == null)
                throw new Exception("Orden no encontrada");

            // AUDITORÍA: Capturar estado anterior
            var estadoAnterior = orden.Estado.ToString();

            orden.Estado = nuevoEstado;

            switch (nuevoEstado)
            {
                case OrdenCompra.EstadoOrden.Enviada:
                    orden.FechaEnvio = DateTime.Now;
                    break;
                case OrdenCompra.EstadoOrden.Recibida:
                    orden.FechaRecepcion = DateTime.Now;
                    ActualizarStock(orden);
                    break;
            }

            context.SaveChanges();

            // AUDITORÍA: Registrar cambio de estado
            ServicioAuditoria.Instancia.AuditarCambioEstado(ordenId, estadoAnterior, nuevoEstado.ToString(),
                $"Cambio de estado por usuario {ControladoraSeguridad.Instancia.UsuarioActual?.NombreUsuario}");

            NotificadorOrdenesCompra.Instancia.NotifyObservers("ESTADO_CAMBIADO", orden);
        }

        public void ModificarOrden(int ordenId, int nuevoProveedorId, string nuevasObservaciones)
        {
            var orden = context.OrdenesCompra.Find(ordenId);
            if (orden == null)
                throw new Exception("Orden no encontrada");

            // AUDITORÍA: Capturar estado anterior
            var ordenAnterior = new OrdenCompra
            {
                Id = orden.Id,
                ProveedorId = orden.ProveedorId,
                Observaciones = orden.Observaciones,
                Total = orden.Total
            };

            // Aplicar cambios
            orden.ProveedorId = nuevoProveedorId;
            orden.Observaciones = nuevasObservaciones;

            context.SaveChanges();

            // AUDITORÍA: Registrar modificación
            ServicioAuditoria.Instancia.AuditarModificacion(ordenAnterior, orden, "Modificación de orden de compra");
        }

        public void EliminarOrden(int ordenId, string motivo = "")
        {
            var orden = context.OrdenesCompra
                .Include(o => o.Detalles)
                .FirstOrDefault(o => o.Id == ordenId);

            if (orden == null)
                throw new Exception("Orden no encontrada");

            if (orden.Estado != OrdenCompra.EstadoOrden.Pendiente)
                throw new Exception("Solo se pueden eliminar órdenes pendientes");

            // AUDITORÍA: Registrar eliminación ANTES de eliminar
            ServicioAuditoria.Instancia.AuditarEliminacion(orden, $"Motivo: {motivo}");

            context.OrdenesCompra.Remove(orden);
            context.SaveChanges();
        }

        private void ActualizarStock(OrdenCompra orden)
        {
            var detalles = context.DetallesOrdenesCompra
                .Include(d => d.Producto)
                .Where(d => d.OrdenCompraId == orden.Id)
                .ToList();

            foreach (var detalle in detalles)
            {
                var stockAnterior = detalle.Producto.StockActual;
                detalle.Producto.StockActual += detalle.Cantidad;

                // AUDITORÍA: Registrar cambio de stock
                var auditoriaStock = new AuditoriaOrdenesCompra
                {
                    OrdenCompraId = orden.Id,
                    Accion = "UPDATE_STOCK",
                    Campo = $"Stock_Producto_{detalle.Producto.Codigo}",
                    ValorAnterior = stockAnterior.ToString(),
                    ValorNuevo = detalle.Producto.StockActual.ToString(),
                    FechaHora = DateTime.Now,
                    UsuarioId = ControladoraSeguridad.Instancia.UsuarioActual?.Id ?? 0,
                    Observaciones = $"Actualización automática por recepción de orden {orden.Numero}"
                };

                context.AuditoriasOrdenesCompra.Add(auditoriaStock);
            }
        }

        private string GenerarNumeroOrden()
        {
            var ultimaOrden = context.OrdenesCompra
                .OrderByDescending(o => o.Id)
                .FirstOrDefault();

            int numero = ultimaOrden?.Id + 1 ?? 1;
            return $"OC-{DateTime.Now.Year}-{numero:D4}";
        }
    }
}