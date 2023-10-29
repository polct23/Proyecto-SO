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

namespace Cliente_v2
{
    public partial class Cliente : Form
    {
        Socket server;
        public Cliente()
        {
            InitializeComponent();
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
        }

        private void desconectar_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexion
            string mensaje = "0/"; //codigo 0 para desconectar
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            //Nos desconectamos
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        private void iniciar_sesion_Click(object sender, EventArgs e)
        {
            string mensaje = "1/" + textUsuario.Text + "/" + textPassword.Text; /*EL mensaje 1 servira para iniciar sesion, el servidor tendra que
            buscar en la base de datos al usuario y enviar un mensaje de vuelta que ponga que SI esta. */

            // Enviamos al servidor el nombre y contraseña de teclado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            /*Recibimos la respuesta del servidor, que sera SI o NO, Si es si se mostrara un mensaje en pantalla y 
            se pasara al formulario de consultas, si sale no saldra un mensaje con un error*/

            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            if (mensaje == "SI") //MENSAJE TIENE QUE SER 'SI'
            {
                MessageBox.Show("Sesion Iniciada");
              

            }
            else if (mensaje == "NO")
            {
                MessageBox.Show("Error al iniciar sesion, pruebe nombre o contraseña erroneos");
              
            }
        }

        private void registrarse_Click(object sender, EventArgs e)
        {
            string mensaje = "2/" + textUsuario.Text + "/" + textPassword.Text; /*EL mensaje 2 servira para registrarse, el servidor tendra que
            insertar en la base de datos al usuario y enviar un mensaje de vuelta que lo verifique. */

            // Enviamos al servidor el nombre y contraseña de teclado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            /*Recibimos la respuesta del servidor, que sera SI o NO, Si es si se mostrara un mensaje en pantalla y 
            se pasara al formulario de inicio de sesion, si sale no saldra un mensaje con un error*/

            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            if (mensaje == "SI") //MENSAJE TIENE QUE SER 'SI'
            {
                MessageBox.Show("Registro completado");
                

            }
            else if (mensaje == "NO")
            {
                MessageBox.Show("Error al completar registro, pruebe con otro nombre y contraseña");
               
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

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show("El jugador con más partidas ha ganado más en el escenario: " + mensaje);//Mensaje sera el nombre del escenario
                
            }
            else if (consulta2.Checked)
            {
                string mensaje = "4/" + jugador1.Text + "/" + jugador2.Text;
                // Enviamos al servidor la consulta para la DB
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show("Ha ganado el jugador" + mensaje);//Mensaje tiene el nombre del jugador ganador
                

            }

            else if (consulta3.Checked)
            {
                string mensaje = "6/";
                // Enviamos al servidor la consulta para la DB
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show("El jugador que ha perdido la partida mas larga contra: " + mensaje);
                //Mensaje debera tener un formato JugadorPerdedor-JugadorGanador
               
            }
        }
    }
}

