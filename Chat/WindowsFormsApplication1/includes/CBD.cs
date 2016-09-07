using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication1.includes
{
    //Clase para trabajo contra base de datos.

    public class CBD
    {
        protected SqlConnection conn = null;//conexion de tipo sql server. No esta definido para otras conexiones de momento
        protected SqlCommand comando = null;

        public CBD()
        {
            conectar();
        }

        /// <summary>
        /// Conexión a base de datos
        /// </summary>
        /// <returns>Devuelve booleano que nos indica si la conexión se realizó correctamente</returns>
        public bool conectar()
        {
            bool conectado = false;
            if (this.conn == null)
            {
                //si a conexión está aberta pechámo-la (comprobamos previamente si no es null)
                if (this.conn != null)
                {
                    if (this.conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                try
                {
                    String cadenaConexion = "Data Source=172.18.220.100;Initial Catalog=usuarios;User ID=maqueta;Password=maqueta;Connection Timeout=10";

                    this.conn = new SqlConnection();
                    conn.ConnectionString = cadenaConexion;
                    conn.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                //estado da conexión
                conectado = (this.conn.State == ConnectionState.Open);
                this.comando = this.conn.CreateCommand();
                if (!conectado)
                {
                    //throw new Exception(string.Format("Error CBD::{0} No se ha podido conectar a BD ni con host:{1} ni con hostAxiliar:{2}."));
                }
            }
            return conectado;
        }

        /// <summary>
        /// Función para obtener los posibles destinatarios, los obtenemos de la tabla usuarios
        /// </summary>
        /// <returns>Devuelve string con estructura "string1,string2,string3" para su posterior adicción a los combobox</returns>
        public string obtenerDestinatarios()
        {
            SqlDataReader coso = null;
            string result = "";
            string consulta = "SELECT nombreApellidos FROM usuarios";

            comando.CommandText = consulta;
            comando.CommandTimeout = 40;
            
            try
            {
                coso = comando.ExecuteReader();
                coso.Read();

                int tam = coso.FieldCount; //Filas devueltas por consulta

                if (coso.HasRows)
                {
                    while (coso.Read())
                    {
                        var myString = coso.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                                                          // Do somthing with this rows string, for example to put them in to a list
                        if (result == "")
                        {
                            result = (string)coso.GetString(0);
                        }
                        else
                        {
                            result = result + "," + (string)coso.GetString(0);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (coso != null)
                {
                    coso.Close();
                }
            }

            return result;
        }
    }
}
