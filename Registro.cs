using Microsoft.Win32;
using System;
using System.IO;
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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void txtNivelDeEmergencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombres = txtNombres.Text;
            string apellidos = txtApellidos.Text;
            int dni, nivel;
            string estado;

            if (nombres == "")
            {
                MessageBox.Show("Error: El campo de nombres no puede estar vacio.");
                return;
            }

            if (apellidos == "")
            {
                MessageBox.Show("Error: debe ingresar los apellidos.");
                return;
            }

            int.TryParse(txtDNI.Text, out dni);

            if (dni < 10000000 || dni > 99999999)
            {
                MessageBox.Show("Error: El DNI debe tener 8 digitos.");
                return;
            }

            int.TryParse(txtNivelDeEmergencia.Text, out nivel);

            switch (nivel)
            {
                case 1:
                    estado = "Leve";
                    break;
                case 2:
                    estado = "Poco leve";
                    break;
                case 3:
                    estado = "Severo";
                    break;
                case 4:
                    estado = "Poco severo";
                    break;
                case 5:
                    estado = "Peligroso";
                    break;
                default:
                    MessageBox.Show("Error: Ingrese un nivel correctamente.");
                    return;
            }

            MessageBox.Show("SOLICITUD REGISTRADA" +
                            "\nPaciente: " + nombres + " " + apellidos +
                            "\nDNI: " + dni +
                            "\nNivel de Emergencia: " + nivel +
                            "\nEstado: " + estado);

            string registro = "PAC-0001;" + nombres + ";" + apellidos + ";" + dni + ";" +
                              DateTime.Now.ToString("dd/MM/yyyy") + ";El Agustino;Hospital Nacional Unanue;Ambulancia;Requiere oxigeno de emergencia;" +
                              nivel + ";" + (nivel * 2 + 3) + ";" + estado + ";";

            System.IO.File.AppendAllText("pacientes.txt", registro + Environment.NewLine);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}