using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;              // Interaction.InputBox
using SistemaNotasTLYA.Services;

namespace SistemaNotasTLYA
{
    public partial class Submenu2Form : Form
    {
        private CursadaService _svc = null!;   // lo inyecta el Menú Principal

        public Submenu2Form()
        {
            InitializeComponent();
            Text = "Submenú 2";
            StartPosition = FormStartPosition.CenterParent;
            Font = new System.Drawing.Font("Segoe UI", 10f);

            // Si preferís enganchar eventos por código (en vez de doble-click):
            // btnFechas.Click    += btnFechas_Click;
            // btnCondicion.Click += btnCondicion_Click;
            // btnPromedios.Click += btnPromedios_Click;
            // btnSituacion.Click += btnSituacion_Click;
            // btnBorrar.Click    += btnBorrar_Click;
            // btnVolver.Click    += btnVolver_Click;
        }

        // ctor usado por el Menú para pasar el servicio
        public Submenu2Form(CursadaService svc) : this()
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

        private static bool TryParseDiaMes(string s, out DateTime dt)
        {
            dt = default;
            s = s.Trim();
            if (!DateTime.TryParseExact(s, "d/M", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dm))
                return false;
            dt = new DateTime(DateTime.Now.Year, dm.Month, dm.Day); // año actual
            return true;
        }

        // ---------- Eventos de botones ----------
        private void btnFechas_Click(object sender, EventArgs e)
        {
            Limpiar();
            var fechas = new List<DateTime>();
            DateTime? anterior = null;

            for (int i = 0; i < 4; i++)
            {
                string tipo = i < 3 ? "Examen" : "Recuperatorio";
                while (true)
                {
                    string input = Interaction.InputBox(
                        $"Ingresá fecha de {tipo} #{i + 1} (dd/mm)", "Fechas", "");
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        EscribirLinea("Operación cancelada.");
                        return;
                    }
                    if (!TryParseDiaMes(input, out var dt))
                    {
                        MessageBox.Show("Formato inválido (dd/mm).");
                        continue;
                    }
                    if (anterior.HasValue && dt <= anterior.Value)
                    {
                        MessageBox.Show("Cada fecha debe ser mayor a la anterior.");
                        continue;
                    }
                    fechas.Add(dt); anterior = dt; break;
                }
            }

            _svc.SetFechasExamenesYRecuperatorios(fechas);

            EscribirTitulo("FECHAS CARGADAS");
            for (int i = 0; i < fechas.Count; i++)
            {
                string tipo = i < 3 ? "Examen" : "Recuperatorio";
                EscribirLinea($"{fechas[i]:dd/MM} - {tipo}");
            }
        }

        private void btnCondicion_Click(object sender, EventArgs e)
        {
            Limpiar();
            var r = _svc.PorCondicionCursada();
            EscribirTitulo("CANTIDAD POR CONDICIÓN DE CURSADA");
            EscribirLinea($"Ausentes: {r.ausentes} ({r.pAusentes:0.##}%)");
            EscribirLinea($"Cursando: {r.cursando} ({r.pCursando:0.##}%)");
        }

        private void btnPromedios_Click(object sender, EventArgs e)
        {
            Limpiar();
            EscribirTitulo("PROMEDIO POR ALUMNO");
            foreach (var a in _svc.Alumnos)
                EscribirLinea($"Reg:{a.Registro}  Promedio: {a.Promedio:0.##}");
        }

        private void btnSituacion_Click(object sender, EventArgs e)
        {
            Limpiar();
            var r = _svc.PorSituacionFinal();
            EscribirTitulo("CANTIDAD POR SITUACIÓN FINAL");
            EscribirLinea($"Ausentes:      {r.aus} ({r.pAus:0.##}%)");
            EscribirLinea($"Insuficientes: {r.insu} ({r.pInsu:0.##}%)");
            EscribirLinea($"Regularizados: {r.reg} ({r.pReg:0.##}%)");
            EscribirLinea($"Aprobados:     {r.apr} ({r.pApr:0.##}%)");
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            string s = Interaction.InputBox(
                "Número de registro a borrar (100000..999999):", "Borrar", "");
            if (string.IsNullOrWhiteSpace(s)) return;

            if (!int.TryParse(s, out int reg) || reg < 100000 || reg > 999999)
            {
                MessageBox.Show("Registro inválido.");
                return;
            }

            bool ok = _svc.Borrar(reg);
            Limpiar();
            EscribirLinea(ok ? $"Se eliminó el registro {reg}" : "No se encontró ese registro.");
        }

        private void btnVolver_Click(object sender, EventArgs e) => Close();
    }
}
