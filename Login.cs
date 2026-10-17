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
using System.Drawing.Imaging;

namespace RegistroDePacientesAPP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            int radio = 30;
            GraphicsPath forma = new GraphicsPath();
            forma.AddArc(0, 0, radio, radio, 180, 90);
            forma.AddArc(panelblanco.Width - radio, 0, radio, radio, 270, 90);
            forma.AddArc(panelblanco.Width - radio, panelblanco.Height - radio, radio, radio, 0, 90);
            forma.AddArc(0, panelblanco.Height - radio, radio, radio, 90, 90);
            forma.CloseFigure();
            panelblanco.Region = new Region(forma);

            pictureBox3.BackColor = Color.FromArgb(200, 255, 255, 255);

            pictureBox3.Image = ConOpacidad(pictureBox3.Image, 0.4f);

            Point posicion = new Point(panelbeige.Left - pictureBox3.Left, panelbeige.Top - pictureBox3.Top);
            panelbeige.Parent = pictureBox3;
            panelbeige.Location = posicion;
            panelbeige.BackColor = Color.FromArgb(170, 240, 239, 234);
            panelbeige.Region = new Region(Redondeado(new Rectangle(0, 0, panelbeige.Width, panelbeige.Height), 30));

            pictureBox3.Paint += PictureBox3_Paint;
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
                Rectangle sombra = new Rectangle(r.X - i, r.Y - i + 6, r.Width + i * 2, r.Height + i * 2);

                using (GraphicsPath p = Redondeado(sombra, 30 + i * 2))
                using (SolidBrush pincel = new SolidBrush(Color.FromArgb(9, 0, 0, 0)))
                {
                    e.Graphics.FillPath(pincel, p);
                }
            }
        }

        private Image ConOpacidad(Image imagen, float opacidad)
        {
            Bitmap resultado = new Bitmap(imagen.Width, imagen.Height);

            using (Graphics g = Graphics.FromImage(resultado))
            {
                ColorMatrix matriz = new ColorMatrix();
                matriz.Matrix33 = opacidad;

                ImageAttributes atributos = new ImageAttributes();
                atributos.SetColorMatrix(matriz, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                g.DrawImage(imagen, new Rectangle(0, 0, imagen.Width, imagen.Height),
                            0, 0, imagen.Width, imagen.Height, GraphicsUnit.Pixel, atributos);
            }

            return resultado;
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
                MessageBox.Show("Contraseña correcta.");
                using (Sistema sistema = new Sistema())
                {
                    this.Hide();
                    sistema.ShowDialog();
                    this.Show();
                }

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkContraseña_CheckedChanged(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = !checkContraseña.Checked;
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}