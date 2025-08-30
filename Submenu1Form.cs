using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemaNotasTLYA.Services;

namespace SistemaNotasTLYA
{
    public partial class Submenu1Form : Form
    {
        // El diseñador necesita ctor vacío. El otro permite inyectar el servicio desde el Menú.
        private CursadaService _svc = null!;

        public Submenu1Form()
        {
            InitializeComponent();
            // Ajustes visuales opcionales del form
            Text = "Submenú 1";
            StartPosition = FormStartPosition.CenterParent;
        }

        public Submenu1Form(CursadaService svc) : this()
        {
            _svc = svc;
        }

        // ---------- Helpers ----------
        private void Limpiar() => txtSalida.Clear();
        private void EscribirLinea(string s) => txtSalida.AppendText(s + Environment.NewLine);

        private void EscribirTitulo(string t)
        {
            EscribirLinea(new string('=', 60));
            EscribirLinea(t);
            EscribirLinea(new string('-', 60));
        }

        // ---------- Eventos de botones ----------
        private void btnAusentes_Click(object sender, EventArgs e)
        {
            Limpiar();
            var lista = _svc.Ausentes().ToList();
            var total = _svc.Alumnos.Count;
            double pct = total == 0 ? 0 : lista.Count * 100.0 / total;

            EscribirTitulo("AUSENTES");
            foreach (var a in lista)
                EscribirLinea($"{a.Nombre} {a.Apellido} - Reg:{a.Registro}");
            EscribirLinea($"Total: {lista.Count}  ({pct:0.##}%)");
        }

        private void btnInsuficientes_Click(object sender, EventArgs e)
        {
            Limpiar();
            var lista = _svc.Insuficientes().ToList();
            var total = _svc.Alumnos.Count;
            double pct = total == 0 ? 0 : lista.Count * 100.0 / total;

            EscribirTitulo("INSUFICIENTES (promedio < 4)");
            foreach (var a in lista)
                EscribirLinea($"{a.Nombre} {a.Apellido} - Reg:{a.Registro}");
            EscribirLinea($"Total: {lista.Count}  ({pct:0.##}%)");
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            Limpiar();
            EscribirTitulo("LISTADO DE ALUMNOS");
            foreach (var a in _svc.Alumnos)
                EscribirLinea($"{a.Nombre} {a.Apellido} - Reg:{a.Registro} - {a.Condicion} - {a.SituacionFinal}");
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            Limpiar();
            EscribirTitulo("NOTAS DE PARCIALES");
            foreach (var a in _svc.Alumnos)
                EscribirLinea($"Reg:{a.Registro}  Notas: {string.Join(" - ", a.Notas)}");
        }

        private void btnRegularizados_Click(object sender, EventArgs e)
        {
            Limpiar();
            var lista = _svc.Regularizados().ToList();
            var total = _svc.Alumnos.Count;
            double pct = total == 0 ? 0 : lista.Count * 100.0 / total;

            EscribirTitulo("REGULARIZADOS (4 <= promedio < 7)");
            foreach (var a in lista)
                EscribirLinea($"{a.Nombre} {a.Apellido} - Reg:{a.Registro}");
            EscribirLinea($"Total: {lista.Count}  ({pct:0.##}%)");
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
