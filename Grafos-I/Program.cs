using System;
using System.Collections.Generic;

// =============================
// Módulo: Representación del Grafo
// =============================

// Esta clase representa un grafo usando una lista de adyacencia.
// Permite agregar nodos y aristas, y visualizar el grafo de manera sencilla.
class Grafo
{
    // Diccionario para almacenar los nodos y sus conexiones (aristas)
    private Dictionary<string, List<string>> adyacencias;

    public Grafo()
    {
        adyacencias = new Dictionary<string, List<string>>();
    }

    // =============================
    // Módulo: Agregar Nodo
    // =============================
    // Este método agrega un nodo al grafo si no existe ya.
    public void AgregarNodo(string nodo)
    {
        if (!adyacencias.ContainsKey(nodo))
            adyacencias[nodo] = new List<string>();
    }

    // =============================
    // Módulo: Agregar Arista
    // =============================
    // Este método conecta dos nodos; crea los nodos si no existen.
    // Para un grafo dirigido, solo conecta de origen a destino.
    public void AgregarArista(string origen, string destino)
    {
        AgregarNodo(origen);
        AgregarNodo(destino);
        adyacencias[origen].Add(destino);
        // Si quieres grafo no dirigido, descomenta la siguiente línea:
        // adyacencias[destino].Add(origen);
    }

    // =============================
    // Módulo: Mostrar Grafo
    // =============================
    // Este método imprime cada nodo y sus conexiones de manera explícita.
    public void Mostrar()
    {
        Console.WriteLine("\nLista de Adyacencia:");
        Console.WriteLine("===================");
        
        foreach (var nodo in adyacencias)
        {
            if (nodo.Value.Count > 0)
            {
                Console.Write($"Nodo {nodo.Key} está conectado a: ");
                for (int i = 0; i < nodo.Value.Count; i++)
                {
                    Console.Write(nodo.Value[i]);
                    if (i < nodo.Value.Count - 1)
                        Console.Write(", ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Nodo {nodo.Key} no tiene conexiones salientes.");
            }
        }
        
        Console.WriteLine("\nRelaciones (Aristas):");
        Console.WriteLine("=====================");
        foreach (var nodo in adyacencias)
        {
            foreach (var vecino in nodo.Value)
            {
                Console.WriteLine($"  {nodo.Key} -> {vecino}");
            }
        }
    }
}

// =============================
// Módulo: Programa Principal
// =============================
// Este módulo crea el grafo, agrega nodos/aristas y muestra el resultado.
class Program
{
    static void Main(string[] args)
    {
        Grafo grafo = new Grafo();

        // Agregar aristas, los nodos se crean automáticamente
        grafo.AgregarArista("A", "B");
        grafo.AgregarArista("A", "C");
        grafo.AgregarArista("B", "D");
        grafo.AgregarArista("C", "D");
        grafo.AgregarArista("D", "E");

        Console.WriteLine("Representación elemental de un Grafo:");
        grafo.Mostrar();
    }
}

