
namespace ProyectoGrafoFamiliar.Presentacion
{
    partial class EstadisticasForm
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
            this.lblResumen = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.flowLayoutPanelPersonas = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();

            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = false;
            this.lblResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumen.Location = new System.Drawing.Point(12, 12);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(790, 100);
            this.lblResumen.TabIndex = 0;
            this.lblResumen.Text = "Cargando estadísticas...";

            // 
            // flowLayoutPanelPersonas
            // 
            this.flowLayoutPanelPersonas.AutoScroll = true;
            this.flowLayoutPanelPersonas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown; // Cambiado para apilar verticalmente las secciones
            this.flowLayoutPanelPersonas.Location = new System.Drawing.Point(12, 120);
            this.flowLayoutPanelPersonas.Name = "flowLayoutPanelPersonas";
            this.flowLayoutPanelPersonas.Size = new System.Drawing.Size(790, 400); // Aumentar ancho para mayor espacio
            this.flowLayoutPanelPersonas.TabIndex = 2;
            this.flowLayoutPanelPersonas.WrapContents = false; // No envolver para mantener secciones apiladas
            this.flowLayoutPanelPersonas.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelPersonas.Margin = new System.Windows.Forms.Padding(0);

            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(350, 530); // Posición ajustada según tamaño form
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 30);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);

            // 
            // EstadisticasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 580); // Mayor altura y ancho para acomodar tarjetas
            this.Controls.Add(this.flowLayoutPanelPersonas);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblResumen);
            this.Name = "EstadisticasForm";
            this.Text = "Estadísticas Familiares";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPersonas;
    }
}