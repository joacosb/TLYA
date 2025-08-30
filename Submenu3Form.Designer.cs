namespace SistemaNotasTLYA
{
    partial class Submenu3Form
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
            btnBuscar = new Button();
            btnEditar = new Button();
            btnModa = new Button();
            btnOrdenar = new Button();
            btnUnificar = new Button();
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
            splitContainer1.Panel2.AutoScroll = true;
            splitContainer1.Panel2.Controls.Add(txtSalida);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 372;
            splitContainer1.TabIndex = 0;
            // 
            // flpBotones
            // 
            flpBotones.AutoScroll = true;
            flpBotones.Controls.Add(btnBuscar);
            flpBotones.Controls.Add(btnEditar);
            flpBotones.Controls.Add(btnModa);
            flpBotones.Controls.Add(btnOrdenar);
            flpBotones.Controls.Add(btnUnificar);
            flpBotones.Controls.Add(btnVolver);
            flpBotones.Dock = DockStyle.Fill;
            flpBotones.FlowDirection = FlowDirection.TopDown;
            flpBotones.Location = new Point(0, 0);
            flpBotones.Name = "flpBotones";
            flpBotones.Size = new Size(372, 450);
            flpBotones.TabIndex = 0;
            flpBotones.WrapContents = false;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(3, 3);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(351, 46);
            btnBuscar.TabIndex = 0;
            btnBuscar.Text = "1-Buscar Alumno";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(3, 55);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(351, 46);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "2-Editar Alumnos";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnModa
            // 
            btnModa.Location = new Point(3, 107);
            btnModa.Name = "btnModa";
            btnModa.Size = new Size(351, 46);
            btnModa.TabIndex = 2;
            btnModa.Text = "3-Moda de parciales";
            btnModa.UseVisualStyleBackColor = true;
            btnModa.Click += btnModa_Click;
            // 
            // btnOrdenar
            // 
            btnOrdenar.Location = new Point(3, 159);
            btnOrdenar.Name = "btnOrdenar";
            btnOrdenar.Size = new Size(351, 46);
            btnOrdenar.TabIndex = 3;
            btnOrdenar.Text = "4-Ordenar por registro";
            btnOrdenar.UseVisualStyleBackColor = true;
            btnOrdenar.Click += btnOrdenar_Click;
            // 
            // btnUnificar
            // 
            btnUnificar.Location = new Point(3, 211);
            btnUnificar.Name = "btnUnificar";
            btnUnificar.Size = new Size(351, 46);
            btnUnificar.TabIndex = 4;
            btnUnificar.Text = "5-Unificar datos cargados";
            btnUnificar.UseVisualStyleBackColor = true;
            btnUnificar.Click += btnUnificar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(3, 263);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(351, 46);
            btnVolver.TabIndex = 5;
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
            txtSalida.ScrollBars = ScrollBars.Vertical;
            txtSalida.Size = new Size(424, 450);
            txtSalida.TabIndex = 0;
            txtSalida.Text = "Submenú 3";
            // 
            // Submenu3Form
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Submenu3Form";
            Text = "Submenu3Form";
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
        private Button btnBuscar;
        private Button btnEditar;
        private Button btnModa;
        private Button btnOrdenar;
        private Button btnUnificar;
        private Button btnVolver;
        private TextBox txtSalida;
    }
}