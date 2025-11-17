using System.Collections.Generic;
using GMap.NET.WindowsForms;
using GMap.NET;
using ProyectoGrafoFamiliar.Datos;
using System.Windows.Forms;

namespace ProyectoGrafoFamiliar.Presentacion
{
    public class VisualizadorMapa
    {
        public GMapControl Mapa { get; private set; }
        public List<GMapMarker> Marcadores { get; private set; }

        public VisualizadorMapa(GMapControl mapaControl)
        {
            Mapa = mapaControl;
            Marcadores = new List<GMapMarker>();

            // Configuración básica del mapa
            Mapa.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            Mapa.MinZoom = 0;
            Mapa.MaxZoom = 24;
            Mapa.Zoom = 2;
        }

        public void CargarMapa()
        {
            // Inicializar o refrescar el mapa si es necesario
            Mapa.Position = new PointLatLng(0, 0);
        }

        public void AgregarMarcador(Persona persona)
        {
            if (persona.Coordenadas == null) return;

            var punto = new PointLatLng(persona.Coordenadas.Latitud, persona.Coordenadas.Longitud);
            var marcador = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(punto, GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_dot);
            marcador.ToolTipText = $"Cédula: {persona.Cedula}";

            Mapa.Overlays.Clear();
            var overlay = new GMapOverlay("Marcadores");
            overlay.Markers.Add(marcador);
            Mapa.Overlays.Add(overlay);

            Marcadores.Add(marcador);
        }

        public void MostrarDistancia(Persona origen, Persona destino)
        {
            // Aquí puedes implementar lógica para mostrar distancia en tooltip o label
            // Ejemplo simple:
            MessageBox.Show($"Distancia entre {origen.Cedula} y {destino.Cedula}: " +
                $"{new Logica.CalculadoraDistancia().CalcularDistanciaPersonas(origen, destino):F2} km");
        }
    }
}