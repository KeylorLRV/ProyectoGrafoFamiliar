namespace ProyectoGrafoFamiliar.Datos
{
    public class Coordenada
    {
        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public override string ToString()
        {
            return $"Latitud: {Latitud}, Longitud: {Longitud}";
        }

        public bool EsValida()
        {
            // Latitud entre -90 y 90, longitud entre -180 y 180 (validación simple)
            return Latitud >= -90 && Latitud <= 90 && Longitud >= -180 && Longitud <= 180;
        }
    }
}