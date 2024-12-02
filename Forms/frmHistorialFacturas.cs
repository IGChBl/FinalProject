using Proyecto.Models;
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

namespace Proyecto
{
    public partial class frmHistorialFacturas : Form
    {
        public frmHistorialFacturas()
        {
            InitializeComponent();
        }
        private void frmHistorialFacturas_Load(object sender, EventArgs e)
        {
            // Configurar las columnas del DataGridView si no están configuradas
            if (dgvFacturas.Columns.Count == 0)
            {
                dgvFacturas.AutoGenerateColumns = false;

                // Número de Factura
                DataGridViewTextBoxColumn numeroColumna = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Numero",
                    HeaderText = "Número de Factura"
                };
                dgvFacturas.Columns.Add(numeroColumna);

                // Cliente
                DataGridViewTextBoxColumn clienteColumna = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Cliente",
                    HeaderText = "Cliente"
                };
                dgvFacturas.Columns.Add(clienteColumna);

                // Total
                DataGridViewTextBoxColumn totalColumna = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Total",
                    HeaderText = "Total ($)"
                };
                dgvFacturas.Columns.Add(totalColumna);

                // Fecha
                DataGridViewTextBoxColumn fechaColumna = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Fecha",
                    HeaderText = "Fecha"
                };
                dgvFacturas.Columns.Add(fechaColumna);

                // Cargar las facturas existentes
                dgvFacturas.DataSource = null;
                dgvFacturas.DataSource = FacturaStorage.CargarFacturas();
            }
        }
        private void CargarFacturas()
        {
            // Cargar las facturas desde el archivo JSON
            var facturas = FacturaStorage.CargarFacturas();

            // Configurar el DataGridView para mostrar las facturas
            dgvFacturas.DataSource = null; // Limpiar el DataGridView
            dgvFacturas.DataSource = facturas;
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            var facturaSeleccionada = dgvFacturas.CurrentRow?.DataBoundItem as Factura;

            if (facturaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una factura para ver los detalles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear contenido del archivo .txt
            StringBuilder detalles = new StringBuilder();
            detalles.AppendLine($"Factura: {facturaSeleccionada.Numero}");
            detalles.AppendLine($"Cliente: {facturaSeleccionada.Cliente}");
            detalles.AppendLine($"Fecha: {facturaSeleccionada.Fecha:dd/MM/yyyy}");
            detalles.AppendLine("\nServicios:");
            foreach (var servicio in facturaSeleccionada.Servicios)
            {
                detalles.AppendLine($"- {servicio.Nombre}: ${servicio.Precio}");
            }
            detalles.AppendLine($"\nTotal: ${facturaSeleccionada.Total}");

            // Guardar archivo
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Factura_{facturaSeleccionada.Numero}.txt");
            File.WriteAllText(rutaArchivo, detalles.ToString());

            // Mostrar mensaje y abrir el archivo
            MessageBox.Show($"Detalles guardados en: {rutaArchivo}", "Factura Detallada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start("notepad.exe", rutaArchivo);
        }

        private void btnElimiarFactura_Click(object sender, EventArgs e)
        {
            // Obtener la factura seleccionada
            var facturaSeleccionada = dgvFacturas.CurrentRow?.DataBoundItem as Factura;

            if (facturaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una factura para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirmar eliminación
            var confirmResult = MessageBox.Show(
                $"¿Está seguro de eliminar la factura {facturaSeleccionada.Numero}?",
                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Eliminar la factura del archivo JSON
                FacturaStorage.EliminarFactura(facturaSeleccionada.Numero);

                // Actualizar el DataGridView
                dgvFacturas.DataSource = null;
                dgvFacturas.DataSource = FacturaStorage.CargarFacturas();

                MessageBox.Show("Factura eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
