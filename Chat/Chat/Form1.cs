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

namespace Chat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfiguracionINI ini = new ConfiguracionINI();
            ini.getValorParametro(); //Cargamos en variables los datos necesarios para conexion (ip y puerto)
           
            //clases.CreateListener.StartListener();
            //textBoxErrores.Text = clases.CreateListener.StartListener();       
        }
    }
}
