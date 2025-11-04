using System;
using System.Windows.Forms;
using ProyectoGrafoFamiliar.Datos;
using ProyectoGrafoFamiliar.Logica;
using ProyectoGrafoFamiliar.Presentacion;

namespace ProyectoGrafoFamiliar.Presentacion
{
    public partial class MainForm : Form
    {
        private GrafoFamiliar grafo;
        private VisualizadorMapa visualizador;
        private CalculadoraDistancia calculadora;

        public MainForm()
        {
            try
            {
                InitializeComponent();

                grafo = new GrafoFamiliar();
                calculadora = new CalculadoraDistancia();
                visualizador = new VisualizadorMapa(MapaControl);

                visualizador.CargarMapa();
            }
            catch (Exception ex)
            {
                // Log and surface a friendly message
                Program.LogException(ex);
                MessageBox.Show("Ocurrió un error al inicializar la ventana principal. Revise logs/startup.log para más detalles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void AgregarPersona_Click(object sender, EventArgs e)
        {
            // Validar y crear persona
            if (string.IsNullOrWhiteSpace(TxtCedula.Text))
            {
                MessageBox.Show("Ingrese una cédula válida.");
                return;
            }

            // Crear coordenada y persona (solo ejemplo estático; adaptalo)
            var coord = new Coordenada() { Latitud = 9.935, Longitud = -84.081 }; // Ejemplo Costa Rica
            var persona = new Persona()
            {
                Cedula = TxtCedula.Text.Trim(),
                Coordenadas = coord,
                FechaNac = DateTime.Now.AddYears(-30), // Ejemplo edad 30 años
                Foto = null // Aquí carga byte[] de foto si tienes
            };

            if (!persona.ValidarDatos())
            {
                MessageBox.Show("Datos inválidos en la persona.");
                return;
            }

            grafo.AgregarNodo(persona);
            visualizador.AgregarMarcador(persona);

            MessageBox.Show($"Persona {persona.Cedula} agregada al grafo y mapa.");
        }

        private void MapaControl_OnMarkerClick(GMap.NET.WindowsForms.GMapMarker marker, MouseEventArgs e)
        {
            // Ejemplo: Mostrar tooltip o info al clicar marcadores
            MessageBox.Show(marker.ToolTipText);
        }

        private void MostrarEstadisticas()
        {
            EstadisticasFamiliares estadisticas = new EstadisticasFamiliares(grafo, calculadora);
            string resumen = estadisticas.GenerarResumen();
            MessageBox.Show(resumen, "Estadísticas del Grafo Familiar");
        }
    }
}
