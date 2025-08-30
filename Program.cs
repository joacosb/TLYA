using SistemaNotasTLYA;
using SistemaNotasTLYA.Services;
using System;
using System.Windows.Forms;

namespace SistemaNotasTLYA
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 1) Una única instancia del servicio para toda la app
            var svc = new CursadaService();

            // 2) Setup inicial (Fechas + Alumnos) en UN solo form
            using (var setup = new SetupInicialForm(svc))
            {
                // si el usuario cancela, salimos
                if (setup.ShowDialog() != DialogResult.OK) return;
            }

            // 3) Menú principal usando el mismo servicio
            Application.Run(new MenuPrincipalForm(svc));
        }
    }
}
