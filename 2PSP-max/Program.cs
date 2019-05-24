using System;
using System.Collections.Generic;

namespace _2PSP_max
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Edge> edges = new List<Edge>{new Edge(0, 6, 11), new Edge(0, 1, 5),
                                        new Edge(1, 6, 3), new Edge(1, 5, 5),
                                        new Edge(1, 2, 7), new Edge(2, 3, -8),
                                        new Edge(3, 4, 10), new Edge(5, 2, -1),
                                        new Edge(5, 3, 9), new Edge(5, 4, 1),
                                        new Edge(6, 5, 2), new Edge(7, 6, 9),
                                        new Edge(7, 1, 6)
            };

            int N = 9;

            // create a graph from edges
            Graph g = new Graph(edges, N);

            int src = 0;

            // Do modified BFS traversal from source vertex src
            var maxCost = g.ModifiedBFS(src);
            foreach (var v in maxCost)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();

        }
    }
}