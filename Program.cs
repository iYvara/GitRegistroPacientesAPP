using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RegistroDePacientesAPP
{
    internal static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {
            SetProcessDPIAware(); // debe ir antes de crear cualquier formulario

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cuentas.txt");

            try
            {
                // Empezar siempre sin cuenta
                if (File.Exists(ruta)) File.Delete(ruta);

                Application.Run(new SignUp());
            }
            finally
            {
                // Al cerrar la app se borra la cuenta
                try
                {
                    if (File.Exists(ruta)) File.Delete(ruta);
                }
                catch { }
            }
        }
    }
}