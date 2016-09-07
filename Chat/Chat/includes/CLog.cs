using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApplication1.includes
{
    //Clase destinada a manejar todas las peticiones de escritura a fichero .log
    public class CLog
    {
        private string fichero;
        private string extension;
        private bool ponFechaHora;
        private string nombreFicheroFecha;
        private string formatoFecha; //define el formato que va a llevar la fecha, puede incluir caracters por delante detras o por el medio


        /// <summary>
        /// Funcion que escribe en fichero de log
        /// </summary>
        /// <param name="linea">Linea a escribir</param>
        /// <returns>Devuelve false/true para indicarnos si la escritura a log ha finalizado correctamente</returns>
        public bool EscribirEnLog(String linea)
        {
            lock (this)
            {
                StreamWriter fichLog = null;
                try
                {
                    //if (fichero == null) return true;

                    string sufijo = String.Format("{0:yyyyMMdd}", DateTime.Now);

                    nombreFicheroFecha = fichero + "_" + sufijo + extension;

                    if (ponFechaHora == true)
                    {
                        string prefijo = String.Format(formatoFecha, DateTime.Now);
                        linea = prefijo + " " + linea;
                    }

                    fichLog = new StreamWriter(nombreFicheroFecha, true, System.Text.ASCIIEncoding.Default);

                    /* if (!linea.Substring(linea.Length - 2).Equals(Environment.NewLine))
                     {
                         linea = linea + Environment.NewLine;
                     }*/

                    fichLog.WriteLine(linea);
                    fichLog.Close();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
