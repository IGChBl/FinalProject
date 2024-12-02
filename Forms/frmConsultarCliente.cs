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
    public partial class frmConsultarCliente : Form
    {
        private List<Cliente> clientes; // Lista de clientes cargados desde JSON

        public frmConsultarCliente()
        {
            InitializeComponent();
            ClienteData.CargarClientes();
        }

        private void frmConsultarCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // Obtener el texto de búsqueda y convertirlo a minúsculas
            string criterioBusqueda = tbBuscarCliente.Text.ToLower();

            // Cargar los clientes desde el archivo JSON si aún no se han cargado
            var clientes = ClienteData.CargarClientes();

            // Validar si hay clientes disponibles
            if (clientes == null || !clientes.Any())
            {
                MessageBox.Show("No hay clientes disponibles para consultar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar clientes por nombre o correo
            var resultados = clientes.Where(cliente =>
                cliente.Nombre.ToLower().Contains(criterioBusqueda) ||
                cliente.Email.ToLower().Contains(criterioBusqueda)).ToList();

            // Mostrar los resultados en el DataGridView
            if (resultados.Any())
            {
                dgvClientes.DataSource = resultados;
                dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajustar columnas
            }
            else
            {
                // Mostrar mensaje si no hay resultados
                MessageBox.Show("No se encontraron clientes con el criterio ingresado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvClientes.DataSource = null; // Limpiar DataGridView
            }
        }

    }
}