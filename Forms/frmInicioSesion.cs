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
using Proyecto.Forms;

namespace Proyecto.Forms
{
    public partial class frmInicioSesion : Form
    {
        private List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { Nombre = "Ivan", Apellido = "Chavarría", Matricula = "15021113", Carrera = "Ingeniería en Sistemas", Telefono = "", Email = "ichavarria@uamv.edu.ni", Direccion = "", FechaNacimiento = "31/07/1997", Sexo = "M", Contraseña = "ABC123!" },
            new Usuario { Nombre = "Violeta", Apellido = "Vanegas", Matricula = "", Carrera = "Ingeniería en Sistemas", Telefono = "", Email = "", Direccion = "", FechaNacimiento = "", Sexo = "F", Contraseña = "PantonyRival" },
        };

        public frmInicioSesion()
        {
            InitializeComponent();
            this.Icon = new Icon(@"Resources\CornIslandTV.ico");
        }

        // Método para validar usuario y contraseña
        private bool ValidarUsuario(string nombre, string contraseña)
        {
            foreach (var usuario in usuarios)
            {
                if (usuario.Nombre == nombre && usuario.Contraseña == contraseña)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string usuario = tbUser.Text;
            string contrasena = tbPassword.Text;

            if (ValidarUsuario(usuario, contrasena))
            {
                frmMenuPrincipal frmmenuPrincipal = new frmMenuPrincipal();
                frmmenuPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmInicioSesion_Load(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = '*';
        }
    }
}