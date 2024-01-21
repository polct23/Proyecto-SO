using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using System.Runtime.InteropServices;

namespace Cliente_v2
{
    public partial class Cliente : Form
    {
        //Variables Globales
        Socket server;
        Thread atender;
        delegate void Delegado();
        delegate void Delegadoparadibujar(Point p1, Point p2, string col, int a);
        delegate void Delegadoparaescribir(string s);



        string palabra;
        int contador = 60;
        bool creador;
        int puntuacion;
        string ganador;
        bool dibujante = false;
        int numsala;
        //variables para guardar los puntos del dibujo
        int pos_puntos_color = 0;
        int pos_puntos_borrar = 0;
        int[] puntos_color = new int[50];
        int[] puntos_borrar = new int[50];
        int a;
        public Cliente()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            lista.Items.Add("Inicia sesión para ver quien esta conectado");
            bm = new Bitmap(pic.Width, pic.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pic.Image = bm;
            //Desactivamos los botones hasta que se conecten o empiece el juego
            btn_pencil.Enabled = false;
            btn_eraser.Enabled = false;
            Consultas_menu.Enabled = false;
            BtnAbandon.Enabled = false;
            invitar.Enabled = true;
            button2.Enabled = false;
        }

        private void atenderServidor()
        {
            while (true)
            {
                //mensaje que llega desde el servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1].Split('\0')[0];
                switch (codigo)
                {
                    case 1: //respusta cuando intentamos iniciar sesión
                        /*Recibimos la respuesta del servidor, que sera SI o NO, ..., Si es si se mostrara un mensaje en pantalla y 
                        se pasara al formulario de consultas, si sale no saldra un mensaje con un error*/

                        if (mensaje == "SI") //MENSAJE TIENE QUE SER 'SI'
                        {
                            this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { "Sesion iniciada" });
                            //para que el usuario no vuelva a inciar o registrarse, ya que ya estara registrado
                            iniciar_sesion.Visible = false;
                            registrarse.Visible = false;
                            Consultas_menu.Enabled = true;
                            numsala = -1;
                        }
                        else if (mensaje == "incorrectPass")
                        {
                            this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { "Error al iniciar sesion, compruebe el usuario o la contraseña" });

                        }
                        else if (mensaje == "noUser")
                        {
                            this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { "No existe el usuario introducido" });
                        }
                        else if (mensaje == "yaConectado")
                        {
                            this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { "El usuario ya está conectado al servidor" });
                        }
                        break;
                    case 2: //respuesta cuando nos intentamos registrar
                        /*Recibimos la respuesta del servidor, que sera SI o NO, Si es si se mostrara un mensaje en pantalla y 
                        se pasara al formulario de inicio de sesion, si sale no saldra un mensaje con un error*/

