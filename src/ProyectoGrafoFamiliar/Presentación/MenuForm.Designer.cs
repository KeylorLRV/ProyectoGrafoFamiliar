namespace ProyectoGrafoFamiliar.Presentacion
{
    partial class MenuForm
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
            this.BtnAgregarPersona = new System.Windows.Forms.Button();
            this.BtnVisualizarGrafo = new System.Windows.Forms.Button();
            this.BtnVisualizarEstadisticas = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.Location = new System.Drawing.Point(60, 20);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(250, 24);
            this.LblTitulo.TabIndex = 0;
            this.LblTitulo.Text = "Menú Principal - Grafo Familiar";

            // 
            // BtnAgregarPersona
            // 
            this.BtnAgregarPersona.Location = new System.Drawing.Point(100, 70);
            this.BtnAgregarPersona.Name = "BtnAgregarPersona";
            this.BtnAgregarPersona.Size = new System.Drawing.Size(200, 40);
            this.BtnAgregarPersona.TabIndex = 1;
            this.BtnAgregarPersona.Text = "Agregar Persona al Grafo";
            this.BtnAgregarPersona.UseVisualStyleBackColor = true;
            this.BtnAgregarPersona.Click += new System.EventHandler(this.BtnAgregarPersona_Click);

            // 
            // BtnVisualizarGrafo
            // 
            this.BtnVisualizarGrafo.Location = new System.Drawing.Point(100, 130);
            this.BtnVisualizarGrafo.Name = "BtnVisualizarGrafo";
            this.BtnVisualizarGrafo.Size = new System.Drawing.Size(200, 40);
            this.BtnVisualizarGrafo.TabIndex = 2;
            this.BtnVisualizarGrafo.Text = "Visualizar Grafo en Mapa";
            this.BtnVisualizarGrafo.UseVisualStyleBackColor = true;
            this.BtnVisualizarGrafo.Click += new System.EventHandler(this.BtnVisualizarGrafo_Click);

            // 
            // BtnVisualizarEstadisticas
            // 
            this.BtnVisualizarEstadisticas.Location = new System.Drawing.Point(100, 190);
            this.BtnVisualizarEstadisticas.Name = "BtnVisualizarEstadisticas";
            this.BtnVisualizarEstadisticas.Size = new System.Drawing.Size(200, 40);
            this.BtnVisualizarEstadisticas.TabIndex = 3;
            this.BtnVisualizarEstadisticas.Text = "Visualizar Estadísticas Familiares";
            this.BtnVisualizarEstadisticas.UseVisualStyleBackColor = true;
            this.BtnVisualizarEstadisticas.Click += new System.EventHandler(this.BtnVisualizarEstadisticas_Click);

            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.BtnVisualizarEstadisticas);
            this.Controls.Add(this.BtnVisualizarGrafo);
            this.Controls.Add(this.BtnAgregarPersona);
            this.Controls.Add(this.LblTitulo);
            this.Name = "MenuForm";
            this.Text = "Menú Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button BtnAgregarPersona;
        private System.Windows.Forms.Button BtnVisualizarGrafo;
        private System.Windows.Forms.Button BtnVisualizarEstadisticas;
        private System.Windows.Forms.Label LblTitulo;
    }
}