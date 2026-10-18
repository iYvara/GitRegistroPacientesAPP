using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroDePacientesAPP
{
    public partial class Registro : Form
    {
        private string tipoSolicitud = "";
        private Color colorAyuda = Color.Gray;
        private Color colorEscrito = Color.FromArgb(44, 62, 80);
        private Dictionary<TextBox, string> ayudas = new Dictionary<TextBox, string>();
        private PictureBox barraNivel;
        private int nivelActual = 0;

        public Registro()
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

        private void Bordear(Control control, int radio, int grosor, Color? colorBorde = null)
        {
            control.Region = new Region(Redondeado(new Rectangle(0, 0, control.Width, control.Height), radio));

            control.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Color color = colorBorde ?? ControlPaint.Dark(control.BackColor, 0.2f);

                int d = grosor / 2 + 1;
                Rectangle r = new Rectangle(d, d, control.Width - d * 2 - 1, control.Height - d * 2 - 1);

                using (GraphicsPath p = Redondeado(r, radio - d * 2))
                using (Pen lapiz = new Pen(color, grosor))
                {
                    e.Graphics.DrawPath(lapiz, p);
                }
            };
        }

        private void BordearTexto(TextBox caja, int radio, int grosor, Color colorBorde)
        {
            Control padre = caja.Parent;

            Panel marco = new Panel();
            marco.Location = new Point(caja.Left - 6, caja.Top - 4);
            marco.Size = new Size(caja.Width + 12, caja.Height + 8);
            marco.BackColor = caja.BackColor;
            padre.Controls.Add(marco);
            marco.BringToFront();

            marco.Controls.Add(caja);
            caja.Location = new Point(6, 4);
            caja.BorderStyle = BorderStyle.None;

            Bordear(marco, radio, grosor, colorBorde);
        }

        private Color ColorNivel(int nivel)
        {
            switch (nivel)
            {
                case 1: return Color.FromArgb(39, 174, 96);
                case 2: return Color.FromArgb(130, 195, 65);
                case 3: return Color.FromArgb(229, 169, 26);
                case 4: return Color.FromArgb(230, 126, 34);
                case 5: return Color.FromArgb(192, 57, 43);
                default: return Color.FromArgb(225, 222, 214);
            }
        }

        private void CrearBarraNivel()
        {
            barraNivel = new PictureBox();
            barraNivel.Bounds = pbNivelDeEmergencia.Bounds;
            barraNivel.BackColor = Color.Transparent;
            barraNivel.Visible = false;
            pbNivelDeEmergencia.Parent.Controls.Add(barraNivel);
            pbNivelDeEmergencia.Visible = false;
            barraNivel.BringToFront();
            barraNivel.Paint += BarraNivel_Paint;
        }

        private void BarraNivel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int espacio = 6;
            int ancho = (barraNivel.Width - espacio * 4) / 5;
            int alto = barraNivel.Height - 1;

            for (int i = 0; i < 5; i++)
            {
                Rectangle r = new Rectangle(i * (ancho + espacio), 0, ancho, alto);
                Color c = i < nivelActual ? ColorNivel(nivelActual) : ColorNivel(0);

                using (GraphicsPath p = Redondeado(r, Math.Min(10, alto)))
                using (SolidBrush pincel = new SolidBrush(c))
                {
                    e.Graphics.FillPath(pincel, p);
                }
            }
        }

        private void MostrarBarraNivel(int nivel)
        {
            if (barraNivel == null)
                return;

            nivelActual = nivel;
            barraNivel.Visible = true;
            barraNivel.Invalidate();
        }

        private void PonerAyuda(TextBox caja, string texto)
        {
            ayudas[caja] = texto;
            caja.Text = texto;
            caja.ForeColor = colorAyuda;
            caja.Tag = "ayuda";

            caja.Enter += (s, e) =>
            {
                if (caja.Tag != null && caja.Tag.ToString() == "ayuda")
                {
                    caja.Text = "";
                    caja.ForeColor = colorEscrito;
                    caja.Tag = "";
                }
            };

            caja.Leave += (s, e) =>
            {
                if (caja.Text.Trim() == "")
                {
                    caja.Text = texto;
                    caja.ForeColor = colorAyuda;
                    caja.Tag = "ayuda";
                }
            };
        }

        private void RestaurarAyuda(TextBox caja)
        {
            caja.Text = ayudas[caja];
            caja.ForeColor = colorAyuda;
            caja.Tag = "ayuda";
        }

        private string Valor(TextBox caja)
        {
            if (caja.Tag != null && caja.Tag.ToString() == "ayuda")
                return "";

            return caja.Text.Trim();
        }

        private void LimpiarFormulario()
        {
            foreach (TextBox caja in ayudas.Keys)
            {
                RestaurarAyuda(caja);
            }

            btnAmbulancia.Checked = false;
            btnCitaMedica.Checked = false;
            btnMedicamentos.Checked = false;
            tipoSolicitud = "";

            this.ActiveControl = btnIngresar;
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
            string nombres = Valor(txtNombres);
            string apellidos = Valor(txtApellidos);
            string dni = Valor(txtDNI);
            string sexo = Valor(txtSexo);
            string descripcion = Valor(txtDescripcion);
            int nivel;
            string estado;
            int contador = 1;
            bool repetido = false;

            if (nombres == "")
            {
                MessageBox.Show("Error: El campo de nombres no puede estar vacio.");
                txtNombres.Focus();
                return;
            }

            if (!nombres.All(c => char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("Error: Los nombres solo pueden tener letras.");
                txtNombres.Focus();
                return;
            }

            if (apellidos == "")
            {
                MessageBox.Show("Error: debe ingresar los apellidos.");
                txtApellidos.Focus();
                return;
            }

            if (!apellidos.All(c => char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("Error: Los apellidos solo pueden tener letras.");
                txtApellidos.Focus();
                return;
            }

            if (dni.Length != 8 || !dni.All(char.IsDigit))
            {
                MessageBox.Show("Error: El DNI debe tener 8 digitos (solo numeros).");
                txtDNI.Focus();
                return;
            }

            if (System.IO.File.Exists("pacientes.txt"))
            {
                foreach (string linea in System.IO.File.ReadAllLines("pacientes.txt"))
                {
                    if (string.IsNullOrWhiteSpace(linea))
                        continue;

                    string[] datos = linea.Split(';');

                    if (datos.Length >= 12 && datos[4] == dni)
                    {
                        repetido = true;
                        break;
                    }
                }
            }

            if (repetido)
            {
                MessageBox.Show("Error: este DNI ya fue registrado anteriormente.");
                txtDNI.Focus();
                return;
            }

            if (sexo == "")
            {
                MessageBox.Show("Error: debe ingresar el sexo.");
                txtSexo.Focus();
                return;
            }

            if (sexo.ToLower() == "masculino")
            {
                sexo = "Masculino";
            }
            else if (sexo.ToLower() == "femenino")
            {
                sexo = "Femenino";
            }
            else
            {
                MessageBox.Show("Error: El sexo debe ser 'Masculino' o 'Femenino'.");
                txtSexo.Focus();
                return;
            }

            int.TryParse(Valor(txtNivelDeEmergencia), out nivel);

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
                    MessageBox.Show("Error: Ingrese un nivel correctamente (1 al 5).");
                    txtNivelDeEmergencia.Focus();
                    return;
            }

            if (tipoSolicitud == "")
            {
                MessageBox.Show("Error: debe elegir un tipo de solicitud.");
                return;
            }

            if (descripcion == "")
            {
                descripcion = "No hay descripcion.";
            }

            descripcion = descripcion.Replace(";", ",").Replace("\r", " ").Replace("\n", " ");

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

            string codigo = GenerarCodigoPaciente(contador);
            string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            lblNombresyApellidos.Text = nombres + " " + apellidos;
            lblCodigoyDNI.Text = codigo + " · " + dni;
            lblFecha.Text = fecha;
            lblSolicitud.Text = tipoSolicitud;
            lblPrioridad.Text = Convert.ToString(CalcularPrioridad(nivel));
            lblDescripcion.Text = descripcion;

            MostrarBarraNivel(nivel);

            string registro = codigo + ";" + nombres + ";" + apellidos + ";" + sexo + ";" + dni + ";" +
                              fecha + ";El Agustino;Hospital Nacional Unanue;" + tipoSolicitud + ";" + descripcion + ";" +
                              nivel + ";" + CalcularPrioridad(nivel) + ";" + estado + ";";

            System.IO.File.AppendAllText("pacientes.txt", registro + Environment.NewLine);

            LimpiarFormulario();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
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

        private void Registro_Load(object sender, EventArgs e)
        {
            Color gris = Color.FromArgb(224, 222, 214);
            Color beige = Color.FromArgb(213, 211, 202);

            Bordear(panel2, 20, 2, beige);
            Bordear(panel4, 30, 1, gris);
            Bordear(panel3, 20, 2, beige);
            Bordear(lblDescripcion, 12, 2, gris);

            BordearTexto(txtNombres, 12, 2, gris);
            BordearTexto(txtApellidos, 12, 2, gris);
            BordearTexto(txtDNI, 12, 2, gris);
            BordearTexto(txtNivelDeEmergencia, 12, 2, gris);
            BordearTexto(txtSexo, 12, 2, gris);
            BordearTexto(txtDescripcion, 12, 2, gris);

            CrearBarraNivel();

            PonerAyuda(txtNombres, "Ingrese sus nombres");
            PonerAyuda(txtApellidos, "Ingrese sus apellidos");
            PonerAyuda(txtDNI, "(8 digitos)");
            PonerAyuda(txtSexo, "Masculino / Femenino");
            PonerAyuda(txtNivelDeEmergencia, "1 al 5");
            PonerAyuda(txtDescripcion, "Descripcion del caso (opcional)");

            this.ActiveControl = btnSalir;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSexo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lblNombresyApellidos_Click(object sender, EventArgs e)
        {

        }

        private void lblCodigoyDNI_Click(object sender, EventArgs e)
        {

        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }

        private void lblSolicitud_Click(object sender, EventArgs e)
        {

        }

        private void lblPrioridad_Click(object sender, EventArgs e)
        {

        }

        private void lblDescripcion_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pbNivelDeEmergencia_Click(object sender, EventArgs e)
        {

        }
    }
}