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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConfirmarContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            bool tieneNumero = false;
            bool tieneCaracterEspecial = false; 

            string usuario = txtUsuario.Text;
            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Por favor, ingrese un nombre de usuario.");
                return;
            }
            if (string.IsNullOrEmpty(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, ingrese una contraseña.");
                return;
            }

            if (string.IsNullOrEmpty(txtConfirmarContraseña.Text))
            {
                MessageBox.Show("Por favor, confirme su contraseña.");
                return;
            }

            if( usuario.Length < 5)
            {
                MessageBox.Show("El nombre de usuario debe tener al menos 5 caracteres.");
                return;
            }

            if (usuario.ToUpper() == usuario || usuario.ToLower() == usuario)
            {
                MessageBox.Show("El nombre de usuario debe tener una mayuscula o minuscula.");
                return;
            }

        foreach (char c in txtContraseña.Text)
            {
                if (char.IsDigit(c))
                {
                    tieneNumero = true;
                }
                if (!char.IsLetterOrDigit(c))
                {
                    tieneCaracterEspecial = true;
                }
            }
        if (!tieneNumero)
            {
                MessageBox.Show("La contraseña debe contener al menos un número.");
                return;
            }

            string confirmarcontraseña = txtConfirmarContraseña.Text;
            string contraseña = txtContraseña.Text;

            if (contraseña.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres.");
                return;
            }

            if(contraseña.Length > 8)
            {
                MessageBox.Show("La contraseña no puede tener mas de 8 caracteres.");
                return;
            }

            if(!tieneNumero)
            {
                MessageBox.Show("La contraseña debe contener al menos un número.");
                return;
            }

            if(!tieneCaracterEspecial)
            {
                MessageBox.Show("La contraseña debe contener al menos un caracter especial.");
                return;
            }

            if (contraseña == confirmarcontraseña)
            {
                MessageBox.Show("Contraseñas correctas, Bienvenido/a.");
                this.Hide();
                using (Login login = new Login())
                {
                    this.Hide();
                    login.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden.");
            }
            return;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
