using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class frmModificarDatosClientes : Form
    {
        private List<Cliente> clientes; // Lista de clientes cargada desde JSON
        private Cliente clienteSeleccionado; // Cliente que se busca y selecciona para modificar

        public frmModificarDatosClientes()
        {
            InitializeComponent();
        }

        private void fModificarCliente_Load(object sender, EventArgs e)
        {
            // Cargar los clientes al abrir el formulario
            clientes = ClienteData.CargarClientes();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            // Capturar el texto ingresado en el cuadro de búsqueda
            string criterioBusqueda = tbBuscarCliente.Text.Trim(); 


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
                // Mostrar los datos del cliente en los campos correspondientes
                tbNombre.Text = clienteSeleccionado.Nombre;
                tbApellido.Text = clienteSeleccionado.Apellido;
                tbDireccion.Text = clienteSeleccionado.Direccion;
                tbEmail.Text = clienteSeleccionado.Email;
                tbTelefono.Text = clienteSeleccionado.Telefono;

                MessageBox.Show("Cliente encontrado. Modifique los datos y haga clic en 'Modificar Cliente'.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cliente no encontrado. Verifique el nombre o correo ingresado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado == null)
            {
                MessageBox.Show("Primero debe buscar un cliente para modificar sus datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string telefono = tbTelefono.Text.Trim();
            string email = tbEmail.Text.Trim();

            // Validación del Teléfono
            if (telefono.Length != 8 || !Regex.IsMatch(telefono, @"^\d{8}$"))
            {
                MessageBox.Show("El número de teléfono debe ser de 8 dígitos y contener solo números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación del Correo Electrónico
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingrese un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Modificar los datos del cliente seleccionado
            clienteSeleccionado.Nombre = tbNombre.Text.Trim();
            clienteSeleccionado.Apellido = tbApellido.Text.Trim();
            clienteSeleccionado.Direccion = tbDireccion.Text.Trim();
            clienteSeleccionado.Email = email;
            clienteSeleccionado.Telefono = telefono;

            // Guardar los cambios en el archivo JSON
            ClienteData.GuardarClientes(clientes);

            MessageBox.Show("Datos del cliente modificados correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar los campos
            tbBuscarCliente.Clear();
            tbNombre.Clear();
            tbApellido.Clear();
            tbDireccion.Clear();
            tbEmail.Clear();
            tbTelefono.Clear();

            // Reiniciar el cliente seleccionado
            clienteSeleccionado = null;
        }
    }
}
    
