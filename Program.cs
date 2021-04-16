using System;
using System.Text.RegularExpressions;

namespace TGR3a
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph("TGR 3a");
            while (true)
            {
                string line = Console.ReadLine();

                if (line != null)
                {
                    int value;
                    string[] splitLine = Regex.Split(line, ": ");
                    Int32.TryParse(splitLine[1], out value);
                    string[] nodeInput = Regex.Split(splitLine[0], " - ");
                    graph.AddEdge(nodeInput[0], nodeInput[1], value);

                }
                else { break; }
            }

            Node firstNode = null;

            try
            {
               firstNode = graph["Vy"];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            var sorted = graph.Dijsktra(firstNode);
            foreach (Node node in sorted)
            {
                Console.WriteLine($"{node.Name}: {node.MinValue}");
            }

        }
    }
}
