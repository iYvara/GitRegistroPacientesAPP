using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroDePacientesAPP
{
    public partial class Sistema : Form
    {
        private ToolTip ayuda = new ToolTip();

        public Sistema()
        {
            InitializeComponent();
        }

        private GraphicsPath Redondeado(Rectangle r, int radio)
        {
            GraphicsPath p = new GraphicsPath();
            p.AddArc(r.X, r.Y, radio, radio, 180, 90);
            p.AddArc(r.Right - radio, r.Y, radio, radio, 270, 90);
            p.AddArc(r.Right - radio, r.Bottom - radio, radio, radio, 0, 90);
            p.AddArc(r.X, r.Bottom - radio, radio, radio, 90, 90);
            p.CloseFigure();
            return p;
        }

        private void Bordear(Control control, int radio, int grosor)
        {
            control.Region = new Region(Redondeado(new Rectangle(0, 0, control.Width, control.Height), radio));

            control.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                int d = grosor / 2 + 1;
                Rectangle r = new Rectangle(d, d, control.Width - d * 2 - 1, control.Height - d * 2 - 1);

                using (GraphicsPath p = Redondeado(r, radio - d * 2))
                using (Pen lapiz = new Pen(ControlPaint.Dark(control.BackColor, 0.2f), grosor))
                {
                    e.Graphics.DrawPath(lapiz, p);
                }
            };
        }

        private void btnRegistrar_Paint(object sender, PaintEventArgs e)
        {

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
            using (Buscador buscador = new Buscador())
            {
                this.Hide();
                buscador.ShowDialog();
                this.Show();
            }
        }

        private void Sistema_Load(object sender, EventArgs e)
        {
            Bordear(btnRegistrar, 30, 3);
            Bordear(btnBuscar, 30, 3);
            Bordear(btnLeer, 30, 3);
            Bordear(btnBorrar, 30, 3);
            Bordear(panel1, 30, 3);


            ayuda.ShowAlways = true;
            ayuda.InitialDelay = 300;
            ayuda.ReshowDelay = 100;

            ayuda.SetToolTip(btnRegistrar, "Registrar un nuevo paciente");
            ayuda.SetToolTip(btnBuscar, "Buscar un paciente por su código");
            ayuda.SetToolTip(btnLeer, "Abrir el archivo con todos los pacientes");
            ayuda.SetToolTip(btnBorrar, "Borrar todos los pacientes guardados");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Handler requerido por el diseñador. No se realiza dibujo adicional aquí.
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Handler requerido por el diseñador. No se realiza dibujo adicional aquí.
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            // Método vacío para satisfacer el evento enlazado en el diseñador.
        }
    }
}
