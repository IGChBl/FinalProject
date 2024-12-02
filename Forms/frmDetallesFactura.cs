using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto.Models;

namespace Proyecto
{
    public partial class frmDetallesFactura : Form
    {
        private Factura factura;
        public frmDetallesFactura(Factura facturaSeleccionada)
        {
            InitializeComponent();
            factura = facturaSeleccionada;
            CargarDetallesFactura();
        }

        private void frmDetallesFactura_Load(object sender, EventArgs e)
        {

        }

        private void CargarDetallesFactura()
        {
            // Asigna los valores de la factura a los controles del formulario
            tbCliente.Text = factura.Cliente;
            tbFecha.Text = factura.Fecha.ToString("dd/MM/yyyy");
            tbNumeroFactura.Text = factura.Numero;
            tbTotal.Text = factura.Total.ToString("C");

            // Configura el DataGridView para mostrar los servicios
            dgvServicios.AutoGenerateColumns = false;
            dgvServicios.Columns.Clear();

            // Columna de Nombre del Servicio
            var nombreColumna = new DataGridViewTextBoxColumn
            {
                HeaderText = "Servicio",
                DataPropertyName = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvServicios.Columns.Add(nombreColumna);

            // Columna de Precio del Servicio
            var precioColumna = new DataGridViewTextBoxColumn
            {
                HeaderText = "Precio",
                DataPropertyName = "Precio",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvServicios.Columns.Add(precioColumna);

            // Establecer los servicios como fuente de datos para el DataGridView
            dgvServicios.DataSource = factura.Servicios;
        }
    }
}
