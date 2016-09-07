using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.clases
{
    /// <summary>
    /// La función de esta clase es abrir un servidor en el puerto indicado por el usuario
    /// </summary>
    class serverprincipal
    {
        // State object para leer datos desde cliente asincronicamente
        public class StateObject
        {
            // Socket.
            public Socket workSocket = null;
            // Tamaño de buffer a recibir
            public const int BufferSize = 1024;
            // Buffer recibido.
            public byte[] buffer = new byte[BufferSize];
            // Recibido en string
            public StringBuilder sb = new StringBuilder();
        }

        public class CreateListener
        {
            /// <summary>
            /// Arranca el servidor en localhost y permanece en ejecución para manejar los distintos envíos de clientes.
            /// </summary>
            /// <returns> Al final de su ejecución devuelve el último estado registrado, en caso de fallo devuelve motivo</returns>
            /// 
            static includes.CLog log = new includes.CLog();

            private static System.Threading.Thread hiloServidor;
            // Thread señal.
            public static ManualResetEvent allDone = new ManualResetEvent(false);

            public CreateListener()
            {
            }

            public static void StartListener(int puerto)
            {
                // Buffer para datos entrantes.
                byte[] bytes = new Byte[1024];

                // Establecemos dirección local del socket.
                // 
                // 
                IPHostEntry ipHostInfo = Dns.Resolve("localhost");
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, puerto);

                // Creamos un TCP/IP socket.
                Socket listener = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Enlazar el socket a la dirección especificada antes (localEndPoint) y escuchar por conexiones entrantes.
                try
                {
                    listener.Bind(localEndPoint);
                    listener.Listen(100);

                    while (true)
                    {
                        // Set el evento a nonsignaled state.
                        allDone.Reset();

                        // IMPORTANTE: AQUÍ ES DONDE LANZAMOS EL SOCKET DE FORMA ASÍNCRONA A LA ESPERA DE RECIBIR CONEXIONES ENTRANTES.
                        log.EscribirEnLog(String.Format("El servidor está esperando conexiones en el puerto {0}",puerto));
                        listener.BeginAccept(
                            new AsyncCallback(AcceptCallback),
                            listener);

                        // Esperar hasta que una conexión sea hecha antes de continuar.
                        allDone.WaitOne();
                        Form1 interfazGrafica = new Form1();
                        interfazGrafica.setText("Hemos recibido algo en WaitOne()");
                    }

                }
                catch (Exception e)
                {
                    log.EscribirEnLog("Error al intentar enlazar el socket a la dirección: " + e.ToString());
                }

                //Console.WriteLine("\nPress ENTER to continue...");
                //Console.Read();
            }

            public static void AcceptCallback(IAsyncResult ar)
            {
                // Señal a main para que continúe.
                allDone.Set();

                // Socket que maneja peticiones
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);

                // Creamos state object.
                StateObject state = new StateObject();
                state.workSocket = handler;
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
            }

            public static void ReadCallback(IAsyncResult ar)
            {
                String content = String.Empty;

                // Recibir state object y el handler socket
                // desde el state object asíncrono
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;

                // Leemos datos del socket cliente. 
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // Puede haber más datos....
                    state.sb.Append(Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead));

                    // Comprobar por señal de final de datos, sino seguimos leyendo 
                    content = state.sb.ToString();
                    if (content.IndexOf("<EOF>") > -1)
                    {
                        // Todos los datos han sido leídos 
                        // Guardalos en log
                        //log.EscribirEnLog(content);
                        // IMPORTANTE: ENVÍA DATA DE VUELTA AL CLIENTE.
                        Send(handler, content);
                        Form1 interfazGrafica = new Form1();
                        interfazGrafica.setText(content);
                    }
                    else
                    {
                        // No se ha recibido todo, trae más
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReadCallback), state);
                    }
                }
            }

            private static void Send(Socket handler, String data)
            {
                // Convierte el string a byte usando codificación ASCII.
                byte[] byteData = Encoding.ASCII.GetBytes(data);

                // Empieza a enviar datos al servidor
                handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
            }

            private static void SendCallback(IAsyncResult ar)
            {
                try
                {
                    // Trae socket desde state object.
                    Socket handler = (Socket)ar.AsyncState;

                    // Completa enviando datos.
                    int bytesSent = handler.EndSend(ar);
                    log.EscribirEnLog(String.Format("Enviados {0} bytes al cliente", bytesSent));

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();

                }
                catch (Exception e)
                {
                    log.EscribirEnLog("Error en SendCallback: " + e.ToString());
                }
            }


            public static void lanzarHiloServidor(int puerto)
            {
                includes.CLog log = new includes.CLog();
                try
                {
                   hiloServidor = new Thread(() => StartListener(puerto));
                   hiloServidor.Start();
                    
                    while (!hiloServidor.IsAlive)
                    {
                        log.EscribirEnLog("No arranco el servidor (StartListener()),reintentamos");
                        System.Threading.Thread.Sleep(5000);
                    }
                    //log.EscribirEnLog("Servidor arrancado");
                }
                catch (Exception e)
                {
                    log.EscribirEnLog("Error lanzando servidor (lanzarHiloServidor)" + e.Message);
                }
            }
        }
    }
}
