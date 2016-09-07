namespace Chat
{
    partial class Interfaz
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
            this.iniciaServidorButton = new System.Windows.Forms.Button();
            this.textBoxMensajes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxErrores = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // iniciaServidorButton
            // 
            this.iniciaServidorButton.Location = new System.Drawing.Point(12, 288);
            this.iniciaServidorButton.Name = "iniciaServidorButton";
            this.iniciaServidorButton.Size = new System.Drawing.Size(120, 37);
            this.iniciaServidorButton.TabIndex = 0;
            this.iniciaServidorButton.Text = "Iniciar Servidor";
            this.iniciaServidorButton.UseVisualStyleBackColor = true;
            this.iniciaServidorButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxMensajes
            // 
            this.textBoxMensajes.Location = new System.Drawing.Point(12, 53);
            this.textBoxMensajes.Multiline = true;
            this.textBoxMensajes.Name = "textBoxMensajes";
            this.textBoxMensajes.Size = new System.Drawing.Size(439, 229);
            this.textBoxMensajes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mensaje:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(454, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Información";
            // 
            // textBoxErrores
            // 
            this.textBoxErrores.Location = new System.Drawing.Point(457, 55);
            this.textBoxErrores.Multiline = true;
            this.textBoxErrores.Name = "textBoxErrores";
            this.textBoxErrores.Size = new System.Drawing.Size(132, 122);
            this.textBoxErrores.TabIndex = 4;
            // 
            // Interfaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 337);
            this.Controls.Add(this.textBoxErrores);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMensajes);
            this.Controls.Add(this.iniciaServidorButton);
            this.Name = "Interfaz";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button iniciaServidorButton;
        private System.Windows.Forms.TextBox textBoxMensajes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxErrores;
    }
}

