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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cliente));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.registrarse = new System.Windows.Forms.Button();
            this.iniciar_sesion = new System.Windows.Forms.Button();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.estado = new System.Windows.Forms.Label();
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
            this.start = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.respuesta = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pic_color = new System.Windows.Forms.Button();
            this.color_picker = new System.Windows.Forms.PictureBox();
            this.btn_eraser = new System.Windows.Forms.Button();
            this.btn_pencil = new System.Windows.Forms.Button();
            this.btn_color = new System.Windows.Forms.Button();
            this.pic = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.Label_tiempo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lista = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.invitacion = new System.Windows.Forms.TextBox();
            this.invitar = new System.Windows.Forms.Button();
            this.crearSala = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnAbandon = new System.Windows.Forms.Button();
            this.tiempo = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color_picker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
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
            this.groupBox1.Location = new System.Drawing.Point(9, 243);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(374, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro / Inicio Sesion";
            // 
            // registrarse
            // 
            this.registrarse.Location = new System.Drawing.Point(25, 136);
            this.registrarse.Margin = new System.Windows.Forms.Padding(2);
            this.registrarse.Name = "registrarse";
            this.registrarse.Size = new System.Drawing.Size(79, 20);
            this.registrarse.TabIndex = 5;
            this.registrarse.Text = "Registrarse";
            this.registrarse.UseVisualStyleBackColor = true;
            this.registrarse.Click += new System.EventHandler(this.registrarse_Click);
            // 
            // iniciar_sesion
            // 
            this.iniciar_sesion.Location = new System.Drawing.Point(25, 111);
            this.iniciar_sesion.Margin = new System.Windows.Forms.Padding(2);
            this.iniciar_sesion.Name = "iniciar_sesion";
            this.iniciar_sesion.Size = new System.Drawing.Size(79, 20);
            this.iniciar_sesion.TabIndex = 4;
            this.iniciar_sesion.Text = "Iniciar Sesion";
            this.iniciar_sesion.UseVisualStyleBackColor = true;
            this.iniciar_sesion.Click += new System.EventHandler(this.iniciar_sesion_Click);
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(122, 76);
            this.textPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(168, 23);
            this.textPassword.TabIndex = 3;
            // 
            // textUsuario
            // 
            this.textUsuario.Location = new System.Drawing.Point(122, 54);
            this.textUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.Size = new System.Drawing.Size(168, 23);
            this.textUsuario.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de usuario:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox2.Controls.Add(this.estado);
            this.groupBox2.Controls.Add(this.desconectar);
            this.groupBox2.Controls.Add(this.conectar);
            this.groupBox2.Location = new System.Drawing.Point(9, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(374, 85);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conexion";
            // 
            // estado
            // 
            this.estado.AutoSize = true;
            this.estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estado.Location = new System.Drawing.Point(4, 26);
            this.estado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.estado.Name = "estado";
            this.estado.Size = new System.Drawing.Size(196, 32);
            this.estado.TabIndex = 3;
            this.estado.Text = "Desconectado";
            // 
            // desconectar
            // 
            this.desconectar.Location = new System.Drawing.Point(159, 41);
            this.desconectar.Margin = new System.Windows.Forms.Padding(2);
            this.desconectar.Name = "desconectar";
            this.desconectar.Size = new System.Drawing.Size(82, 28);
            this.desconectar.TabIndex = 1;
            this.desconectar.Text = "Desconectar";
            this.desconectar.UseVisualStyleBackColor = true;
            this.desconectar.Click += new System.EventHandler(this.desconectar_Click);
            // 
            // conectar
            // 
            this.conectar.Location = new System.Drawing.Point(159, 9);
            this.conectar.Margin = new System.Windows.Forms.Padding(2);
            this.conectar.Name = "conectar";
            this.conectar.Size = new System.Drawing.Size(69, 28);
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
            this.groupBox3.Location = new System.Drawing.Point(9, 99);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(374, 140);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Consultas DB";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Jugador 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Jugador 1:";
            // 
            // jugador2
            // 
            this.jugador2.Location = new System.Drawing.Point(234, 60);
            this.jugador2.Margin = new System.Windows.Forms.Padding(2);
            this.jugador2.Name = "jugador2";
            this.jugador2.Size = new System.Drawing.Size(105, 23);
            this.jugador2.TabIndex = 5;
            // 
            // jugador1
            // 
            this.jugador1.Location = new System.Drawing.Point(68, 56);
            this.jugador1.Margin = new System.Windows.Forms.Padding(2);
            this.jugador1.Name = "jugador1";
            this.jugador1.Size = new System.Drawing.Size(105, 23);
            this.jugador1.TabIndex = 4;
            // 
            // consulta3
            // 
            this.consulta3.AutoSize = true;
            this.consulta3.Location = new System.Drawing.Point(0, 83);
            this.consulta3.Margin = new System.Windows.Forms.Padding(2);
            this.consulta3.Name = "consulta3";
            this.consulta3.Size = new System.Drawing.Size(444, 21);
            this.consulta3.TabIndex = 3;
            this.consulta3.TabStop = true;
            this.consulta3.Text = "Jugador que haya perdido la partida mas larga y contra quien era";
            this.consulta3.UseVisualStyleBackColor = true;
            // 
            // consulta2
            // 
            this.consulta2.AutoSize = true;
            this.consulta2.Location = new System.Drawing.Point(0, 38);
            this.consulta2.Margin = new System.Windows.Forms.Padding(2);
            this.consulta2.Name = "consulta2";
            this.consulta2.Size = new System.Drawing.Size(504, 21);
            this.consulta2.TabIndex = 2;
            this.consulta2.TabStop = true;
            this.consulta2.Text = "La partida en que el jugador1 y jugador2 han coincidido y quien ha ganado";
            this.consulta2.UseVisualStyleBackColor = true;
            // 
            // consulta1
            // 
            this.consulta1.AutoSize = true;
            this.consulta1.Location = new System.Drawing.Point(0, 17);
            this.consulta1.Margin = new System.Windows.Forms.Padding(2);
            this.consulta1.Name = "consulta1";
            this.consulta1.Size = new System.Drawing.Size(421, 21);
            this.consulta1.TabIndex = 1;
            this.consulta1.TabStop = true;
            this.consulta1.Text = "En que escenario ha ganado mas el jugador con mas partidas";
            this.consulta1.UseVisualStyleBackColor = true;
            // 
            // enviar
            // 
            this.enviar.Location = new System.Drawing.Point(4, 113);
            this.enviar.Margin = new System.Windows.Forms.Padding(2);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(46, 23);
            this.enviar.TabIndex = 0;
            this.enviar.Text = "Enviar";
            this.enviar.UseVisualStyleBackColor = true;
            this.enviar.Click += new System.EventHandler(this.enviar_Click);
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.start.Location = new System.Drawing.Point(107, 593);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 42);
            this.start.TabIndex = 4;
            this.start.Text = "START";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(10, 429);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(689, 272);
            this.label5.TabIndex = 5;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // respuesta
            // 
            this.respuesta.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.respuesta.Location = new System.Drawing.Point(970, 479);
            this.respuesta.Name = "respuesta";
            this.respuesta.Size = new System.Drawing.Size(102, 23);
            this.respuesta.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(986, 506);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 28);
            this.button2.TabIndex = 8;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(983, 463);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "La palabra es:";
            // 
            // pic_color
            // 
            this.pic_color.BackColor = System.Drawing.Color.White;
            this.pic_color.Location = new System.Drawing.Point(1185, 138);
            this.pic_color.Name = "pic_color";
            this.pic_color.Size = new System.Drawing.Size(53, 38);
            this.pic_color.TabIndex = 11;
            this.pic_color.UseVisualStyleBackColor = false;
            // 
            // color_picker
            // 
            this.color_picker.BackgroundImage = global::Cliente_v2.Properties.Resources.color_palette;
            this.color_picker.Image = global::Cliente_v2.Properties.Resources.color_palette;
            this.color_picker.Location = new System.Drawing.Point(1074, 36);
            this.color_picker.Name = "color_picker";
            this.color_picker.Size = new System.Drawing.Size(252, 89);
            this.color_picker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.color_picker.TabIndex = 16;
            this.color_picker.TabStop = false;
            this.color_picker.MouseClick += new System.Windows.Forms.MouseEventHandler(this.color_picker_MouseClick);
            // 
            // btn_eraser
            // 
            this.btn_eraser.BackColor = System.Drawing.Color.White;
            this.btn_eraser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btn_eraser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_eraser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eraser.ForeColor = System.Drawing.Color.Black;
            this.btn_eraser.Image = global::Cliente_v2.Properties.Resources.eraser;
            this.btn_eraser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_eraser.Location = new System.Drawing.Point(1174, 349);
            this.btn_eraser.Name = "btn_eraser";
            this.btn_eraser.Size = new System.Drawing.Size(73, 50);
            this.btn_eraser.TabIndex = 15;
            this.btn_eraser.Text = "Borrar";
            this.btn_eraser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_eraser.UseVisualStyleBackColor = false;
            this.btn_eraser.Click += new System.EventHandler(this.btn_eraser_Click);
            // 
            // btn_pencil
            // 
            this.btn_pencil.BackColor = System.Drawing.Color.White;
            this.btn_pencil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btn_pencil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_pencil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pencil.ForeColor = System.Drawing.Color.Black;
            this.btn_pencil.Image = global::Cliente_v2.Properties.Resources.pencil;
            this.btn_pencil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pencil.Location = new System.Drawing.Point(1174, 265);
            this.btn_pencil.Name = "btn_pencil";
            this.btn_pencil.Size = new System.Drawing.Size(73, 50);
            this.btn_pencil.TabIndex = 14;
            this.btn_pencil.Text = "Lápiz";
            this.btn_pencil.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_pencil.UseVisualStyleBackColor = false;
            this.btn_pencil.Click += new System.EventHandler(this.btn_pencil_Click);
            // 
            // btn_color
            // 
            this.btn_color.BackColor = System.Drawing.Color.White;
            this.btn_color.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btn_color.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_color.ForeColor = System.Drawing.Color.Black;
            this.btn_color.Image = global::Cliente_v2.Properties.Resources.color;
            this.btn_color.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_color.Location = new System.Drawing.Point(1174, 185);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(73, 50);
            this.btn_color.TabIndex = 12;
            this.btn_color.Text = "Color";
            this.btn_color.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_color.UseVisualStyleBackColor = false;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.White;
            this.pic.Location = new System.Drawing.Point(388, 10);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(669, 414);
            this.pic.TabIndex = 10;
            this.pic.TabStop = false;
            this.pic.Paint += new System.Windows.Forms.PaintEventHandler(this.pic_Paint);
            this.pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_MouseDown);
            this.pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_MouseMove);
            this.pic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_MouseUp);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1253, 354);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 30);
            this.button3.TabIndex = 17;
            this.button3.Text = "Limpiar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Label_tiempo
            // 
            this.Label_tiempo.AutoSize = true;
            this.Label_tiempo.Location = new System.Drawing.Point(1148, 479);
            this.Label_tiempo.Name = "Label_tiempo";
            this.Label_tiempo.Size = new System.Drawing.Size(60, 17);
            this.Label_tiempo.TabIndex = 18;
            this.Label_tiempo.Text = "TIEMPO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(583, 426);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Lista Conectados";
            // 
            // lista
            // 
            this.lista.FormattingEnabled = true;
            this.lista.ItemHeight = 17;
            this.lista.Location = new System.Drawing.Point(526, 443);
            this.lista.Margin = new System.Windows.Forms.Padding(2);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(224, 123);
            this.lista.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(528, 579);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Nombre Jugador:";
            // 
            // invitacion
            // 
            this.invitacion.Location = new System.Drawing.Point(530, 594);
            this.invitacion.Margin = new System.Windows.Forms.Padding(2);
            this.invitacion.Name = "invitacion";
            this.invitacion.Size = new System.Drawing.Size(105, 23);
            this.invitacion.TabIndex = 22;
            // 
            // invitar
            // 
            this.invitar.Location = new System.Drawing.Point(531, 617);
            this.invitar.Margin = new System.Windows.Forms.Padding(2);
            this.invitar.Name = "invitar";
            this.invitar.Size = new System.Drawing.Size(95, 26);
            this.invitar.TabIndex = 21;
            this.invitar.Text = "Invitar a tu sala";
            this.invitar.UseVisualStyleBackColor = true;
            this.invitar.Click += new System.EventHandler(this.invitar_Click);
            // 
            // crearSala
            // 
            this.crearSala.Location = new System.Drawing.Point(655, 618);
            this.crearSala.Margin = new System.Windows.Forms.Padding(2);
            this.crearSala.Name = "crearSala";
            this.crearSala.Size = new System.Drawing.Size(68, 26);
            this.crearSala.TabIndex = 25;
            this.crearSala.Text = "Crear";
            this.crearSala.UseVisualStyleBackColor = true;
            this.crearSala.Click += new System.EventHandler(this.crearSala_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(652, 593);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "Crear Sala";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(731, 593);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 20);
            this.label10.TabIndex = 27;
            this.label10.Text = "Abandonar Sala";
            // 
            // BtnAbandon
            // 
            this.BtnAbandon.Location = new System.Drawing.Point(748, 618);
            this.BtnAbandon.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAbandon.Name = "BtnAbandon";
            this.BtnAbandon.Size = new System.Drawing.Size(68, 26);
            this.BtnAbandon.TabIndex = 26;
            this.BtnAbandon.Text = "abandonar";
            this.BtnAbandon.UseVisualStyleBackColor = true;
            this.BtnAbandon.Click += new System.EventHandler(this.BtnAbandon_Click);
            // 
            // tiempo
            // 
            this.tiempo.AutoSize = true;
            this.tiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiempo.Location = new System.Drawing.Point(1143, 505);
            this.tiempo.Name = "tiempo";
            this.tiempo.Size = new System.Drawing.Size(81, 58);
            this.tiempo.TabIndex = 28;
            this.tiempo.Text = "60";
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info.Location = new System.Drawing.Point(776, 478);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(113, 25);
            this.info.TabIndex = 29;
            this.info.Text = "Información";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(968, 569);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 17);
            this.label11.TabIndex = 30;
            this.label11.Text = "Puntuación";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(968, 592);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 29);
            this.label12.TabIndex = 31;
            this.label12.Text = "label12";
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1365, 665);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.start);
            this.Controls.Add(this.info);
            this.Controls.Add(this.tiempo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.BtnAbandon);
            this.Controls.Add(this.crearSala);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.invitacion);
            this.Controls.Add(this.invitar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lista);
            this.Controls.Add(this.Label_tiempo);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.color_picker);
            this.Controls.Add(this.btn_eraser);
            this.Controls.Add(this.btn_pencil);
            this.Controls.Add(this.btn_color);
            this.Controls.Add(this.pic_color);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.respuesta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Cliente";
            this.Text = "Cliente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color_picker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox respuesta;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Button pic_color;
        private System.Windows.Forms.Button btn_color;
        private System.Windows.Forms.Button btn_pencil;
        private System.Windows.Forms.Button btn_eraser;
        private System.Windows.Forms.PictureBox color_picker;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label Label_tiempo;
        private System.Windows.Forms.Label estado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lista;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox invitacion;
        private System.Windows.Forms.Button invitar;
        private System.Windows.Forms.Button crearSala;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnAbandon;
        private System.Windows.Forms.Label tiempo;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

