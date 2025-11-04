using System;
using System.Collections.Generic;
using ProyectoGrafoFamiliar.Datos;

namespace ProyectoGrafoFamiliar.Logica
{
    public class GrafoFamiliar
    {
        public List<Persona> Nodos { get; private set; } = new List<Persona>();
        public Dictionary<Persona, List<Persona>> Adyacencias { get; private set; } = new Dictionary<Persona, List<Persona>>();

        public void AgregarNodo(Persona persona)
        {
            if (!Nodos.Contains(persona))
            {
                Nodos.Add(persona);
                Adyacencias[persona] = new List<Persona>();
            }
        }

        public void AgregarConexion(Persona origen, Persona destino)
        {
            if (Nodos.Contains(origen) && Nodos.Contains(destino))
            {
                if (!Adyacencias[origen].Contains(destino))
                    Adyacencias[origen].Add(destino);
                // Si se desea que la relación sea bidireccional, agregar la siguiente línea
                // Adyacencias[destino].Add(origen);
            }
        }

        public List<Persona> ObtenerRelaciones(Persona persona)
        {
            if (Adyacencias.ContainsKey(persona))
            {
                return Adyacencias[persona];
            }
            return new List<Persona>();
        }

        public bool EsConexo()
        {
            if (Nodos.Count == 0) return true;

            var visitados = new HashSet<Persona>();
            var cola = new Queue<Persona>();
            cola.Enqueue(Nodos[0]);
            visitados.Add(Nodos[0]);

            while (cola.Count > 0)
            {
                var actual = cola.Dequeue();
                foreach (var vecino in ObtenerRelaciones(actual))
                {
                    if (!visitados.Contains(vecino))
                    {
                        visitados.Add(vecino);
                        cola.Enqueue(vecino);
                    }
                }
            }
            // El grafo es conexo si todos los nodos se visitaron
            return visitados.Count == Nodos.Count;
        }

        public List<Persona> RecorrerArbol(Persona inicio)
        {
            var visitados = new List<Persona>();
            var pila = new Stack<Persona>();
            pila.Push(inicio);

            while (pila.Count > 0)
            {
                var actual = pila.Pop();
                if (!visitados.Contains(actual))
                {
                    visitados.Add(actual);
                    foreach (var vecino in ObtenerRelaciones(actual))
                    {
                        if (!visitados.Contains(vecino))
                            pila.Push(vecino);
                    }
                }
            }
            return visitados;
        }
    }
}
