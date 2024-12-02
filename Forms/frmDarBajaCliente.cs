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
    public partial class frmDarBajaCliente : Form
    {
        private List<Cliente> clientes; // Lista de clientes cargada desde JSON
        private Cliente clienteSeleccionado; // Cliente que se busca y selecciona para eliminar
        public frmDarBajaCliente()
        {
            InitializeComponent();
        }


        private void DarDeBajaCliente_Load(object sender, EventArgs e)
        {
            // Cargar los clientes desde el archivo JSON al abrir el formulario
            clientes = ClienteData.CargarClientes();

            // Configurar las columnas del DataGridView
            dgvClienteSeleccionado.ColumnCount = 5;
            dgvClienteSeleccionado.Columns[0].Name = "Nombre";
            dgvClienteSeleccionado.Columns[1].Name = "Apellido";
            dgvClienteSeleccionado.Columns[2].Name = "Dirección";
            dgvClienteSeleccionado.Columns[3].Name = "Correo Electrónico";
            dgvClienteSeleccionado.Columns[4].Name = "Teléfono";
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string criterioBusqueda = tbCliente.Text.Trim(); // Capturar texto del cuadro de búsqueda

            // Validar que el criterio no esté vacío
            if (string.IsNullOrEmpty(criterioBusqueda))
            {
                MessageBox.Show("Por favor, ingrese un nombre o correo para buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Buscar el cliente en la lista
            clienteSeleccionado = clientes.FirstOrDefault(c =>
                c.Nombre.Equals(criterioBusqueda, StringComparison.OrdinalIgnoreCase) ||
                c.Email.Equals(criterioBusqueda, StringComparison.OrdinalIgnoreCase));

            if (clienteSeleccionado != null)
            {
                // Mostrar los datos del cliente en el DataGridView
                dgvClienteSeleccionado.Rows.Clear(); // Limpiar cualquier dato previo
                dgvClienteSeleccionado.Rows.Add(
                    clienteSeleccionado.Nombre,
                    clienteSeleccionado.Apellido,
                    clienteSeleccionado.Direccion,
                    clienteSeleccionado.Email,
                    clienteSeleccionado.Telefono
                );
            }
            else
            {
                MessageBox.Show("Cliente no encontrado. Verifique el nombre o correo ingresado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            // Verificar si hay un cliente seleccionado
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Primero debe buscar un cliente antes de darlo de baja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirmar eliminación
            var confirmacion = MessageBox.Show($"¿Está seguro de eliminar al cliente {clienteSeleccionado.Nombre} {clienteSeleccionado.Apellido}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                // Eliminar el cliente de la lista
                clientes.Remove(clienteSeleccionado);

                // Guardar los cambios en el archivo JSON
                ClienteData.GuardarClientes(clientes);

                // Mostrar mensaje de confirmación
                MessageBox.Show("Cliente eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar el formulario
                tbCliente.Clear();
                dgvClienteSeleccionado.Rows.Clear(); // Limpiar el DataGridView
                clienteSeleccionado = null;
            }
        }
    }
}

