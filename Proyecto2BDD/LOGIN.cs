using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto2BDD
{
    class LOGIN
    {
        private static string nombre;
        private static int id;

        public static string Nombre { get => nombre; set => nombre = value; }
        public static int Id { get => id; set => id = value; }

        public static Boolean Credenciales(String nombre, String pass)
        {
            bool resultado = false;
            SqlCommand Ocomando = new SqlCommand();
            SqlConnection OConection = new SqlConnection("Data Source = (local); Initial Catalog = Actas; Integrated Security = True");
            SqlDataReader Lector;
            Ocomando.Connection = OConection;
            Ocomando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar, 20)).Value = nombre;
            Ocomando.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar, 20)).Value = pass;

            Ocomando.CommandText = "select *from Usuario where nombre=@nombre and Contraseña=@pass";
            OConection.Open();
            Lector = Ocomando.ExecuteReader();
            if (Lector.HasRows)
            {
                Lector.Read();
                id = Lector.GetInt32(0);
                nombre = Lector.GetString(1);
                resultado = true;
            }
            Lector.Close();
            return resultado;



        }
       
    }
}