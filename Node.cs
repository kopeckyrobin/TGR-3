using System;
using System.Collections.Generic;

namespace TGR3a
{
    public class Node
    {
        public List<Edge> ListEdge { get; set; }

        public string Name { get; set; }
        public int MinValue { get; set; } = int.MaxValue;

        /// <summary>
        /// Init Node, create list of edges
        /// </summary>
        /// <param name="name"></param>
        public Node(string name)
        {
            Name = name;
            ListEdge = new List<Edge>();
        }

        /// <summary>
        /// Add new edge to list
        /// </summary>
        /// <param name="edge"></param>
        public void AddEdge(Edge edge)
        {
            ListEdge.Add(edge);
        }

    }
}
