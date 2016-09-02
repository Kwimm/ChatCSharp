using System;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using System.Text;
using WindowsFormsApplication1.includes;

namespace Chat.clases
{
    public class CreateListener : ConfiguracionINI
    {
        public static string StartListener()
        {
            string output = "";

            //Create Listener
            TcpListener Listener = null;
            IPAddress LocalIp = Dns.GetHostEntry(servidor).AddressList[0];
            try
            {
                //Set the listener on the localhost and specify a port
                Listener = new TcpListener(LocalIp, puerto);
                Listener.Start();
                output = "Esperando conexiones...";
                
            }
            catch (Exception e)
            {
                output = "Error: " + e.ToString();
            }

            byte[] rcvBuffer = new byte[256]; 
            int bytesRcvd; 
            for (;;)
            { //   
                TcpClient client = null;
                NetworkStream netStream = null;
                //Console.WriteLine(IPAddress.None);

                try
                {
                    client = Listener.AcceptTcpClient(); // Get client connection
                    netStream = client.GetStream();
                    Console.Write("Manejando Cliente - ");

                    // Receive until client closes connection, indicated by 0 return value
                    int totalBytesEchoed = 0;
                    while ((bytesRcvd = netStream.Read(rcvBuffer, 0, rcvBuffer.Length)) > 0)
                    {
                        netStream.Write(rcvBuffer, 0, bytesRcvd);
                        totalBytesEchoed += bytesRcvd;
                    }
                    string szReceived = Encoding.ASCII.GetString(rcvBuffer);

                    //Console.WriteLine("Mensaje recibido." + szReceived);

                    // Close the stream and socket. We are done with this client!
                    netStream.Close();
                    client.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    netStream.Close();
                }
            }

            Listener.Stop();
            return output;
        }

    }
}
