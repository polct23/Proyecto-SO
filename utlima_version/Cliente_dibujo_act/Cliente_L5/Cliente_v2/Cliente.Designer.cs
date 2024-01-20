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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.estado = new System.Windows.Forms.Label();
            this.desconectar = new System.Windows.Forms.Button();
            this.conectar = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.iniciar_sesion = new System.Windows.Forms.Button();
            this.registrarse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Consultas_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.consulta1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consulta2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consulta3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queEsCadaConsultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comoSeJuegaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreNosotrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color_picker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox2.Controls.Add(this.estado);
            this.groupBox2.Controls.Add(this.desconectar);
            this.groupBox2.Controls.Add(this.conectar);
            this.groupBox2.Location = new System.Drawing.Point(7, 29);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(280, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conexion";
            // 
            // estado
            // 
            this.estado.AutoSize = true;
            this.estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estado.Location = new System.Drawing.Point(3, 20);
            this.estado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.estado.Name = "estado";
            this.estado.Size = new System.Drawing.Size(151, 26);
            this.estado.TabIndex = 3;
            this.estado.Text = "Desconectado";
            // 
            // desconectar
            // 
            this.desconectar.Location = new System.Drawing.Point(158, 40);
            this.desconectar.Margin = new System.Windows.Forms.Padding(2);
            this.desconectar.Name = "desconectar";
            this.desconectar.Size = new System.Drawing.Size(98, 21);
            this.desconectar.TabIndex = 1;
            this.desconectar.Text = "Desconectar";
            this.desconectar.UseVisualStyleBackColor = true;
            this.desconectar.Click += new System.EventHandler(this.desconectar_Click);
            // 
            // conectar
            // 
            this.conectar.Location = new System.Drawing.Point(158, 20);
            this.conectar.Margin = new System.Windows.Forms.Padding(2);
            this.conectar.Name = "conectar";
            this.conectar.Size = new System.Drawing.Size(98, 21);
            this.conectar.TabIndex = 0;
            this.conectar.Text = "Conectar";
            this.conectar.UseVisualStyleBackColor = true;
            this.conectar.Click += new System.EventHandler(this.conectar_Click);
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.Location = new System.Drawing.Point(291, 520);
            this.start.Margin = new System.Windows.Forms.Padding(2);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(111, 63);
            this.start.TabIndex = 4;
            this.start.Text = "START";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // respuesta
            // 
            this.respuesta.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.respuesta.Location = new System.Drawing.Point(875, 520);
            this.respuesta.Margin = new System.Windows.Forms.Padding(2);
            this.respuesta.Name = "respuesta";
            this.respuesta.Size = new System.Drawing.Size(78, 20);
            this.respuesta.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(892, 544);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 28);
            this.button2.TabIndex = 8;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(879, 502);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "La palabra es:";
            // 
            // pic_color
            // 
            this.pic_color.BackColor = System.Drawing.Color.White;
            this.pic_color.Location = new System.Drawing.Point(1106, 99);
            this.pic_color.Margin = new System.Windows.Forms.Padding(2);
            this.pic_color.Name = "pic_color";
            this.pic_color.Size = new System.Drawing.Size(40, 29);
            this.pic_color.TabIndex = 11;
            this.pic_color.UseVisualStyleBackColor = false;
            // 
            // color_picker
            // 
            this.color_picker.BackgroundImage = global::Cliente_v2.Properties.Resources.color_palette;
            this.color_picker.Image = global::Cliente_v2.Properties.Resources.color_palette;
            this.color_picker.Location = new System.Drawing.Point(957, 26);
            this.color_picker.Margin = new System.Windows.Forms.Padding(2);
            this.color_picker.Name = "color_picker";
            this.color_picker.Size = new System.Drawing.Size(189, 68);
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
            this.btn_eraser.Location = new System.Drawing.Point(1076, 244);
            this.btn_eraser.Margin = new System.Windows.Forms.Padding(2);
            this.btn_eraser.Name = "btn_eraser";
            this.btn_eraser.Size = new System.Drawing.Size(72, 53);
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
            this.btn_pencil.Location = new System.Drawing.Point(1076, 186);
            this.btn_pencil.Margin = new System.Windows.Forms.Padding(2);
            this.btn_pencil.Name = "btn_pencil";
            this.btn_pencil.Size = new System.Drawing.Size(70, 54);
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
            this.btn_color.Location = new System.Drawing.Point(1091, 139);
            this.btn_color.Margin = new System.Windows.Forms.Padding(2);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(55, 38);
            this.btn_color.TabIndex = 12;
            this.btn_color.Text = "Color";
            this.btn_color.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_color.UseVisualStyleBackColor = false;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.Color.White;
            this.pic.Location = new System.Drawing.Point(291, 26);
            this.pic.Margin = new System.Windows.Forms.Padding(2);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(662, 449);
            this.pic.TabIndex = 10;
            this.pic.TabStop = false;
            this.pic.Paint += new System.Windows.Forms.PaintEventHandler(this.pic_Paint);
            this.pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_MouseDown);
            this.pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_MouseMove);
            this.pic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_MouseUp);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1076, 328);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Limpiar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Label_tiempo
            // 
            this.Label_tiempo.AutoSize = true;
            this.Label_tiempo.Location = new System.Drawing.Point(1058, 462);
            this.Label_tiempo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_tiempo.Name = "Label_tiempo";
            this.Label_tiempo.Size = new System.Drawing.Size(48, 13);
            this.Label_tiempo.TabIndex = 18;
            this.Label_tiempo.Text = "TIEMPO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 254);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Lista Conectados";
            // 
            // lista
            // 
            this.lista.FormattingEnabled = true;
            this.lista.Location = new System.Drawing.Point(7, 273);
            this.lista.Margin = new System.Windows.Forms.Padding(2);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(228, 134);
            this.lista.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 414);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Nombre Jugador:";
            // 
            // invitacion
            // 
            this.invitacion.Location = new System.Drawing.Point(102, 411);
            this.invitacion.Margin = new System.Windows.Forms.Padding(2);
            this.invitacion.Name = "invitacion";
            this.invitacion.Size = new System.Drawing.Size(92, 20);
            this.invitacion.TabIndex = 22;
            // 
            // invitar
            // 
            this.invitar.Location = new System.Drawing.Point(102, 435);
            this.invitar.Margin = new System.Windows.Forms.Padding(2);
            this.invitar.Name = "invitar";
            this.invitar.Size = new System.Drawing.Size(92, 27);
            this.invitar.TabIndex = 21;
            this.invitar.Text = "Invitar a tu sala";
            this.invitar.UseVisualStyleBackColor = true;
            this.invitar.Click += new System.EventHandler(this.invitar_Click);
            // 
            // crearSala
            // 
            this.crearSala.Location = new System.Drawing.Point(26, 502);
            this.crearSala.Margin = new System.Windows.Forms.Padding(2);
            this.crearSala.Name = "crearSala";
            this.crearSala.Size = new System.Drawing.Size(65, 25);
            this.crearSala.TabIndex = 25;
            this.crearSala.Text = "Crear";
            this.crearSala.UseVisualStyleBackColor = true;
            this.crearSala.Click += new System.EventHandler(this.crearSala_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 483);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Crear Sala";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 542);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 17);
            this.label10.TabIndex = 27;
            this.label10.Text = "Abandonar Sala";
            // 
            // BtnAbandon
            // 
            this.BtnAbandon.Location = new System.Drawing.Point(26, 561);
            this.BtnAbandon.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAbandon.Name = "BtnAbandon";
            this.BtnAbandon.Size = new System.Drawing.Size(76, 25);
            this.BtnAbandon.TabIndex = 26;
            this.BtnAbandon.Text = "Abandonar";
            this.BtnAbandon.UseVisualStyleBackColor = true;
            this.BtnAbandon.Click += new System.EventHandler(this.BtnAbandon_Click);
            // 
            // tiempo
            // 
            this.tiempo.AutoSize = true;
            this.tiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiempo.Location = new System.Drawing.Point(1053, 483);
            this.tiempo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tiempo.Name = "tiempo";
            this.tiempo.Size = new System.Drawing.Size(64, 46);
            this.tiempo.TabIndex = 28;
            this.tiempo.Text = "60";
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info.Location = new System.Drawing.Point(513, 539);
            this.info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(93, 20);
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
            this.label11.Location = new System.Drawing.Point(717, 508);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Puntuación";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(715, 534);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 25);
            this.label12.TabIndex = 31;
            this.label12.Text = "label12";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña:";
            // 
            // textUsuario
            // 
            this.textUsuario.Location = new System.Drawing.Point(136, 41);
            this.textUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.Size = new System.Drawing.Size(127, 20);
            this.textUsuario.TabIndex = 2;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(136, 65);
            this.textPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(127, 20);
            this.textPassword.TabIndex = 3;
            // 
            // iniciar_sesion
            // 
            this.iniciar_sesion.Location = new System.Drawing.Point(95, 116);
            this.iniciar_sesion.Margin = new System.Windows.Forms.Padding(2);
            this.iniciar_sesion.Name = "iniciar_sesion";
            this.iniciar_sesion.Size = new System.Drawing.Size(59, 21);
            this.iniciar_sesion.TabIndex = 4;
            this.iniciar_sesion.Text = "Iniciar Sesion";
            this.iniciar_sesion.UseVisualStyleBackColor = true;
            this.iniciar_sesion.Click += new System.EventHandler(this.iniciar_sesion_Click);
            // 
            // registrarse
            // 
            this.registrarse.Location = new System.Drawing.Point(176, 116);
            this.registrarse.Margin = new System.Windows.Forms.Padding(2);
            this.registrarse.Name = "registrarse";
            this.registrarse.Size = new System.Drawing.Size(59, 21);
            this.registrarse.TabIndex = 5;
            this.registrarse.Text = "Registrarse";
            this.registrarse.UseVisualStyleBackColor = true;
            this.registrarse.Click += new System.EventHandler(this.registrarse_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(7, 111);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(280, 141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro / Inicio Sesion";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Consultas_menu,
            this.comoSeJuegaToolStripMenuItem,
            this.sobreNosotrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1157, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Consultas_menu
            // 
            this.Consultas_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consulta1ToolStripMenuItem,
            this.consulta2ToolStripMenuItem,
            this.consulta3ToolStripMenuItem,
            this.queEsCadaConsultaToolStripMenuItem});
            this.Consultas_menu.Name = "Consultas_menu";
            this.Consultas_menu.Size = new System.Drawing.Size(146, 20);
            this.Consultas_menu.Text = "Consultas Base de datos";
            // 
            // consulta1ToolStripMenuItem
            // 
            this.consulta1ToolStripMenuItem.Name = "consulta1ToolStripMenuItem";
            this.consulta1ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.consulta1ToolStripMenuItem.Text = "Consulta 1";
            this.consulta1ToolStripMenuItem.Click += new System.EventHandler(this.consulta1ToolStripMenuItem_Click);
            // 
            // consulta2ToolStripMenuItem
            // 
            this.consulta2ToolStripMenuItem.Name = "consulta2ToolStripMenuItem";
            this.consulta2ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.consulta2ToolStripMenuItem.Text = "Consulta 2";
            this.consulta2ToolStripMenuItem.Click += new System.EventHandler(this.consulta2ToolStripMenuItem_Click);
            // 
            // consulta3ToolStripMenuItem
            // 
            this.consulta3ToolStripMenuItem.Name = "consulta3ToolStripMenuItem";
            this.consulta3ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.consulta3ToolStripMenuItem.Text = "Consulta 3";
            this.consulta3ToolStripMenuItem.Click += new System.EventHandler(this.consulta3ToolStripMenuItem_Click);
            // 
            // queEsCadaConsultaToolStripMenuItem
            // 
            this.queEsCadaConsultaToolStripMenuItem.Name = "queEsCadaConsultaToolStripMenuItem";
            this.queEsCadaConsultaToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.queEsCadaConsultaToolStripMenuItem.Text = "¿Que es cada consulta?";
            this.queEsCadaConsultaToolStripMenuItem.Click += new System.EventHandler(this.queEsCadaConsultaToolStripMenuItem_Click);
            // 
            // comoSeJuegaToolStripMenuItem
            // 
            this.comoSeJuegaToolStripMenuItem.Name = "comoSeJuegaToolStripMenuItem";
            this.comoSeJuegaToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.comoSeJuegaToolStripMenuItem.Text = "Como se juega";
            this.comoSeJuegaToolStripMenuItem.Click += new System.EventHandler(this.comoSeJuegaToolStripMenuItem_Click);
            // 
            // sobreNosotrosToolStripMenuItem
            // 
            this.sobreNosotrosToolStripMenuItem.Name = "sobreNosotrosToolStripMenuItem";
            this.sobreNosotrosToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.sobreNosotrosToolStripMenuItem.Text = "Sobre nosotros";
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1157, 652);
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
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Cliente";
            this.Text = "Cliente";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.color_picker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button desconectar;
        private System.Windows.Forms.Button conectar;
        private System.Windows.Forms.Button start;
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
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textUsuario;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Button iniciar_sesion;
        private System.Windows.Forms.Button registrarse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Consultas_menu;
        private System.Windows.Forms.ToolStripMenuItem comoSeJuegaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreNosotrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consulta1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consulta2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consulta3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queEsCadaConsultaToolStripMenuItem;
    }
}

