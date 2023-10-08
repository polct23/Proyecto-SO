using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Cliente_ProyectoSO
{
    public partial class ConexionServidor : Form
    {
        Socket server;
        
        public ConexionServidor()
        {
            InitializeComponent();
        }
        

        private void conectar_Click(object sender, EventArgs e)
        {
            IniciarSesion f2 = new IniciarSesion();
            f2.Show();
            this.Hide();
        }

        private void registrarse_Click(object sender, EventArgs e)
        {
            Registarse f = new Registarse();
            f.Show();
            this.Hide();
        }

        private void ConexionServidor_Load(object sender, EventArgs e)
        {
            //Primer paso es establecer una conexion, usamos IPEndPoint con el ip del sevidor y su puerto

            IPAddress direc = IPAddress.Parse("192.168.56.101"); //INDICAMOS IP// La ip establecida es un ejemplo
            IPEndPoint ipep = new IPEndPoint(direc, 9050); //INDICAMOS PUERTO// El puerto establecido es un ejemplo

            //Creamos el socket
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep); //Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");

            }
            catch (SocketException ex)
            {
                //Si hay excepcion indicamos error y salimos del programa con un return
                MessageBox.Show("Conexion con servidor fallida: " + ex.Message);
                return;

            }
            finally
            {
                // Cerramos el socket en el bloque finally para asegurarnos de que se libere correctamente
                if (server != null && server.Connected)
                {
                    server.Close();
                }
            }
        }
    }
}
