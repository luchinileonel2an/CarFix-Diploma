namespace Vista.Patrones
{
    public interface IFormularioDatos
    {
        Operacion ModoOperacion { get; set; }
        DialogResult MostrarDialogo();
        void ConfigurarOperacion(Operacion operacion, object entidad = null);
    }
}