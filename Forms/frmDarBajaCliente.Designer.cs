namespace Proyecto
{
    partial class frmDarBajaCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDarBajaCliente));
            this.lblDardeBajaalCliente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.btnDarBaja = new System.Windows.Forms.Button();
            this.tbCliente = new System.Windows.Forms.TextBox();
            this.dgvClienteSeleccionado = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClienteSeleccionado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDardeBajaalCliente
            // 
            this.lblDardeBajaalCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDardeBajaalCliente.AutoSize = true;
            this.lblDardeBajaalCliente.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDardeBajaalCliente.Location = new System.Drawing.Point(360, 27);
            this.lblDardeBajaalCliente.Name = "lblDardeBajaalCliente";
            this.lblDardeBajaalCliente.Size = new System.Drawing.Size(205, 24);
            this.lblDardeBajaalCliente.TabIndex = 0;
            this.lblDardeBajaalCliente.Text = "Dar de baja al cliente";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Buscar por Nombre o Correo";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(462, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = " ¿Está seguro que desea dar de baja a este cliente?";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBuscarCliente.Location = new System.Drawing.Point(225, 181);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(112, 23);
            this.btnBuscarCliente.TabIndex = 3;
            this.btnBuscarCliente.Text = "Buscar cliente";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // btnDarBaja
            // 
            this.btnDarBaja.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDarBaja.Location = new System.Drawing.Point(225, 431);
            this.btnDarBaja.Name = "btnDarBaja";
            this.btnDarBaja.Size = new System.Drawing.Size(100, 23);
            this.btnDarBaja.TabIndex = 4;
            this.btnDarBaja.Text = "Dar de baja";
            this.btnDarBaja.UseVisualStyleBackColor = true;
            this.btnDarBaja.Click += new System.EventHandler(this.btnDarBaja_Click);
            // 
            // tbCliente
            // 
            this.tbCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCliente.Location = new System.Drawing.Point(225, 153);
            this.tbCliente.Name = "tbCliente";
            this.tbCliente.Size = new System.Drawing.Size(428, 22);
            this.tbCliente.TabIndex = 5;
            // 
            // dgvClienteSeleccionado
            // 
            this.dgvClienteSeleccionado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClienteSeleccionado.Location = new System.Drawing.Point(12, 265);
            this.dgvClienteSeleccionado.Name = "dgvClienteSeleccionado";
            this.dgvClienteSeleccionado.RowHeadersWidth = 51;
            this.dgvClienteSeleccionado.RowTemplate.Height = 24;
            this.dgvClienteSeleccionado.Size = new System.Drawing.Size(732, 150);
            this.dgvClienteSeleccionado.TabIndex = 6;
            // 
            // frmDarBajaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 665);
            this.Controls.Add(this.dgvClienteSeleccionado);
            this.Controls.Add(this.tbCliente);
            this.Controls.Add(this.btnDarBaja);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDardeBajaalCliente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDarBajaCliente";
            this.Text = "Dar de Baja a Cliente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DarDeBajaCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClienteSeleccionado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDardeBajaalCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Button btnDarBaja;
        private System.Windows.Forms.TextBox tbCliente;
        private System.Windows.Forms.DataGridView dgvClienteSeleccionado;
    }
}