namespace Cliente_ProyectoSO
{
    partial class ConexionServidor
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.registrarse = new System.Windows.Forms.Button();
            this.iniciarsesion = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.registrarse);
            this.groupBox1.Controls.Add(this.iniciarsesion);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // registrarse
            // 
            this.registrarse.Location = new System.Drawing.Point(7, 100);
            this.registrarse.Name = "registrarse";
            this.registrarse.Size = new System.Drawing.Size(186, 51);
            this.registrarse.TabIndex = 1;
            this.registrarse.Text = "Registrarse";
            this.registrarse.UseVisualStyleBackColor = true;
            this.registrarse.Click += new System.EventHandler(this.registrarse_Click);
            // 
            // iniciarsesion
            // 
            this.iniciarsesion.Location = new System.Drawing.Point(7, 22);
            this.iniciarsesion.Name = "iniciarsesion";
            this.iniciarsesion.Size = new System.Drawing.Size(186, 50);
            this.iniciarsesion.TabIndex = 0;
            this.iniciarsesion.Text = "Iniciar Sesion";
            this.iniciarsesion.UseVisualStyleBackColor = true;
            this.iniciarsesion.Click += new System.EventHandler(this.conectar_Click);
            // 
            // ConexionServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConexionServidor";
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.ConexionServidor_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button registrarse;
        private System.Windows.Forms.Button iniciarsesion;
    }
}

