using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2PSP_max
{
    public class Graph
    {
        //adjency list
        private List<List<Edge>> adj = new List<List<Edge>>();

        public Graph(List<Edge> edges, int N)
        {
            for (int i = 0; i < N; i++)
            {
                adj.Add(new List<Edge>());
            }

            foreach (var e in edges)
            {
                adj[e.Source].Add(new Edge(e.Source, e.Destination, e.Weight));
                adj[e.Destination].Add(new Edge(e.Destination, e.Source, e.Weight));
            }
        }

        public HashSet<int> ModifiedBFS(int source)
        {
            var q = new Queue<Vertex>();
            var vertices = new HashSet<int>() { 0 };
            q.Enqueue(new Vertex(source, 0, vertices));
            int maxWeight = 0;
            var s = new HashSet<int>();
            while (q.Count != 0)
            {
                var vertex = q.Dequeue();
                int v = vertex.Number;
                int weight = vertex.Weight;
                vertices = new HashSet<int>(vertex.Visiteds);
                if (weight >= 0)
                {
                    maxWeight = Math.Max(maxWeight, weight);
                }

                foreach (var edge in adj[v])
                {
                    if (!vertices.Contains(edge.Destination))
                    {
                        s = new HashSet<int>(vertices);
                        s.Add(edge.Destination);
                        q.Enqueue(new Vertex(edge.Destination, weight + edge.Weight, s));
                    }
                }
            }
            return s;
        }
    }


    //public IList<Edge> Edges
    //{
    //    get
    //    {
    //        return edges.AsReadOnly();
    //    }
    //}

    //public void Clear()
    //{
    //    foreach (var vertex in vertices)
    //    {
    //        vertex.RemoveAllNeighbors();
    //    }

    //    for (int i = vertices.Count - 1; i >= 0; --i)
    //    {
    //        vertices.RemoveAt(i);
    //    }
    //}


    //public bool TryAddEdge(Edge e)
    //{
    //    if (edges.Contains(e))
    //        return false;
    //    e.V1.TryAddNeighbor(e.V2);
    //    e.V2.TryAddNeighbor(e.V1);
    //    edges.Add(e);
    //    return true;
    //}

    //public bool TryRemoveVertex(Vertex v)
    //{
    //    vertices.Remove(v);
    //    foreach (var vertex in vertices)
    //    {
    //        vertex.TryRemoveNeighbor(v);
    //    }
    //    return true;
    //}

    //public bool TryRemoveEdge(Edge e)
    //{
    //    if (!edges.Contains(e))
    //        return false;
    //    e.V1.Neighbors.Remove(e.V2);
    //    e.V2.Neighbors.Remove(e.V1);
    //    edges.Remove(e);
    //    return true;
    //}

    //public Vertex Find(int weight)

    //{
    //    foreach (var vertex in vertices)
    //    {
    //        if (vertex.Weight == weight)
    //            return vertex;
    //    }
    //    return new Vertex(0);
    //}

    //public override string ToString()
    //{
    //    var s = new StringBuilder();
    //    for (int i = 0; i < edges.Count; ++i)
    //    {
    //        s.Append(edges[i].ToString());
    //        if (i < edges.Count - 1)
    //        {
    //            s.Append("\n");
    //        }
    //    }
    //    return s.ToString();
    //}

    //finding map, i.e. maximum weight augmenting path 
    //public Vertex Map(Vertex v)
    //{
    //    int max = 0;
    //    var u = new Vertex(0);
    //    foreach (var neighbour in v.Neighbors)
    //    {
    //        if (v.DistanceTo(neighbour) >= max)
    //        {
    //            max = v.DistanceTo(neighbour);
    //            u = neighbour;
    //        }
    //    }
    //    return u;
    //}

}