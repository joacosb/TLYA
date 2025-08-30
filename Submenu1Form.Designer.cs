namespace SistemaNotasTLYA
{
    partial class Submenu1Form
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
            btnAusentes = new Button();
            btnInsuficientes = new Button();
            btnListar = new Button();
            btnNotas = new Button();
            btnRegularizados = new Button();
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
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // flpBotones
            // 
            flpBotones.Controls.Add(btnAusentes);
            flpBotones.Controls.Add(btnInsuficientes);
            flpBotones.Controls.Add(btnListar);
            flpBotones.Controls.Add(btnNotas);
            flpBotones.Controls.Add(btnRegularizados);
            flpBotones.Controls.Add(btnVolver);
            flpBotones.Dock = DockStyle.Fill;
            flpBotones.FlowDirection = FlowDirection.TopDown;
            flpBotones.Location = new Point(0, 0);
            flpBotones.Name = "flpBotones";
            flpBotones.Padding = new Padding(12);
            flpBotones.Size = new Size(266, 450);
            flpBotones.TabIndex = 0;
            // 
            // btnAusentes
            // 
            btnAusentes.Location = new Point(15, 15);
            btnAusentes.Name = "btnAusentes";
            btnAusentes.Size = new Size(215, 46);
            btnAusentes.TabIndex = 0;
            btnAusentes.Text = "1 - Ausentes";
            btnAusentes.UseVisualStyleBackColor = true;
            btnAusentes.Click += btnAusentes_Click;
            // 
            // btnInsuficientes
            // 
            btnInsuficientes.Location = new Point(15, 67);
            btnInsuficientes.Name = "btnInsuficientes";
            btnInsuficientes.Size = new Size(215, 46);
            btnInsuficientes.TabIndex = 1;
            btnInsuficientes.Text = "2 - Insuficientes";
            btnInsuficientes.UseVisualStyleBackColor = true;
            btnInsuficientes.Click += btnInsuficientes_Click;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(15, 119);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(215, 46);
            btnListar.TabIndex = 2;
            btnListar.Text = "3 - Listar datos";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // btnNotas
            // 
            btnNotas.Location = new Point(15, 171);
            btnNotas.Name = "btnNotas";
            btnNotas.Size = new Size(215, 46);
            btnNotas.TabIndex = 3;
            btnNotas.Text = "4 - Notas";
            btnNotas.UseVisualStyleBackColor = true;
            btnNotas.Click += btnNotas_Click;
            // 
            // btnRegularizados
            // 
            btnRegularizados.Location = new Point(15, 223);
            btnRegularizados.Name = "btnRegularizados";
            btnRegularizados.Size = new Size(215, 46);
            btnRegularizados.TabIndex = 4;
            btnRegularizados.Text = "5 - Regularizados";
            btnRegularizados.UseVisualStyleBackColor = true;
            btnRegularizados.Click += btnRegularizados_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(15, 275);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(215, 46);
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
            txtSalida.Size = new Size(530, 450);
            txtSalida.TabIndex = 0;
            txtSalida.Text = "Submenú 1";
            // 
            // Submenu1Form
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Submenu1Form";
            Text = "Submenu1Form";
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
        private Button btnAusentes;
        private Button btnInsuficientes;
        private Button btnListar;
        private Button btnNotas;
        private Button btnRegularizados;
        private Button btnVolver;
        private TextBox txtSalida;
    }
}