// EstadisticasForm.cs
using System;
using System.Windows.Forms;
using ProyectoGrafoFamiliar.Logica;

namespace ProyectoGrafoFamiliar.Presentacion
{
    public partial class EstadisticasForm : Form
    {
        private EstadisticasFamiliares estadisticas;

        public EstadisticasForm(EstadisticasFamiliares est)
        {
            InitializeComponent();
            estadisticas = est;
            MostrarEstadisticas();
        }

        private void MostrarEstadisticas()
        {
            var resumen = estadisticas.GenerarResumen();
            // Asume un Label llamado LblResumen en Designer
            LblResumen.Text = resumen;
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}