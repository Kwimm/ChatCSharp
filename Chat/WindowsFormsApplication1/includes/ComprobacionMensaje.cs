using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.includes
{
    /*
     * Clase destinadada a comprobar para quien es el mensaje que llega y en caso de que sea para el usuario actual, mostrarlo
     */
    /// <summary>
    /// Clase destinadada a comprobar para quien es el mensaje que llega y en caso de que sea para el usuario actual, mostrarlo
    /// </summary>
    public class ComprobacionMensaje
    {
        /// <summary>
        /// Funcion que compara dos usuarios, actual del cliente y para quien es el mensaje. De esta forma sabemos si tenemos que montar el mensaje en pantalla
        /// </summary>
        /// <param name="usuarioMensaje">Usuario para el cual va destinado el mensaje</param>
        /// <returns>Si el usuario es el mismo: true, de lo contrario: false</returns>
        public bool VerificaMensaje(string usuarioMensaje,string miUsuario)
        {
            if(usuarioMensaje == miUsuario)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
