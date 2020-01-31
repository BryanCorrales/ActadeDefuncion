using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2BDD
{
    public partial class CONSULTA : Form
    {
        public CONSULTA()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtcedula.Text == "")
            {
                MessageBox.Show("Ingrese la cedula de la madre para buscar");
            }
            else
            {
                DataTable dt = new DataTable();
                String strSql;
                strSql = "MostrarTodo";
                SqlConnection cn = new SqlConnection("Data Source = (local); Initial Catalog = Actas; Integrated Security = True");
                SqlDataAdapter da = new SqlDataAdapter(strSql, cn);

                cn.Open();

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@CI_madre", SqlDbType.VarChar).Value = Convert.ToInt32(txtcedula.Text);
                da.Fill(dt);

                dataTodo.DataSource = dt;
                cn.Close();
            }
            

            
        }
    }
}
