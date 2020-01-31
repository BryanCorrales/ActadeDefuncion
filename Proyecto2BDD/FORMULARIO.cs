using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2BDD
{
    public partial class FORMULARIO : Form
    {
        public FORMULARIO()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
          
            INICIO inicio = new INICIO();
            inicio.Visible=true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CONSULTA consulta = new CONSULTA();
            consulta.Visible = true;
            this.Visible = false;
        }
    }
}
