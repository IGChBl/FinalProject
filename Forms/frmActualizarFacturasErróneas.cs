using Proyecto.Forms;
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

namespace Proyecto
{
    public partial class frmActualizarEliminarFacturaErronea : Form
    {

        public frmActualizarEliminarFacturaErronea()
        {
            InitializeComponent();
        }


        private void ActualizarEliminarFacturaErronea_Load(object sender, EventArgs e)
        {
            dgvFacturas.ColumnCount = 4;
            dgvFacturas.Columns[0].Name = "Numero";
            dgvFacturas.Columns[1].Name = "Cliente";
            dgvFacturas.Columns[2].Name = "Fecha";
            dgvFacturas.Columns[3].Name = "Total";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string criterioBusqueda = txtBuscar.Text.Trim();

            // Validar que el criterio no esté vacío
            if (string.IsNullOrEmpty(criterioBusqueda))
            {
                MessageBox.Show("Por favor, ingrese un número de factura o nombre de cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cargar las facturas desde el archivo JSON
            var facturas = FacturaStorage.CargarFacturas();

            // Depuración: verificar cuántas facturas se cargaron
            MessageBox.Show($"Número de Facturas Cargadas: {facturas.Count}", "Depuración");

            // Filtrar las facturas que coincidan con el criterio de búsqueda
            var facturasFiltradas = facturas.Where(f =>
                f.Numero.ToLower().Contains(criterioBusqueda.ToLower()) ||
                f.Cliente.ToLower().Contains(criterioBusqueda.ToLower())).ToList();

            // Depuración: verificar cuántas facturas se encontraron
            MessageBox.Show($"Número de Facturas Encontradas: {facturasFiltradas.Count}", "Depuración");

            // Mostrar los resultados en el DataGridView
            dgvFacturas.Rows.Clear();
            if (facturasFiltradas.Count > 0)
            {
                foreach (var factura in facturasFiltradas)
                {
                    dgvFacturas.Rows.Add(factura.Numero, factura.Cliente, factura.Fecha.ToShortDateString(), factura.Total.ToString("C"));
                }
            }
            else
            {
                MessageBox.Show("No se encontraron facturas con el criterio de búsqueda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count > 0)
            {
                // Extraer datos de la fila seleccionada
                string cliente = dgvFacturas.SelectedRows[0].Cells["Cliente"].Value.ToString();
                string numeroFactura = dgvFacturas.SelectedRows[0].Cells["Numero"].Value.ToString();
                DateTime fecha = DateTime.Parse(dgvFacturas.SelectedRows[0].Cells["Fecha"].Value.ToString());
                string total = dgvFacturas.SelectedRows[0].Cells["Total"].Value.ToString();

                // Crear una lista con los datos seleccionados para pasar al segundo DataGridView
                List<string[]> datosFactura = new List<string[]>
        {
            new string[] { numeroFactura, cliente, fecha.ToShortDateString(), total }
        };

                // Crear una instancia del segundo formulario
                frmActualizaDatosFactura frmActualizar = new frmActualizaDatosFactura
                {
                    NombreCliente = cliente, // Pasar el nombre del cliente
                    DatosFactura = datosFactura // Pasar los datos de la factura
                };

                // Mostrar el segundo formulario
                frmActualizar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una factura para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
