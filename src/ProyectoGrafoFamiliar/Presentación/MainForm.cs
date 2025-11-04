using System;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using ProyectoGrafoFamiliar.Datos;
using ProyectoGrafoFamiliar.Logica;
using System.Collections.Generic;

namespace ProyectoGrafoFamiliar.Presentacion
{
    public partial class MainForm : Form
    {
        public TextBox TxtCedula { get; private set; }
        public Button AgregarPersona { get; private set; }
        public GMapControl MapaControl { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            // Inicializar controles aquí o en InitializeComponent
        }


        private void AgregarPersona_Click(object sender, EventArgs e)
        {
            // TODO: Lógica para agregar persona usando TxtCedula y otros controles
            MessageBox.Show($"Se agregó la persona con cédula: {TxtCedula.Text}");
        }

        // Event handler para clics en el mapa (ejemplo)
        private void MapaControl_OnMarkerClick(GMap.NET.WindowsForms.GMapMarker item, MouseEventArgs e)
        {
            // TODO: Mostrar distancias o información al hacer clic en un marcador
        }

        private void MostrarEstadisticas()
        {
            // TODO: Mostrar estadísticas del grafo en UI o MessageBox
        }
    }
}
