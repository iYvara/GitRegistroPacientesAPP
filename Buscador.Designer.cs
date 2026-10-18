namespace RegistroDePacientesAPP
{
    partial class Buscador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvPacientes = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNombresyApellidos = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDNI = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.lblNivelDeEmergencia = new System.Windows.Forms.Label();
            this.lblSolicitud = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnOrdenar = new System.Windows.Forms.ComboBox();
            this.btnBuscarMultiple = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Escriba el codigo del paciente:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Courier New", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(152, 64);
            this.txtBuscar.Multiline = true;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(191, 28);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(222)))), ((int)(((byte)(214)))));
            this.btnSalir.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.btnSalir.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnSalir.Location = new System.Drawing.Point(70, 397);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(145, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(48)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Font = new System.Drawing.Font("Goudy Stout", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1060, 109);
            this.panel1.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 6F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(731, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "El Agustino, Lima - Peru";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::RegistroDePacientesAPP.Properties.Resources.images_removebg_preview;
            this.pictureBox3.Location = new System.Drawing.Point(921, -64);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(254, 290);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Garamond", 8F);
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(123, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 18);
            this.label10.TabIndex = 2;
            this.label10.Text = "Buscador de Pacientes";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Franklin Gothic Heavy", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(119, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 37);
            this.label3.TabIndex = 1;
            this.label3.Text = "HIPOLITO UNANUE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Demi", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(121, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "HOSPITAL NACIONAL";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::RegistroDePacientesAPP.Properties.Resources.images_removebg_preview;
            this.pictureBox4.Location = new System.Drawing.Point(-108, -64);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(254, 290);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Location = new System.Drawing.Point(12, 244);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(720, 380);
            this.panel2.TabIndex = 20;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(239)))), ((int)(((byte)(234)))));
            this.panel5.Controls.Add(this.dgvPacientes);
            this.panel5.Location = new System.Drawing.Point(25, 26);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(671, 330);
            this.panel5.TabIndex = 21;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // dgvPacientes
            // 
            this.dgvPacientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(38)))), ((int)(((byte)(59)))));
            this.dgvPacientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacientes.GridColor = System.Drawing.Color.Khaki;
            this.dgvPacientes.Location = new System.Drawing.Point(19, 16);
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.RowHeadersWidth = 62;
            this.dgvPacientes.RowTemplate.Height = 28;
            this.dgvPacientes.Size = new System.Drawing.Size(633, 301);
            this.dgvPacientes.TabIndex = 0;
            this.dgvPacientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Location = new System.Drawing.Point(746, 124);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(320, 500);
            this.panel3.TabIndex = 21;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(239)))), ((int)(((byte)(234)))));
            this.panel6.Controls.Add(this.lblCodigo);
            this.panel6.Controls.Add(this.lblNombresyApellidos);
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Controls.Add(this.lblDNI);
            this.panel6.Controls.Add(this.label21);
            this.panel6.Controls.Add(this.lblSexo);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Controls.Add(this.lblDescripcion);
            this.panel6.Controls.Add(this.lblPrioridad);
            this.panel6.Controls.Add(this.lblNivelDeEmergencia);
            this.panel6.Controls.Add(this.lblSolicitud);
            this.panel6.Controls.Add(this.lblFecha);
            this.panel6.Controls.Add(this.label19);
            this.panel6.Controls.Add(this.btnSalir);
            this.panel6.Controls.Add(this.label18);
            this.panel6.Controls.Add(this.label17);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Location = new System.Drawing.Point(21, 26);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(280, 450);
            this.panel6.TabIndex = 4;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // lblCodigo
            // 
            this.lblCodigo.Font = new System.Drawing.Font("MS Reference Sans Serif", 7F);
            this.lblCodigo.Location = new System.Drawing.Point(118, 38);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(114, 27);
            this.lblCodigo.TabIndex = 36;
            this.lblCodigo.Text = "PAC-0000";
            // 
            // lblNombresyApellidos
            // 
            this.lblNombresyApellidos.Font = new System.Drawing.Font("MS Reference Sans Serif", 7F);
            this.lblNombresyApellidos.Location = new System.Drawing.Point(118, 67);
            this.lblNombresyApellidos.Name = "lblNombresyApellidos";
            this.lblNombresyApellidos.Size = new System.Drawing.Size(159, 27);
            this.lblNombresyApellidos.TabIndex = 35;
            this.lblNombresyApellidos.Text = "Nombres y Apellidos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RegistroDePacientesAPP.Properties.Resources.profile;
            this.pictureBox1.Location = new System.Drawing.Point(14, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Font = new System.Drawing.Font("MS Reference Sans Serif", 6F);
            this.lblDNI.Location = new System.Drawing.Point(167, 137);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(0, 16);
            this.lblDNI.TabIndex = 33;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("MS Reference Sans Serif", 6F);
            this.label21.Location = new System.Drawing.Point(16, 136);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 16);
            this.label21.TabIndex = 32;
            this.label21.Text = "DNI:";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Font = new System.Drawing.Font("MS Reference Sans Serif", 6F);
            this.lblSexo.Location = new System.Drawing.Point(167, 162);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(0, 16);
            this.lblSexo.TabIndex = 31;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("MS Reference Sans Serif", 6F);
            this.label14.Location = new System.Drawing.Point(16, 162);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 16);
            this.label14.TabIndex = 30;
            this.label14.Text = "Sexo:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("MS Reference Sans Serif", 6F);
            this.lblDescripcion.Location = new System.Drawing.Point(16, 349);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(105, 16);
            this.lblDescripcion.TabIndex = 29;
            this.lblDescripcion.Text = "Observaciones:";
            this.lblDescripcion.Click += new System.EventHandler(this.lblDescripcion_Click);
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.Font = new System.Drawing.Font("MS Reference Sans Serif", 6F);
            this.lblPrioridad.Location = new System.Drawing.Point(167, 272);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(0, 16);
            this.lblPrioridad.TabIndex = 28;
            // 
            // lblNivelDeEmergencia
            // 
            this.lblNivelDeEmergencia.AutoSize = true;
            this.lblNivelDeEmergencia.Font = new System.Drawing.Font("MS Reference Sans Serif", 6F);
            this.lblNivelDeEmergencia.Location = new System.Drawing.Point(167, 242);
            this.lblNivelDeEmergencia.Name = "lblNivelDeEmergencia";
            this.lblNivelDeEmergencia.Size = new System.Drawing.Size(0, 16);
            this.lblNivelDeEmergencia.TabIndex = 27;
            // 
            // lblSolicitud
            // 
            this.lblSolicitud.AutoSize = true;
            this.lblSolicitud.Font = new System.Drawing.Font("MS Reference Sans Serif", 6F);
            this.lblSolicitud.Location = new System.Drawing.Point(167, 216);
            this.lblSolicitud.Name = "lblSolicitud";
            this.lblSolicitud.Size = new System.Drawing.Size(0, 16);
            this.lblSolicitud.TabIndex = 26;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("MS Reference Sans Serif", 6F);
            this.lblFecha.Location = new System.Drawing.Point(167, 189);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 16);
            this.lblFecha.TabIndex = 25;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("MS Reference Sans Serif", 6F);
            this.label19.Location = new System.Drawing.Point(11, 315);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(105, 16);
            this.label19.TabIndex = 24;
            this.label19.Text = "Observaciones:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("MS Reference Sans Serif", 6F);
            this.label18.Location = new System.Drawing.Point(16, 272);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 16);
            this.label18.TabIndex = 23;
            this.label18.Text = "Prioridad:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("MS Reference Sans Serif", 6F);
            this.label17.Location = new System.Drawing.Point(16, 242);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(139, 16);
            this.label17.TabIndex = 22;
            this.label17.Text = "Nivel de emergencia:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("MS Reference Sans Serif", 6F);
            this.label15.Location = new System.Drawing.Point(16, 189);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 16);
            this.label15.TabIndex = 20;
            this.label15.Text = "Fecha:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("MS Reference Sans Serif", 6F);
            this.label16.Location = new System.Drawing.Point(16, 216);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 16);
            this.label16.TabIndex = 21;
            this.label16.Text = "Solicitud:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(239)))));
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.btnBuscar);
            this.panel4.Controls.Add(this.btnOrdenar);
            this.panel4.Controls.Add(this.btnBuscarMultiple);
            this.panel4.Controls.Add(this.txtBuscar);
            this.panel4.Location = new System.Drawing.Point(12, 124);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(720, 110);
            this.panel4.TabIndex = 22;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label7.Location = new System.Drawing.Point(483, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(223, 32);
            this.label7.TabIndex = 7;
            this.label7.Text = "Ordenar por:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(269, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Consulta la informacion de pacientes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label5.Location = new System.Drawing.Point(22, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 32);
            this.label5.TabIndex = 5;
            this.label5.Text = "Busca pacientes";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(222)))), ((int)(((byte)(214)))));
            this.btnBuscar.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnBuscar.Location = new System.Drawing.Point(359, 64);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(108, 28);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // btnOrdenar
            // 
            this.btnOrdenar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrdenar.FormattingEnabled = true;
            this.btnOrdenar.Location = new System.Drawing.Point(538, 58);
            this.btnOrdenar.Name = "btnOrdenar";
            this.btnOrdenar.Size = new System.Drawing.Size(168, 30);
            this.btnOrdenar.TabIndex = 4;
            this.btnOrdenar.SelectedIndexChanged += new System.EventHandler(this.btnOrdenar_SelectedIndexChanged);
            // 
            // btnBuscarMultiple
            // 
            this.btnBuscarMultiple.Font = new System.Drawing.Font("Courier New", 10F);
            this.btnBuscarMultiple.FormattingEnabled = true;
            this.btnBuscarMultiple.Location = new System.Drawing.Point(25, 64);
            this.btnBuscarMultiple.Name = "btnBuscarMultiple";
            this.btnBuscarMultiple.Size = new System.Drawing.Size(121, 30);
            this.btnBuscarMultiple.TabIndex = 3;
            this.btnBuscarMultiple.SelectedIndexChanged += new System.EventHandler(this.btnBuscarMultiple_SelectedIndexChanged);
            // 
            // Buscador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(222)))), ((int)(((byte)(214)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1078, 644);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximizeBox = false;
            this.Name = "Buscador";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscador";
            this.Load += new System.EventHandler(this.Buscador_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox btnOrdenar;
        private System.Windows.Forms.ComboBox btnBuscarMultiple;
        private System.Windows.Forms.DataGridView dgvPacientes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPrioridad;
        private System.Windows.Forms.Label lblNivelDeEmergencia;
        private System.Windows.Forms.Label lblSolicitud;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNombresyApellidos;
        private System.Windows.Forms.Label lblCodigo;
    }
}