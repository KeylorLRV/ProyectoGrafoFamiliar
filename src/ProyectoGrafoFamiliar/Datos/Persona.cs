using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoGrafoFamiliar.Datos
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public enum Genero { Masculino, Femenino, Otro }
        public Genero Sexo { get; set; } = Genero.Otro;
        public Persona Padre { get; set; }
        public Persona Madre { get; set; }
        public List<Persona> Hijos { get; set; } = new List<Persona>();

        public List<Persona> Hermanos { get; set; } = new List<Persona>();
        public Persona Conyuge { get; set; }
        public byte[] Foto { get; set; }
        public string Cedula { get; set; }
        public Coordenada Coordenadas { get; set; }
        public DateTime FechaNac { get; set; }
        public bool EstaVivo { get; set; } = true;

        public int Edad => CalcularEdad();
        public string NombreCompleto => $"{Nombre} {Apellidos}";

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
        //Establece el padre de esta persona
        public void EstablecerPadre(Persona padre)
        {
            if (padre == null) return;
        
            // Validar que no sea la misma persona
            if (padre == this)
                throw new InvalidOperationException("Una persona no puede ser su propio padre");
        
            // Validar género 
            if (padre.Sexo == Genero.Femenino)
                throw new InvalidOperationException("El padre debe ser de género masculino. Use EstablecerMadre()");
        
            // Validar que el padre sea mayor
            if (padre.FechaNac >= this.FechaNac)
                throw new InvalidOperationException("El padre debe ser mayor que el hijo");
        
            // Remover de la lista de hijos del padre anterior si existe
            if (this.Padre != null)
            {
                this.Padre.Hijos.Remove(this);
            }
        
            // Establecer nuevo padre
            this.Padre = padre;
        
            // Agregar a la lista de hijos del padre
            if (!padre.Hijos.Contains(this))
            {
                padre.Hijos.Add(this);
            }
        }
        public void EstablecerHermano(Persona hermano)
        {
            if (hermano == null) return;
            if (hermano == this) throw new InvalidOperationException("Una persona no puede ser su propio hermano");
            if (EsParienteDirecto(hermano)) throw new InvalidOperationException("Ya es un pariente directo, no se puede agregar como hermano adicional");
            if (!Hermanos.Contains(hermano))
            {
                Hermanos.Add(hermano);
                hermano.Hermanos.Add(this); // Bidireccional
            }
        }
        // Actualizar ObtenerHermanos para incluir biológicos y manuales
        public List<Persona> ObtenerHermanos()
        {
            var hermanos = new HashSet<Persona>(Hermanos); // Incluir manuales
            // Hermanos por parte del padre
            if (Padre != null)
            {
                foreach (var hijo in Padre.Hijos)
                {
                    if (hijo != this) hermanos.Add(hijo);
                }
            }
            // Hermanos por parte de la madre
            if (Madre != null)
            {
                foreach (var hijo in Madre.Hijos)
                {
                    if (hijo != this) hermanos.Add(hijo);
                }
            }
            return hermanos.ToList();
        }
        
        //Establece la madre de esta persona
        public void EstablecerMadre(Persona madre)
        {
            if (madre == null) return;
        
            // Validar que no sea la misma persona
            if (madre == this)
                throw new InvalidOperationException("Una persona no puede ser su propia madre");
        
            // Validar género 
            if (madre.Sexo == Genero.Masculino)
                throw new InvalidOperationException("La madre debe ser de género femenino. Use EstablecerPadre()");
        
            // Validar que la madre sea mayor
            if (madre.FechaNac >= this.FechaNac)
                throw new InvalidOperationException("La madre debe ser mayor que el hijo");
        
            // Remover de la lista de hijos de la madre anterior si existe
            if (this.Madre != null)
            {
                this.Madre.Hijos.Remove(this);
            }
        
            // Establecer nueva madre
            this.Madre = madre;
        
            // Agregar a la lista de hijos de la madre
            if (!madre.Hijos.Contains(this))
            {
                madre.Hijos.Add(this);
            }
        }
        
          
        // Establece el cónyuge de esta persona
        public void EstablecerConyuge(Persona conyuge)
        {
            if (conyuge == null) return;
        
            // Validar que no sea la misma persona
            if (conyuge == this)
                throw new InvalidOperationException("Una persona no puede ser su propio cónyuge");
        
            // Validar que no sea un pariente directo
            if (EsParienteDirecto(conyuge))
                throw new InvalidOperationException("No se puede establecer como cónyuge a un pariente directo");
        
            // Remover cónyuge anterior 
            if (this.Conyuge != null)
            {
                this.Conyuge.Conyuge = null;
            }
        
            if (conyuge.Conyuge != null)
            {
                conyuge.Conyuge.Conyuge = null;
            }
            if (conyuge == this) throw new InvalidOperationException("Una persona no puede ser su propio cónyuge");
            if (EsParienteDirecto(conyuge)) throw new InvalidOperationException("No se puede establecer como cónyuge a un pariente directo");
            // Remover cónyuge anterior
            if (this.Conyuge != null) this.Conyuge.Conyuge = null;
            if (conyuge.Conyuge != null) conyuge.Conyuge.Conyuge = null;
            // Establecer relación bidireccional
            this.Conyuge = conyuge;
            conyuge.Conyuge = this;
            // Agregar hijos de esta persona al cónyuge
            foreach (var hijo in this.Hijos)
            {
                if (!conyuge.Hijos.Contains(hijo))
                {
                    conyuge.Hijos.Add(hijo); // Agregar sin cambiar padre/madre biológico
                }
            }
        }
        
        // Agrega un hijo a esta persona
        public void AgregarHijo(Persona hijo)
        {
            if (hijo == null) return;
        
            // Validar que no sea la misma persona
            if (hijo == this)
                throw new InvalidOperationException("Una persona no puede ser su propio hijo");
        
            // Validar que el hijo sea menor
            if (hijo.FechaNac <= this.FechaNac)
                throw new InvalidOperationException("El hijo debe ser menor que el padre/madre");
        
            // Establecer relación según género
            if (this.Sexo == Genero.Masculino)
            {
                hijo.EstablecerPadre(this);
            }
            else if (this.Sexo == Genero.Femenino)
            {
                hijo.EstablecerMadre(this);
            }
            else
            {
                // Si no se especifica género, solo agregar a lista de hijos
                if (!this.Hijos.Contains(hijo))
                {
                    this.Hijos.Add(hijo);
                }
            }
        }
        
        // Verifica si otra persona es un pariente directo (padre, madre, hijo, hermano)
        public bool EsParienteDirecto(Persona otra)
        {
            if (otra == null) return false;
            if (otra == this) return true;
        
            // Es padre o madre
            if (this.Padre == otra || this.Madre == otra) return true;
        
            // Es hijo
            if (this.Hijos.Contains(otra)) return true;
        
            // Es hermano (mismo padre o madre)
            if (this.Padre != null && this.Padre == otra.Padre) return true;
            if (this.Madre != null && this.Madre == otra.Madre) return true;
        
            return false;
        }
        
        // Obtiene los abuelos de esta persona
        public List<Persona> ObtenerAbuelos()
        {
            var abuelos = new List<Persona>();
        
            if (Padre != null)
            {
                if (Padre.Padre != null) abuelos.Add(Padre.Padre);
                if (Padre.Madre != null) abuelos.Add(Padre.Madre);
            }
        
            if (Madre != null)
            {
                if (Madre.Padre != null) abuelos.Add(Madre.Padre);
                if (Madre.Madre != null) abuelos.Add(Madre.Madre);
            }
        
            return abuelos;
        }
        
        //Obtiene todos los nietos de esta persona
        public List<Persona> ObtenerNietos()
        {
            var nietos = new List<Persona>();
        
            foreach (var hijo in Hijos)
            {
                nietos.AddRange(hijo.Hijos);
            }
        
            return nietos;
        }
        
        // Calcula la generación de esta persona respecto a una raíz
        public int CalcularGeneracion(Persona raiz)
        {
            if (this == raiz) return 0;
        
            int generacion = 0;
            var actual = this;
        
            // Subir por el árbol hasta encontrar la raíz o llegar al tope
            while (actual != null && actual != raiz)
            {
                generacion++;
                // Priorizar padre, luego madre
                actual = actual.Padre ?? actual.Madre;
        
                // Evitar bucles infinitos
                if (generacion > 20) break;
            }
        
            return actual == raiz ? generacion : -1; // -1 si no está relacionado
        }
        
        //Obtiene una descripción de las relaciones familiares
        public string ObtenerDescripcionRelaciones()
        {
            var relaciones = new List<string>();
            

            if (Padre != null)
                relaciones.Add($"Padre: {Padre.NombreCompleto}");
        
            if (Madre != null)
                relaciones.Add($"Madre: {Madre.NombreCompleto}");
        
            if (Conyuge != null)
                relaciones.Add($"Cónyuge: {Conyuge.NombreCompleto}");
        
            if (Hijos.Count > 0)
                relaciones.Add($"Hijos: {Hijos.Count}");
        
            var hermanos = ObtenerHermanos();
            if (hermanos.Count > 0)
                relaciones.Add($"Hermanos: {hermanos.Count}");
        
            return relaciones.Count > 0
                ? string.Join(" | ", relaciones)
                : "Sin relaciones familiares registradas";
        }

        public string ObtenerGeneroTexto()
        {
            switch (Sexo)
            {
                case Genero.Masculino:
                    return "Masculino";
                case Genero.Femenino:
                    return "Femenino";
                case Genero.Otro:
                    return "Otro";
                default:
                    return "No especificado";
            }
        }
    }
}
