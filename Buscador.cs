
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
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

            btnBuscarMultiple.DropDownStyle = ComboBoxStyle.DropDownList;
            btnBuscarMultiple.Items.Clear();
            btnBuscarMultiple.Items.Add("Codigo");
            btnBuscarMultiple.Items.Add("DNI");
            btnBuscarMultiple.Items.Add("Nombre");
            btnBuscarMultiple.Items.Add("Fecha");
            btnBuscarMultiple.Items.Add("Prioridad");
            btnBuscarMultiple.Items.Add("Estado");
            btnBuscarMultiple.Items.Add("Solicitud");
            btnBuscarMultiple.SelectedIndex = 0;

            btnOrdenar.DropDownStyle = ComboBoxStyle.DropDownList;
            btnOrdenar.Items.Clear();
            btnOrdenar.Items.Add("Codigo");
            btnOrdenar.Items.Add("Prioridad (mayor a menor)");
            btnOrdenar.Items.Add("Prioridad (menor a mayor)");
            btnOrdenar.Items.Add("Fecha (mas reciente)");
            btnOrdenar.Items.Add("Fecha (mas antigua)");
            btnOrdenar.Items.Add("Nombre (A-Z)");
            btnOrdenar.SelectedIndex = 0;

            CrearColumnas();

            dgvPacientes.ReadOnly = true;
            dgvPacientes.AllowUserToAddRows = false;
            dgvPacientes.RowHeadersVisible = false;
            dgvPacientes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvPacientes.CellDoubleClick += dgvPacientes_CellDoubleClick;
            dgvPacientes.CellClick += dgvPacientes_CellClick;

            LimpiarDetalle();
            Buscar(false);
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

        private void Bordear(
            Control control,
            int radio,
            int grosor,
            Color? colorBorde = null)
        {
            control.Region = new Region(
                Redondeado(
                    new Rectangle(0, 0, control.Width, control.Height),
                    radio));

            control.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Color color = colorBorde ??
                    ControlPaint.Dark(control.BackColor, 0.2f);

                int d = grosor / 2 + 1;

                Rectangle r = new Rectangle(
                    d,
                    d,
                    control.Width - d * 2 - 1,
                    control.Height - d * 2 - 1);

                using (GraphicsPath p = Redondeado(r, radio - d * 2))
                using (Pen lapiz = new Pen(color, grosor))
                {
                    e.Graphics.DrawPath(lapiz, p);
                }
            };
        }

        private List<string[]> LeerPacientes()
        {
            List<string[]> lista = new List<string[]>();

            if (!System.IO.File.Exists("pacientes.txt"))
                return lista;

            foreach (string linea in System.IO.File.ReadAllLines("pacientes.txt"))
            {
                if (string.IsNullOrWhiteSpace(linea))
                    continue;

                string[] datos = linea.Split(';');

                if (datos.Length >= 13)
                    lista.Add(datos);
            }

            return lista;
        }

        private bool Coincide(string[] d, string criterio, string texto)
        {
            switch (criterio)
            {
                case "Codigo":
                    return d[0].ToUpper().Contains(texto.ToUpper());

                case "DNI":
                    return d[4].Contains(texto);

                case "Nombre":
                    return (d[1] + " " + d[2])
                        .ToLower().Contains(texto.ToLower());

                case "Fecha":
                    return d[5].Contains(texto);

                case "Prioridad":
                    return d[11] == texto;

                case "Estado":
                    return d[12].ToLower().Contains(texto.ToLower());

                case "Solicitud":
                    return d[8].ToLower().Contains(texto.ToLower());

                default:
                    return false;
            }
        }

        private int Numero(string texto)
        {
            int n;
            int.TryParse(texto, out n);
            return n;
        }

        private DateTime Fecha(string texto)
        {
            DateTime f;

            DateTime.TryParseExact(
                texto,
                "dd/MM/yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out f);

            return f;
        }

        private List<string[]> Ordenar(List<string[]> lista)
        {
            switch (btnOrdenar.Text)
            {
                case "Prioridad (mayor a menor)":
                    return lista.OrderByDescending(d => Numero(d[11])).ToList();

                case "Prioridad (menor a mayor)":
                    return lista.OrderBy(d => Numero(d[11])).ToList();

                case "Fecha (mas reciente)":
                    return lista.OrderByDescending(d => Fecha(d[5])).ToList();

                case "Fecha (mas antigua)":
                    return lista.OrderBy(d => Fecha(d[5])).ToList();

                case "Nombre (A-Z)":
                    return lista.OrderBy(d => d[2] + " " + d[1]).ToList();

                default:
                    return lista.OrderBy(d => d[0]).ToList();
            }
        }

        private Color ColorEstado(string estado)
        {
            switch (estado)
            {
                case "Leve":
                    return Color.FromArgb(39, 174, 96);

                case "Poco leve":
                    return Color.FromArgb(130, 195, 65);

                case "Severo":
                    return Color.FromArgb(229, 169, 26);

                case "Poco severo":
                    return Color.FromArgb(230, 126, 34);

                case "Peligroso":
                    return Color.FromArgb(192, 57, 43);

                default:
                    return Color.Gray;
            }
        }

        private void CrearColumnas()
        {
            dgvPacientes.AutoGenerateColumns = false;
            dgvPacientes.Columns.Clear();

            dgvPacientes.Columns.Add("codigo", "Codigo");
            dgvPacientes.Columns.Add("paciente", "Paciente");
            dgvPacientes.Columns.Add("sexo", "Sexo");
            dgvPacientes.Columns.Add("dni", "DNI");
            dgvPacientes.Columns.Add("fecha", "Fecha");
            dgvPacientes.Columns.Add("solicitud", "Solicitud");
            dgvPacientes.Columns.Add("nivel", "Nivel");
            dgvPacientes.Columns.Add("prioridad", "Prioridad");
            dgvPacientes.Columns.Add("estado", "Estado");

            dgvPacientes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void MostrarEnTabla(List<string[]> lista)
        {
            if (dgvPacientes.Columns.Count != 9)
            {
                CrearColumnas();
            }

            dgvPacientes.Rows.Clear();

            foreach (string[] d in lista)
            {
                int fila = dgvPacientes.Rows.Add(
                    d[0],
                    d[1] + " " + d[2],
                    d[3],
                    d[4],
                    d[5],
                    d[8],
                    d[10],
                    d[11],
                    d[12]);

                // Guardar todos los datos del paciente en la fila.
                dgvPacientes.Rows[fila].Tag = d;

                DataGridViewCell celda =
                    dgvPacientes.Rows[fila].Cells["estado"];

                celda.Style.BackColor = ColorEstado(d[12]);
                celda.Style.ForeColor = Color.White;
                celda.Style.SelectionBackColor = ColorEstado(d[12]);
                celda.Style.SelectionForeColor = Color.White;
            }
        }

        private void MostrarDetalle(string[] d)
        {
            if (d == null || d.Length < 13)
                return;

            lblCodigo.Text = d[0];
            lblNivelDeEmergencia.Text = d[10] + "·" + d[12];
            lblNombresyApellidos.Text = d[1] + " " + d[2];
            lblDNI.Text = d[4];
            lblFecha.Text = d[5].Substring(0, 5);
            lblSexo.Text = d[3];
            lblSolicitud.Text = d[8];
            lblPrioridad.Text = d[11];
            lblDescripcion.Text = d[9];
        }

        private void LimpiarDetalle()
        {
            
            lblNivelDeEmergencia.Text = "-";
            lblNombresyApellidos.Text = "-";
            lblDNI.Text = "-";
            lblFecha.Text = "-";
            lblSexo.Text = "-";
            lblSolicitud.Text = "-";
            lblPrioridad.Text = "-";
            lblDescripcion.Text = "-";
        }

        private void Buscar(bool avisar)
        {
            string criterio = btnBuscarMultiple.Text;
            string texto = txtBuscar.Text.Trim();

            List<string[]> lista = LeerPacientes();

            if (texto != "")
            {
                lista = lista
                    .Where(d => Coincide(d, criterio, texto))
                    .ToList();
            }

            lista = Ordenar(lista);
            MostrarEnTabla(lista);

            if (avisar && lista.Count == 0)
            {
                MessageBox.Show(
                    "No se encontro ningun paciente con ese dato.");

                LimpiarDetalle();
            }
        }

        private void dgvPacientes_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string[] d =
                dgvPacientes.Rows[e.RowIndex].Tag as string[];

            if (d == null)
                return;

            MostrarDetalle(d);
        }

        private void dgvPacientes_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar(true);

            if (dgvPacientes.Rows.Count > 0)
            {
                string[] d =
                    dgvPacientes.Rows[0].Tag as string[];

                if (d != null)
                {
                    dgvPacientes.ClearSelection();
                    dgvPacientes.Rows[0].Selected = true;

                    MostrarDetalle(d);
                }
            }
            else
            {
                LimpiarDetalle();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void btnBuscarMultiple_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
        }

        private void btnOrdenar_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            Buscar(false);
            LimpiarDetalle();
        }

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void Buscador_Load(object sender, EventArgs e)
        {
            Color gris = Color.FromArgb(224, 222, 214);

            Bordear(panel2, 20, 2, gris);
            Bordear(panel3, 20, 2, gris);
            Bordear(panel4, 20, 2, gris);
            Bordear(panel5, 20, 2, gris);
            Bordear(panel6, 20, 2, gris);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void lblDescripcion_Click(object sender, EventArgs e)
        {
        }
    }
}
