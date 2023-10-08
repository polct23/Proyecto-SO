namespace Cliente_ProyectoSO
{
    partial class ConsultasBD
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.enviar = new System.Windows.Forms.Button();
            this.consulta1 = new System.Windows.Forms.RadioButton();
            this.consulta2 = new System.Windows.Forms.RadioButton();
            this.consulta4 = new System.Windows.Forms.RadioButton();
            this.consulta3 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.jugador1 = new System.Windows.Forms.TextBox();
            this.jugador2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.jugador2);
            this.groupBox1.Controls.Add(this.jugador1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.consulta3);
            this.groupBox1.Controls.Add(this.consulta4);
            this.groupBox1.Controls.Add(this.consulta2);
            this.groupBox1.Controls.Add(this.consulta1);
            this.groupBox1.Controls.Add(this.enviar);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(632, 425);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultas en la Base de Datos";
            // 
            // enviar
            // 
            this.enviar.Location = new System.Drawing.Point(24, 385);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(75, 23);
            this.enviar.TabIndex = 0;
            this.enviar.Text = "Enviar";
            this.enviar.UseVisualStyleBackColor = true;
            this.enviar.Click += new System.EventHandler(this.enviar_Click);
            // 
            // consulta1
            // 
            this.consulta1.AutoSize = true;
            this.consulta1.Location = new System.Drawing.Point(55, 50);
            this.consulta1.Name = "consulta1";
            this.consulta1.Size = new System.Drawing.Size(399, 20);
            this.consulta1.TabIndex = 1;
            this.consulta1.TabStop = true;
            this.consulta1.Text = "En que escenario ha ganado mas el jugador con mas partidas";
            this.consulta1.UseVisualStyleBackColor = true;
            // 
            // consulta2
            // 
            this.consulta2.AutoSize = true;
            this.consulta2.Location = new System.Drawing.Point(55, 76);
            this.consulta2.Name = "consulta2";
            this.consulta2.Size = new System.Drawing.Size(472, 20);
            this.consulta2.TabIndex = 2;
            this.consulta2.TabStop = true;
            this.consulta2.Text = "La partida en que el jugador1 y jugador2 han coincidido y quien ha ganado";
            this.consulta2.UseVisualStyleBackColor = true;
            // 
            // consulta4
            // 
            this.consulta4.AutoSize = true;
            this.consulta4.Location = new System.Drawing.Point(55, 243);
            this.consulta4.Name = "consulta4";
            this.consulta4.Size = new System.Drawing.Size(418, 20);
            this.consulta4.TabIndex = 3;
            this.consulta4.TabStop = true;
            this.consulta4.Text = "Jugador que haya perdido la partida mas larga y contra quien era";
            this.consulta4.UseVisualStyleBackColor = true;
            this.consulta4.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // consulta3
            // 
            this.consulta3.AutoSize = true;
            this.consulta3.Location = new System.Drawing.Point(55, 217);
            this.consulta3.Name = "consulta3";
            this.consulta3.Size = new System.Drawing.Size(432, 20);
            this.consulta3.TabIndex = 4;
            this.consulta3.TabStop = true;
            this.consulta3.Text = "Jugador mas antiguo que haya perdido mas de 3 partidas seguidas";
            this.consulta3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Jugador 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Jugador 2";
            // 
            // jugador1
            // 
            this.jugador1.Location = new System.Drawing.Point(129, 113);
            this.jugador1.Name = "jugador1";
            this.jugador1.Size = new System.Drawing.Size(130, 22);
            this.jugador1.TabIndex = 7;
            // 
            // jugador2
            // 
            this.jugador2.Location = new System.Drawing.Point(129, 141);
            this.jugador2.Name = "jugador2";
            this.jugador2.Size = new System.Drawing.Size(130, 22);
            this.jugador2.TabIndex = 8;
            // 
            // ConsultasBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConsultasBD";
            this.Text = "Cliente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button enviar;
        private System.Windows.Forms.TextBox jugador2;
        private System.Windows.Forms.TextBox jugador1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton consulta3;
        private System.Windows.Forms.RadioButton consulta4;
        private System.Windows.Forms.RadioButton consulta2;
        private System.Windows.Forms.RadioButton consulta1;
    }
}