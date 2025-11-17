namespace ProyectoGrafoFamiliar.Presentacion
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellidos = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblLatitud = new System.Windows.Forms.Label();
            this.numLatitud = new System.Windows.Forms.NumericUpDown();
            this.lblLongitud = new System.Windows.Forms.Label();
            this.numLongitud = new System.Windows.Forms.NumericUpDown();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblFoto = new System.Windows.Forms.Label();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.btnCargarFoto = new System.Windows.Forms.Button();
            this.btnAgregarPersona = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numLatitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLongitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.lblNombre.Location = new System.Drawing.Point(30, 30);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(50, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.txtNombre.Location = new System.Drawing.Point(150, 27);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblApellidos
            // 
            this.lblApellidos.AutoSize = true;
            this.lblApellidos.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.lblApellidos.Location = new System.Drawing.Point(30, 60);
            this.lblApellidos.Name = "lblApellidos";
            this.lblApellidos.Size = new System.Drawing.Size(52, 13);
            this.lblApellidos.TabIndex = 2;
            this.lblApellidos.Text = "Apellidos:";
            // 
            // txtApellidos
            // 
            this.txtApellidos.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtApellidos.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.txtApellidos.Location = new System.Drawing.Point(150, 57);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(200, 20);
            this.txtApellidos.TabIndex = 3;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.lblCedula.Location = new System.Drawing.Point(30, 90);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(43, 13);
            this.lblCedula.TabIndex = 4;
            this.lblCedula.Text = "Cédula:";
            // 
            // txtCedula
            // 
            this.txtCedula.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtCedula.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.txtCedula.Location = new System.Drawing.Point(150, 87);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(200, 20);
            this.txtCedula.TabIndex = 5;
            // 
            // lblLatitud
            // 
            this.lblLatitud.AutoSize = true;
            this.lblLatitud.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.lblLatitud.Location = new System.Drawing.Point(30, 120);
            this.lblLatitud.Name = "lblLatitud";
            this.lblLatitud.Size = new System.Drawing.Size(45, 13);
            this.lblLatitud.TabIndex = 6;
            this.lblLatitud.Text = "Latitud:";
            // 
            // numLatitud
            // 
            this.numLatitud.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.numLatitud.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.numLatitud.DecimalPlaces = 6;
            this.numLatitud.Location = new System.Drawing.Point(150, 117);
            this.numLatitud.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
            this.numLatitud.Minimum = new decimal(new int[] { 90, 0, 0, -2147483648 });
            this.numLatitud.Name = "numLatitud";
            this.numLatitud.Size = new System.Drawing.Size(200, 20);
            this.numLatitud.TabIndex = 7;
            // 
            // lblLongitud
            // 
            this.lblLongitud.AutoSize = true;
            this.lblLongitud.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.lblLongitud.Location = new System.Drawing.Point(30, 150);
            this.lblLongitud.Name = "lblLongitud";
            this.lblLongitud.Size = new System.Drawing.Size(51, 13);
            this.lblLongitud.TabIndex = 8;
            this.lblLongitud.Text = "Longitud:";
            // 
            // numLongitud
            // 
            this.numLongitud.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.numLongitud.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.numLongitud.DecimalPlaces = 6;
            this.numLongitud.Location = new System.Drawing.Point(150, 147);
            this.numLongitud.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            this.numLongitud.Minimum = new decimal(new int[] { 180, 0, 0, -2147483648 });
            this.numLongitud.Name = "numLongitud";
            this.numLongitud.Size = new System.Drawing.Size(200, 20);
            this.numLongitud.TabIndex = 9;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.lblFechaNacimiento.Location = new System.Drawing.Point(30, 180);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(96, 13);
            this.lblFechaNacimiento.TabIndex = 10;
            this.lblFechaNacimiento.Text = "Fecha Nacimiento:";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.CalendarMonthBackground = System.Drawing.Color.FromArgb(30, 30, 30);
            this.dtpFechaNacimiento.CalendarForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(150, 177);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaNacimiento.TabIndex = 11;
            // 
            // lblFoto
            // 
            this.lblFoto.AutoSize = true;
            this.lblFoto.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.lblFoto.Location = new System.Drawing.Point(30, 210);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(31, 13);
            this.lblFoto.TabIndex = 12;
            this.lblFoto.Text = "Foto:";
            // 
            // picFoto
            // 
            this.picFoto.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFoto.Location = new System.Drawing.Point(150, 210);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(120, 120);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 13;
            this.picFoto.TabStop = false;
            // 
            // btnCargarFoto
            // 
            this.btnCargarFoto.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnCargarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarFoto.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.btnCargarFoto.Location = new System.Drawing.Point(280, 210);
            this.btnCargarFoto.Name = "btnCargarFoto";
            this.btnCargarFoto.Size = new System.Drawing.Size(70, 30);
            this.btnCargarFoto.TabIndex = 14;
            this.btnCargarFoto.Text = "Cargar...";
            this.btnCargarFoto.UseVisualStyleBackColor = false;
            this.btnCargarFoto.Click += new System.EventHandler(this.BtnCargarFoto_Click);
            // 
            // btnAgregarPersona
            // 
            this.btnAgregarPersona.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnAgregarPersona.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPersona.ForeColor = System.Drawing.Color.White;
            this.btnAgregarPersona.Location = new System.Drawing.Point(50, 350);
            this.btnAgregarPersona.Name = "btnAgregarPersona";
            this.btnAgregarPersona.Size = new System.Drawing.Size(140, 35);
            this.btnAgregarPersona.TabIndex = 15;
            this.btnAgregarPersona.Text = "Agregar Persona";
            this.btnAgregarPersona.UseVisualStyleBackColor = false;
            this.btnAgregarPersona.Click += new System.EventHandler(this.AgregarPersona_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.btnVolver.Location = new System.Drawing.Point(210, 350);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(140, 35);
            this.btnVolver.TabIndex = 16;
            this.btnVolver.Text = "Volver al Menú";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            this.ClientSize = new System.Drawing.Size(400, 420);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAgregarPersona);
            this.Controls.Add(this.btnCargarFoto);
            this.Controls.Add(this.picFoto);
            this.Controls.Add(this.lblFoto);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.lblFechaNacimiento);
            this.Controls.Add(this.numLongitud);
            this.Controls.Add(this.lblLongitud);
            this.Controls.Add(this.numLatitud);
            this.Controls.Add(this.lblLatitud);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.lblCedula);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.lblApellidos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Persona al Grafo Familiar";
            ((System.ComponentModel.ISupportInitialize)(this.numLatitud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLongitud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellidos;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblLatitud;
        private System.Windows.Forms.NumericUpDown numLatitud;
        private System.Windows.Forms.Label lblLongitud;
        private System.Windows.Forms.NumericUpDown numLongitud;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Button btnCargarFoto;
        private System.Windows.Forms.Button btnAgregarPersona;
        private System.Windows.Forms.Button btnVolver;
    }
}
