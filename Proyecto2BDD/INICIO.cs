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
    public partial class INICIO : Form
    {

        int idregistro;
        String oficinaRegistro;
        String parroquiaRegistro;
        String CantonRegistro;
        String provinciaRegistro;
        String fechaacta;
        String actaNum;
        public INICIO()
        {
            InitializeComponent();
            

        }

        private void btnSiguiente1_Click(object sender, EventArgs e)
        {
            oficinaRegistro = txtOficinaRegistroCi.Text;
            parroquiaRegistro = txtParroquia.Text;
            CantonRegistro = txtCanton.Text;
            provinciaRegistro = txtProvincia.Text;
            fechaacta = txtFechaInscripcion.Text;
            actaNum = txtActaInscripcion.Text;
            

            if (txtOficina.Text=="")
            {
                MessageBox.Show("Ingrese el numero de oficia");

            }
            else
            {
                idregistro = Convert.ToInt32(txtOficina.Text);
            }
            if (txtActaInscripcion.Text=="" || txtCanton.Text=="" || txtFechaInscripcion.Text=="" || txtOficinaRegistroCi.Text==""
                || txtParroquia.Text=="" || txtProvincia.Text=="") 
            {
                MessageBox.Show("Ingrese todos los campos");
            }
            else
            {
                
                SqlConnection OConection = new SqlConnection("Data Source = (local); Initial Catalog = Actas; Integrated Security = True");
                SqlDataAdapter guarda = new SqlDataAdapter();
                guarda.InsertCommand = new SqlCommand("insert into REGISTROCIVIL(IDREGISTROCIVIL,OFICINAREGISTRO,PARROQUIAREGISTRO,CANTONREGISTRO,PROVINCIAREGISTRO) " +
                    "VALUES(@oficina,@oficinaRegistro,@parroquiaRegistro,@cantonRegistro,@provinciaRegistro)", OConection);


                guarda.InsertCommand.Parameters.Add(new SqlParameter("@oficina", SqlDbType.Int)).Value = idregistro;
                guarda.InsertCommand.Parameters.Add(new SqlParameter("@oficinaRegistro", SqlDbType.Char, 50)).Value = oficinaRegistro;
                guarda.InsertCommand.Parameters.Add(new SqlParameter("@cantonRegistro", SqlDbType.Char, 30)).Value = CantonRegistro;
                guarda.InsertCommand.Parameters.Add(new SqlParameter("@provinciaRegistro", SqlDbType.Char, 30)).Value = provinciaRegistro;
                guarda.InsertCommand.Parameters.Add(new SqlParameter("@parroquiaRegistro", SqlDbType.Char, 30)).Value = parroquiaRegistro;
                                OConection.Open();
                guarda.InsertCommand.ExecuteNonQuery();
                OConection.Close();




                DATOS_DEFUNCION datDef = new DATOS_DEFUNCION(fechaacta, idregistro,actaNum);
                datDef.Visible = true;
                this.Visible = false;
            }
            
                
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
       

        private void txtActaInscripcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
