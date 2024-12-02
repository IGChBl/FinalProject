using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.Forms
{
    public partial class frmActualizaDatosFactura : Form
    {
        public frmActualizaDatosFactura()
        {
            InitializeComponent();
           

        }
        // Agregar una propiedad pública para recibir el nombre del cliente
        public string NombreCliente
        {
            set
            {
                txtCliente.Text = value; // txtCliente debe ser el TextBox donde se muestra el nombre del cliente
            }
        }
        public List<string[]> DatosFactura { get; set; } // Listado de datos de la factura
        private void frmActualizaDatosFactura_Load(object sender, EventArgs e)
        {
            if (DatosFactura != null && DatosFactura.Count > 0)
            {
                // Configurar columnas del DataGridView
                dgvFecha.ColumnCount = 4;
                dgvFecha.Columns[0].Name = "Numero";
                dgvFecha.Columns[1].Name = "Cliente";
                dgvFecha.Columns[2].Name = "Fecha";
                dgvFecha.Columns[3].Name = "Total";
                dgvFecha.Rows.Clear(); // Limpia cualquier fila existente
                foreach (var fila in DatosFactura)
                {
                    dgvFecha.Rows.Add(fila); // Agrega cada fila recibida
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que la fecha seleccionada no esté vacía
            DateTime nuevaFecha = dtpFecha.Value;

            // Cargar las facturas desde el almacenamiento
            var facturas = FacturaStorage.CargarFacturas();

            // Buscar la factura seleccionada por su número
            var factura = facturas.FirstOrDefault(f => f.Numero == DatosFactura[0][0]); // `DatosFactura[0][0]` contiene el número de la factura

            if (factura != null)
            {
                // Actualizar la fecha de la factura
                factura.Fecha = nuevaFecha;

                // Guardar las facturas actualizadas en el sistema
                FacturaStorage.GuardarFacturas(facturas);

                // Mostrar mensaje de confirmación
                MessageBox.Show("La fecha de la factura ha sido actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cerrar el formulario actual
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo encontrar la factura para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
