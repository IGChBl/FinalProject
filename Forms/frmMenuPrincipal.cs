using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto.Forms;

namespace Proyecto
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nuevaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGenerarFactura generarFacturaForm = new frmGenerarFactura();
            generarFacturaForm.Show(); // Muestra el formulario de generación de factura
        }

        private void agregarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarCliente agregarClienteForm = new frmAgregarCliente();
            agregarClienteForm.Show(); // Muestra el formulario de agregar cliente
        }

        private void verHistorialDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorialFacturas historialFacturasForm = new frmHistorialFacturas();
            historialFacturasForm.Show();// muestra el formulario historial facturas
        }

        private void modificarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModificarDatosClientes modificarDatosClientesForm = new frmModificarDatosClientes();
            modificarDatosClientesForm.Show(); // Abre el formulario 
        }

        private void consultarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarCliente consultarClienteForm = new frmConsultarCliente();
            consultarClienteForm.Show();
        }

        private void darDeBajaAClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDarBajaCliente dardeBajaClientes = new frmDarBajaCliente();
            dardeBajaClientes.Show();
        }

        private void actualizarOEliminarFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crea una instancia del formulario
            frmActualizarEliminarFacturaErronea formActualizarEliminar = new frmActualizarEliminarFacturaErronea();

            // Muestra el formulario
            formActualizarEliminar.ShowDialog(); 
        }

  
     }
 }
