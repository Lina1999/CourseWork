using System;
using System.Collections.Generic;
using System.Text;

namespace _2PSP_max
{
    public class Vertex
    {
        public int Number { get; set; }
        public int Weight { get; set; }

        //set of nodes visited in current path 
        public HashSet<int> Visiteds { get; set; }

        private List<Vertex> neighbors;

        public IList<Vertex> Neighbors
        {
            get
            {
                return this.neighbors.AsReadOnly();
            }
        }

        public Vertex(int number, int weight)
        {
            Weight = weight;
            Number = number;
            neighbors = new List<Vertex>();
        }

        public Vertex(int number, int weight, HashSet<int> visiteds): this(number, weight)
        {
            Visiteds = visiteds;
        }

        public bool TryAddNeighbor(Vertex neighbor)
        {
            if (!neighbors.Contains(neighbor))
            {
                neighbors.Add(neighbor);
                return true;
            }
            return false;
        }

        public bool TryRemoveNeighbor(Vertex neighbor)
        {
            return neighbors.Remove(neighbor);
        }

        public bool RemoveAllNeighbors()
        {
            for (int i = neighbors.Count - 1; i >= 0; --i)
            {
                neighbors.RemoveAt(i);
            }
            return true;
        }

        public int DistanceTo(Vertex v)
        {
            return Math.Abs(this.Weight - v.Weight);
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            s.Append("Vertex Weight: " + Weight + ", Neighbors: ");
            foreach (var vertex in neighbors)
            {
                s.Append(vertex.Weight + " ");
            }
            return s.ToString();
        }
        
    }
}