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
            this.lblPadre = new System.Windows.Forms.Label();
            this.cmbPadre = new System.Windows.Forms.ComboBox();
            this.lblMadre = new System.Windows.Forms.Label();
            this.cmbMadre = new System.Windows.Forms.ComboBox();
            this.lblConyuge = new System.Windows.Forms.Label();
            this.cmbConyuge = new System.Windows.Forms.ComboBox();
            this.lblHijos = new System.Windows.Forms.Label();
            this.lstHijos = new System.Windows.Forms.ListBox();
            this.lblHermanos = new System.Windows.Forms.Label();
            this.lstHermanos = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numLatitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLongitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // Configuración de lblPadre
            this.lblPadre.AutoSize = true;
            this.lblPadre.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.lblPadre.Location = new System.Drawing.Point(420, 180);
            this.lblPadre.Name = "lblPadre";
            this.lblPadre.Size = new System.Drawing.Size(40, 13);
            this.lblPadre.TabIndex = 17;
            this.lblPadre.Text = "Padre:";
            //
            // Configuración de cmbPadre
            this.cmbPadre.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.cmbPadre.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.cmbPadre.Location = new System.Drawing.Point(490, 177);
            this.cmbPadre.Name = "cmbPadre";
            this.cmbPadre.Size = new System.Drawing.Size(200, 21);
            this.cmbPadre.TabIndex = 18;
            //
            // Configuración de lblMadre
            this.lblMadre.AutoSize = true;
            this.lblMadre.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.lblMadre.Location = new System.Drawing.Point(420, 210);
            this.lblMadre.Name = "lblMadre";
            this.lblMadre.Size = new System.Drawing.Size(45, 13);
            this.lblMadre.TabIndex = 19;
            this.lblMadre.Text = "Madre:";
            //
            // Configuración de cmbMadre
            this.cmbMadre.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.cmbMadre.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.cmbMadre.Location = new System.Drawing.Point(490, 207);
            this.cmbMadre.Name = "cmbMadre";
            this.cmbMadre.Size = new System.Drawing.Size(200, 21);
            this.cmbMadre.TabIndex = 20;
            //
            // Configuración de lblConyuge
            this.lblConyuge.AutoSize = true;
            this.lblConyuge.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.lblConyuge.Location = new System.Drawing.Point(420, 240);
            this.lblConyuge.Name = "lblConyuge";
            this.lblConyuge.Size = new System.Drawing.Size(55, 13);
            this.lblConyuge.TabIndex = 21;
            this.lblConyuge.Text = "Cónyuge:";
            //
            // Configuración de cmbConyuge
            this.cmbConyuge.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.cmbConyuge.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.cmbConyuge.Location = new System.Drawing.Point(490, 237);
            this.cmbConyuge.Name = "cmbConyuge";
            this.cmbConyuge.Size = new System.Drawing.Size(200, 21);
            this.cmbConyuge.TabIndex = 22;
            //
            // Configuración de lblHijos
            this.lblHijos.AutoSize = true;
            this.lblHijos.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.lblHijos.Location = new System.Drawing.Point(420, 270);
            this.lblHijos.Name = "lblHijos";
            this.lblHijos.Size = new System.Drawing.Size(35, 13);
            this.lblHijos.TabIndex = 23;
            this.lblHijos.Text = "Hijos:";
            //
            // Configuración de lstHijos
            this.lstHijos.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lstHijos.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.lstHijos.Location = new System.Drawing.Point(490, 267);
            this.lstHijos.Name = "lstHijos";
            this.lstHijos.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstHijos.Size = new System.Drawing.Size(200, 60);
            this.lstHijos.TabIndex = 24;
            //
            // Configuración de lblHermanos
            this.lblHermanos.AutoSize = true;
            this.lblHermanos.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.lblHermanos.Location = new System.Drawing.Point(420, 340); // Ajustar posición
            this.lblHermanos.Name = "lblHermanos";
            this.lblHermanos.Size = new System.Drawing.Size(50, 13);
            this.lblHermanos.TabIndex = 25;
            this.lblHermanos.Text = "Hermanos:";
            //
            // Configuración de lstHermanos
            this.lstHermanos.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lstHermanos.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.lstHermanos.Location = new System.Drawing.Point(490, 337); // Ajustar posición
            this.lstHermanos.Name = "lstHermanos";
            this.lstHermanos.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstHermanos.Size = new System.Drawing.Size(200, 60);
            this.lstHermanos.TabIndex = 26;
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
            this.btnAgregarPersona.Location = new System.Drawing.Point(140, 400);
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
            this.btnVolver.Location = new System.Drawing.Point(300, 400);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(140, 35);
            this.btnVolver.TabIndex = 16;
            this.btnVolver.Text = "Volver al Menú";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
           
            // Agregar después de los controles existentes
            this.MapaControl = new GMap.NET.WindowsForms.GMapControl();
            this.MapaControl.Bearing = 0F;
            this.MapaControl.CanDragMap = true;
            this.MapaControl.Dock = System.Windows.Forms.DockStyle.None; // No dock, posicionar manualmente
            this.MapaControl.EmptyTileColor = System.Drawing.Color.FromArgb(37, 37, 38);
            this.MapaControl.GrayScaleMode = false;
            this.MapaControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MapaControl.MarkersEnabled = true;
            this.MapaControl.MaxZoom = 18;
            this.MapaControl.MinZoom = 2;
            this.MapaControl.MouseWheelZoomEnabled = true;
            this.MapaControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.MapaControl.Name = "MapaControl";
            this.MapaControl.NegativeMode = false;
            this.MapaControl.ShowCenter = false;
            this.MapaControl.ShowTileGridLines = false;
            this.MapaControl.Size = new System.Drawing.Size(320, 150); // Tamaño del mapa
            this.MapaControl.Location = new System.Drawing.Point(420, 10); // Posición a la derecha de los campos
            this.MapaControl.TabIndex = 17;
            this.MapaControl.Zoom = 7D;
            this.Controls.Add(this.MapaControl);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            this.ClientSize = new System.Drawing.Size(800, 450); // Aumentar ancho para incluir el mapa
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
            this.Controls.Add(this.lblPadre);
            this.Controls.Add(this.cmbPadre);
            this.Controls.Add(this.lblMadre);
            this.Controls.Add(this.cmbMadre);
            this.Controls.Add(this.lblConyuge);
            this.Controls.Add(this.cmbConyuge);
            this.Controls.Add(this.lblHijos);
            this.Controls.Add(this.lstHijos);
            this.Controls.Add(this.lblHermanos);
            this.Controls.Add(this.lstHermanos);
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
        private GMap.NET.WindowsForms.GMapControl MapaControl;

        private System.Windows.Forms.Label lblPadre;
        private System.Windows.Forms.ComboBox cmbPadre;
        private System.Windows.Forms.Label lblMadre;
        private System.Windows.Forms.ComboBox cmbMadre;
        private System.Windows.Forms.Label lblConyuge;
        private System.Windows.Forms.ComboBox cmbConyuge;
        private System.Windows.Forms.Label lblHijos;
        private System.Windows.Forms.ListBox lstHijos;

        private System.Windows.Forms.Label lblHermanos;
        private System.Windows.Forms.ListBox lstHermanos;
    }
}
