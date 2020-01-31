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
    public partial class DATOS_MADRE : Form
    {
        int ci_madre;
        int edad;
        int hijosviven;
        int hijosmuertosviven;
        int hijosmuertos;
        int numcomntroles;
        String nombreMadre;
        String nacionalidadMadre;
        String FechaNacimiento;
        String etnia;
        String estadocivil;
        String lectura;
        String nivelinstru;
        String provincia;
        String canton;
        String parroquia;
        String ciudad;
        String dirmadre;
        String fechaactual;
        int idRegistro;
        int idDef;
        String acta;
        
        public DATOS_MADRE(String fechaacta, int idregistro, int idDef,String acta)
        {
            InitializeComponent();
            fechaactual = fechaacta;
            this.idRegistro = idregistro;
            this.idDef = idDef;
            this.acta = acta;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCedulaMadre.Text=="" || txtEdadMadre.Text=="" || txtHijosMadre.Text=="" 
                || txtHijosNacidosVivosMuertos.Text=="" || txtHijosNacidosMuertos.Text==""
                || txtControlPrenatal.Text=="")
            {
                MessageBox.Show("Ingrese todos los datos");
            }
            else
            {
                ci_madre = Convert.ToInt32(txtCedulaMadre.Text);
                edad = Convert.ToInt32(txtEdadMadre.Text);
                hijosviven = Convert.ToInt32(txtHijosMadre.Text);
                hijosmuertosviven = Convert.ToInt32(txtHijosNacidosVivosMuertos.Text);
                hijosmuertos = Convert.ToInt32(txtHijosNacidosMuertos.Text);
                numcomntroles = Convert.ToInt32(txtControlPrenatal.Text);
                nombreMadre = txtNombreMadre.Text;
                FechaNacimiento = txtFechaNacimientoMadre.Text;
                provincia = txtProvinciaMadre.Text;
                canton = txtCantonMadre.Text;
                parroquia = txtParroquiaMadre.Text;
                ciudad = txtLocalidadMadre.Text;
                dirmadre = txtDireccionMadre.Text;
                if (JpanelLectura.Enabled==true)
                {
                    SqlConnection OConection = new SqlConnection("Data Source = (local); Initial Catalog = Actas; Integrated Security = True");
                    SqlDataAdapter guarda = new SqlDataAdapter();
                    guarda.InsertCommand = new SqlCommand("insert into MADRE(CI_MADRE,NOMBREMADRE,NACIONALMADRE,FECHANACIMIMADRE,EDADMADRE,HIJOSVIVEN,HIJOSMUERTOSVIVEN,HIJOSMUERTOS," +
                        "NUMCONTROLES,AUTOMADRE,ESTADOCIVIL,LECTURA,NIVELINSTRUCCIONMADRE,PROVINCIAMADRE,CANTONMADRE,PARROQUIAMADRE,CIUDADMADRE,DIREMADRE)" +
                        "VALUES(@ci_madre,@nombreMadre,@nacionalidadMadre,@FechaNacimiento,@edad,@hijosviven,@hijosmuertosviven,@hijosmuertos,@numcomntroles,@etnia" +
                        ",@estadocivil,@lectura,@nivelinstru,@provincia,@canton,@parroquia,@ciudad,@dirmadre)", OConection);


                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@ci_madre", SqlDbType.Int)).Value = ci_madre;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@nombremadre", SqlDbType.Char, 50)).Value = nombreMadre;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@nacionalidadMadre", SqlDbType.Char,30)).Value = nacionalidadMadre;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@FechaNacimiento", SqlDbType.VarChar, 30)).Value = FechaNacimiento;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@edad", SqlDbType.Int)).Value = edad;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@hijosviven", SqlDbType.SmallInt)).Value =hijosviven;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@hijosmuertosviven", SqlDbType.SmallInt)).Value = hijosmuertosviven;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@hijosmuertos", SqlDbType.SmallInt)).Value = hijosmuertos;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@numcomntroles", SqlDbType.Int)).Value = numcomntroles;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@etnia", SqlDbType.Char,20)).Value = etnia;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@estadocivil", SqlDbType.Char, 30)).Value = estadocivil;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@lectura", SqlDbType.Char, 20)).Value = lectura;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@nivelinstru", SqlDbType.Char, 40)).Value = nivelinstru;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@provincia", SqlDbType.Char, 30)).Value = provincia;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@canton", SqlDbType.VarChar, 30)).Value = canton;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@parroquia", SqlDbType.Char, 40)).Value = parroquia;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@ciudad", SqlDbType.Char, 30)).Value = ciudad;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@dirmadre", SqlDbType.Char, 40)).Value = dirmadre;

                    OConection.Open();
                    guarda.InsertCommand.ExecuteNonQuery();
                    OConection.Close();
                }

                else
                {
                    SqlConnection OConection = new SqlConnection("Data Source = (local); Initial Catalog = Actas; Integrated Security = True");
                    SqlDataAdapter guarda = new SqlDataAdapter();
                    guarda.InsertCommand = new SqlCommand("insert into MADRE(CI_MADRE,NOMBREMADRE,NACIONALMADRE,FECHANACIMIMADRE,EDADMADRE,HIJOSVIVEN,HIJOSMUERTOSVIVEN,HIJOSMUERTOS," +
                        "NUMCONTROLES,AUTOMADRE,ESTADOCIVIL,LECTURA,PROVINCIAMADRE,CANTONMADRE,PARROQUIAMADRE,CIUDADMADRE,DIREMADRE)" +
                        "VALUES(@ci_madre,@nombreMadre,@nacionalidadMadre,@FechaNacimiento,@edad,@hijosviven,@hijosmuertosviven,@hijosmuertos,@numcomntroles,@etnia" +
                        ",@estadocivil,@lectura,@provincia,@canton,@parroquia,@ciudad,@dirmadre)", OConection);


                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@ci_madre", SqlDbType.Int)).Value = ci_madre;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@nombremadre", SqlDbType.Char, 50)).Value = nombreMadre;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@nacionalidadMadre", SqlDbType.Char, 30)).Value = nacionalidadMadre;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@FechaNacimiento", SqlDbType.VarChar, 30)).Value = FechaNacimiento;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@edad", SqlDbType.Int)).Value = edad;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@hijosviven", SqlDbType.SmallInt)).Value = hijosviven;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@hijosmuertosviven", SqlDbType.SmallInt)).Value = hijosmuertosviven;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@hijosmuertos", SqlDbType.SmallInt)).Value = hijosmuertos;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@numcomntroles", SqlDbType.Int)).Value = numcomntroles;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@etnia", SqlDbType.Char, 20)).Value = etnia;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@estadocivil", SqlDbType.Char, 30)).Value = estadocivil;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@lectura", SqlDbType.Char, 20)).Value = lectura;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@provincia", SqlDbType.Char, 30)).Value = provincia;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@canton", SqlDbType.VarChar, 30)).Value = canton;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@parroquia", SqlDbType.Char, 40)).Value = parroquia;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@ciudad", SqlDbType.Char, 30)).Value = ciudad;
                    guarda.InsertCommand.Parameters.Add(new SqlParameter("@dirmadre", SqlDbType.Char, 40)).Value = dirmadre;

                    OConection.Open();
                    guarda.InsertCommand.ExecuteNonQuery();
                    OConection.Close();
                }
                

                INFORMACION_GENERAL info = new INFORMACION_GENERAL(fechaactual,idRegistro, acta,idDef, ci_madre);
               
                info.Visible = true;
                this.Visible = false;
            }
            
        }

        private void rBEcutoriana_CheckedChanged(object sender, EventArgs e)
        {
            nacionalidadMadre = "Ecuatoriana";
            txtNacionalidadMadre.Enabled = false;
        }

        private void rBEtranjero_CheckedChanged(object sender, EventArgs e)
        {
            txtNacionalidadMadre.Enabled = true;
            nacionalidadMadre = txtNacionalidadMadre.Text;

        }

        private void rBIndigena_CheckedChanged(object sender, EventArgs e)
        {
            etnia = "Indigena";
        }

        private void rBAfro_CheckedChanged(object sender, EventArgs e)
        {
            etnia = "Afroecuatoriana";
        }

        private void rBNegra_CheckedChanged(object sender, EventArgs e)
        {
            etnia = "Negra";
        }

        private void rBMulata_CheckedChanged(object sender, EventArgs e)
        {
            etnia = "Mulata";
        }

        private void rBMontubia_CheckedChanged(object sender, EventArgs e)
        {
            etnia = "Montubia";
        }

        private void rBMestiza_CheckedChanged(object sender, EventArgs e)
        {
            etnia = "Meztiza";
        }

        private void rBBlanca_CheckedChanged(object sender, EventArgs e)
        {
            etnia = "Blanca";
        }

        private void rBOtraEtnia_CheckedChanged(object sender, EventArgs e)
        {
            etnia = "Otra";
        }

        private void rBUnida_CheckedChanged(object sender, EventArgs e)
        {
            estadocivil = "Unida";
        }

        private void rBSoltera_CheckedChanged(object sender, EventArgs e)
        {
            estadocivil = "Soltera";
        }

        private void rBCasada_CheckedChanged(object sender, EventArgs e)
        {
            estadocivil = "Casada";
        }

        private void rBDivorciada_CheckedChanged(object sender, EventArgs e)
        {
            estadocivil = "Divorsiada";
        }

        private void rBSeparada_CheckedChanged(object sender, EventArgs e)
        {
            estadocivil = "Separada";
        }

        private void rBViuda_CheckedChanged(object sender, EventArgs e)
        {
            estadocivil = "Viuda";
        }

        private void rBSiLeer_CheckedChanged(object sender, EventArgs e)
        {
            lectura = "si";
            JpanelLectura.Enabled = true;
        }

        private void rBNoLeer_CheckedChanged(object sender, EventArgs e)
        {
            lectura = "no";
            JpanelLectura.Enabled = false;
        }

        private void rBNinguno_CheckedChanged(object sender, EventArgs e)
        {
            nivelinstru = "Ninguno";
        }

        private void rBCentroAlfa_CheckedChanged(object sender, EventArgs e)
        {
            nivelinstru = "Centro de Alfabetizacion";
        }

        private void rBPrimaria_CheckedChanged(object sender, EventArgs e)
        {
            nivelinstru = "Primaria";
        }

        private void rBSecundario_CheckedChanged(object sender, EventArgs e)
        {
            nivelinstru = "Secundaria";
        }

        private void rBBasica_CheckedChanged(object sender, EventArgs e)
        {
            nivelinstru = "Educacion Basica";
        }

        private void rBBachillerato_CheckedChanged(object sender, EventArgs e)
        {
            nivelinstru = "Bachillerato";
        }

        private void rBPosbachillerato_CheckedChanged(object sender, EventArgs e)
        {
            nivelinstru = "Pos bachillerato";
        }

        private void rBSuperior_CheckedChanged(object sender, EventArgs e)
        {
            nivelinstru = "Superior";
        }

        private void rBPosgrado_CheckedChanged(object sender, EventArgs e)
        {
            nivelinstru = "Postgrado";
        }
    }
}