                        if (mensaje == "SI") //MENSAJE TIENE QUE SER 'SI'
                        {
                            this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { "Registro completado" });
                        }
                        else if (mensaje == "NO")
                        {
                            this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { "Error, pruebe otro nombre de usuario" });
                        }
                        else if (mensaje == "EXISTE")
                        {
                            this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { "Ese usuario ya existe" });
                        }
                        break;

                    //Del Caso 3 al 5 son las consultas a la base de datos
                    case 3:
                        string nombres = trozos[1];
                        this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] {nombres});
                        break;
                    case 4:
                        if (mensaje == "NO")
                        {
                            this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { "No hay jugadores en el rango especificado" });
                            break;
                        }
                        else
                        {
                            string jugadores = mensaje;
                            this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { jugadores });
                            break;

                        }
                    case 5:
                        if (mensaje == "NO")
                        {
                            this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { "No hay jugadores en el rango especificado" });
                            break;
                        }
                        else
                        {
                            string jugadores = mensaje;
                            this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { jugadores });
                            break;

                        }
                        
                        


                    //Caso 6: lista de conectados
                    case 6: //lista de usuarios conectados
                        int num = Convert.ToInt32(trozos[1]);
                        int i = 0;
                        lista.Items.Clear();
                        while (i < num)
                        {
                            lista.Items.Add(trozos[i + 2]);
                            i++;
                        }
                        break;
                    //Caso 7: Confirmación de si la sala se ha podido crear o no
                    case 7://crear la sala
                        if (trozos[1] == "Creada")
                        {
                            this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { "Sala creada" });
                            numsala = Convert.ToInt32(trozos[2]);
                        }
                       
                        else
                            this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { "Sala no creada" });
                        break;


                    //Caso 8: Petición para unirse a una sala
                    case 8://invitacio
                        if (mensaje == "Enviada")
                        {
                            DialogResult result = MessageBox.Show("¿Deseas aceptar la invitación?", "Invitación", MessageBoxButtons.OKCancel);

                            // Verificar qué botón se presionó
                            if (result == DialogResult.OK)
                            {
                                // Lógica para aceptar la invitación
                                string msgEnvio = "9/" + textUsuario.Text + "/" + trozos[2];
                                // Enviamos al servidor la consulta para la DB
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(msgEnvio);
                                server.Send(msg);
                                numsala = Convert.ToInt32(trozos[3]);
                            }
                            else if (result == DialogResult.Cancel)
                            {
                                // Lógica para cancelar la invitación
                                string msgEnvio = "16/" + textUsuario.Text;
                                // Enviamos al servidor la consulta para la DB
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(msgEnvio);
                                server.Send(msg);
                            }
                        }
                        else if (mensaje == "NoConectado")
                            this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { "Sala llena" });
                        break;

                    //Caso 10: Notifica que el usuario al que han invitado se ha unido correctamente
                    case 10://missatge de notificacio
                        this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { "El usuario ha aceptado la invitación" });
                        break;

                    //Caso 13: Los jugadores reciben la información del dibujo de la persona que está dibujando, la persona que dibuja descarta este mensaje
                    case 13:
                        if (dibujante == false)
                        {

                            string color = trozos[3];
                            int a = Convert.ToInt32(trozos[4]);
                            int pos_puntos = Convert.ToInt32(trozos[5]);
                            int f = 8;
                            Point p1 = new Point();
                            p1.X = Convert.ToInt32(trozos[6]);
                            p1.Y = Convert.ToInt32(trozos[7]);
                            while (f < pos_puntos)
                            {
                                Point p2 = new Point();
                                p2.X = Convert.ToInt32(trozos[f]);
                                p2.Y = Convert.ToInt32(trozos[f + 1]);
                                this.Invoke(new Delegadoparadibujar(recibir_dibujo), new object[] { p1, p2, color, a });

                                p1 = p2;
                                f = f + 2;
                            }
                        }
                       

                        break;


                    //Caso 15: Una vez se haya acabado la partida y desde el servidor se haya comparado todas las puntuaciones, se avisa a los jugadores quien ha sido el ganador
                    case 15:
                        ganador = trozos[1];
                        info.Text = (ganador + "gana la partida");
                        if(creador)
                        {
                            start.Enabled = true;
                        }
                        break;


                    //Caso 16: asigna a la persona que recibe este mensaje como dibujante de esta ronda
                    case 16:
                        dibujante = true;
                        btn_pencil.Enabled = true;
                        btn_eraser.Enabled = true;
                        break;

                    //Caso 18: Cada ronda se escoge una palabra al azar que tienen que adivinar. Solo el dibujante puede verla.
                    case 18:
                        palabra = trozos[1];
                        palabra.Trim();

                        if (dibujante == true)
                            info.Text = ("Te toca dibujar, la palabra es: " + palabra);
                        else
                        {
                            info.Text = ("Empieza la ronda");
                            button2.Enabled = true;
                        }

                        this.Invoke(new Delegado(pontimer));
                        //timer.Enabled = true;
                        break;

                    //Caso 20: El servidor informa a los jugadores que la partida se ha acabado y cada jugador envía su puntuación al servidor para que elija al ganador.
                    case 20:
                        string m = "20/" + textUsuario.Text + "/" + puntuacion + "/" + numsala;
                        // Enviamos al servidor la consulta para la DB
                        byte[] ms = System.Text.Encoding.ASCII.GetBytes(m);
                        server.Send(ms);
                        break;

                    case 21:
                        chat.Items.Add(trozos[1]);
                        break;

                }
            }
        }

        private void conectar_Click(object sender, EventArgs e)
        {
            IPAddress direc = IPAddress.Parse("192.168.56.102"); //INDICAMOS IP// La ip establecida es un ejemplo
            IPEndPoint ipep = new IPEndPoint(direc, 9039); //INDICAMOS PUERTO// El puerto establecido es un ejemplo

            //Creamos el socket
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep); //Intentamos conectar el socket
            }
            catch (SocketException ex)
            {
                //Si hay excepcion indicamos error y salimos del programa con un return
                MessageBox.Show("Conexion con servidor fallida: " + ex.Message);
                return;
            }

            ThreadStart ts = delegate { atenderServidor(); };
            atender = new Thread(ts);
            atender.Start();

            //cambia el texto de los labels para informar al usuario, ademas desactiva o activa botones para evitar errores y que el usuario sepa que puede hacer
            estado.Text = "Conectado";
            desconectar.Enabled = true;
            conectar.Enabled = false;
            iniciar_sesion.Enabled = true;
            registrarse.Enabled = true;
            
        }

        private void desconectar_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexion
            string mensaje = "0/"; //codigo 0 para desconectar
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Nos desconectamos
            atender.Abort();
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();

            //limpiamos la lista, he indicamos al usuario que para poder observar quien esta conectado tiene que inciar sesión
            lista.Items.Clear();
            lista.Items.Add("Inicia sesión para ver quien esta conectado");

            //cambia el texto de los labels para informar al usuario, ademas desactiva o activa botones para evitar errores y que el usuario sepa que puede hacer
            estado.Text = "Desconectado";
            iniciar_sesion.Visible = true;
            registrarse.Visible = true;
            desconectar.Enabled = false;
            conectar.Enabled = true;
            iniciar_sesion.Enabled = false;
            registrarse.Enabled = false;
            Consultas_menu.Enabled = false;
        }

        private void iniciar_sesion_Click(object sender, EventArgs e)
        {
            string mensaje = "1/" + textUsuario.Text + "/" + textPassword.Text; /*EL mensaje 1 servira para iniciar sesion, el servidor tendra que
            buscar en la base de datos al usuario y enviar un mensaje de vuelta que ponga que SI esta. */

            //antes de enviar se comprobara que el usuario ha introducido correctamente los campos necesarios
            if ((textUsuario.Text != "") && (textPassword.Text != ""))
            {
                // Enviamos al servidor el nombre y contraseña de teclado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { "Introduzca usuario y contraseña" });
            }
        }

        private void registrarse_Click(object sender, EventArgs e)
        {
            string mensaje = "2/" + textUsuario.Text + "/" + textPassword.Text; /*EL mensaje 2 servira para registrarse, el servidor tendra que
            insertar en la base de datos al usuario y enviar un mensaje de vuelta que lo verifique. */

            //antes de enviar se comprobara que el usuario ha introducido correctamente los campos necesarios
            if ((textUsuario.Text != "") && (textPassword.Text != ""))
            {
                // Enviamos al servidor el nombre y contraseña de teclado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { "Introduzca usuario y contraseña" });
            }
        }



        private void invitar_Click(object sender, EventArgs e)
        {
            string mensaje = "7/" + textUsuario.Text + "/" + invitacion.Text + "/" + numsala;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void crearSala_Click(object sender, EventArgs e)
        {
            string mensaje = "6/" + textUsuario.Text;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            creador = true;
            BtnAbandon.Enabled = true;
            invitacion.Enabled = true;
        }

        private void BtnAbandon_Click(object sender, EventArgs e)//Abandonar sala
        {
            string mensaje = "11/" + textUsuario.Text + "/" + numsala;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        private async void start_Click(object sender, EventArgs e)//El creador de la sala empieza la partida
        {
            if (creador == true)
            {
                string mensaje = "12/" + textUsuario.Text + "/" + numsala;//Mensaje para avisar al servidor que va a empezar una partida
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                await Task.Delay(1000);
                string mensajex = "18/" + textUsuario.Text + "/" + numsala;//Mensaje para escoger una palabra aleatoria
                byte[] msgx = System.Text.Encoding.ASCII.GetBytes(mensajex);
                server.Send(msgx);
                start.Enabled = false;
            }
            else
                this.Invoke(new Delegadoparaescribir(Ponnotificacion), new object[] { "Solo el creador de la sala puede empezar la partida" });
        }
        private void button2_Click(object sender, EventArgs e)//Botón para adivinar la palabra
        {
            string rp = respuesta.Text;
            respuesta.Clear();

            bool res = string.Equals(palabra, rp, StringComparison.InvariantCultureIgnoreCase);

            if (res)
            {
                puntuacion = puntuacion + contador;
                info.Text = ("¡Has acertado!");
                label12.Text = Convert.ToString(puntuacion);
                button2.Enabled = false;
            }
            else
                info.Text = ("No es correcta");
        }
        private async void timer_Tick(object sender, EventArgs e)//timer de los segundos de cada ronda
        {
            contador--;
            tiempo.Text = Convert.ToString(contador);
            if (contador == 0)
            {
                timer.Enabled = false;
                info.Text = ("¡Se acabó el tiempo, la palabra era " + palabra);
                await Task.Delay(5000);
                contador = 60;
                tiempo.Text = Convert.ToString(contador);
                if (dibujante == true)//Se desaciva los controles de dibujante
                {
                    dibujante = false;
                    btn_pencil.Enabled = false;
                    btn_eraser.Enabled = false;

                }
                if (creador == true)
                {
                    string mensaje = "18/" + textUsuario.Text + "/" + numsala;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
            }
        }
        private void pontimer()
        {
            timer.Enabled = true;
        }



        private void recibir_dibujo(Point px, Point py, string cl, int e)
        {
            if (e == 1)
            {
                Color col = Color.FromName(cl);
                p.Color = col;
                g.DrawLine(p, px, py);

            }
            else
                g.DrawLine(erase, px, py);

        }
        private void Ponnotificacion(string s)
        {
            notificaciones.Items.Add(s);
        }


















        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 1);
        Pen erase = new Pen(Color.White, 50);
        int index;


        ColorDialog cd = new ColorDialog();
        Color new_color;


        private void btn_color_Click(object sender, EventArgs e)
        {
            cd.ShowDialog();
            new_color = cd.Color;
            pic_color.BackColor = cd.Color;
            p.Color = cd.Color;
        }

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            if(index !=0)
            {
                paint = true;
                py = e.Location;
            }
            


        }

        private void color_picker_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = set_point(color_picker, e.Location);
            pic_color.BackColor = ((Bitmap)color_picker.Image).GetPixel(point.X, point.Y);
            new_color = pic_color.BackColor;
            p.Color = pic_color.BackColor;
        }



        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint == true)
            {
                if (index == 1)
                {
                    px = e.Location;
                    g.DrawLine(p, px, py);
                    a = 1;
                    //Enviar_Dibujo(px,py,p,a);

                    puntos_color[pos_puntos_color] = px.X;
                    puntos_color[pos_puntos_color + 1] = px.Y;
                    pos_puntos_color = pos_puntos_color + 2;
                    if (pos_puntos_color == 50)
                    {
                        int z = 0;
                        Enviar_puntos(puntos_color, p, a, pos_puntos_color);
                        while (z < 50)
                        {
                            puntos_color[z] = 0;
                            z++;
                        }
                        pos_puntos_color = 0;

                    }

                    py = px;
                }
                if (index == 2)
                {
                    px = e.Location;
                    a = 50;
                    g.DrawLine(erase, px, py);
                    puntos_borrar[pos_puntos_borrar] = px.X;
                    puntos_borrar[pos_puntos_borrar + 1] = px.Y;
                    pos_puntos_borrar = pos_puntos_borrar + 2;
                    if (pos_puntos_borrar == 50)
                    {
                        int z = 0;
                        Enviar_puntos(puntos_borrar, erase, a, pos_puntos_borrar);
                        while (z < 50)
                        {
                            puntos_borrar[z] = 0;
                            z++;
                        }
                        pos_puntos_borrar = 0;

                    }


                    //Enviar_Dibujo(px, py, erase,a);
                    py = px;
                }
            }
            pic.Refresh();
        }
        private void pic_MouseUp(object sender, MouseEventArgs e)//Cada vez que dejas de dibujar se envía los puntos al servidor
        {
            paint = false;
            if (a == 1)
            {
                int z = 0;
                Enviar_puntos(puntos_color, p, a, pos_puntos_color);
                while (z < 50)
                {
                    puntos_color[z] = 0;
                    z++;
                }
                pos_puntos_color = 0;
            }
            else
            {
                int z = 0;
                Enviar_puntos(puntos_borrar, erase, a, pos_puntos_borrar);
                while (z < 50)
                {
                    puntos_borrar[z] = 0;
                    z++;
                }
                pos_puntos_borrar = 0;
            }
        }

        private void btn_eraser_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void btn_pencil_Click(object sender, EventArgs e)
        {
            index = 1;
        }
        private void pic_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comoSeJuegaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¡Bienvenidos a pinturillo! Este juego consiste en adivinar que objeto o idea está dibujando el rival.\r\n\r\n¿Como funciona? En cada partida hay un dibujante y los otros han de adivinar tu dibujo.\r\n\r\nSi te ha tocado dibujar: Tienes 60 segundos para dibujar la palabra que te ha tocado aleatoriamente, ten en cuenta que si nadie adivina la palabra, se va a restar tu puntuacíon, así que procura que se pueda adivinar facilmente.\r\n\r\nSi tienes que adivinar: Tienes 60 segundos para escribir la palabra correcta que tu contrincante está dibujando, cuando antes lo adivines, más puntos te llevas.\r\n\r\nCrea o únete a una sala y cuando estéis todos listos, que el creador de la sala le de al botón para empezar.\r\n\r\n¡Mucha suerte!\r\n\r\n \r\n");
        }

        private void queEsCadaConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Consulta 1: Lista de jugadores con los que has jugado una partida. \r\n\r\nConsulta 2: Ganadores de las partidas que has jugado con el jugador dado. \r\n\r\nConsulta 3: Lista de jugadores dado un rango de victorias");
        }

        private void consulta1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "3/" + textUsuario.Text;
            // Enviamos al servidor la consulta para la DB
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void consulta2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Consulta2 f2 = new Consulta2();
            f2.ShowDialog();
            string j1 = f2.DevolverJ1();
            string j2 = f2.DevolverJ2();
            string mensaje = "4/" + j1 + "/" + j2;
            // Enviamos al servidor la consulta para la DB
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void consulta3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta3 f = new Consulta3();
            f.ShowDialog();
            int r1 = f.DevolverR1(), r2 = f.DevolverR2();
            string mensaje = "5/"+ textUsuario.Text +"/"+ r1 + "/" + r2;
            // Enviamos al servidor la consulta para la DB
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }


        static Point set_point(PictureBox pb, Point pt)
        {
            float px = 1f * pb.Image.Width / pb.Width;
            float py = 1f * pb.Image.Height / pb.Height;
            return new Point((int)(pt.X * px), (int)(pt.Y * py));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mensaje = "21/" + textUsuario.Text + "/" + textChat.Text + "/" + numsala;
            // Enviamos al servidor la consulta para la DB
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            textChat.Clear();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {

        }

        private void estado_Click(object sender, EventArgs e)
        {

        }

        private void Enviar_puntos(int[] p, Pen pen, int a, int posicion)
        {
            if (a == 1)
            {
                string Puntos_color = null;
                int f = 0;
                while (f < pos_puntos_color)
                {
                    string punto = Convert.ToString(p[f]);
                    Puntos_color += "/" + punto;
                    f++;
                }
                String color = Convert.ToString(pen.Color);
                string mensaje = "13/" + textUsuario.Text + "/" + numsala + "/" + color + "/" + a + "/" + pos_puntos_color + "/" + Puntos_color;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                string Puntos_borrar = null;
                int f = 0;
                while (f < pos_puntos_color)
                {
                    string punto = Convert.ToString(p[f]);
                    Puntos_borrar += "/" + punto;
                    f++;
                }
                String color = Convert.ToString(pen.Color);
                string mensaje = "13/" + textUsuario.Text + "/" + numsala + "/" + color + "/" + a + "/" + pos_puntos_borrar + "/" + Puntos_borrar;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }
    }
}