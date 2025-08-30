using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SistemaNotasTLYA.Models;
using SistemaNotasTLYA.Services;

namespace SistemaNotasTLYA
{
    public partial class CargaAlumnosForm : Form
    {
        private readonly CursadaService _svc;
        private NumericUpDown nudRegistro, n1, n2, n3;
        private TextBox txtNombre, txtApellido;
        private Button btnAgregar, btnEditar, btnBorrar, btnCerrar;
        private DataGridView dgv;

        public CargaAlumnosForm(CursadaService svc)
        {
            _svc = svc;
            Text = "Carga / Edición de Alumnos";
            Width = 800; Height = 500; StartPosition = FormStartPosition.CenterParent;

            txtNombre = new TextBox { Left = 20, Top = 20, Width = 150, PlaceholderText = "Nombre" };
            txtApellido = new TextBox { Left = 180, Top = 20, Width = 150, PlaceholderText = "Apellido" };
            nudRegistro = new NumericUpDown { Left = 340, Top = 20, Width = 120, Minimum = 100000, Maximum = 999999 };

            n1 = new NumericUpDown { Left = 480, Top = 20, Width = 60, Minimum = 0, Maximum = 10 };
            n2 = new NumericUpDown { Left = 550, Top = 20, Width = 60, Minimum = 0, Maximum = 10 };
            n3 = new NumericUpDown { Left = 620, Top = 20, Width = 60, Minimum = 0, Maximum = 10 };

            btnAgregar = new Button { Left = 690, Top = 18, Width = 80, Height = 28, Text = "Agregar" };
            btnEditar = new Button { Left = 690, Top = 52, Width = 80, Height = 28, Text = "Editar" };
            btnBorrar = new Button { Left = 690, Top = 86, Width = 80, Height = 28, Text = "Borrar" };
            btnCerrar = new Button { Left = 690, Top = 400, Width = 80, Height = 35, Text = "Cerrar" };

            btnAgregar.Click += BtnAgregar_Click;
            btnEditar.Click += BtnEditar_Click;
            btnBorrar.Click += BtnBorrar_Click;
            btnCerrar.Click += (_, __) => Close();

            dgv = new DataGridView { Left = 20, Top = 60, Width = 650, Height = 375, ReadOnly = true, AutoGenerateColumns = true };
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            Controls.AddRange(new Control[] { txtNombre, txtApellido, nudRegistro, n1, n2, n3, btnAgregar, btnEditar, btnBorrar, btnCerrar, dgv });
            Refrescar();
        }

        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            var a = new Alumno
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Registro = (int)nudRegistro.Value,
                Notas = new List<int> { (int)n1.Value, (int)n2.Value, (int)n3.Value }
            };
            if (!_svc.AgregarAlumno(a, out var err)) MessageBox.Show(err);
            Refrescar();
        }

        private void BtnEditar_Click(object? sender, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem is not Alumno aSel) return;
            if (!_svc.Editar(aSel.Registro, txtNombre.Text.Trim(), txtApellido.Text.Trim(),
                new List<int> { (int)n1.Value, (int)n2.Value, (int)n3.Value }, out var err))
                MessageBox.Show(err);
            Refrescar();
        }

        private void BtnBorrar_Click(object? sender, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem is not Alumno aSel) return;
            _svc.Borrar(aSel.Registro);
            Refrescar();
        }

        private void Refrescar()
        {
            dgv.DataSource = null;
            dgv.DataSource = _svc.Alumnos.ToList();
        }
    }
}
