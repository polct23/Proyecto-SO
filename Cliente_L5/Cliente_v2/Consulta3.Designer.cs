namespace Cliente_v2
{
    partial class Consulta3
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
            this.enviarBtn = new System.Windows.Forms.Button();
            this.r1Box = new System.Windows.Forms.TextBox();
            this.r2Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // enviarBtn
            // 
            this.enviarBtn.Location = new System.Drawing.Point(79, 73);
            this.enviarBtn.Name = "enviarBtn";
            this.enviarBtn.Size = new System.Drawing.Size(86, 30);
            this.enviarBtn.TabIndex = 1;
            this.enviarBtn.Text = "Enviar";
            this.enviarBtn.UseVisualStyleBackColor = true;
            this.enviarBtn.Click += new System.EventHandler(this.enviarBtn_Click);
            // 
            // r1Box
            // 
            this.r1Box.Location = new System.Drawing.Point(12, 15);
            this.r1Box.Name = "r1Box";
            this.r1Box.Size = new System.Drawing.Size(100, 22);
            this.r1Box.TabIndex = 2;
            // 
            // r2Box
            // 
            this.r2Box.Location = new System.Drawing.Point(139, 15);
            this.r2Box.Name = "r2Box";
            this.r2Box.Size = new System.Drawing.Size(100, 22);
            this.r2Box.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "--";
            // 
            // Consulta3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 128);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.r2Box);
            this.Controls.Add(this.r1Box);
            this.Controls.Add(this.enviarBtn);
            this.Name = "Consulta3";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enviarBtn;
        private System.Windows.Forms.TextBox r1Box;
        private System.Windows.Forms.TextBox r2Box;
        private System.Windows.Forms.Label label1;
    }
}