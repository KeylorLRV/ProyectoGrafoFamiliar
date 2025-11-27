// VisualizarGrafoForm.cs
using GMap.NET;
using GMap.NET.WindowsForms;
using ProyectoGrafoFamiliar.Datos;
using ProyectoGrafoFamiliar.Logica;
using System;
using System.Windows.Forms;

namespace ProyectoGrafoFamiliar.Presentacion
{
    public partial class VisualizarGrafoForm : Form
    {
        private GrafoFamiliar grafo;
        private CalculadoraDistancia calculadora;
        private VisualizadorMapa visualizador;

        public VisualizarGrafoForm(GrafoFamiliar g, CalculadoraDistancia c)
        {
            InitializeComponent();
            grafo = g;
            calculadora = c;
            
            ConfigurarMapa();
            visualizador = new VisualizadorMapa(MapaControl);
            CargarMapaConGrafo();
        }

        private void ConfigurarMapa()
        {
            MapaControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            MapaControl.Position = new PointLatLng(9.748917, -83.753428); // Centro en Costa Rica
            MapaControl.MinZoom = 2;
            MapaControl.MaxZoom = 18;
            MapaControl.Zoom = 7;
            MapaControl.DragButton = MouseButtons.Left;
            MapaControl.CanDragMap = true;
            MapaControl.MouseWheelZoomEnabled = true;
            MapaControl.ShowCenter = false;
            
            // Habilitar el uso de cache para mejor rendimiento
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            try
            {
                // Intentar cargar el mapa
                MapaControl.Manager.Mode = AccessMode.ServerAndCache;
                MapaControl.Position = new PointLatLng(9.748917, -83.753428);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el mapa: " + ex.Message);
            }
        }

        private void CargarMapaConGrafo()
        {
            try
            {
                visualizador.CargarMapa();

                var overlay = new GMapOverlay("Grafo");
                MapaControl.Overlays.Add(overlay);

                foreach (var persona in grafo.Nodos)
                {
                    visualizador.AgregarMarcador(persona);
                    // Dibujar líneas a conexiones
                    foreach (var relacionada in grafo.ObtenerRelaciones(persona))
                    {
                        var punto = new PointLatLng(persona.Coordenadas.Latitud, persona.Coordenadas.Longitud);
                        var puntoRel = new PointLatLng(relacionada.Coordenadas.Latitud, relacionada.Coordenadas.Longitud);
                        var ruta = new GMapRoute(new[] { punto, puntoRel }, "Conexion");
                        ruta.Stroke = new System.Drawing.Pen(System.Drawing.Color.Red, 2);
                        overlay.Routes.Add(ruta);
                    }
                    
                }
                MapaControl.Refresh(); // Asegurar que se muestren todos los marcadores y rutas
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el grafo en el mapa: " + ex.Message);
            }
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}