namespace ProyectoGrafoFamiliar.Presentacion
{
    partial class VisualizarGrafoForm
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

        private void InitializeComponent()
        {
            this.MapaControl = new GMap.NET.WindowsForms.GMapControl();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // MapaControl
            // 
            this.MapaControl.Bearing = 0F;
            this.MapaControl.CanDragMap = true;
            this.MapaControl.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.MapaControl.Size = new System.Drawing.Size(760, 400);
            this.MapaControl.TabIndex = 0;
            this.MapaControl.Zoom = 7D;

            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Location = new System.Drawing.Point(350, 430);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(100, 30);
            this.BtnCerrar.TabIndex = 1;
            this.BtnCerrar.Text = "Cerrar";
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);

            // 
            // VisualizarGrafoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.MapaControl);
            this.Name = "VisualizarGrafoForm";
            this.Text = "Visualizar Grafo Familiar en Mapa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        private GMap.NET.WindowsForms.GMapControl MapaControl;
        private System.Windows.Forms.Button BtnCerrar;
    }
}