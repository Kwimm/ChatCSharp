using System;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using System.Text;
using WindowsFormsApplication1.includes;
using System.Linq;

namespace WindowsFormsApplication1.clases
{
    public class envio
    {
        static string respuesta;
        /// <summary>
        /// Función que envía el mensaje al servidor
        /// </summary>
        /// <param name="mensaje">Mensaje a enviar</param>
        /// <param name="usuario">Destinatario</param>
        /// <param name="miUsuario">Usuario que envía el mensaje</param>
        public static void EnvioMensaje(string mensaje,string usuario,string miUsuario,int port)
        {
            CLog log = new CLog(); //Creamos objeto log para posibles escrituras en esta clase
            ComprobacionMensaje comprobar = new ComprobacionMensaje();
            serverasincrono.EnviarMensaje(mensaje,miUsuario,port);
            //serverprincipal.CreateListener.
        }
        
        public static string guardaRespuesta(string respuesta)
        {           
            envio.respuesta = respuesta;
            return respuesta;
        }

        public static string getRespuesta()
        {
            return respuesta;
        }
    }
}
