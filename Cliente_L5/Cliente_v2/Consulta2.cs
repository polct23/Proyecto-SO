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
    public partial class Consulta2 : Form
    {
        string j1;
        string j2;
        public Consulta2()
        {
            InitializeComponent();
        }

        public string DevolverJ1()
        {
            return j1;
        }
        public string DevolverJ2()
        {
            return j2;
        }
        private void enviarBtn_Click(object sender, EventArgs e)
        {
            j1 = j1Box.Text;
            j2 = j2Box.Text;

            this.Close();
        }
    }
}
