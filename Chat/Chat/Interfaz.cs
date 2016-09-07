using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.includes;
using WindowsFormsApplication1.clases;

namespace Chat
{
    public partial class Interfaz : Form
    {
        static string textoPantalla;
        public Interfaz()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Botón para arrancar el servicio servidor. Envía petición de este inicio a la clase 'server' para arrancar dicho servicio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //ConfiguracionINI ini = new ConfiguracionINI();
            //ini.getValorParametro(); //Cargamos en variables los datos necesarios para conexion (ip y puerto)
            CLog log = new CLog();
            try
            {
                WindowsFormsApplication1.clases.Chat.clases.CreateListener servidor = new WindowsFormsApplication1.clases.Chat.clases.CreateListener();
                servidor.lanzarHiloServidor();
            }
            catch(Exception error)
            {
                log.EscribirEnLog(error.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1_Click(sender,e);
        }

        public void setText(string content)
        {
            this.textBoxMensajes.Text = content;
        }
    }
}
