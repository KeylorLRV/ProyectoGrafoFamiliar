using System;

namespace ProyectoGrafoFamiliar.Datos
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
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
            return $"{Nombre} {Apellidos} (Cédula: {Cedula}, Edad: {Edad})";
        }

        public bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(Nombre)) return false;
            if (string.IsNullOrWhiteSpace(Apellidos)) return false;
            if (string.IsNullOrWhiteSpace(Cedula)) return false;
            if (Coordenadas == null || !Coordenadas.EsValida()) return false;
            if (FechaNac == DateTime.MinValue) return false;
            if (Foto == null || Foto.Length == 0) return false;
            return true;
        }
    }
}