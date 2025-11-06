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
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Name = "MainForm";
            this.Text = "Agregar Persona";
            this.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            this.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            // 
            // TxtCedula
            // 
            this.TxtCedula = new System.Windows.Forms.TextBox();
            this.TxtCedula.Location = new System.Drawing.Point(150, 50);
            this.TxtCedula.Name = "TxtCedula";
            this.TxtCedula.Size = new System.Drawing.Size(100, 23);
            this.TxtCedula.TabIndex = 0;
            this.TxtCedula.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.TxtCedula.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.TxtCedula.Text = "";
            this.Controls.Add(this.TxtCedula);
            // 
            // LblCedula
            // 
            this.LblCedula = new System.Windows.Forms.Label();
            this.LblCedula.Location = new System.Drawing.Point(150, 30);
            this.LblCedula.Name = "LblCedula";
            this.LblCedula.Size = new System.Drawing.Size(100, 13);
            this.LblCedula.TabIndex = 2;
            this.LblCedula.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.LblCedula.BackColor = System.Drawing.Color.Transparent;
            this.LblCedula.Text = "Cédula:";
            this.Controls.Add(this.LblCedula);
            // 
            // AgregarPersona
            // 
            this.AgregarPersona = new System.Windows.Forms.Button();
            this.AgregarPersona.Location = new System.Drawing.Point(150, 100);
            this.AgregarPersona.Name = "AgregarPersona";
            this.AgregarPersona.Size = new System.Drawing.Size(100, 23);
            this.AgregarPersona.TabIndex = 0;
            this.AgregarPersona.ForeColor = System.Drawing.Color.FromArgb(204, 204, 204);
            this.AgregarPersona.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.AgregarPersona.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AgregarPersona.Text = "Agregar Persona";
            this.AgregarPersona.Click += new System.EventHandler(this.AgregarPersona_Click);
            this.Controls.Add(this.AgregarPersona);
            // 
            // Form controls collection
            // 
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.TxtCedula,
                this.LblCedula,
                this.AgregarPersona
            });
            this.ResumeLayout(false);
        }

        #endregion

        // Control declarations
        private System.Windows.Forms.TextBox TxtCedula;
        private System.Windows.Forms.Label LblCedula;
        private System.Windows.Forms.Button AgregarPersona;
    }
}