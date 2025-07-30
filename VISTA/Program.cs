using System.Globalization;

namespace Vista
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var cultura = new CultureInfo("es-AR");
            cultura.NumberFormat.CurrencySymbol = "$";
            cultura.NumberFormat.CurrencyDecimalDigits = 2;

            Thread.CurrentThread.CurrentCulture = cultura;
            Thread.CurrentThread.CurrentUICulture = cultura;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var loginForm = new FormLogin())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new FormInicio());
                }
                else
                {
                    return;
                }
            }
        }
    }
}