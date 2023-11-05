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
using System.Threading;


namespace Cliente_v2
{

    
    public partial class Cliente : Form
    {
        Socket server;
        Thread atender;
        public Cliente()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            lista.Items.Add("Inicia sesión para ver quien esta conectado");
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
                            MessageBox.Show("Sesión Iniciada");
                            //para que el usuario no vuelva a inciar o registrarse, ya que ya estara registrado
                            iniciar_sesion.Visible = false;
                            registrarse.Visible = false;
                        }
                        else if (mensaje == "incorrectPass")
                        {
                            MessageBox.Show("Error al iniciar sesión, pruebe nombre o contraseña erroneos");

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
                            MessageBox.Show("Error al completar registro, pruebe con otro nombre y contraseña");
                        }
                        else if (mensaje == "EXISTE")
                        {
                            MessageBox.Show("El usuario que has introducido ya existe");
                        }
                        break;

                    case 3:
                        MessageBox.Show("El jugador con más partidas ha ganado más en el escenario: " + mensaje);//Mensaje sera el nombre del escenario
                        break;
                    case 4:
                        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                        MessageBox.Show("Ha ganado el jugador" + mensaje);//Mensaje tiene el nombre del jugador ganador
                        break;
                    case 5:
                        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                        MessageBox.Show("El jugador que ha perdido la partida mas larga contra: " + mensaje);
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
                }
            }
        }

        private void conectar_Click(object sender, EventArgs e)
        {
            IPAddress direc = IPAddress.Parse("192.168.56.102"); //INDICAMOS IP// La ip establecida es un ejemplo
            IPEndPoint ipep = new IPEndPoint(direc, 9050); //INDICAMOS PUERTO// El puerto establecido es un ejemplo

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
        }

        private void iniciar_sesion_Click(object sender, EventArgs e)
        {
            string mensaje = "1/" + textUsuario.Text + "/" + textPassword.Text; /*EL mensaje 1 servira para iniciar sesion, el servidor tendra que
            buscar en la base de datos al usuario y enviar un mensaje de vuelta que ponga que SI esta. */

            //antes de enviar se comprobara que el usuario ha introducido correctamente los campos necesarios
            if ((textUsuario.Text != "") && (textPassword.Text != "")){
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
                string mensaje = "4/" + jugador1.Text + "/" + jugador2.Text;
                // Enviamos al servidor la consulta para la DB
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }

            else if (consulta3.Checked)
            {
                string mensaje = "5/";
                // Enviamos al servidor la consulta para la DB
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }
    }
}

