namespace SistemaNotasTLYA
{
    partial class SetupInicialForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabFechas = new TabPage();
            btnGuardarFechas = new Button();
            mtbRecu = new MaskedTextBox();
            mtbExamen3 = new MaskedTextBox();
            mtbExamen2 = new MaskedTextBox();
            mtbExamen1 = new MaskedTextBox();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            tabAlumnos = new TabPage();
            txtP1 = new TextBox();
            txtRegistro = new TextBox();
            dgvAlumnos = new DataGridView();
            btnFinalizar = new Button();
            btnBorrar = new Button();
            btnAgregar = new Button();
            n3 = new NumericUpDown();
            n2 = new NumericUpDown();
            n1 = new NumericUpDown();
            nudRegistro = new NumericUpDown();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            tabControl1.SuspendLayout();
            tabFechas.SuspendLayout();
            tabAlumnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)n3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)n2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)n1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRegistro).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabFechas);
            tabControl1.Controls.Add(tabAlumnos);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(998, 612);
            tabControl1.TabIndex = 0;
            // 
            // tabFechas
            // 
            tabFechas.Controls.Add(btnGuardarFechas);
            tabFechas.Controls.Add(mtbRecu);
            tabFechas.Controls.Add(mtbExamen3);
            tabFechas.Controls.Add(mtbExamen2);
            tabFechas.Controls.Add(mtbExamen1);
            tabFechas.Controls.Add(label4);
            tabFechas.Controls.Add(label2);
            tabFechas.Controls.Add(label1);
            tabFechas.Controls.Add(label3);
            tabFechas.Location = new Point(8, 46);
            tabFechas.Name = "tabFechas";
            tabFechas.Padding = new Padding(3);
            tabFechas.Size = new Size(982, 558);
            tabFechas.TabIndex = 1;
            tabFechas.Text = "Fechas";
            tabFechas.UseVisualStyleBackColor = true;
            // 
            // btnGuardarFechas
            // 
            btnGuardarFechas.Location = new Point(479, 320);
            btnGuardarFechas.Name = "btnGuardarFechas";
            btnGuardarFechas.Size = new Size(285, 46);
            btnGuardarFechas.TabIndex = 10;
            btnGuardarFechas.Text = "Guardar y Continuar";
            btnGuardarFechas.UseVisualStyleBackColor = true;
            btnGuardarFechas.Click += btnGuardarFechas_Click;
            // 
            // mtbRecu
            // 
            mtbRecu.Location = new Point(275, 198);
            mtbRecu.Mask = "00/00";
            mtbRecu.Name = "mtbRecu";
            mtbRecu.Size = new Size(88, 39);
            mtbRecu.TabIndex = 9;
            // 
            // mtbExamen3
            // 
            mtbExamen3.Location = new Point(275, 130);
            mtbExamen3.Mask = "00/00";
            mtbExamen3.Name = "mtbExamen3";
            mtbExamen3.Size = new Size(88, 39);
            mtbExamen3.TabIndex = 8;
            // 
            // mtbExamen2
            // 
            mtbExamen2.Location = new Point(275, 74);
            mtbExamen2.Mask = "00/00";
            mtbExamen2.Name = "mtbExamen2";
            mtbExamen2.Size = new Size(88, 39);
            mtbExamen2.TabIndex = 7;
            // 
            // mtbExamen1
            // 
            mtbExamen1.Location = new Point(275, 20);
            mtbExamen1.Mask = "00/00";
            mtbExamen1.Name = "mtbExamen1";
            mtbExamen1.Size = new Size(88, 39);
            mtbExamen1.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 198);
            label4.Name = "label4";
            label4.Size = new Size(65, 32);
            label4.TabIndex = 5;
            label4.Text = "Recu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 137);
            label2.Name = "label2";
            label2.Size = new Size(117, 32);
            label2.TabIndex = 4;
            label2.Text = "Examen 3";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 81);
            label1.Name = "label1";
            label1.Size = new Size(117, 32);
            label1.TabIndex = 3;
            label1.Text = "Examen 2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 23);
            label3.Name = "label3";
            label3.Size = new Size(117, 32);
            label3.TabIndex = 2;
            label3.Text = "Examen 1";
            // 
            // tabAlumnos
            // 
            tabAlumnos.Controls.Add(txtP1);
            tabAlumnos.Controls.Add(txtRegistro);
            tabAlumnos.Controls.Add(dgvAlumnos);
            tabAlumnos.Controls.Add(btnFinalizar);
            tabAlumnos.Controls.Add(btnBorrar);
            tabAlumnos.Controls.Add(btnAgregar);
            tabAlumnos.Controls.Add(n3);
            tabAlumnos.Controls.Add(n2);
            tabAlumnos.Controls.Add(n1);
            tabAlumnos.Controls.Add(nudRegistro);
            tabAlumnos.Controls.Add(txtApellido);
            tabAlumnos.Controls.Add(txtNombre);
            tabAlumnos.Location = new Point(8, 46);
            tabAlumnos.Name = "tabAlumnos";
            tabAlumnos.Padding = new Padding(3);
            tabAlumnos.Size = new Size(982, 558);
            tabAlumnos.TabIndex = 2;
            tabAlumnos.Text = "Alumnos";
            tabAlumnos.UseVisualStyleBackColor = true;
            // 
            // txtP1
            // 
            txtP1.Location = new Point(662, 61);
            txtP1.Name = "txtP1";
            txtP1.Size = new Size(233, 39);
            txtP1.TabIndex = 11;
            txtP1.Text = "Notas Parciales (0-10)";
            // 
            // txtRegistro
            // 
            txtRegistro.Location = new Point(465, 61);
            txtRegistro.Name = "txtRegistro";
            txtRegistro.Size = new Size(176, 39);
            txtRegistro.TabIndex = 10;
            txtRegistro.Text = "Registro";
            // 
            // dgvAlumnos
            // 
            dgvAlumnos.AllowUserToOrderColumns = true;
            dgvAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlumnos.Location = new Point(55, 202);
            dgvAlumnos.Name = "dgvAlumnos";
            dgvAlumnos.ReadOnly = true;
            dgvAlumnos.RowHeadersWidth = 82;
            dgvAlumnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlumnos.Size = new Size(840, 220);
            dgvAlumnos.TabIndex = 9;
            // 
            // btnFinalizar
            // 
            btnFinalizar.Location = new Point(491, 447);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(150, 46);
            btnFinalizar.TabIndex = 8;
            btnFinalizar.Text = "Finalizar";
            btnFinalizar.UseVisualStyleBackColor = true;
            btnFinalizar.Click += btnFinalizar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(294, 447);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(150, 46);
            btnBorrar.TabIndex = 7;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(93, 447);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(150, 46);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // n3
            // 
            n3.Location = new Point(835, 123);
            n3.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            n3.Name = "n3";
            n3.Size = new Size(60, 39);
            n3.TabIndex = 5;
            // 
            // n2
            // 
            n2.Location = new Point(752, 122);
            n2.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            n2.Name = "n2";
            n2.Size = new Size(60, 39);
            n2.TabIndex = 4;
            // 
            // n1
            // 
            n1.Location = new Point(662, 123);
            n1.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            n1.Name = "n1";
            n1.Size = new Size(60, 39);
            n1.TabIndex = 3;
            // 
            // nudRegistro
            // 
            nudRegistro.AccessibleName = "";
            nudRegistro.Location = new Point(465, 123);
            nudRegistro.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            nudRegistro.Minimum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudRegistro.Name = "nudRegistro";
            nudRegistro.Size = new Size(176, 39);
            nudRegistro.TabIndex = 2;
            nudRegistro.Tag = "";
            nudRegistro.ThousandsSeparator = true;
            nudRegistro.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(244, 123);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(200, 39);
            txtApellido.TabIndex = 1;
            txtApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(55, 122);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(160, 39);
            txtNombre.TabIndex = 0;
            txtNombre.Text = "Nombre";
            // 
            // SetupInicialForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 612);
            Controls.Add(tabControl1);
            Name = "SetupInicialForm";
            Text = "SetUpInicialForm";
            tabControl1.ResumeLayout(false);
            tabFechas.ResumeLayout(false);
            tabFechas.PerformLayout();
            tabAlumnos.ResumeLayout(false);
            tabAlumnos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).EndInit();
            ((System.ComponentModel.ISupportInitialize)n3).EndInit();
            ((System.ComponentModel.ISupportInitialize)n2).EndInit();
            ((System.ComponentModel.ISupportInitialize)n1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRegistro).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabAlumnos;
        private TabPage tabFechas;
        private Button btnGuardarFechas;
        private MaskedTextBox mtbRecu;
        private MaskedTextBox mtbExamen3;
        private MaskedTextBox mtbExamen2;
        private MaskedTextBox mtbExamen1;
        private Label label4;
        private Label label2;
        private Label label1;
        private Label label3;
        private NumericUpDown n1;
        private NumericUpDown nudRegistro;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private DataGridView dgvAlumnos;
        private Button btnFinalizar;
        private Button btnBorrar;
        private Button btnAgregar;
        private NumericUpDown n3;
        private NumericUpDown n2;
        private TextBox txtP1;
        private TextBox txtRegistro;
    }
}