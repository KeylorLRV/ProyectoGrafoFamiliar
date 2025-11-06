namespace ProyectoGrafoFamiliar.Presentacion
{
    partial class MainForm : System.Windows.Forms.Form
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
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            this.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            // 
            // TxtCedula
            // 
            this.TxtCedula = new System.Windows.Forms.TextBox();
            this.TxtCedula.Location = new System.Drawing.Point(0, 0);
            this.TxtCedula.Name = "TxtCedula";
            this.TxtCedula.Size = new System.Drawing.Size(100, 23);
            this.TxtCedula.TabIndex = 0;
            this.TxtCedula.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.TxtCedula.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.TxtCedula.Text = "TxtCedula";
            // 
            // AgregarPersona
            // 
            this.AgregarPersona = new System.Windows.Forms.Button();
            this.AgregarPersona.Location = new System.Drawing.Point(0, 0);
            this.AgregarPersona.Name = "AgregarPersona";
            this.AgregarPersona.Size = new System.Drawing.Size(100, 23);
            this.AgregarPersona.TabIndex = 0;
            this.AgregarPersona.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.AgregarPersona.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.AgregarPersona.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AgregarPersona.Text = "AgregarPersona";
            
            //
            // MapaControl
            //
            this.MapaControl = new GMap.NET.WindowsForms.GMapControl();
            this.MapaControl.Bearing = 0F;
            this.MapaControl.CanDragMap = true;
            this.MapaControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.MapaControl.GrayScaleMode = false;
            this.MapaControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MapaControl.LevelsKeepInMemmory = 5;
            this.MapaControl.Location = new System.Drawing.Point(15, 50);
            this.MapaControl.MarkersEnabled = true;
            this.MapaControl.MaxZoom = 18;
            this.MapaControl.MinZoom = 2;
            this.MapaControl.MouseWheelZoomEnabled = true;
            this.MapaControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.MapaControl.Name = "MapaControl";
            this.MapaControl.ShowTileGridLines = false;
            this.MapaControl.Size = new System.Drawing.Size(640, 380);
            this.MapaControl.TabIndex = 2;
            this.MapaControl.Zoom = 5D;
            this.MapaControl.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.MapaControl_OnMarkerClick);
            // Añadir controles al formulario
            this.Controls.Add(this.TxtCedula);
            this.Controls.Add(this.AgregarPersona);
            this.Controls.Add(this.MapaControl);
            this.ResumeLayout(false);
        }

        #endregion

        // Control declarations
        private System.Windows.Forms.TextBox TxtCedula;
        private System.Windows.Forms.Button AgregarPersona;
        private GMap.NET.WindowsForms.GMapControl MapaControl;
    }
}