using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class IsGraphBiPartite
    {
        public IsGraphBiPartite()
        {
        }

        public bool IsBipartite(int[][] graph)
        {
            // Step 1 -> Build our Adjacency list
            var adjList = EdgeListToAdjacencyList(graph);

            int[] color = new int[graph.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                color[i] = -1; // Not colored


            }

            for (int i = 0; i < graph.Length; i++)
            {
                if (color[i] == -1)
                {
                    if (!IsColoringPossible(adjList, color, i)) return false;
                }
            }

            return true;
        }

        public bool IsColoringPossible(Dictionary<int, List<int>> adjList, int[] color, int i)
        {
            if (color[i] == -1) color[i] = 1;

            foreach (var neighbor in adjList[i])
            {

                if (color[neighbor] == -1) // Not colored yet
                {
                    color[neighbor] = 1 - color[i];
                    if (!IsColoringPossible(adjList, color, neighbor)) return false;

                }
                else //It is colored
                {
                    if (color[neighbor] == color[i]) return false;
                }

            }
            return true;
        }

        public Dictionary<int, List<int>> EdgeListToAdjacencyList(int[][] edgeList)
        {
            var totNumberOfNodes = edgeList.Length;

            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();

            //initialise the AdjList. 
            for (int i = 0; i < totNumberOfNodes; i++)
            {
                adjList.Add(i, new List<int>());
                var neighbors = edgeList[i];
                foreach (var neighbor in neighbors)
                {
                    adjList[i].Add(neighbor);
                }
            }

            return adjList;

        }

    }
}
