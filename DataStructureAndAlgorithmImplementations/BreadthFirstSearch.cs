using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgorithmImplementations
{
    public class BreadthFirstSearchAlgorithm
    {

        public Node Search(Node graphStartingNode, string searchItem)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(graphStartingNode);
            graphStartingNode.Visited = true;
            while (queue.Count>0)
            {
                Node node = queue.Dequeue();

                foreach (var neighbour in node.Neighbours)
                {
                    if (!neighbour.Visited)
                    {
                        if (neighbour.Data.Equals(searchItem))
                            return neighbour;
                        queue.Enqueue(neighbour);
                        neighbour.Visited = true;
                    }
                }
            }

            return null;
        }


    }


    public class Node
    {
        public string Data { get; set; }
        public IEnumerable<Node> Neighbours { get; set; }
        public bool Visited { get; set; } = false;
    }
}
