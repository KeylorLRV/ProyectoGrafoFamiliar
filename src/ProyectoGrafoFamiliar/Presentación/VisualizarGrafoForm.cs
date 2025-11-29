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

            MapaControl.MouseClick += MapaControl_MouseClick;
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
        private void MapaControl_MouseClick(object sender, MouseEventArgs e)
        {
            // Convertir coordenadas del mouse a lat/lng
            var puntoClic = MapaControl.FromLocalToLatLng(e.X, e.Y);
            
            // Buscar el marcador más cercano dentro de un umbral (aprox. 1 km en grados)
            GMapMarker marcadorClicado = null;
            double distanciaMin = double.MaxValue;
            const double umbral = 0.01; // Ajusta según necesidad (0.01 grados ≈ 1 km)
            
            foreach (var overlay in MapaControl.Overlays)
            {
                foreach (var marker in overlay.Markers)
                {
                    // Calcular distancia euclidiana simple (no es exacta, pero suficiente para proximidad)
                    double dist = Math.Sqrt(Math.Pow(marker.Position.Lat - puntoClic.Lat, 2) + Math.Pow(marker.Position.Lng - puntoClic.Lng, 2));
                    if (dist < distanciaMin && dist < umbral)
                    {
                        distanciaMin = dist;
                        marcadorClicado = marker;
                    }
                }
            }
            
            // Si se encontró un marcador cercano y tiene una Persona asociada
            if (marcadorClicado != null && marcadorClicado.Tag is Persona personaSeleccionada)
            {
                // Crear instancia de EstadisticasFamiliares para calcular distancias vía grafo
                var estadisticas = new EstadisticasFamiliares(grafo, calculadora);
                
                // Construir mensaje con distancias
                string mensaje = $"Distancias desde {personaSeleccionada.NombreCompleto} (vía conexiones en el grafo):\n\n";
                bool hayDistancias = false;
                
                foreach (var otraPersona in grafo.Nodos)
                {
                    if (otraPersona != personaSeleccionada)
                    {
                        double distancia = estadisticas.CalcularDistanciaViaGrafo(personaSeleccionada, otraPersona);
                        if (distancia >= 0)  // Solo mostrar si hay un camino (distancia válida)
                        {
                            mensaje += $"{otraPersona.NombreCompleto}: {distancia:F2} km\n";
                            hayDistancias = true;
                        }
                    }
                }
                
                if (!hayDistancias)
                {
                    mensaje += "No hay personas conectadas en el grafo.";
                }
                
                // Mostrar en MessageBox
                MessageBox.Show(mensaje, "Distancias Familiares", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}