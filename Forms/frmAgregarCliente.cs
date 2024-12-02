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

namespace Proyecto.Forms
{
    public partial class frmAgregarCliente : Form
    {
        private List<Cliente> clientes; // Lista de clientes cargada desde JSON

        public frmAgregarCliente()
        {
            InitializeComponent();
        }

        private void frmAgregarCliente_Load(object sender, EventArgs e)
        {
            // Cargar los clientes al abrir el formulario
            clientes = ClienteData.CargarClientes();
        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            string telefono = tbTelefono.Text;
            string email = tbEmail.Text;

            // Validación del Teléfono
            if (telefono.Length != 8 || !Regex.IsMatch(telefono, @"^\d{8}$")) // expresión regular para validar un número de teléfono de 8 dígitos
            {
                MessageBox.Show("El número de teléfono debe ser de 8 dígitos y contener solo números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detiene el proceso de guardado si la validación falla
            }

            // Validación del Correo Electrónico
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) // expresión regular para validar un correo electrónico
            {
                MessageBox.Show("Ingrese un correo electrónico válido que contenga '@' y un dominio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detiene el proceso de guardado si la validación falla
            }

            // Crear una nueva instancia de Cliente con los datos ingresados
            Cliente nuevoCliente = new Cliente
            {
                Nombre = tbNombre.Text,
                Apellido = tbApellido.Text,
                Telefono = tbTelefono.Text,
                Email = tbEmail.Text,
                Direccion = tbDireccion.Text
            };

            // Agregar el cliente a la lista cargada
            clientes.Add(nuevoCliente);

            // Guardar la lista actualizada en el archivo JSON
            ClienteData.GuardarClientes(clientes);

            // Mostrar un mensaje de confirmación
            MessageBox.Show("Cliente agregado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar los campos de texto
            tbNombre.Clear();
            tbApellido.Clear();
            tbTelefono.Clear();
            tbEmail.Clear();
            tbDireccion.Clear();
        }

        private void lblDireccion_Click(object sender, EventArgs e)
        {

        }
    }
}