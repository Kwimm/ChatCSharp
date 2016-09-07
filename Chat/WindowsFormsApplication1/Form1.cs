using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApplication1.includes;
using WindowsFormsApplication1.clases;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        includes.CLog log = new includes.CLog();
        static clases.envio envios = new clases.envio();
        static clases.serverasincrono servidor = new clases.serverasincrono();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Función del botón de envío. Envía datos a clase envio para su manejo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (campoNombreUsuario.Text != "" && textBoxDestinatario.Text != "")
                {
                    string mensaje = textBoxEnvio.Text;
                    clases.envio.EnvioMensaje(mensaje, textBoxDestinatario.Text,campoNombreUsuario.Text, Int32.Parse(puertoContacto.Text));
                    textBoxConversacion.Text = envio.getRespuesta();
                }
                else
                {
                    MessageBox.Show("Introduzca nombre de usuario y destinatario antes de enviar.");
                }
            }
            catch(Exception error)
            {
                log.EscribirEnLog(error.Message);
            }
        }

        /// <summary>
        /// Ejecución de este código en la carga del programa. Lo que hacemos es cargar posibles usuarios y destinatarios.
        /// Para el caso de pruebas, ambos salen de la misma tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //Conectamos a base para sacar datos de destinatarios
                includes.CBD conexion = new includes.CBD();
                conexion.conectar();    //Cargamos conexión

                string destinatarios = "";
                destinatarios = conexion.obtenerDestinatarios(); //Obtenemos posibles destinatarios

                string[] destinatariosArray = destinatarios.Split(',');

                foreach (string i in destinatariosArray) //Cargamos destinatarios
                {
                    textBoxDestinatario.Items.Add(i);
                }

                //Para pruebas usamos la función de destinatarios para obtener también remitentes
                foreach (string i in destinatariosArray) //Cargamos destinatarios
                {
                    campoNombreUsuario.Items.Add(i);
                }
            }
            catch (Exception error)
            {
                log.EscribirEnLog(error.Message);
            }
        }

        private void conectarServidor_Click(object sender, EventArgs e)
        {
            int puertoUser;
            puertoUser = Int32.Parse(puertoUsuario.Text);

            //Antes de empezar a enviar, debemos abrirle un servicio server en el puerto que ha indicado el usuario
            clases.serverprincipal.CreateListener.lanzarHiloServidor(puertoUser);
        }

        public void setText(string content)
        { 
            textBoxConversacion.Text = content;
        }
    }
}
