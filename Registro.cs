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
        private string tipoSolicitud = "";
        public Registro()
        {
            InitializeComponent();
        }

        static string GenerarCodigoPaciente(int contador)
        {
            string numerocodigo;

            numerocodigo = Convert.ToString(contador);

            while (numerocodigo.Length < 4)
            {
                numerocodigo = "0" + numerocodigo;
            }
            return "PAC-" + numerocodigo;
        }

        static int CalcularPrioridad(int nivel)
        {
            int prioridad;

            prioridad = nivel * 2;

            return prioridad;
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
            int contador = 1;


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
            bool repetido;

            repetido = false;

            if (dni < 10000000 || dni > 99999999)
            {
                MessageBox.Show("Error: El DNI debe tener 8 digitos.");
                return;
            }

            if (System.IO.File.Exists("pacientes.txt"))
            {
                foreach (string linea in System.IO.File.ReadAllLines("pacientes.txt"))
                {
                    if (string.IsNullOrWhiteSpace(linea))
                        continue;

                    string[] datos = linea.Split(';');

                    if (datos.Length >= 12 && datos[3] == dni.ToString())
                    {
                        repetido = true;
                        break;
                    }
                }
            }

            if (repetido)
            {
                MessageBox.Show("Error: este DNI ya fue registrado anteriormente.");
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

            if (System.IO.File.Exists("pacientes.txt"))
            {
                foreach (string linea in System.IO.File.ReadAllLines("pacientes.txt"))
                {
                    if (string.IsNullOrWhiteSpace(linea))
                        continue;

                    string[] datos = linea.Split(';');

                    if (datos.Length >= 12)
                    {
                        contador++;
                    }
                }
            }

            MessageBox.Show("SOLICITUD REGISTRADA" +
                            "\nPaciente: " + nombres + " " + apellidos +
                            "\nDNI: " + dni +
                            "\nNivel de Emergencia: " + nivel +
                            "\nEstado: " + estado +
                            "\nTipo de Solicitud: " + tipoSolicitud);

            string registro = GenerarCodigoPaciente(contador) + ";" + nombres + ";" + apellidos + ";" + dni + ";" +
                              DateTime.Now.ToString("dd/MM/yyyy HH:mm") + ";El Agustino;Hospital Nacional Unanue;" + tipoSolicitud + ";Requiere oxigeno de emergencia;" +
                              nivel + ";" + CalcularPrioridad(nivel) + ";" + estado + ";";

            System.IO.File.AppendAllText("pacientes.txt", registro + Environment.NewLine);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAmbulancia_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAmbulancia.Checked)
            {
                tipoSolicitud = "Ambulancia";
            }
        }

        private void btnCitaMedica_CheckedChanged(object sender, EventArgs e)
        {
            if (btnCitaMedica.Checked)
            {
                tipoSolicitud = "Cita Medica";
            }
        }

        private void btnMedicamentos_CheckedChanged(object sender, EventArgs e)
        {
            if (btnMedicamentos.Checked)
            {
                tipoSolicitud = "Medicamentos";
            }
        }
    }
}