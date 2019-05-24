using System;
using System.Collections.Generic;
using System.Text;

namespace _2PSP_max
{
    public class Edge
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Weight { get; set; }
        public Edge(int source, int destination, int weight)
        {
            this.Source = source;
            this.Destination = destination;
            Weight = weight;
        }
    }
}