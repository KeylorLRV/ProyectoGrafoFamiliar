using System;
using ProyectoGrafoFamiliar.Datos;

namespace ProyectoGrafoFamiliar.Logica
{
    public class CalculadoraDistancia
    {
        public const double RadioTierraKm = 6371.0; // Radio en kilómetros

        // Retorna distancia en kilómetros entre dos coordenadas
        public double CalcularDistancia(Coordenada coord1, Coordenada coord2)
        {
            double lat1Rad = ToRadian(coord1.Latitud);
            double lat2Rad = ToRadian(coord2.Latitud);
            double deltaLat = ToRadian(coord2.Latitud - coord1.Latitud);
            double deltaLon = ToRadian(coord2.Longitud - coord1.Longitud);

            double a = Math.Sin(deltaLat/2) * Math.Sin(deltaLat/2) +
                       Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                       Math.Sin(deltaLon/2) * Math.Sin(deltaLon/2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1-a));
            double distancia = RadioTierraKm * c;
            return distancia;
        }

        public double CalcularDistanciaPersonas(Persona p1, Persona p2)
        {
            if (p1.Coordenadas == null || p2.Coordenadas == null)
                throw new ArgumentException("Las personas deben tener coordenadas válidas");

            return CalcularDistancia(p1.Coordenadas, p2.Coordenadas);
        }

        private double ToRadian(double angulo)
        {
            return (Math.PI / 180) * angulo;
        }
    }
}