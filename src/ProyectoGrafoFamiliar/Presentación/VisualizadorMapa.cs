using System.Collections.Generic;
using System.Linq;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using ProyectoGrafoFamiliar.Datos;
using System.Windows.Forms;
using System.Drawing;
using System.IO;


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

            // Configuración básica del mapa (igual que antes)
            Mapa.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            Mapa.MinZoom = 0;
            Mapa.MaxZoom = 24;
            Mapa.Zoom = 2;

            // Crear un overlay persistente para marcadores
            var overlay = new GMapOverlay("MarcadoresPersonas");
            Mapa.Overlays.Add(overlay);
        }

        public void CargarMapa()
        {
            // Inicializar o refrescar el mapa si es necesario
            Mapa.Position = new PointLatLng(0, 0);
        }

        public void AgregarMarcador(Persona persona)
        {
            if (persona.Coordenadas == null || persona.Foto == null) return;

            var punto = new PointLatLng(persona.Coordenadas.Latitud, persona.Coordenadas.Longitud);

            // Crear un marcador personalizado con la foto
            var marker = new GMarkerGoogle(punto, GMarkerGoogleType.arrow);
            marker.ToolTipText = $"{persona.Nombre} {persona.Apellidos} (Cédula: {persona.Cedula}, Edad: {persona.Edad})"; // Tooltip con info

            // Agregar al overlay existente (sin borrar)
            var overlay = Mapa.Overlays.FirstOrDefault(o => o.Id == "MarcadoresPersonas");
            if (overlay != null)
            {
                overlay.Markers.Add(marker);
            }

            Marcadores.Add(marker);
            Mapa.Refresh(); // Refrescar el mapa para mostrar el nuevo marcador
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