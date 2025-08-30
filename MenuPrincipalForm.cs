using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaNotasTLYA.Services;

namespace SistemaNotasTLYA
{
    public partial class MenuPrincipalForm : Form
    {
        // Servicio compartido por toda la app
        private readonly CursadaService _svc = new();

        public MenuPrincipalForm(CursadaService svc)
        {
            InitializeComponent(); // lo genera el diseñador
            _svc = svc;

            // Ajustes estéticos opcionales del form
            Text = "Sistema TLYA – Menú Principal";
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(640, 400);
            Font = new Font("Segoe UI", 10f);
        }

        // ====== Estos métodos se “enganchan” cuando hagas doble-click en cada botón ======

        private void btnSub1_Click(object sender, EventArgs e)
        {
            using var f = new Submenu1Form(_svc);
            f.ShowDialog(this);
        }

        private void btnSub2_Click(object sender, EventArgs e)
        {
            using var f = new Submenu2Form(_svc);
            f.ShowDialog(this);
        }

        private void btnSub3_Click(object sender, EventArgs e)
        {
            using var f = new Submenu3Form(_svc);
            f.ShowDialog(this);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
