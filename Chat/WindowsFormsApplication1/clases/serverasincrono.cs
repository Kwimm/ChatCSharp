using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace WindowsFormsApplication1.clases
{
    /// <summary>
    /// El objetivo final es que tengamos una comunicación permanente con el servidor y que esté analizando si llegan mensajes para el usuario
    /// </summary>
    public class serverasincrono
    {
        static includes.CLog log = new includes.CLog();
        // Numero de puerto en el que está trabajando el servidor
        //private const int port = 12;
        // ManualResetEvent instancias. Señal de completado.
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);
        // La respuesta del servidor remoto.
        public static String response = String.Empty;


        /// <summary>
        /// Esta función es la encargada de mantener funcionando un socket asíncrono
        /// </summary>
        public static void getMessage(string mensaje,string usuario,int port)
        {
            // Intento de conexión a servidor.
            try
            {
                //Indicamos punto remoto para el socket, esto es, dirección del servidor
                IPHostEntry ipHostInfo = Dns.Resolve("localhost");
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Creamos un TCP/IP socket.
                Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Conecta a servidor.
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();

                // Enviamos 
                Send(client, usuario + " ha escrito: "+ mensaje + "<EOF>");
                sendDone.WaitOne();

                // Recibimos la respuesta.
                Receive(client);
                receiveDone.WaitOne();

                // Write the response to the console.
                log.EscribirEnLog(String.Format(response));

                envio devuelveContestacion = new envio();
                //devuelveContestacion.guardaRespuesta(response);
                envio.guardaRespuesta(response);

                // Apaga socket.
                //client.Shutdown(SocketShutdown.Both);
                //client.Close();

            }
            catch (Exception e)
            {
                log.EscribirEnLog("Error getmessage: "+e.ToString());
            }
        }
        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Recoge el socket desde stateobject.
                Socket client = (Socket)ar.AsyncState;

                // Completa la conexión.
                client.EndConnect(ar);
                string informacionCallback = String.Format("Socket conectado a {0}", client.RemoteEndPoint.ToString());
                log.EscribirEnLog(informacionCallback);
                // Señal de que la conexión ha sido hecha.
                connectDone.Set();
            }
            catch (Exception e)
            {
                log.EscribirEnLog("Error ConnectCallback: "+e.ToString());
            }
        }

        public static void Receive(Socket client)
        {
            try
            {
                // Crea stateobject.
                StateObject state = new StateObject();
                state.workSocket = client;

                // Empezamos a recibir datos desde el servidor.
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                log.EscribirEnLog("Error receive: "+e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // recibimos stateobject e o socket cliente
                // desde o stateobject asíncrono.
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Leemos datos desde el servidor.
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // Pode haber máis datos, así que gardamos todo.
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    // Trae o resto.
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // Todo recibido,pono en response.
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    // Señal de que se recibiu todo.
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                log.EscribirEnLog("Error en ReceiveCallback: "+e.ToString());
            }
        }

        public static void Send(Socket client, String data)
        {
            // Convirte string a byte usando codificación ASCII.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Empezamos a enviar datos a servidor.
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Recibir socket desde stateobject.
                Socket client = (Socket)ar.AsyncState;

                // Completamos enviando datos a servidor
                int bytesSent = client.EndSend(ar);
                // Señal de todo enviado
                sendDone.Set();
            }
            catch (Exception e)
            {
                log.EscribirEnLog("Error en sendcallback: "+e.ToString());
            }
        }

        /// <summary>
        /// Esta función lanzará un socket asíncrono con la finalidad de recibir-enviar mensajes, es decir, abriremos un canal que permanecerá a la espera de recibir algo
        /// desde el servidor sin detener la ejecución principal y que además nos permitirá enviar también desde el mismo punto
        /// </summary>
        public static void EnviarMensaje(string mensaje,string usuario,int port)
        {
            try
            {
                getMessage(mensaje,usuario,port);
            }
            catch (Exception e)
            {
                log.EscribirEnLog("Error en el primer paso de creación de socket asíncrono: " + e.Message);
            }
        }
    }

    // Definiciones de lo que recibimos desde remoto.
    public class StateObject
    {
        // Cliente socket.
        public Socket workSocket = null;
        // Tamaño del buffer recibido.
        public const int BufferSize = 256;
        // Buffer recibido.
        public byte[] buffer = new byte[BufferSize];
        // Recibido en string.
        public StringBuilder sb = new StringBuilder();
    }
}
