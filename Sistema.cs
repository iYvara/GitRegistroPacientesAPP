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
    public partial class Sistema : Form
    {
        public Sistema()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de borrar todos los pacientes?", "Confirmar", MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                System.IO.File.WriteAllText("pacientes.txt", "");
                MessageBox.Show("Se borraron los registros.");
            }
            else
            {
                MessageBox.Show("Operacion cancelada.");
            }
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("pacientes.txt"))
            {
                System.Diagnostics.Process.Start("notepad.exe", "pacientes.txt");
            }
            else
            {
                MessageBox.Show("Todavia no existe el archivo de pacientes.");
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ingresando...");
            using (Registro registro = new Registro())
            {
                this.Hide();
                registro.ShowDialog();
                this.Show();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ingresando...");
            using(Buscador buscador = new Buscador())
            {
                this.Hide();
                buscador.ShowDialog();
                this.Show();
            }
        }

        private void Sistema_Load(object sender, EventArgs e)
        {

        }
    }
}
