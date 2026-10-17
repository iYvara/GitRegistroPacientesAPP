namespace RegistroDePacientesAPP
{
    partial class Registro
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtNivelDeEmergencia = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAmbulancia = new System.Windows.Forms.RadioButton();
            this.btnMedicamentos = new System.Windows.Forms.RadioButton();
            this.btnCitaMedica = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellidos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "DNI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nivel de emergencia";
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(222, 69);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(478, 26);
            this.txtNombres.TabIndex = 4;
            this.txtNombres.TextChanged += new System.EventHandler(this.txtNombres_TextChanged);
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(222, 127);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(478, 26);
            this.txtApellidos.TabIndex = 5;
            this.txtApellidos.TextChanged += new System.EventHandler(this.txtApellidos_TextChanged);
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(222, 181);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(478, 26);
            this.txtDNI.TabIndex = 6;
            this.txtDNI.TextChanged += new System.EventHandler(this.txtDNI_TextChanged);
            // 
            // txtNivelDeEmergencia
            // 
            this.txtNivelDeEmergencia.Location = new System.Drawing.Point(222, 234);
            this.txtNivelDeEmergencia.Name = "txtNivelDeEmergencia";
            this.txtNivelDeEmergencia.Size = new System.Drawing.Size(478, 26);
            this.txtNivelDeEmergencia.TabIndex = 7;
            this.txtNivelDeEmergencia.TextChanged += new System.EventHandler(this.txtNivelDeEmergencia_TextChanged);
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(295, 373);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(184, 49);
            this.btnIngresar.TabIndex = 8;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(608, 380);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(146, 42);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Solicitud";
            // 
            // btnAmbulancia
            // 
            this.btnAmbulancia.AutoSize = true;
            this.btnAmbulancia.Location = new System.Drawing.Point(222, 293);
            this.btnAmbulancia.Name = "btnAmbulancia";
            this.btnAmbulancia.Size = new System.Drawing.Size(117, 24);
            this.btnAmbulancia.TabIndex = 11;
            this.btnAmbulancia.TabStop = true;
            this.btnAmbulancia.Text = "Ambulancia";
            this.btnAmbulancia.UseVisualStyleBackColor = true;
            this.btnAmbulancia.CheckedChanged += new System.EventHandler(this.btnAmbulancia_CheckedChanged);
            // 
            // btnMedicamentos
            // 
            this.btnMedicamentos.AutoSize = true;
            this.btnMedicamentos.Location = new System.Drawing.Point(562, 289);
            this.btnMedicamentos.Name = "btnMedicamentos";
            this.btnMedicamentos.Size = new System.Drawing.Size(138, 24);
            this.btnMedicamentos.TabIndex = 12;
            this.btnMedicamentos.TabStop = true;
            this.btnMedicamentos.Text = "Medicamentos";
            this.btnMedicamentos.UseVisualStyleBackColor = true;
            this.btnMedicamentos.CheckedChanged += new System.EventHandler(this.btnMedicamentos_CheckedChanged);
            // 
            // btnCitaMedica
            // 
            this.btnCitaMedica.AutoSize = true;
            this.btnCitaMedica.Location = new System.Drawing.Point(398, 291);
            this.btnCitaMedica.Name = "btnCitaMedica";
            this.btnCitaMedica.Size = new System.Drawing.Size(117, 24);
            this.btnCitaMedica.TabIndex = 13;
            this.btnCitaMedica.TabStop = true;
            this.btnCitaMedica.Text = "Cita Medica";
            this.btnCitaMedica.UseVisualStyleBackColor = true;
            this.btnCitaMedica.CheckedChanged += new System.EventHandler(this.btnCitaMedica_CheckedChanged);
            // 
            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCitaMedica);
            this.Controls.Add(this.btnMedicamentos);
            this.Controls.Add(this.btnAmbulancia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtNivelDeEmergencia);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Registro";
            this.Text = "Registro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtNivelDeEmergencia;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton btnAmbulancia;
        private System.Windows.Forms.RadioButton btnMedicamentos;
        private System.Windows.Forms.RadioButton btnCitaMedica;
    }
}