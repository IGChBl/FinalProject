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
using static Proyecto.frmHistorialFacturas;
using Proyecto.Forms;

namespace Proyecto
{
    public partial class frmGenerarFactura : Form
    {
        private List<Servicio> servicios = new List<Servicio>
        {
            new Servicio { Nombre = "Internet Básico", Precio = 20.00m },
            new Servicio { Nombre = "Internet Avanzado", Precio = 35.00m },
            new Servicio { Nombre = "Televisión Básica", Precio = 15.00m },
            new Servicio { Nombre = "Televisión Avanzada", Precio = 25.00m },
            new Servicio { Nombre = "Streaming Básico", Precio = 10.00m },
            new Servicio { Nombre = "Streaming Avanzado", Precio = 18.00m },
            new Servicio { Nombre = "Mantenimiento Técnico", Precio = 30.00m },
            new Servicio { Nombre = "Alquiler de Router", Precio = 12.00m },
            new Servicio { Nombre = "Canales Premium", Precio = 40.00m },
            new Servicio { Nombre = "Paquete Familiar", Precio = 50.00m },
            new Servicio { Nombre = "Plan de Datos Móvil", Precio = 25.00m }
        };

        public frmGenerarFactura()
        {
            InitializeComponent();
        }

        private void Generarfacturas_Load(object sender, EventArgs e)
        {
            // Cargar los clientes en el ComboBox
            var clientes = ClienteData.CargarClientes(); // Cargar clientes desde JSON
            cmbCliente.DataSource = null; // Limpiar cualquier dato anterior
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "Email";

            // Agregar un ítem inicial que no sea seleccionable
            clientes.Insert(0, new Cliente { Nombre = "Seleccionar Cliente", Email = "", Telefono = "", Apellido = "", Direccion = "" });
            cmbCliente.DataSource = clientes;
            cmbCliente.SelectedIndex = 0; // Mostrar "Seleccionar Cliente" por defecto

            // Configurar el DataGridView para mostrar los servicios
            dgvServicios.AutoGenerateColumns = false;
            dgvServicios.Columns.Clear();

            // Columna de Checkbox para seleccionar servicios
            DataGridViewCheckBoxColumn seleccionarColumna = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Seleccionar",
                Name = "Seleccionar",
                Width = 50
            };
            dgvServicios.Columns.Add(seleccionarColumna);

            // Columna de Nombre del Servicio
            DataGridViewTextBoxColumn nombreColumna = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Servicio"
            };
            dgvServicios.Columns.Add(nombreColumna);

            // Columna de Precio del Servicio
            DataGridViewTextBoxColumn precioColumna = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Precio",
                HeaderText = "Precio"
            };
            dgvServicios.Columns.Add(precioColumna);

            // Establecer la lista de servicios como fuente de datos
            dgvServicios.DataSource = servicios;
        }

        private void btnGenerarFactura(object sender, EventArgs e)
        {
            var clienteSeleccionado = cmbCliente.SelectedItem as Cliente;

            // Verificar que se haya seleccionado un cliente válido
            if (clienteSeleccionado == null || clienteSeleccionado.Nombre == "Seleccionar Cliente")
            {
                MessageBox.Show("Por favor, seleccione un cliente válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Recolectar los servicios seleccionados y calcular el total
            decimal totalFactura = 0;
            var serviciosSeleccionados = new List<Servicio>();

            foreach (DataGridViewRow row in dgvServicios.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Seleccionar"].Value) == true)
                {
                    var servicio = row.DataBoundItem as Servicio;
                    if (servicio != null)
                    {
                        serviciosSeleccionados.Add(servicio);
                        totalFactura += servicio.Precio;
                    }
                }
            }

            if (serviciosSeleccionados.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione al menos un servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear la factura
            Factura nuevaFactura = new Factura
            {
                Numero = "F" + DateTime.Now.Ticks,
                Cliente = clienteSeleccionado.Nombre + " " + clienteSeleccionado.Apellido,
                Fecha = DateTime.Now,
                Servicios = serviciosSeleccionados,
                Total = totalFactura
            };

            // Cargar las facturas existentes desde el archivo JSON
            var facturas = FacturaStorage.CargarFacturas();

            // Verificar si la factura ya existe antes de agregarla
            if (!facturas.Any(f => f.Numero == nuevaFactura.Numero))
            {
                facturas.Add(nuevaFactura); // Agregar la nueva factura si no existe
                FacturaStorage.GuardarFacturas(facturas); // Guardar todas las facturas en el archivo JSON
            }

            // Crear el contenido de la factura para archivo de texto
            StringBuilder factura = new StringBuilder();
            factura.AppendLine("FACTURA");
            factura.AppendLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));
            factura.AppendLine("Cliente: " + clienteSeleccionado.Nombre + " " + clienteSeleccionado.Apellido);
            factura.AppendLine("Email: " + clienteSeleccionado.Email);
            factura.AppendLine("Teléfono: " + clienteSeleccionado.Telefono);
            factura.AppendLine("\nServicios:");
            foreach (var servicio in serviciosSeleccionados)
            {
                factura.AppendLine($"- {servicio.Nombre}: ${servicio.Precio}");
            }
            factura.AppendLine("\nTotal: $" + totalFactura);

            // Guardar la factura en un archivo de texto
            string rutaFactura = @"C:\Facturas\Factura_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            System.IO.Directory.CreateDirectory(@"C:\Facturas"); // Crear el directorio si no existe
            System.IO.File.WriteAllText(rutaFactura, factura.ToString());

            // Mostrar mensaje de confirmación
            MessageBox.Show("Factura generada correctamente.\nRuta: " + rutaFactura, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Abrir el archivo generado en el Bloc de notas
            System.Diagnostics.Process.Start("notepad.exe", rutaFactura);

        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}

