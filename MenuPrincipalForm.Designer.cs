namespace SistemaNotasTLYA
{
    partial class MenuPrincipalForm
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
            btnCarga = new Button();
            btnSub1 = new Button();
            btnSub2 = new Button();
            btnSub3 = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // btnCarga
            // 

            // 
            // btnSub1
            // 
            btnSub1.Location = new Point(278, 118);
            btnSub1.Name = "btnSub1";
            btnSub1.Size = new Size(208, 41);
            btnSub1.TabIndex = 1;
            btnSub1.Text = "Submenú 1";
            btnSub1.UseVisualStyleBackColor = true;
            btnSub1.Click += btnSub1_Click;
            // 
            // btnSub2
            // 
            btnSub2.Location = new Point(278, 188);
            btnSub2.Name = "btnSub2";
            btnSub2.Size = new Size(208, 46);
            btnSub2.TabIndex = 2;
            btnSub2.Text = "Submenú 2";
            btnSub2.UseVisualStyleBackColor = true;
            btnSub2.Click += btnSub2_Click;
            // 
            // btnSub3
            // 
            btnSub3.Location = new Point(278, 257);
            btnSub3.Name = "btnSub3";
            btnSub3.Size = new Size(208, 46);
            btnSub3.TabIndex = 3;
            btnSub3.Text = "Submenú 3";
            btnSub3.UseVisualStyleBackColor = true;
            btnSub3.Click += btnSub3_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(592, 367);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(150, 46);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // MenuPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(btnSub3);
            Controls.Add(btnSub2);
            Controls.Add(btnSub1);
            Controls.Add(btnCarga);
            Name = "MenuPrincipalForm";
            Text = "MenuPrincipalForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btnCarga;
        private Button btnSub1;
        private Button btnSub2;
        private Button btnSub3;
        private Button btnSalir;
    }
}