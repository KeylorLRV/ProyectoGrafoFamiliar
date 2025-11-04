using System;

namespace ProyectoGrafoFamiliar.Datos
{
    public class Persona
    {
        public byte[] Foto { get; set; }
        public string Cedula { get; set; }
        public Coordenada Coordenadas { get; set; }
        public DateTime FechaNac { get; set; }

        public int Edad => CalcularEdad();

        public int CalcularEdad()
        {
            var hoy = DateTime.Today;
            int edad = hoy.Year - FechaNac.Year;
            if (FechaNac.Date > hoy.AddYears(-edad)) edad--;
            return edad;
        }

        public override string ToString()
        {
            return $"Cédula: {Cedula}, Edad: {Edad}, Coordenadas: {Coordenadas}";
        }

        public bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(Cedula)) return false;
            if (Coordenadas == null || !Coordenadas.EsValida()) return false;
            if (FechaNac == DateTime.MinValue) return false;
            // Podrías agregar validación para Foto no nula o mínima longitud según sea necesario
            return true;
        }
    }
}