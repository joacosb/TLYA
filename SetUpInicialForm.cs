using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using SistemaNotasTLYA.Services;
using SistemaNotasTLYA.Models;

namespace SistemaNotasTLYA
{
    public partial class SetupInicialForm : Form
    {
        // Servicio compartido (alumnos, fechas, etc.)
        private readonly CursadaService _svc;

        // Flag para bloquear la pestaña "Alumnos" hasta guardar las fechas
        private bool _fechasOk = false;

        // --- Constructor que usa Program.cs (recomendado) ---
        public SetupInicialForm(CursadaService svc)
        {
            InitializeComponent();
            _svc = svc;

            Text = "Carga inicial (Fechas + Alumnos)";
            StartPosition = FormStartPosition.CenterScreen;

            // Arranca en la pestaña Fechas y bloquea navegar a Alumnos hasta guardar
            tabControl1.SelectedTab = tabFechas;
            tabControl1.Selecting += (s, e) =>
            {
                if (e.TabPage == tabAlumnos && !_fechasOk)
                {
                    e.Cancel = true;
                    MessageBox.Show("Primero cargá y guardá las fechas.");
                }
            };

            Refrescar(); // carga la grilla si ya había datos
        }

        // --- Constructor sin parámetros SOLO para que el diseñador no se queje ---
        // (No usar en runtime)
        public SetupInicialForm() : this(new CursadaService()) { }

        // =====================  FECHAS  =====================
        private void btnGuardarFechas_Click(object sender, EventArgs e)
        {
            if (!TryParseDiaMes(mtbExamen1.Text, out var f1) ||
                !TryParseDiaMes(mtbExamen2.Text, out var f2) ||
                !TryParseDiaMes(mtbExamen3.Text, out var f3) ||
                !TryParseDiaMes(mtbRecu.Text, out var fr))
            {
                MessageBox.Show("Formato inválido. Usá dd/mm.", "Fechas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Fechas crecientes: Ex1 < Ex2 < Ex3 < Recuperatorio
            if (!(f1 < f2 && f2 < f3 && f3 < fr))
            {
                MessageBox.Show("Las fechas deben ser crecientes (Ex1 < Ex2 < Ex3 < Recuperatorio).",
                    "Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _svc.SetFechasExamenesYRecuperatorios(new List<DateTime> { f1, f2, f3, fr });

            _fechasOk = true;
            tabControl1.SelectedTab = tabAlumnos; // ahora sí pasamos a Alumnos
        }

        private static bool TryParseDiaMes(string s, out DateTime dt)
        {
            dt = default;
            s = (s ?? "").Trim();
            if (!DateTime.TryParseExact(s, "d/M", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dm))
                return false;
            dt = new DateTime(DateTime.Now.Year, dm.Month, dm.Day);
            return true;
        }

        // =====================  ALUMNOS  =====================
        private void Refrescar()
        {
            dgvAlumnos.DataSource = null;
            dgvAlumnos.AutoGenerateColumns = true;
            dgvAlumnos.DataSource = _svc.Alumnos.ToList(); // snapshot para la grilla
        }

        private void LimpiarEntrada()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            nudRegistro.Value = Math.Max(100000m, nudRegistro.Minimum);
            n1.Value = 0; n2.Value = 0; n3.Value = 0;
        }

        // Copia la fila seleccionada a las cajas
        private void dgvAlumnos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAlumnos.CurrentRow?.DataBoundItem is not Alumno a) return;

            txtNombre.Text = a.Nombre;
            txtApellido.Text = a.Apellido;

            // NumericUpDown usa decimal
            nudRegistro.Value = Math.Min(
                Math.Max((decimal)a.Registro, nudRegistro.Minimum),
                nudRegistro.Maximum);

            n1.Value = a.Notas[0];
            n2.Value = a.Notas[1];
            n3.Value = a.Notas[2];
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var a = new Alumno
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Registro = (int)nudRegistro.Value,
                Notas = new List<int> { (int)n1.Value, (int)n2.Value, (int)n3.Value }
            };

            if (!_svc.AgregarAlumno(a, out var err))
            {
                MessageBox.Show(err, "Alumno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Refrescar();
            LimpiarEntrada();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.CurrentRow?.DataBoundItem is not Alumno aSel) return;

            if (!_svc.Editar(
                    aSel.Registro,
                    txtNombre.Text.Trim(),
                    txtApellido.Text.Trim(),
                    new List<int> { (int)n1.Value, (int)n2.Value, (int)n3.Value },
                    out var err))
            {
                MessageBox.Show(err, "Alumno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Refrescar();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.CurrentRow?.DataBoundItem is not Alumno aSel) return;
            _svc.Borrar(aSel.Registro);
            Refrescar();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (!_fechasOk || _svc.FechasExamenesYRecuperatorios == null ||
                _svc.FechasExamenesYRecuperatorios.Count < 4)
            {
                MessageBox.Show("Primero cargá y guardá las fechas en la pestaña Fechas.");
                tabControl1.SelectedTab = tabFechas;
                return;
            }

            if (_svc.Alumnos.Count == 0)
            {
                MessageBox.Show("Cargá al menos 1 alumno para continuar.");
                return;
            }

            DialogResult = DialogResult.OK; // cierra el setup y vuelve a Program.cs
        }

       
    }
}
