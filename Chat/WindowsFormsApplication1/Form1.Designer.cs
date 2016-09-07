namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxEnvio = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDestinatario = new System.Windows.Forms.ComboBox();
            this.campoNombreUsuario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxConversacion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.puertoUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.puertoContacto = new System.Windows.Forms.TextBox();
            this.conectarServidor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxEnvio
            // 
            this.textBoxEnvio.Location = new System.Drawing.Point(12, 166);
            this.textBoxEnvio.Multiline = true;
            this.textBoxEnvio.Name = "textBoxEnvio";
            this.textBoxEnvio.Size = new System.Drawing.Size(260, 54);
            this.textBoxEnvio.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(260, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Destinatario";
            // 
            // textBoxDestinatario
            // 
            this.textBoxDestinatario.FormattingEnabled = true;
            this.textBoxDestinatario.Location = new System.Drawing.Point(103, 41);
            this.textBoxDestinatario.Name = "textBoxDestinatario";
            this.textBoxDestinatario.Size = new System.Drawing.Size(169, 21);
            this.textBoxDestinatario.TabIndex = 6;
            // 
            // campoNombreUsuario
            // 
            this.campoNombreUsuario.FormattingEnabled = true;
            this.campoNombreUsuario.Location = new System.Drawing.Point(103, 14);
            this.campoNombreUsuario.Name = "campoNombreUsuario";
            this.campoNombreUsuario.Size = new System.Drawing.Size(169, 21);
            this.campoNombreUsuario.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mensaje:";
            // 
            // textBoxConversacion
            // 
            this.textBoxConversacion.Enabled = false;
            this.textBoxConversacion.Location = new System.Drawing.Point(12, 277);
            this.textBoxConversacion.Multiline = true;
            this.textBoxConversacion.Name = "textBoxConversacion";
            this.textBoxConversacion.Size = new System.Drawing.Size(260, 286);
            this.textBoxConversacion.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Conversación:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Puerto Contacto";
            // 
            // puertoUsuario
            // 
            this.puertoUsuario.Location = new System.Drawing.Point(103, 68);
            this.puertoUsuario.Name = "puertoUsuario";
            this.puertoUsuario.Size = new System.Drawing.Size(169, 20);
            this.puertoUsuario.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Puerto Servidor";
            // 
            // puertoContacto
            // 
            this.puertoContacto.Enabled = false;
            this.puertoContacto.Location = new System.Drawing.Point(103, 94);
            this.puertoContacto.Name = "puertoContacto";
            this.puertoContacto.Size = new System.Drawing.Size(169, 20);
            this.puertoContacto.TabIndex = 14;
            this.puertoContacto.Text = "12";
            // 
            // conectarServidor
            // 
            this.conectarServidor.Location = new System.Drawing.Point(15, 124);
            this.conectarServidor.Name = "conectarServidor";
            this.conectarServidor.Size = new System.Drawing.Size(257, 23);
            this.conectarServidor.TabIndex = 15;
            this.conectarServidor.Text = "Conectar";
            this.conectarServidor.UseVisualStyleBackColor = true;
            this.conectarServidor.Click += new System.EventHandler(this.conectarServidor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 575);
            this.Controls.Add(this.conectarServidor);
            this.Controls.Add(this.puertoContacto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.puertoUsuario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxConversacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.campoNombreUsuario);
            this.Controls.Add(this.textBoxDestinatario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxEnvio);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEnvio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox textBoxDestinatario;
        private System.Windows.Forms.ComboBox campoNombreUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxConversacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox puertoUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox puertoContacto;
        private System.Windows.Forms.Button conectarServidor;
    }
}

