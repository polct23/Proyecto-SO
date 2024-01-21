using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente_v2
{
    public partial class Consulta3 : Form
    {
        int r1;
        int r2;
        public Consulta3()
        {
            InitializeComponent();
        }

        public int DevolverR1()
        {
            return r1;
        }
        public int DevolverR2()
        {
            return r2;
        }
        private void enviarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                r1 = Convert.ToInt32(r1Box.Text);
                r2 = Convert.ToInt32(r2Box.Text);

                this.Close();
            }
            catch 
            {
                MessageBox.Show("Formato de datos INCORRECTO");
            }
            
        }
    }
}
