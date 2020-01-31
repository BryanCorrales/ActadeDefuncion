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
    public partial class DATOS_DEFUNCION : Form
    {
        int id;
        String sexo;
        int SemanaGest;
        String fecha;
        String productoEm;
        String asistenciaFet;
        String Lugar;
        String nomEstable;
        String provinciaFet;
        String CantonFet;
        String parroquiaFet;
        String LocalidaFet;
        String Causa;
        String fechaactual;
        int idRegistros;
        String acta;
        public DATOS_DEFUNCION(String fechaacta, int idregistro,String actanum)
        {
            InitializeComponent();
            jPanelOtro.Enabled = false;
            this.fechaactual = fechaacta;
            this.idRegistros = idregistro;
            this.acta = actanum;
        }
       

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fecha = txtFechaOcurrencia.Text;
            Causa = txtCausaDefuncion.Text;
            if (txtCIE.Text == ""  || txtSemanasGestacion.Text=="")
            {
                MessageBox.Show("Ingrese el numero de CI");

            }
            else
            {
                
                id = Convert.ToInt32(txtCIE.Text);
                SemanaGest = Convert.ToInt32(txtSemanasGestacion.Text);
              


                SqlConnection OConection = new SqlConnection("Data Source = (local); Initial Catalog = Actas; Integrated Security = True");
                SqlDataAdapter guarda = new SqlDataAdapter();
                guarda.InsertCommand = new SqlCommand("insert into DEF_FETAL(ID_FETAL,SEXOFETO,SEMANAGESTA,FECHADEFUN,PRODUCTOEMBARA,ASISTENCIAFETAL,CAUSAFETAL)" +
                    "values(@id,@sexo,@semGest,@fechadef,@productEm,@asistencia,@causa)", OConection);


                guarda.InsertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                guarda.InsertCommand.Parameters.Add(new SqlParameter("@sexo", SqlDbType.Char, 50)).Value = sexo;
                guarda.InsertCommand.Parameters.Add(new SqlParameter("@semGest", SqlDbType.Int)).Value = SemanaGest;
                guarda.InsertCommand.Parameters.Add(new SqlParameter("@fechadef", SqlDbType.VarChar, 30)).Value = fecha;
                guarda.InsertCommand.Parameters.Add(new SqlParameter("@productEm", SqlDbType.Char, 20)).Value = productoEm;
                guarda.InsertCommand.Parameters.Add(new SqlParameter("@asistencia", SqlDbType.Char, 30)).Value = asistenciaFet;
                guarda.InsertCommand.Parameters.Add(new SqlParameter("@causa", SqlDbType.Char, 30)).Value = Causa;

                OConection.Open();
                guarda.InsertCommand.ExecuteNonQuery();
                OConection.Close();
                DATOS_MADRE dMadre = new DATOS_MADRE(fechaactual,idRegistros,id,acta);
                dMadre.Visible = true;
                this.Visible = false;
            }
            

            
        }

        private void rB1_CheckedChanged(object sender, EventArgs e)
        {
            sexo = "hombre";
        }

        private void rB2_CheckedChanged(object sender, EventArgs e)
        {
            sexo = "mujer";
        }

        private void rBSimple_CheckedChanged(object sender, EventArgs e)
        {
            productoEm = "simple";

        }

        private void rBDoble_CheckedChanged(object sender, EventArgs e)
        {
            productoEm = "doble";
        }

        private void rBTriple_CheckedChanged(object sender, EventArgs e)
        {
            productoEm = "triple";

        }

        private void rBCuadru_CheckedChanged(object sender, EventArgs e)
        {
            productoEm = "Cuadruple o Mas";
        }

        private void rBMedico_CheckedChanged(object sender, EventArgs e)
        {
            asistenciaFet = "Medico";

        }

        private void rBObste_CheckedChanged(object sender, EventArgs e)
        {
            asistenciaFet = "Obstetriz";
        }

        private void rBEnfer_CheckedChanged(object sender, EventArgs e)
        {
            asistenciaFet = "Enfermero";
        }

        private void rBAuxiliar_CheckedChanged(object sender, EventArgs e)
        {
            asistenciaFet = "Auxiliar";
        }

        private void rBPartero_CheckedChanged(object sender, EventArgs e)
        {
            asistenciaFet = "Partero";
        }

        private void rBOtro_CheckedChanged(object sender, EventArgs e)
        {
            asistenciaFet = txtOtroAsistido.Text;
        }

        private void rBMinisterio_CheckedChanged(object sender, EventArgs e)
        {
            nomEstable = "Ministerio";
            jPanelOtro.Enabled = false;
        }

        private void rbIESS_CheckedChanged(object sender, EventArgs e)
        {
            nomEstable = "Iess";
            jPanelOtro.Enabled = false;
        }

        private void rbJunta_CheckedChanged(object sender, EventArgs e)
        {
            nomEstable = "Junta Benenficiencia";
            jPanelOtro.Enabled = false;
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void rBOtroPublico_CheckedChanged(object sender, EventArgs e)
        {
            nomEstable = "Otro";

        }

        private void rBPrivado_CheckedChanged(object sender, EventArgs e)
        {
            nomEstable = "Hospital Clinica Privada";
            jPanelOtro.Enabled = false;
        }

        private void rBCasa_CheckedChanged(object sender, EventArgs e)
        {
            nomEstable = "Casa";
            jPanelOtro.Enabled = false;
        }

        private void rBOtro2_CheckedChanged(object sender, EventArgs e)
        {
            nomEstable = txtOtroLugar.Text;
            jPanelOtro.Enabled = true;
        }

        private void txtNombreEstablecimiento_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSemanasGestacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void DATOS_DEFUNCION_Load(object sender, EventArgs e)
        {

        }
    }
}
