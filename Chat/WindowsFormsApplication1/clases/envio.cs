using System;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using System.Text;
using WindowsFormsApplication1.includes;

namespace WindowsFormsApplication1.clases
{
    public class envio
    {
        public static void EnvioMensaje(string mensaje)
        {
            try
            {
                //Obtendremos los datos para la conexión desde el fichero .ini
                String server = "localhost"; 
                // Convert input String to bytes
                byte[] byteBuffer = Encoding.ASCII.GetBytes(mensaje); // Encoding.ASCII.GetBytes(args[1]);

                //Indicamos puerto
                int servPort = 12;  

                TcpClient client = null;
                NetworkStream netStream = null;

                try
                {
                    // Create socket that is connected to server on specified port
                    client = new TcpClient(server, servPort);

                    Console.WriteLine("Connected to server... sending echo string");

                    netStream = client.GetStream();

                    // Send the encoded string to the server
                    netStream.Write(byteBuffer, 0, byteBuffer.Length);

                    Console.WriteLine("Sent {0} bytes to server...", byteBuffer.Length);

                    int totalBytesRcvd = 0;
                    int bytesRcvd = 0; 

                    // Receive the same string back from the server
                    while (totalBytesRcvd < byteBuffer.Length)
                    {
                        if ((bytesRcvd = netStream.Read(byteBuffer, totalBytesRcvd,
                        byteBuffer.Length - totalBytesRcvd)) == 0)
                        {
                            Console.WriteLine("Connection closed prematurely.");
                            break;
                        }
                        totalBytesRcvd += bytesRcvd;
                    }
                    Console.WriteLine("Received {0} bytes from server: {1}", totalBytesRcvd,
                    Encoding.ASCII.GetString(byteBuffer, 0, totalBytesRcvd));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (netStream != null)
                        netStream.Close();
                    if (client != null)
                        client.Close();
                }
                Thread.Sleep(1000);

            }
            catch (Exception error)
            {

            }
        } 
    }
}
