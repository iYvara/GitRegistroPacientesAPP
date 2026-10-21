using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace RegistroDePacientesAPP
{
    public partial class Login : Form
    {
        private readonly string ruta =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cuentas.txt");

        private Color colorAyuda = Color.Gray;
        private Color colorEscrito = Color.FromArgb(44, 62, 80);

        private const int AlphaPanelBeige = 170;

        private Dictionary<TextBox, string> ayudas = new Dictionary<TextBox, string>();

        private Image fondoOriginal;

        public Login()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            if (!File.Exists(ruta))
            {
                File.WriteAllText(ruta, "");
            }


            PonerAyuda(txtUsuario, "Ingrese su usuario");
            PonerAyuda(txtContraseña, "Ingrese su contraseña");

  
            fondoOriginal = pictureBox3.Image;
            pictureBox3.BackColor = Color.FromArgb(200, 255, 255, 255);
            pictureBox3.SizeChanged += (s, e) => ActualizarFondo();
            ActualizarFondo();

  
            Point posicion = new Point(
                panelbeige.Left - pictureBox3.Left,
                panelbeige.Top - pictureBox3.Top);

            panelbeige.Parent = pictureBox3;
            panelbeige.Location = posicion;
            panelbeige.BackColor = Color.FromArgb(AlphaPanelBeige, 240, 239, 234);

           
            panelblanco.SizeChanged += (s, e) => AplicarBordesRedondeados();
            panelbeige.SizeChanged += (s, e) => AplicarBordesRedondeados();
            AplicarBordesRedondeados();

            pictureBox3.Paint += PictureBox3_Paint;
        }


        private bool EsAyuda(TextBox caja)
        {
            return caja.Tag != null && caja.Tag.ToString() == "ayuda";
        }

        private void MostrarAyuda(TextBox caja)
        {
            if (caja == txtContraseña)
            {
                caja.UseSystemPasswordChar = false;
            }

            caja.Text = ayudas[caja];
            caja.ForeColor = colorAyuda;
            caja.Tag = "ayuda";
        }

        private void PonerAyuda(TextBox caja, string texto)
        {
            ayudas[caja] = texto;
            MostrarAyuda(caja);

            caja.Enter += (s, e) =>
            {
                if (EsAyuda(caja))
                {
                    caja.Text = "";
                    caja.ForeColor = colorEscrito;
                    caja.Tag = "";

                    if (caja == txtContraseña)
                    {
                        caja.UseSystemPasswordChar = !checkContraseña.Checked;
                    }
                }
            };

            caja.Leave += (s, e) =>
            {
                if (caja.Text.Trim() == "")
                {
                    MostrarAyuda(caja);
                }
            };
        }

        private string Valor(TextBox caja, bool recortar = true)
        {
            if (EsAyuda(caja))
            {
                return "";
            }

            return recortar ? caja.Text.Trim() : caja.Text;
        }

        private void checkContraseña_CheckedChanged(object sender, EventArgs e)
        {
         
            if (EsAyuda(txtContraseña))
            {
                return;
            }

            txtContraseña.UseSystemPasswordChar = !checkContraseña.Checked;
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

        private void AplicarBordesRedondeados()
        {
            Region viejoBlanco = panelblanco.Region;
            using (GraphicsPath p = Redondeado(
                new Rectangle(0, 0, panelblanco.Width, panelblanco.Height), 30))
            {
                panelblanco.Region = new Region(p);
            }
            if (viejoBlanco != null) viejoBlanco.Dispose();

            Region viejoBeige = panelbeige.Region;
            using (GraphicsPath p = Redondeado(
                new Rectangle(0, 0, panelbeige.Width, panelbeige.Height), 30))
            {
                panelbeige.Region = new Region(p);
            }
            if (viejoBeige != null) viejoBeige.Dispose();
        }

        private void ActualizarFondo()
        {
            if (fondoOriginal == null ||
                pictureBox3.Width <= 0 ||
                pictureBox3.Height <= 0)
            {
                return;
            }

            Image anterior = pictureBox3.Image;

            pictureBox3.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox3.Image = ConOpacidad(fondoOriginal, 0.4f, pictureBox3.Size);

            if (anterior != null && anterior != fondoOriginal)
            {
                anterior.Dispose();
            }
        }

        private void PictureBox3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle r = panelbeige.Bounds;

            using (GraphicsPath hueco = Redondeado(r, 30))
            {
                e.Graphics.SetClip(hueco, CombineMode.Exclude);
            }

            for (int i = 14; i >= 1; i--)
            {
                Rectangle sombra = new Rectangle(
                    r.X - i,
                    r.Y - i + 6,
                    r.Width + i * 2,
                    r.Height + i * 2);

                using (GraphicsPath p = Redondeado(sombra, 30 + i * 2))
                using (SolidBrush pincel =
                    new SolidBrush(Color.FromArgb(9, 0, 0, 0)))
                {
                    e.Graphics.FillPath(pincel, p);
                }
            }
        }

        private Image ConOpacidad(Image imagen, float opacidad, Size tamaño)
        {
            if (imagen == null)
                return null;

            Bitmap resultado = new Bitmap(tamaño.Width, tamaño.Height);

            using (Graphics g = Graphics.FromImage(resultado))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;

                ColorMatrix matriz = new ColorMatrix();
                matriz.Matrix33 = opacidad;

                using (ImageAttributes atributos = new ImageAttributes())
                {
                    atributos.SetColorMatrix(
                        matriz,
                        ColorMatrixFlag.Default,
                        ColorAdjustType.Bitmap);

                    atributos.SetWrapMode(WrapMode.TileFlipXY);

                    g.DrawImage(
                        imagen,
                        new Rectangle(0, 0, tamaño.Width, tamaño.Height),
                        0, 0,
                        imagen.Width, imagen.Height,
                        GraphicsUnit.Pixel,
                        atributos);
                }
            }

            return resultado;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = Valor(txtUsuario);
            string clave = Valor(txtContraseña, false);

            if (usuario == "")
            {
                MessageBox.Show("Escribe tu usuario.");
                txtUsuario.Focus();
                return;
            }

            if (clave == "")
            {
                MessageBox.Show("Escribe la contraseña.");
                txtContraseña.Focus();
                return;
            }

            if (!File.Exists(ruta))
            {
                MessageBox.Show(
                    "No se encontró cuentas.txt.\n\n" +
                    "Primero debes registrarte.\n" +
                    AppDomain.CurrentDomain.BaseDirectory);
                return;
            }

            try
            {
                bool encontrado = false;

                foreach (string linea in File.ReadAllLines(ruta))
                {
                    if (string.IsNullOrWhiteSpace(linea))
                        continue;

                 
                    string[] datos = linea.Split(new[] { ':' }, 2);

                    if (datos.Length == 2 &&
                        usuario == datos[0].Trim() &&
                        clave == datos[1])
                    {
                        encontrado = true;
                        break;
                    }
                }

                if (encontrado)
                {
                    MessageBox.Show("Inicio de sesión correcta.");

                    using (Sistema sistema = new Sistema())
                    {
                        this.Hide();
                        sistema.ShowDialog();
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Usuario o contraseña incorrectos. Inténtalo de nuevo.");

                    txtContraseña.Clear();
                    txtContraseña.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al leer cuentas.txt:\n" + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void panelbeige_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}