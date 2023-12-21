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
        Socket server;
        Thread atender;
        string palabra;
        int contador = 60;
        bool creador;
        int puntuacion;
        string ganador;
        bool dibujante = false;
        
        public Cliente()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            lista.Items.Add("Inicia sesión para ver quien esta conectado");
            bm =new Bitmap(pic.Width,pic.Height);
            g=Graphics.FromImage(bm);
            g.Clear(Color.White);
            pic.Image = bm;
            btn_pencil.Enabled = false;
            btn_eraser.Enabled = false;
            button3.Enabled = false;
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
                MessageBox.Show(trozos[1]);
                string mensaje = trozos[1].Split('\0')[0];
                switch (codigo)
                {
                    case 1: //respusta cuando intentamos iniciar sesión
                        /*Recibimos la respuesta del servidor, que sera SI o NO, ..., Si es si se mostrara un mensaje en pantalla y 
                        se pasara al formulario de consultas, si sale no saldra un mensaje con un error*/

                        if (mensaje == "SI") //MENSAJE TIENE QUE SER 'SI'
                        {
                            MessageBox.Show("Sesión Iniciada");
                            //para que el usuario no vuelva a inciar o registrarse, ya que ya estara registrado
                            iniciar_sesion.Visible = false;
                            registrarse.Visible = false;
                        }
                        else if (mensaje == "incorrectPass")
                        {
                            MessageBox.Show("Error al iniciar sesión, compruebe el nombre o la contraseña");

                        }
                        else if (mensaje == "noUser")
                        {
                            MessageBox.Show("Error al inciar sesión, no existe el usuario introducido");
                        }
                        else if (mensaje == "yaConectado")
                        {
                            MessageBox.Show("El usuario ya esta conectado a nuestro servidor");
                        }
                        break;
                    case 2: //respuesta cuando nos intentamos registrar
                        /*Recibimos la respuesta del servidor, que sera SI o NO, Si es si se mostrara un mensaje en pantalla y 
                        se pasara al formulario de inicio de sesion, si sale no saldra un mensaje con un error*/

                        if (mensaje == "SI") //MENSAJE TIENE QUE SER 'SI'
                        {
                            MessageBox.Show("Registro completado");
                        }
                        else if (mensaje == "NO")
                        {
                            MessageBox.Show("Error al completar el registro, pruebe con otro nombre o contraseña");
                        }
                        else if (mensaje == "EXISTE")
                        {
                            MessageBox.Show("El usuario que has introducido ya existe");
                        }
                        break;

                    case 3:
                        if (mensaje != "no resultados")
                            MessageBox.Show("El esecnario es el siguiente: " + mensaje);//Mensaje sera el nombre del escenario
                        else
                            MessageBox.Show("No hay resultados");
                        break;
                    case 4:
                        if (mensaje != "no resultados")
                            MessageBox.Show("Si hay coincidencia y ha ganado el jugador: " + mensaje);//Mensaje tiene el nombre del jugador ganador
                                                                                                      //aqui se podria implementar una tabla utilizando un grid
                        else
                            MessageBox.Show("No hay resultados");
                        break;
                    case 5:
                        if (mensaje != "no resultados")
                            MessageBox.Show("El jugador que ha perdido la partida mas larga es el siguiente: " + mensaje);
                        else
                            MessageBox.Show("No hay resultados");

                        //Mensaje debera tener un formato JugadorPerdedor-JugadorGanador
                        break;
                    case 6:
                        int num = Convert.ToInt32(trozos[1]);
                        int i = 0;
                        lista.Items.Clear();
                        while (i < num)
                        {
                            lista.Items.Add(trozos[i + 2]);
                            i++;
                        }
                        break;
                    case 7:
                        if (mensaje == "Creada")
                            MessageBox.Show("Sala Creada");//Mensaje tiene el nombre del jugador ganador
                                                           //aqui se podria implementar una tabla utilizando un grid
                        else
                            MessageBox.Show("Sala no creada");
                        break;
                    case 8:
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
                            MessageBox.Show("No te has podido unirte, sala llena");
                        break;
                    case 10:
                        MessageBox.Show("El usuario ha aceptado la invitación");
                        break;
                    case 13:
                        if (dibujante == false) {
                                int p1_x = Convert.ToInt32(trozos[2]);
                                int p1_y = Convert.ToInt32(trozos[3]);
                                int p2_x = Convert.ToInt32(trozos[4]);
                                int p2_y = Convert.ToInt32(trozos[5]);
                                string color = trozos[6];
                                int a = Convert.ToInt32(trozos[7]);
                                Point p1 = new Point(p1_x, p1_y);
                                Point p2 = new Point(p2_x, p2_y);
                                recibir_dibujo(p1, p2, color, a);
                        }

                        break;
                    case 18:
                        palabra = trozos[1];
                        if(dibujante == true) 
                             info.Text = ("Te toca dibujar, la palabra es: " + palabra);
                        else
                            info.Text = ("Empieza la ronda");

                        
                        timer.Start();
                        break;
                    case 15:
                        ganador = trozos[1];
                        info.Text = (ganador + "gana la partida");
                        break;
                    case 16:
                        dibujante = true;
                        btn_pencil.Enabled = true;
                        btn_eraser.Enabled = true;
                        button3.Enabled = true;
                       
                        break;
                    case 20:
                        string m = "20/" + jugador1.Text + puntuacion;
                        // Enviamos al servidor la consulta para la DB
                        byte[] ms = System.Text.Encoding.ASCII.GetBytes(m);
                        server.Send(ms);
                        break;



                }
            }
        }

        private void conectar_Click(object sender, EventArgs e)
        {
            IPAddress direc = IPAddress.Parse("192.168.0.22"); //INDICAMOS IP// La ip establecida es un ejemplo
            IPEndPoint ipep = new IPEndPoint(direc, 9110); //INDICAMOS PUERTO// El puerto establecido es un ejemplo

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
            enviar.Enabled = true;
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
            enviar.Enabled = false;
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
                MessageBox.Show("Introduzca un usuario o contraseña");
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
                MessageBox.Show("Introduzca un usuario o contraseña");
            }
        }

        private void enviar_Click(object sender, EventArgs e)
        {
            if (consulta1.Checked)
            {
                string mensaje = "3/";
                // Enviamos al servidor la consulta para la DB
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else if (consulta2.Checked)
            {
                if ((jugador1.Text != "") && (jugador2.Text != ""))
                {
                    string mensaje = "4/" + jugador1.Text + "/" + jugador2.Text;
                    // Enviamos al servidor la consulta para la DB
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else
                {
                    MessageBox.Show("Introduzca el nombre de usuario de dos jugadores");
                }
            }

            else if (consulta3.Checked)
            {
                string mensaje = "5/";
                // Enviamos al servidor la consulta para la DB
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        private void invitar_Click(object sender, EventArgs e)
        {
            string mensaje = "7/" + textUsuario.Text + "/" + invitacion.Text;
            // Enviamos al servidor la consulta para la DB
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void crearSala_Click(object sender, EventArgs e)
        {
            string mensaje = "6/" + textUsuario.Text;
            // Enviamos al servidor la consulta para la DB
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            creador = true;
        }

        private void BtnAbandon_Click(object sender, EventArgs e)
        {
            string mensaje = "11/" + textUsuario.Text;
            // Enviamos al servidor la consulta para la DB
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
        private void start_Click(object sender, EventArgs e)//El creador de la sala empieza la partida
        {
            if (creador == true)
            {
                string mensaje = "12/" + textUsuario.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                string mensajex = "18/" + textUsuario.Text;
                byte[] msgx = System.Text.Encoding.ASCII.GetBytes(mensajex);
                server.Send(msgx);
            }
            else
                MessageBox.Show("Solo el creador puede empezar la partida");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(palabra == respuesta.Text)
                {
                puntuacion = puntuacion + contador;
                info.Text = ("¡Has acertado!");
                label12.Text = Convert.ToString(puntuacion);
                }
            else
                info.Text = ("No es correcta");
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            contador--;
            tiempo.Text = Convert.ToString(contador);
            if (contador == 0)
            {
                timer.Enabled = false;
                info.Text = ("¡Se acabó el tiempo");
                MessageBox.Show("La palabra era:" + palabra);
                contador = 60;
                tiempo.Text = Convert.ToString(contador);
                if (dibujante == true)
                {
                    dibujante = false;
                    btn_pencil.Enabled = false;
                    btn_eraser.Enabled = false;
                    button3.Enabled = false;
                }
                if (creador == true)
                {
                    string mensaje = "18/";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
            }
        }
        private void Enviar_Dibujo(Point px, Point py, Pen p, int a)
        {
            String p1_x = Convert.ToString(px.X);
            String p1_y = Convert.ToString(px.Y);
            String p2_x = Convert.ToString(py.X);
            String p2_y = Convert.ToString(py.Y);
            String color = Convert.ToString(p.Color);
           
            string mensaje = "13/" + textUsuario.Text  + "/" + p1_x + "/" + p1_y + "/" + p2_x + "/" + p2_y + "/" + color + "/" + a;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        private void recibir_dibujo(Point px, Point py, string cl, int e)
        {
            Pen p = new Pen(Color.FromName(cl), e);
            g.DrawLine(p, px, py);

        }


















        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 1);
        Pen erase=new Pen(Color.White, 50);
        int index;
        

        ColorDialog cd = new ColorDialog();
        Color new_color;
        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pic.Image = bm;
            index = 0;

        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            cd.ShowDialog();
            new_color = cd.Color;
            pic_color.BackColor = cd.Color;
            p.Color = cd.Color;
        }

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;

            
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
            if(paint==true)
            {
                if(index==1)
                {
                    px = e.Location;
                    g.DrawLine(p,px,py);
                    int a = 1;
                    Enviar_Dibujo(px,py,p,a);
                    py = px;
                }
                if (index == 2)
                {
                    px = e.Location;
                    g.DrawLine(erase, px, py);
                    int a = 50;
                    Enviar_Dibujo(px, py, erase,a);
                    py = px;
                }
            }
            pic.Refresh();
        }
        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            paint=false;
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

        static Point set_point(PictureBox pb, Point pt)
        {
            float px = 1f*pb.Image.Width/ pb.Width;
            float py = 1f*pb.Image.Height/ pb.Height;
            return new Point((int)(pt.X*px), (int)(pt.Y*py));
        }

    }

}



