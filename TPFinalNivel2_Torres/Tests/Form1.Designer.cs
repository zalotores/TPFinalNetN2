namespace Tests
{
    partial class formTest
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
            this.btnTestDDBB = new System.Windows.Forms.Button();
            this.lblConectado = new System.Windows.Forms.Label();
            this.lblConectadoResultado = new System.Windows.Forms.Label();
            this.lblDesconectado = new System.Windows.Forms.Label();
            this.lblDesconectadoResultado = new System.Windows.Forms.Label();
            this.groupBoxTestDDBB = new System.Windows.Forms.GroupBox();
            this.groupBoxTestDDBB.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTestDDBB
            // 
            this.btnTestDDBB.Location = new System.Drawing.Point(6, 19);
            this.btnTestDDBB.Name = "btnTestDDBB";
            this.btnTestDDBB.Size = new System.Drawing.Size(75, 63);
            this.btnTestDDBB.TabIndex = 0;
            this.btnTestDDBB.Text = "Test";
            this.btnTestDDBB.UseVisualStyleBackColor = true;
            this.btnTestDDBB.Click += new System.EventHandler(this.btnTestDDBB_Click);
            // 
            // lblConectado
            // 
            this.lblConectado.AutoSize = true;
            this.lblConectado.Location = new System.Drawing.Point(87, 28);
            this.lblConectado.Name = "lblConectado";
            this.lblConectado.Size = new System.Drawing.Size(50, 13);
            this.lblConectado.TabIndex = 1;
            this.lblConectado.Text = "Conectar";
            // 
            // lblConectadoResultado
            // 
            this.lblConectadoResultado.AutoSize = true;
            this.lblConectadoResultado.Location = new System.Drawing.Point(161, 28);
            this.lblConectadoResultado.Name = "lblConectadoResultado";
            this.lblConectadoResultado.Size = new System.Drawing.Size(0, 13);
            this.lblConectadoResultado.TabIndex = 2;
            // 
            // lblDesconectado
            // 
            this.lblDesconectado.AutoSize = true;
            this.lblDesconectado.Location = new System.Drawing.Point(87, 59);
            this.lblDesconectado.Name = "lblDesconectado";
            this.lblDesconectado.Size = new System.Drawing.Size(68, 13);
            this.lblDesconectado.TabIndex = 3;
            this.lblDesconectado.Text = "Desconectar";
            // 
            // lblDesconectadoResultado
            // 
            this.lblDesconectadoResultado.AutoSize = true;
            this.lblDesconectadoResultado.Location = new System.Drawing.Point(161, 59);
            this.lblDesconectadoResultado.Name = "lblDesconectadoResultado";
            this.lblDesconectadoResultado.Size = new System.Drawing.Size(0, 13);
            this.lblDesconectadoResultado.TabIndex = 4;
            // 
            // groupBoxTestDDBB
            // 
            this.groupBoxTestDDBB.Controls.Add(this.btnTestDDBB);
            this.groupBoxTestDDBB.Controls.Add(this.lblDesconectadoResultado);
            this.groupBoxTestDDBB.Controls.Add(this.lblConectado);
            this.groupBoxTestDDBB.Controls.Add(this.lblDesconectado);
            this.groupBoxTestDDBB.Controls.Add(this.lblConectadoResultado);
            this.groupBoxTestDDBB.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTestDDBB.Name = "groupBoxTestDDBB";
            this.groupBoxTestDDBB.Size = new System.Drawing.Size(200, 100);
            this.groupBoxTestDDBB.TabIndex = 5;
            this.groupBoxTestDDBB.TabStop = false;
            this.groupBoxTestDDBB.Text = "Conexion a DDBB";
            // 
            // formTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxTestDDBB);
            this.Name = "formTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pruebas";
            this.groupBoxTestDDBB.ResumeLayout(false);
            this.groupBoxTestDDBB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestDDBB;
        private System.Windows.Forms.Label lblConectado;
        private System.Windows.Forms.Label lblConectadoResultado;
        private System.Windows.Forms.Label lblDesconectado;
        private System.Windows.Forms.Label lblDesconectadoResultado;
        private System.Windows.Forms.GroupBox groupBoxTestDDBB;
    }
}

