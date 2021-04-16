using System;
using System.Collections.Generic;
using System.Linq;
// Test
// Test 2

namespace TGR3a
{
    public class Graph
    {
        public string Name { get; set; }

        public Dictionary<string, Node> NodeDict { get; set; }

        /// <summary>
        /// Init graph name and create instance of distionary of nodes
        /// </summary>
        /// <param name="name"></param>
        public Graph(string name)
        {
            Name = name;
            NodeDict = new Dictionary<string, Node>();
        }

        /// <summary>
        /// Indexer to get node by its name
        /// </summary>
        /// <param name="nameNode"></param>
        /// <returns></returns>
        public Node this[string nameNode]
        {
            get
            {
                if (NodeDict.ContainsKey(nameNode))
                {
                    return NodeDict[nameNode];
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

        }

        /// <summary>
        /// Add node to nodeDict if there is no same node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public void AddToDict(Node node)
        {
            if (!NodeDict.ContainsKey(node.Name))
            {
                NodeDict.Add(node.Name, node);
            }

        }

        /// <summary>
        /// Function that print all nodes name in nodeDict
        /// </summary>
        public void PrintNodes()
        {
            foreach (Node node in NodeDict.Values)
            {
                Console.WriteLine($"{node.Name} {node.MinValue}");
            }
        }

        /// <summary>
        /// Print all edges associated to each node
        /// </summary>
        public void PrintNodesAndTheirEdges()
        {
            foreach (Node node in NodeDict.Values)
            {
                Console.Write(node.Name + ": ");
                foreach (Edge edge in node.ListEdge)
                {
                    Console.Write($@"{edge.SourceNode.Name} - {edge.DestinationNode.Name}, ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Return true if NodeDict contains input key
        /// </summary>
        /// <param name="nameNode"></param>
        /// <returns></returns>
        public bool NodeExists(string nameNode)
        {
            return NodeDict.ContainsKey(nameNode);
        }

        public List<Edge> GetUniqueEdges()
        {
            List<Edge> uniqueEdges = new List<Edge>();

            foreach (Node node in NodeDict.Values)
            {
                foreach (Edge edge in node.ListEdge)
                {
                    if (!uniqueEdges.Contains(edge))
                    {
                        uniqueEdges.Add(edge);
                    }
                }
            }

            return uniqueEdges;
        }

        /// <summary>
        /// Method that add node to graph if there is not yet. Also
        /// add new edge to each node.
        /// </summary>
        /// <param name="nodeName1"></param>
        /// <param name="nodeName2"></param>
        /// <param name="value"></param>
        public void AddEdge(string nodeName1, string nodeName2, int value)
        {
            Node node1;
            Node node2;

            if (NodeExists(nodeName1))
            {
                node1 = this[nodeName1];
            }
            else
            {
                node1 = new Node(nodeName1);
                AddToDict(node1);
            }
            if (NodeExists(nodeName2))
            {
                node2 = this[nodeName2];
            }
            else
            {
                node2 = new Node(nodeName2);
                AddToDict(node2);
            }

            Edge edge = new Edge(node1, node2, value);

            node1.AddEdge(edge);
            node2.AddEdge(edge);
        }

        public Node GetOpositeNodeFromEdge(Node node, Edge edge)
        {
            if (edge.DestinationNode == node)
                return edge.SourceNode;
            else if (edge.SourceNode == node)
                return edge.DestinationNode;
            else
                return null;
        }

        public void AssignNodes(Node node, ref Queue<Node> queue, ref List<Node> approachedNodes)
        {
            foreach (Edge edge in node.ListEdge)
            {
                Node oposite = GetOpositeNodeFromEdge(node, edge);
                if (oposite.MinValue > node.MinValue + edge.Value)
                {
                    oposite.MinValue = node.MinValue + edge.Value;
                }
                if (!approachedNodes.Contains(oposite))
                {
                    queue.Enqueue(oposite);
                }
                if (!approachedNodes.Contains(node))
                {
                    approachedNodes.Add(node);
                }
            }
        }

        public List<Node> Dijsktra(Node first)
        {
            Queue<Node> queue = new Queue<Node>();
            List<Node> approachedNodes = new List<Node>();
            first.MinValue = 0;
            queue.Enqueue(first);

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                AssignNodes(node, ref queue, ref approachedNodes);
            }

            return approachedNodes.OrderBy(x => x.MinValue).ToList();

        }
    }
}
