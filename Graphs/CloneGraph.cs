using System;
using System.Collections.Generic;

namespace CloneGraph
{
    public class CloneGraph
    {
        public CloneGraph()
        {

        }

        Dictionary<Node, Node> cloneList = new Dictionary<Node, Node>();

        public Node CloneGraph1(Node node)
        {

            if (node == null) return node;

            // If orig node exists as key, return the clone of it, which is the value.
            if (cloneList.ContainsKey(node))
            {
                return cloneList[node];
            }

            // otherwise, clone of current node does not exist, so create it
            Node clone = new Node(node.val, new List<Node>());

            cloneList[node] = clone;

            foreach (var nei in node.neighbors)
            {
                clone.neighbors.Add(CloneGraph1(nei));
            }

            return clone;

        }
    }

    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

}
