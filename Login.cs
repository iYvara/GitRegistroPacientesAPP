using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroDePacientesAPP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string clave = txtContraseña.Text.Trim();

            if (clave == "")
            {
                MessageBox.Show("Escribe la contraseña.");
                return;
            }

            if (clave == "Admin123")
            {
                MessageBox.Show("Contraseña correcta, bienvenido/a.");

            }
            else
            {
                MessageBox.Show("Contraseña incorrecta, intentelo de nuevo.");
                txtContraseña.Clear();
                txtContraseña.Focus();
            }
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
