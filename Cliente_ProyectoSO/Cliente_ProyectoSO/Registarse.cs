using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente_ProyectoSO
{
    
    public partial class Registarse : Form
    {
        Socket server;
        public Registarse()
        {
            InitializeComponent();
        }

        private void iniciar_Click(object sender, EventArgs e)
        {
            string mensaje = "2/" + nombre.Text + "/" + contraseña.Text; /*EL mensaje 2 servira para registrarse, el servidor tendra que
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
                IniciarSesion f = new IniciarSesion();
                f.Show();
                this.Hide();

            }
            else if (mensaje == "NO")
            {
                MessageBox.Show("Error al completar registro, pruebe con otro nombre y contraseña");
            }
        }
    }
}
