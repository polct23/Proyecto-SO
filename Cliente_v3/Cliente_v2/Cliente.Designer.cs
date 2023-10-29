namespace Cliente_v2
{
    partial class Cliente
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
            this.iniciar_sesion = new System.Windows.Forms.Button();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.desconectar = new System.Windows.Forms.Button();
            this.conectar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.jugador2 = new System.Windows.Forms.TextBox();
            this.jugador1 = new System.Windows.Forms.TextBox();
            this.consulta3 = new System.Windows.Forms.RadioButton();
            this.consulta2 = new System.Windows.Forms.RadioButton();
            this.consulta1 = new System.Windows.Forms.RadioButton();
            this.enviar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBox1.Controls.Add(this.registrarse);
            this.groupBox1.Controls.Add(this.iniciar_sesion);
            this.groupBox1.Controls.Add(this.textPassword);
            this.groupBox1.Controls.Add(this.textUsuario);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 299);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro / Inicio Sesion";
            // 
            // registrarse
            // 
            this.registrarse.Location = new System.Drawing.Point(33, 167);
            this.registrarse.Name = "registrarse";
            this.registrarse.Size = new System.Drawing.Size(105, 24);
            this.registrarse.TabIndex = 5;
            this.registrarse.Text = "Registrarse";
            this.registrarse.UseVisualStyleBackColor = true;
            this.registrarse.Click += new System.EventHandler(this.registrarse_Click);
            // 
            // iniciar_sesion
            // 
            this.iniciar_sesion.Location = new System.Drawing.Point(33, 137);
            this.iniciar_sesion.Name = "iniciar_sesion";
            this.iniciar_sesion.Size = new System.Drawing.Size(105, 24);
            this.iniciar_sesion.TabIndex = 4;
            this.iniciar_sesion.Text = "Iniciar Sesion";
            this.iniciar_sesion.UseVisualStyleBackColor = true;
            this.iniciar_sesion.Click += new System.EventHandler(this.iniciar_sesion_Click);
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(162, 93);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(223, 22);
            this.textPassword.TabIndex = 3;
            // 
            // textUsuario
            // 
            this.textUsuario.Location = new System.Drawing.Point(162, 66);
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.Size = new System.Drawing.Size(223, 22);
            this.textUsuario.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de usuario:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox2.Controls.Add(this.desconectar);
            this.groupBox2.Controls.Add(this.conectar);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(452, 259);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conexion";
            // 
            // desconectar
            // 
            this.desconectar.Location = new System.Drawing.Point(63, 128);
            this.desconectar.Name = "desconectar";
            this.desconectar.Size = new System.Drawing.Size(92, 35);
            this.desconectar.TabIndex = 1;
            this.desconectar.Text = "Desconectar";
            this.desconectar.UseVisualStyleBackColor = true;
            this.desconectar.Click += new System.EventHandler(this.desconectar_Click);
            // 
            // conectar
            // 
            this.conectar.Location = new System.Drawing.Point(63, 51);
            this.conectar.Name = "conectar";
            this.conectar.Size = new System.Drawing.Size(92, 35);
            this.conectar.TabIndex = 0;
            this.conectar.Text = "Conectar";
            this.conectar.UseVisualStyleBackColor = true;
            this.conectar.Click += new System.EventHandler(this.conectar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.jugador2);
            this.groupBox3.Controls.Add(this.jugador1);
            this.groupBox3.Controls.Add(this.consulta3);
            this.groupBox3.Controls.Add(this.consulta2);
            this.groupBox3.Controls.Add(this.consulta1);
            this.groupBox3.Controls.Add(this.enviar);
            this.groupBox3.Location = new System.Drawing.Point(481, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(585, 512);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Consultas DB";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Jugador 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Jugador 1:";
            // 
            // jugador2
            // 
            this.jugador2.Location = new System.Drawing.Point(154, 245);
            this.jugador2.Name = "jugador2";
            this.jugador2.Size = new System.Drawing.Size(139, 22);
            this.jugador2.TabIndex = 5;
            // 
            // jugador1
            // 
            this.jugador1.Location = new System.Drawing.Point(154, 206);
            this.jugador1.Name = "jugador1";
            this.jugador1.Size = new System.Drawing.Size(139, 22);
            this.jugador1.TabIndex = 4;
            // 
            // consulta3
            // 
            this.consulta3.AutoSize = true;
            this.consulta3.Location = new System.Drawing.Point(81, 316);
            this.consulta3.Name = "consulta3";
            this.consulta3.Size = new System.Drawing.Size(418, 20);
            this.consulta3.TabIndex = 3;
            this.consulta3.TabStop = true;
            this.consulta3.Text = "Jugador que haya perdido la partida mas larga y contra quien era";
            this.consulta3.UseVisualStyleBackColor = true;
            // 
            // consulta2
            // 
            this.consulta2.AutoSize = true;
            this.consulta2.Location = new System.Drawing.Point(81, 142);
            this.consulta2.Name = "consulta2";
            this.consulta2.Size = new System.Drawing.Size(472, 20);
            this.consulta2.TabIndex = 2;
            this.consulta2.TabStop = true;
            this.consulta2.Text = "La partida en que el jugador1 y jugador2 han coincidido y quien ha ganado";
            this.consulta2.UseVisualStyleBackColor = true;
            // 
            // consulta1
            // 
            this.consulta1.AutoSize = true;
            this.consulta1.Location = new System.Drawing.Point(81, 98);
            this.consulta1.Name = "consulta1";
            this.consulta1.Size = new System.Drawing.Size(399, 20);
            this.consulta1.TabIndex = 1;
            this.consulta1.TabStop = true;
            this.consulta1.Text = "En que escenario ha ganado mas el jugador con mas partidas";
            this.consulta1.UseVisualStyleBackColor = true;
            // 
            // enviar
            // 
            this.enviar.Location = new System.Drawing.Point(489, 474);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(90, 32);
            this.enviar.TabIndex = 0;
            this.enviar.Text = "Enviar";
            this.enviar.UseVisualStyleBackColor = true;
            this.enviar.Click += new System.EventHandler(this.enviar_Click);
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 542);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Cliente";
            this.Text = "Cliente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Button registrarse;
        private System.Windows.Forms.Button iniciar_sesion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button desconectar;
        private System.Windows.Forms.Button conectar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton consulta3;
        private System.Windows.Forms.RadioButton consulta2;
        private System.Windows.Forms.RadioButton consulta1;
        private System.Windows.Forms.Button enviar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox jugador2;
        private System.Windows.Forms.TextBox jugador1;
    }
}

