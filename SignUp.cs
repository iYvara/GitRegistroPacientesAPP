using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace RegistroDePacientesAPP
{
    public partial class SignUp : Form
    {
        private string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cuentas.txt");

        private Color colorAyuda = Color.Gray;
        private Color colorEscrito = Color.FromArgb(228, 228, 231);

        private Dictionary<TextBox, string> ayudas = new Dictionary<TextBox, string>();

        private CheckBox checkContraseña;

        public SignUp()
        {
            InitializeComponent();

            if (!File.Exists(ruta))
            {
                File.WriteAllText(ruta, "");
            }

            PonerAyuda(txtUsuario, "Ingrese su usuario");
            PonerAyuda(txtContraseña, "Ingrese su contraseña");
            PonerAyuda(txtConfirmarContraseña, "Confirme su contraseña");
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

        private bool EsAyuda(TextBox caja)
        {
            return caja.Tag != null && caja.Tag.ToString() == "ayuda";
        }

        private bool EsCampoContraseña(TextBox caja)
        {
            return caja == txtContraseña || caja == txtConfirmarContraseña;
        }

        private void MostrarAyuda(TextBox caja)
        {
            if (EsCampoContraseña(caja))
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
            bool ocultar = !checkContraseña.Checked;

            if (!EsAyuda(txtContraseña))
            {
                txtContraseña.UseSystemPasswordChar = ocultar;
            }

            if (!EsAyuda(txtConfirmarContraseña))
            {
                txtConfirmarContraseña.UseSystemPasswordChar = ocultar;
            }
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

            string usuario = Valor(txtUsuario);
            string contraseña = Valor(txtContraseña, false);
            string confirmarcontraseña = Valor(txtConfirmarContraseña, false);

            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("Por favor, ingrese un nombre de usuario.");
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, ingrese una contraseña.");
                txtContraseña.Focus();
                return;
            }

            if (string.IsNullOrEmpty(confirmarcontraseña))
            {
                MessageBox.Show("Por favor, confirme su contraseña.");
                txtConfirmarContraseña.Focus();
                return;
            }

            if (usuario.Length < 5)
            {
                MessageBox.Show("El nombre de usuario debe tener al menos 5 caracteres.");
                txtUsuario.Focus();
                return;
            }

            if (usuario.Contains(":"))
            {
                MessageBox.Show("El nombre de usuario no puede contener ':'.");
                txtUsuario.Focus();
                return;
            }

            if (usuario.ToUpper() == usuario || usuario.ToLower() == usuario)
            {
                MessageBox.Show("El nombre de usuario debe tener al menos una mayúscula y una minúscula.");
                txtUsuario.Focus();
                return;
            }

            foreach (char c in contraseña)
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

            if (contraseña.Length != 8)
            {
                MessageBox.Show("La contraseña debe tener exactamente 8 caracteres.");
                txtContraseña.Focus();
                return;
            }

            if (!tieneNumero)
            {
                MessageBox.Show("La contraseña debe contener al menos un número.");
                txtContraseña.Focus();
                return;
            }

            if (!tieneCaracterEspecial)
            {
                MessageBox.Show("La contraseña debe contener al menos un carácter especial.");
                txtContraseña.Focus();
                return;
            }

            if (contraseña != confirmarcontraseña)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                txtConfirmarContraseña.Focus();
                return;
            }

            try
            {
                File.WriteAllText(ruta, usuario + ":" + contraseña + Environment.NewLine);

                MessageBox.Show("Cuenta registrada correctamente, Bienvenido/a.");

                using (Login login = new Login())
                {
                    this.Hide();
                    login.ShowDialog();
                    this.Show();
                }

                
                MostrarAyuda(txtUsuario);
                MostrarAyuda(txtContraseña);
                MostrarAyuda(txtConfirmarContraseña);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la cuenta:\n" + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            BordearTexto(txtUsuario, 10, 2, Color.FromArgb(161, 161, 170));
            BordearTexto(txtContraseña, 10, 2, Color.FromArgb(161, 161, 170));
            BordearTexto(txtConfirmarContraseña, 10,2, Color.FromArgb(161, 161, 170));
            Bordear(btnRegistrarse, 10,2, Color.FromArgb(161, 161, 170));
            Bordear(panel1, 30, 2, Color.FromArgb(161, 161, 170));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}