namespace Cliente_v2
{
    partial class Consulta2
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
            this.label1 = new System.Windows.Forms.Label();
            this.j2Box = new System.Windows.Forms.TextBox();
            this.j1Box = new System.Windows.Forms.TextBox();
            this.enviarBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "--";
            // 
            // j2Box
            // 
            this.j2Box.Location = new System.Drawing.Point(142, 24);
            this.j2Box.Name = "j2Box";
            this.j2Box.Size = new System.Drawing.Size(100, 22);
            this.j2Box.TabIndex = 7;
            // 
            // j1Box
            // 
            this.j1Box.Location = new System.Drawing.Point(15, 24);
            this.j1Box.Name = "j1Box";
            this.j1Box.Size = new System.Drawing.Size(100, 22);
            this.j1Box.TabIndex = 6;
            // 
            // enviarBtn
            // 
            this.enviarBtn.Location = new System.Drawing.Point(82, 82);
            this.enviarBtn.Name = "enviarBtn";
            this.enviarBtn.Size = new System.Drawing.Size(86, 30);
            this.enviarBtn.TabIndex = 5;
            this.enviarBtn.Text = "Enviar";
            this.enviarBtn.UseVisualStyleBackColor = true;
            this.enviarBtn.Click += new System.EventHandler(this.enviarBtn_Click);
            // 
            // Consulta2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 137);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.j2Box);
            this.Controls.Add(this.j1Box);
            this.Controls.Add(this.enviarBtn);
            this.Name = "Consulta2";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox j2Box;
        private System.Windows.Forms.TextBox j1Box;
        private System.Windows.Forms.Button enviarBtn;
    }
}