namespace SistemaNotasTLYA
{
    partial class Submenu2Form
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
            splitContainer1 = new SplitContainer();
            flpBotones = new FlowLayoutPanel();
            btnFechas = new Button();
            btnCondicion = new Button();
            btnPromedios = new Button();
            btnSituacion = new Button();
            btnBorrar = new Button();
            btnVolver = new Button();
            txtSalida = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            flpBotones.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(flpBotones);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(txtSalida);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 334;
            splitContainer1.TabIndex = 0;
            // 
            // flpBotones
            // 
            flpBotones.AutoScroll = true;
            flpBotones.Controls.Add(btnFechas);
            flpBotones.Controls.Add(btnCondicion);
            flpBotones.Controls.Add(btnPromedios);
            flpBotones.Controls.Add(btnSituacion);
            flpBotones.Controls.Add(btnBorrar);
            flpBotones.Controls.Add(btnVolver);
            flpBotones.FlowDirection = FlowDirection.TopDown;
            flpBotones.Location = new Point(0, 3);
            flpBotones.Name = "flpBotones";
            flpBotones.Size = new Size(331, 444);
            flpBotones.TabIndex = 0;
            flpBotones.WrapContents = false;
            // 
            // btnFechas
            // 
            btnFechas.Dock = DockStyle.Fill;
            btnFechas.Location = new Point(3, 3);
            btnFechas.Name = "btnFechas";
            btnFechas.Size = new Size(309, 46);
            btnFechas.TabIndex = 1;
            btnFechas.Text = "1 - Fechas ex. y recu";
            btnFechas.UseVisualStyleBackColor = true;
            btnFechas.Click += btnFechas_Click;
            // 
            // btnCondicion
            // 
            btnCondicion.Location = new Point(3, 55);
            btnCondicion.Name = "btnCondicion";
            btnCondicion.Size = new Size(309, 46);
            btnCondicion.TabIndex = 2;
            btnCondicion.Text = "2 - Cant. x Condicion";
            btnCondicion.UseVisualStyleBackColor = true;
            btnCondicion.Click += btnCondicion_Click;
            // 
            // btnPromedios
            // 
            btnPromedios.Location = new Point(3, 107);
            btnPromedios.Name = "btnPromedios";
            btnPromedios.Size = new Size(309, 46);
            btnPromedios.TabIndex = 3;
            btnPromedios.Text = "3 - Promedio x Alumno";
            btnPromedios.UseVisualStyleBackColor = true;
            btnPromedios.Click += btnPromedios_Click;
            // 
            // btnSituacion
            // 
            btnSituacion.Location = new Point(3, 159);
            btnSituacion.Name = "btnSituacion";
            btnSituacion.Size = new Size(309, 46);
            btnSituacion.TabIndex = 4;
            btnSituacion.Text = "4 - Cantidad por Situación";
            btnSituacion.UseVisualStyleBackColor = true;
            btnSituacion.Click += btnSituacion_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(3, 211);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(309, 46);
            btnBorrar.TabIndex = 5;
            btnBorrar.Text = "5 - Sacar alumno";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(3, 263);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(309, 46);
            btnVolver.TabIndex = 6;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // txtSalida
            // 
            txtSalida.Dock = DockStyle.Fill;
            txtSalida.Location = new Point(0, 0);
            txtSalida.Multiline = true;
            txtSalida.Name = "txtSalida";
            txtSalida.ReadOnly = true;
            txtSalida.ScrollBars = ScrollBars.Vertical;
            txtSalida.Size = new Size(462, 450);
            txtSalida.TabIndex = 0;
            txtSalida.Text = "Submenú 2";
            // 
            // Submenu2Form
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Submenu2Form";
            Text = "Submenú2Form";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            flpBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private FlowLayoutPanel flpBotones;
        private Button btnFechas;
        private Button btnCondicion;
        private Button btnPromedios;
        private Button btnSituacion;
        private Button btnBorrar;
        private Button btnVolver;
        private TextBox txtSalida;
    }
}