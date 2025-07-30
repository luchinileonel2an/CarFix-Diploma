using Entidades.Tickets;

namespace Vista.Patrones
{
    public class FormularioFactoryManager
    {
        private static FormularioFactoryManager _instancia;
        private static readonly object _lock = new object();
        private readonly Dictionary<TipoEntidad, FormularioFactory> _factories;

        private FormularioFactoryManager()
        {
            _factories = new Dictionary<TipoEntidad, FormularioFactory>
            {
                { TipoEntidad.Cliente, new ClienteFormFactory() },
                { TipoEntidad.Tecnico, new TecnicoFormFactory() },
                { TipoEntidad.Vehiculo, new VehiculoFormFactory() },
                { TipoEntidad.Ticket, new TicketFormFactory() }
            };
        }

        public static FormularioFactoryManager Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    lock (_lock)
                    {
                        if (_instancia == null)
                            _instancia = new FormularioFactoryManager();
                    }
                }
                return _instancia;
            }
        }

        public IFormularioDatos CrearFormulario(TipoEntidad tipo, Operacion operacion, object entidad = null)
        {
            if (_factories.TryGetValue(tipo, out FormularioFactory factory))
            {
                return factory.CrearYConfigurarFormulario(operacion, entidad);
            }
            throw new ArgumentException($"No existe factory para el tipo {tipo}");
        }

        public DialogResult CrearYMostrarFormulario(TipoEntidad tipo, Operacion operacion, object entidad = null)
        {
            var formulario = CrearFormulario(tipo, operacion, entidad);
            return formulario.MostrarDialogo();
        }
    }
}