using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;              // Interaction.InputBox
using SistemaNotasTLYA.Services;
using SistemaNotasTLYA.Models;

namespace SistemaNotasTLYA
{
    public partial class Submenu3Form : Form
    {
        private CursadaService _svc = null!;   // lo inyecta el Menú Principal

        public Submenu3Form()
        {
            InitializeComponent();
            Text = "Submenú 3";
            StartPosition = FormStartPosition.CenterParent;
            Font = new System.Drawing.Font("Segoe UI", 10f);

            // Si querés, podés enganchar eventos por código en vez de doble-click:
            // btnBuscar.Click   += btnBuscar_Click;
            // btnEditar.Click   += btnEditar_Click;
            // btnModa.Click     += btnModa_Click;
            // btnOrdenar.Click  += btnOrdenar_Click;
            // btnUnificar.Click += btnUnificar_Click;
            // btnVolver.Click   += btnVolver_Click;
        }

        // ctor usado por el Menú para pasar el servicio
        public Submenu3Form(CursadaService svc) : this()
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

        private int PedirRegistro(string titulo)
        {
            while (true)
            {
                string s = Interaction.InputBox($"{titulo}\n(100000..999999)", "Registro", "");
                if (string.IsNullOrWhiteSpace(s)) return -1;            // canceló
                if (int.TryParse(s, out int reg) && reg >= 100000 && reg <= 999999) return reg;
                MessageBox.Show("Registro inválido.");
            }
        }

        private int PedirNota(string prompt, int def)
        {
            while (true)
            {
                string s = Interaction.InputBox($"{prompt} [0..10]", "Nota", def.ToString());
                if (string.IsNullOrWhiteSpace(s)) return def;           // vacío => mantiene
                if (int.TryParse(s, out int v) && v >= 0 && v <= 10) return v;
                MessageBox.Show("Nota inválida.");
            }
        }

        private string PedirTexto(string prompt, string def)
        {
            string s = Interaction.InputBox($"{prompt} (Enter para mantener)", "Editar", def).Trim();
            return string.IsNullOrWhiteSpace(s) ? def : s;
        }

        // ---------- Eventos de botones ----------
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int reg = PedirRegistro("Número de registro a buscar");
            if (reg == -1) return;

            var a = _svc.Buscar(reg);
            Limpiar();
            if (a == null) { EscribirLinea("No se encontró ese registro."); return; }

            EscribirTitulo("ALUMNO ENCONTRADO");
            EscribirLinea($"{a.Nombre} {a.Apellido}  Reg:{a.Registro}");
            EscribirLinea($"Condición: {a.Condicion}  Situación: {a.SituacionFinal}");
            EscribirLinea($"Notas: {string.Join(" - ", a.Notas)}  Promedio: {a.Promedio:0.##}");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int reg = PedirRegistro("Número de registro a editar");
            if (reg == -1) return;

            var a = _svc.Buscar(reg);
            if (a == null) { MessageBox.Show("No existe ese registro."); return; }

            string nuevoNombre = PedirTexto("Nombre", a.Nombre);
            string nuevoApellido = PedirTexto("Apellido", a.Apellido);
            int n1 = PedirNota("Nota 1", a.Notas[0]);
            int n2 = PedirNota("Nota 2", a.Notas[1]);
            int n3 = PedirNota("Nota 3", a.Notas[2]);

            if (!_svc.Editar(reg, nuevoNombre, nuevoApellido, new List<int> { n1, n2, n3 }, out var err))
                MessageBox.Show(err);
            else
            {
                Limpiar();
                EscribirLinea("Alumno editado.");
            }
        }

        private void btnModa_Click(object sender, EventArgs e)
        {
            var (nota, rep, alumnosUnicos) = _svc.ModaNotas();
            Limpiar();
            EscribirTitulo("MODA DE NOTAS EN PARCIALES");
            EscribirLinea($"Nota de moda: {nota}");
            EscribirLinea($"Repeticiones: {rep}");
            EscribirLinea($"Cant Alumnos únicos: {alumnosUnicos}");
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            _svc.OrdenarPorRegistro();
            Limpiar();
            EscribirLinea("Listado ordenado por número de registro (asc).");
        }

        private void btnUnificar_Click(object sender, EventArgs e)
        {
            _svc.UnificarDatos();
            Limpiar();
            EscribirLinea("Registros duplicados unificados (se mantuvo el primero).");
        }

        private void btnVolver_Click(object sender, EventArgs e) => Close();
    }
}
