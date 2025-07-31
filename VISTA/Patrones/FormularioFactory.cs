using Vista.Formularios.Datos;

namespace Vista.Patrones
{
    public abstract class FormularioFactory
    {
        public abstract IFormularioDatos CrearFormulario();

        public IFormularioDatos CrearYConfigurarFormulario(Operacion operacion, object entidad = null)
        {
            var formulario = CrearFormulario();
            formulario.ConfigurarOperacion(operacion, entidad);
            return formulario;
        }
    }

    public class ClienteFormFactory : FormularioFactory
    {
        public override IFormularioDatos CrearFormulario()
        {
            return new FormDatosCliente();
        }
    }

    public class TecnicoFormFactory : FormularioFactory
    {
        public override IFormularioDatos CrearFormulario()
        {
            return new FormDatosTecnicos();
        }
    }

    public class VehiculoFormFactory : FormularioFactory
    {
        public override IFormularioDatos CrearFormulario()
        {
            return new FormDatosVehiculos();
        }
    }

    public class TicketFormFactory : FormularioFactory
    {
        public override IFormularioDatos CrearFormulario()
        {
            return new FormDatosTickets();
        }
    }
}
