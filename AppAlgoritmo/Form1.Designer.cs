namespace AppAlgoritmo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnOrdenar = new System.Windows.Forms.Button();
            this.btnJump = new System.Windows.Forms.Button();
            this.btnInterpolada = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstOrdenada = new System.Windows.Forms.ListView();
            this.lstDatos = new System.Windows.Forms.ListView();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblFin = new System.Windows.Forms.Label();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cantidad de Registros:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(218, 23);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(188, 22);
            this.txtCantidad.TabIndex = 1;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(71, 66);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(151, 48);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            // Suscripción del evento Click al manejador existente:
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnOrdenar
            // 
            this.btnOrdenar.Location = new System.Drawing.Point(235, 66);
            this.btnOrdenar.Name = "btnOrdenar";
            this.btnOrdenar.Size = new System.Drawing.Size(157, 48);
            this.btnOrdenar.TabIndex = 3;
            this.btnOrdenar.Text = "Ordenar";
            this.btnOrdenar.UseVisualStyleBackColor = true;
            this.btnOrdenar.Click += new System.EventHandler(this.btnOrdenar_Click);
            // 
            // btnJump
            // 
            this.btnJump.Location = new System.Drawing.Point(71, 130);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(151, 48);
            this.btnJump.TabIndex = 4;
            this.btnJump.Text = "Busqueda Jump";
            this.btnJump.UseVisualStyleBackColor = true;
            // 
            // btnInterpolada
            // 
            this.btnInterpolada.Location = new System.Drawing.Point(235, 130);
            this.btnInterpolada.Name = "btnInterpolada";
            this.btnInterpolada.Size = new System.Drawing.Size(157, 48);
            this.btnInterpolada.TabIndex = 5;
            this.btnInterpolada.Text = "Busqueda Interpolada";
            this.btnInterpolada.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstOrdenada);
            this.groupBox1.Controls.Add(this.lstDatos);
            this.groupBox1.Location = new System.Drawing.Point(56, 205);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 205);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registros: 0";
            // 
            // lstOrdenada
            // 
            this.lstOrdenada.HideSelection = false;
            this.lstOrdenada.Location = new System.Drawing.Point(179, 21);
            this.lstOrdenada.Name = "lstOrdenada";
            this.lstOrdenada.Size = new System.Drawing.Size(157, 168);
            this.lstOrdenada.TabIndex = 1;
            this.lstOrdenada.UseCompatibleStateImageBehavior = false;
            // 
            // lstDatos
            // 
            this.lstDatos.HideSelection = false;
            this.lstDatos.Location = new System.Drawing.Point(15, 22);
            this.lstDatos.Name = "lstDatos";
            this.lstDatos.Size = new System.Drawing.Size(151, 168);
            this.lstDatos.TabIndex = 0;
            this.lstDatos.UseCompatibleStateImageBehavior = false;
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(53, 450);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(161, 16);
            this.lblInicio.TabIndex = 7;
            this.lblInicio.Text = "Tiempo de Inicio: 00.00.00";
            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.Location = new System.Drawing.Point(53, 487);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(129, 16);
            this.lblFin.TabIndex = 8;
            this.lblFin.Text = "Tiempo Fin: 00.00.00";
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(53, 524);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(139, 16);
            this.lblDuracion.TabIndex = 9;
            this.lblDuracion.Text = "Duracion: 0 Segundos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 563);
            this.Controls.Add(this.lblDuracion);
            this.Controls.Add(this.lblFin);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnInterpolada);
            this.Controls.Add(this.btnJump);
            this.Controls.Add(this.btnOrdenar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Analisis de Ordenamiento y Busqueda";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnOrdenar;
        private System.Windows.Forms.Button btnJump;
        private System.Windows.Forms.Button btnInterpolada;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstOrdenada;
        private System.Windows.Forms.ListView lstDatos;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.Label lblDuracion;
    }
}

