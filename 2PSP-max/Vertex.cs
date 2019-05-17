using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2PSP_max
{
    public class Vertex
    {
        private int weight;
        public int Weight
        {
            get
            {
                return this.weight;
            }
        }

        private List<Vertex> neighbors;
        
        public IList<Vertex> Neighbors
        {
            get
            {
                return this.neighbors.AsReadOnly();
            }
        }

        public Vertex(int weight)
        {
            this.weight = weight;
            neighbors = new List<Vertex>();
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

        public override string ToString()
        {
            var s = new StringBuilder();
            s.Append("Vertex Weight: " + weight + ", Neighbors: ");
            foreach (var vertex in neighbors)
            {
                s.Append(vertex.Weight + " ");
            }
            return s.ToString();
        }
    }
}
