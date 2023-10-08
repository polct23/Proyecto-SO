using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente_ProyectoSO
{
    public partial class ConsultasBD : Form
    {
        Socket server;
        public ConsultasBD()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void enviar_Click(object sender, EventArgs e)
        {
            if(consulta1.Checked)
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
            else if(consulta2.Checked)
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
                string mensaje = "5/";
                // Enviamos al servidor la consulta para la DB
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show("El jugador con más antiguo que ha perdido más de 3 partidas seguidas es: " + mensaje);
                //Mensaje debe incluir el nombre del jugador que especifica la consulta

            }
            else if (consulta4.Checked)
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
