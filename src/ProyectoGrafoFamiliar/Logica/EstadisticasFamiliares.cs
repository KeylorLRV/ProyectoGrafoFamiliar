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

        // Retorna el par de personas más cercanas en el grafo
        public Tuple<Persona, Persona> ObtenerParMasCercano()
        {
            double minDist = double.MaxValue;
            Persona p1 = null, p2 = null;

            foreach (var origen in Grafo.Nodos)
            {
                foreach(var destino in Grafo.Nodos)
                {
                    if (origen == destino) continue;

                    double dist = Calculadora.CalcularDistanciaPersonas(origen, destino);
                    if (dist < minDist)
                    {
                        minDist = dist;
                        p1 = origen;
                        p2 = destino;
                    }
                }
            }
            return new Tuple<Persona, Persona>(p1, p2);
        }

        // Retorna el par de personas más lejanas en el grafo
        public Tuple<Persona, Persona> ObtenerParMasLejano()
        {
            double maxDist = double.MinValue;
            Persona p1 = null, p2 = null;

            foreach (var origen in Grafo.Nodos)
            {
                foreach(var destino in Grafo.Nodos)
                {
                    if (origen == destino) continue;

                    double dist = Calculadora.CalcularDistanciaPersonas(origen, destino);
                    if (dist > maxDist)
                    {
                        maxDist = dist;
                        p1 = origen;
                        p2 = destino;
                    }
                }
            }
            return new Tuple<Persona, Persona>(p1, p2);
        }

        // Retorna la distancia promedio entre todas las personas
        public double CalculaDistanciaPromedio()
        {
            double sumaDistancias = 0;
            int contador = 0;

            for (int i = 0; i < Grafo.Nodos.Count; i++)
            {
                for (int j = i + 1; j < Grafo.Nodos.Count; j++)
                {
                    sumaDistancias += Calculadora.CalcularDistanciaPersonas(Grafo.Nodos[i], Grafo.Nodos[j]);
                    contador++;
                }
            }
            return (contador == 0) ? 0 : sumaDistancias / contador;
        }

        // Genera resumen textual
        public string GenerarResumen()
        {
            var cercano = ObtenerParMasCercano();
            var lejano = ObtenerParMasLejano();
            double promedio = CalculaDistanciaPromedio();

            return $"Par más cercano: {cercano.Item1.Cedula} - {cercano.Item2.Cedula} ({Calculadora.CalcularDistanciaPersonas(cercano.Item1, cercano.Item2):F2} km)\n" +
                   $"Par más lejano: {lejano.Item1.Cedula} - {lejano.Item2.Cedula} ({Calculadora.CalcularDistanciaPersonas(lejano.Item1, lejano.Item2):F2} km)\n" +
                   $"Distancia promedio: {promedio:F2} km";
        }
    }
}