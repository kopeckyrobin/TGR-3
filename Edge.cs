using System;
namespace TGR3a
{
    public class Edge
    {
        public Node SourceNode { get; set; }
        public Node DestinationNode { get; set; }
        public int Value { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Edge()
        {
        }
        /// <summary>
        /// To init SourceNode and DestinationNode
        /// </summary>
        /// <param name="sourceNode"></param>
        /// <param name="destinationNode"></param>
        public Edge(Node sourceNode, Node destinationNode)
        {
            SourceNode = sourceNode;
            DestinationNode = destinationNode;
        }
        /// <summary>
        /// To init SourceNode, DestinationNode and Value
        /// </summary>
        /// <param name="sourceNode"></param>
        /// <param name="destinationNode"></param>
        /// <param name="value"></param>
        public Edge(Node sourceNode, Node destinationNode, int value)
        {
            SourceNode = sourceNode;
            DestinationNode = destinationNode;
            Value = value;
        }
    }
}
