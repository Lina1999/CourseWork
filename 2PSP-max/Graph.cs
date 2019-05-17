using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2PSP_max
{
    public class Graph
    {
        private List<Vertex> vertices = new List<Vertex>();

        public Graph()
        {

        }

        public int Size
        {
            get
            {
                return vertices.Count();
            }
        }

        public IList<Vertex> Vertices
        {
            get
            {
                return vertices.AsReadOnly();
            }
        }

        public void Clear()
        {
            foreach (var vertex in vertices)
            {
                vertex.RemoveAllNeighbors();
            }

            for (int i = vertices.Count - 1; i >= 0; --i)
            {
                vertices.RemoveAt(i);
            }
        }

        public void AddVertex(int weight)
        {
            vertices.Add(new Vertex(weight));
        }

        public bool TryAddEdge(Vertex v1, Vertex v2)
        {
            if ((v1.Neighbors).Contains(v2))
                return false;
            v1.TryAddNeighbor(v2);
            v2.TryAddNeighbor(v1);
            return true;
        }

        public bool TryRemoveVertex(Vertex v)
        {
            vertices.Remove(v);
            foreach (var vertex in vertices)
            {
                vertex.TryRemoveNeighbor(v);
            }
            return true;
        }

        public bool TryRemoveEdge(Vertex v1, Vertex v2)
        {
            if (!v1.Neighbors.Contains(v2))
                return false;
            v1.Neighbors.Remove(v2);
            v2.Neighbors.Remove(v1);
            return true;
        }

        public Vertex Find(int weight)
        {
            foreach (var vertex in vertices)
            {
                if (vertex.Weight == weight)
                    return vertex;
            }
            return new Vertex(0);
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            for (int i = 0; i < Size; ++i)
            {
                s.Append(vertices[i].ToString());
                if (i < Size - 1)
                {
                    s.Append(", ");
                }
            }
            return s.ToString();
        }
    }
}
