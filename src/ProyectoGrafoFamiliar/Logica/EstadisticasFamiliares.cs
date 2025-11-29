using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoGrafoFamiliar.Datos;

namespace ProyectoGrafoFamiliar.Logica
{
    public class EstadisticasFamiliares
    {
        public GrafoFamiliar Grafo { get; private set; }
        public CalculadoraDistancia Calculadora { get; private set; }

        public EstadisticasFamiliares(GrafoFamiliar grafo, CalculadoraDistancia calculadora)
        {
            Grafo = grafo;
            Calculadora = calculadora;
        }

        // Nuevo método: Calcula la distancia mínima entre dos personas usando Dijkstra (a través de conexiones en el grafo)
        public double CalcularDistanciaViaGrafo(Persona origen, Persona destino)
        {
            if (origen == destino) return 0.0;

            // Diccionario para distancias mínimas
            var distancias = new Dictionary<Persona, double>();
            // Conjunto ordenado para la cola de prioridad (distancia, persona)
            var cola = new SortedSet<(double dist, Persona p)>();

            // Inicializar distancias
            foreach (var persona in Grafo.Nodos)
            {
                distancias[persona] = double.MaxValue;
            }
            distancias[origen] = 0.0;
            cola.Add((0.0, origen));

            while (cola.Count > 0)
            {
                // Extraer el nodo con la menor distancia
                var actual = cola.Min;
                cola.Remove(actual);
                var (distActual, personaActual) = actual;

                // Si llegamos al destino, podemos detenernos
                if (personaActual == destino) break;

                // Explorar vecinos (conexiones en el grafo)
                foreach (var vecino in Grafo.ObtenerRelaciones(personaActual))
                {
                    // Peso de la arista: distancia geográfica directa entre personaActual y vecino
                    double peso = Calculadora.CalcularDistanciaPersonas(personaActual, vecino);
                    double nuevaDist = distActual + peso;

                    // Si encontramos una distancia menor, actualizar
                    if (nuevaDist < distancias[vecino])
                    {
                        // Remover la entrada anterior si existe (SortedSet no permite actualización directa)
                        cola.Remove((distancias[vecino], vecino));
                        distancias[vecino] = nuevaDist;
                        cola.Add((nuevaDist, vecino));
                    }
                }
            }

            // Retornar la distancia si es finita; -1 si no hay camino
            return distancias[destino] == double.MaxValue ? -1.0 : distancias[destino];
        }

        // Modificado: Retorna el par de personas más cercanas basado en distancia vía grafo
        public Tuple<Persona, Persona> ObtenerParMasCercano()
        {
            double minDist = double.MaxValue;
            Persona p1 = null, p2 = null;

            foreach (var origen in Grafo.Nodos)
            {
                foreach (var destino in Grafo.Nodos)
                {
                    if (origen == destino) continue;

                    double dist = CalcularDistanciaViaGrafo(origen, destino);
                    if (dist >= 0 && dist < minDist)  // Solo considerar distancias válidas (>=0)
                    {
                        minDist = dist;
                        p1 = origen;
                        p2 = destino;
                    }
                }
            }
            return new Tuple<Persona, Persona>(p1, p2);
        }

        // Modificado: Retorna el par de personas más lejanas basado en distancia vía grafo
        public Tuple<Persona, Persona> ObtenerParMasLejano()
        {
            double maxDist = double.MinValue;
            Persona p1 = null, p2 = null;

            foreach (var origen in Grafo.Nodos)
            {
                foreach (var destino in Grafo.Nodos)
                {
                    if (origen == destino) continue;

                    double dist = CalcularDistanciaViaGrafo(origen, destino);
                    if (dist >= 0 && dist > maxDist)  // Solo considerar distancias válidas (>=0)
                    {
                        maxDist = dist;
                        p1 = origen;
                        p2 = destino;
                    }
                }
            }
            return new Tuple<Persona, Persona>(p1, p2);
        }

        // Modificado: Retorna la distancia promedio entre todas las personas (solo conexiones válidas)
        public double CalculaDistanciaPromedio()
        {
            double sumaDistancias = 0;
            int contador = 0;

            for (int i = 0; i < Grafo.Nodos.Count; i++)
            {
                for (int j = i + 1; j < Grafo.Nodos.Count; j++)
                {
                    double dist = CalcularDistanciaViaGrafo(Grafo.Nodos[i], Grafo.Nodos[j]);
                    if (dist >= 0)  // Solo sumar distancias válidas
                    {
                        sumaDistancias += dist;
                        contador++;
                    }
                }
            }
            return (contador == 0) ? 0 : sumaDistancias / contador;
        }

        // Modificado: Genera resumen textual usando distancias vía grafo
        public string GenerarResumen()
        {
            var cercano = ObtenerParMasCercano();
            var lejano = ObtenerParMasLejano();
            double promedio = CalculaDistanciaPromedio();

            string resumenCercano = (cercano.Item1 != null && cercano.Item2 != null) 
                ? $"{cercano.Item1.Nombre} - {cercano.Item2.Nombre} ({CalcularDistanciaViaGrafo(cercano.Item1, cercano.Item2):F2} km)" 
                : "No hay pares conectados";

            string resumenLejano = (lejano.Item1 != null && lejano.Item2 != null) 
                ? $"{lejano.Item1.Nombre} - {lejano.Item2.Nombre} ({CalcularDistanciaViaGrafo(lejano.Item1, lejano.Item2):F2} km)" 
                : "No hay pares conectados";

            return $"Par más cercano: {resumenCercano}\n" +
                   $"Par más lejano: {resumenLejano}\n" +
                   $"Distancia promedio: {promedio:F2} km";
        }
    }
}