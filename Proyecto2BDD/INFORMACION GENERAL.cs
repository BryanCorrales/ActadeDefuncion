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
    public partial class INFORMACION_GENERAL : Form
    {
        public String acta;
        public int id_fetal;
        public int registroCivil;
        public int ci_madre;
        int ci_medico;
        int numMedico;
        String nombreMedico;
        String observaciones;
        public String fechainscripcion;
        public String fechaCritica;
        public INFORMACION_GENERAL(String fechaactual, int idRegistro,String acta, int idDef, int ci_madre)
        {
            InitializeComponent();
            this.acta = acta;
            fechainscripcion = fechaactual;
            registroCivil = idRegistro;
            id_fetal = idDef;
            this.ci_madre = ci_madre;
           
        }

        private void button1_Click(object sender, EventArgs e)

            
        {
            if (txtCedulaPersona.Text=="" || txtTelefonoPersona.Text=="")
            {
                MessageBox.Show("Ingrese la cedula");

            }
            else
            {
                ci_medico = Convert.ToInt32(txtCedulaPersona.Text);
                numMedico = Convert.ToInt32(txtTelefonoPersona.Text);
                nombreMedico = txtNombreApellidoPersona.Text;
                observaciones = txtObservacionPersona.Text;

                SqlConnection OConection = new SqlConnection("Data Source = (local); Initial Catalog = Actas; Integrated Security = True");
                SqlDataAdapter guarda = new SqlDataAdapter();
                guarda.InsertCommand = new SqlCommand("insert into MEDICO(CI_MEDICO,NOMBREMEDICO,NUMTELEMEDICO,OBSERMEDICO) " +
                    "VALUES(@ci_medico,@nombreMedico,@numMedico,@observaciones)", OConection);


                guarda.InsertCommand.Parameters.Add(new SqlParameter("@ci_medico", SqlDbType.Int)).Value = ci_medico;
                guarda.InsertCommand.Parameters.Add(new SqlParameter("@nombreMedico", SqlDbType.Char, 50)).Value = nombreMedico;
                guarda.InsertCommand.Parameters.Add(new SqlParameter("@numMedico", SqlDbType.Char, 30)).Value = numMedico;
                guarda.InsertCommand.Parameters.Add(new SqlParameter("@observaciones", SqlDbType.Char, 30)).Value = observaciones;
             
                OConection.Open();
                guarda.InsertCommand.ExecuteNonQuery();
                OConection.Close();

                
                SqlDataAdapter guardatotal = new SqlDataAdapter();
                guardatotal.InsertCommand = new SqlCommand("insert into ACTA_INSCRIPCION(ACTAINSCRIPCION,IDREGISTROCIVIL,ID_FETAL,CI_MADRE,CI_MEDICO" +
                    ",FECHAINSCRIPCION) " +
                    "VALUES(@acta,@registroCivil,@id_fetal,@ci_madre,@ci_medico2,@fechainscripcion)", OConection);


                guardatotal.InsertCommand.Parameters.Add(new SqlParameter("@acta", SqlDbType.VarChar,30)).Value = acta;
                guardatotal.InsertCommand.Parameters.Add(new SqlParameter("@registroCivil", SqlDbType.Int)).Value = registroCivil ;
                guardatotal.InsertCommand.Parameters.Add(new SqlParameter("@id_fetal", SqlDbType.Int)).Value = id_fetal;
                guardatotal.InsertCommand.Parameters.Add(new SqlParameter("@ci_madre", SqlDbType.Int)).Value = ci_madre;
                guardatotal.InsertCommand.Parameters.Add(new SqlParameter("@ci_medico2", SqlDbType.Int)).Value = ci_medico;
                guardatotal.InsertCommand.Parameters.Add(new SqlParameter("@fechainscripcion", SqlDbType.VarChar,30)).Value = fechainscripcion;
                OConection.Open();
                guardatotal.InsertCommand.ExecuteNonQuery();
                OConection.Close();
                MessageBox.Show("Se ingreso correctamente");

                SqlDataAdapter guardatotalau = new SqlDataAdapter();
                guardatotalau.InsertCommand = new SqlCommand("insert into AUDITORIA(ACTAINSCRIPCION,IDREGISTROCIVIL,ID_FETAL,CI_MADRE,CI_MEDICO" +
                    ",FECHAINSCRIPCION) " +
                    "VALUES(@acta2,@registroCivil2,@id_fetal2,@ci_madre2,@ci_medico3,@fechainscripcion2)", OConection);

                String acta2 = acta;
                guardatotal.InsertCommand.Parameters.Add(new SqlParameter("@acta2", SqlDbType.VarChar, 30)).Value = acta2;
                guardatotal.InsertCommand.Parameters.Add(new SqlParameter("@registroCivil2", SqlDbType.Int)).Value = registroCivil;
                guardatotal.InsertCommand.Parameters.Add(new SqlParameter("@id_fetal2", SqlDbType.Int)).Value = id_fetal;
                guardatotal.InsertCommand.Parameters.Add(new SqlParameter("@ci_madre2", SqlDbType.Int)).Value = ci_madre;
                guardatotal.InsertCommand.Parameters.Add(new SqlParameter("@ci_medico3", SqlDbType.Int)).Value = ci_medico;
                guardatotal.InsertCommand.Parameters.Add(new SqlParameter("@fechainscripcion2", SqlDbType.VarChar, 30)).Value = fechainscripcion;
                OConection.Open();
                guardatotal.InsertCommand.ExecuteNonQuery();
                OConection.Close();


                FORMULARIO forme = new FORMULARIO();
                forme.Visible = true;
                this.Visible = false;










            }
        }
    }
}
