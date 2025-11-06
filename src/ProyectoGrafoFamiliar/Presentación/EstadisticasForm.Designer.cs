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
            this.LblResumen = new System.Windows.Forms.Label();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // LblResumen
            // 
            this.LblResumen.AutoSize = false;
            this.LblResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblResumen.Location = new System.Drawing.Point(12, 12);
            this.LblResumen.Name = "LblResumen";
            this.LblResumen.Size = new System.Drawing.Size(560, 200);
            this.LblResumen.TabIndex = 0;
            this.LblResumen.Text = "Cargando estadísticas...";

            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Location = new System.Drawing.Point(250, 230);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(100, 30);
            this.BtnCerrar.TabIndex = 1;
            this.BtnCerrar.Text = "Cerrar";
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);

            // 
            // EstadisticasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 280);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.LblResumen);
            this.Name = "EstadisticasForm";
            this.Text = "Estadísticas Familiares";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label LblResumen;
        private System.Windows.Forms.Button BtnCerrar;
    }
}