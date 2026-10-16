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
    public partial class Buscador : Form
    {
        public Buscador()
        {
            InitializeComponent();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            bool encontrado = false;
            string codigo_busqueda = txtBuscar.Text;

            if (System.IO.File.Exists("pacientes.txt"))
            {
                string[] registros = System.IO.File.ReadAllLines("pacientes.txt");

                foreach (string registro in registros)
                {
                    if (string.IsNullOrWhiteSpace(registro))
                        continue;

                    string[] datos = registro.Split(';');

                    if (datos.Length >= 12 && codigo_busqueda == datos[0])
                    {
                        encontrado = true;

                        MessageBox.Show("PACIENTE ENCONTRADO" +
                                        "\nCodigo: " + datos[0] +
                                        "\nFecha: " + datos[4] +
                                        "\nPaciente: " + datos[1] + " " + datos[2] +
                                        "\nDNI: " + datos[3] +
                                        "\nCentro de Salud: " + datos[6] +
                                        "\nDistrito: " + datos[5] +
                                        "\nTipo de Solicitud: " + datos[7] +
                                        "\nNivel de Emergencia: " + datos[9] +
                                        "\nEstado: " + datos[11] +
                                        "\nPrioridad: " + datos[10] +
                                        "\nDescripcion: " + datos[8]);

                        break;
                    }
                }
            }

            if (!encontrado)
            {
                MessageBox.Show("Error: no se encontro ningun paciente con ese codigo.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}