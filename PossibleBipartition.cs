using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class IsPossibleBipartition
    {
        public IsPossibleBipartition()
        {

        }


        public bool PossibleBipartition(int n, int[][] dislikes)
        {
            var adjList = EdgeListToAdjacencyList(dislikes, n);

            int[] color = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                color[i] = -1; //initialise with -1

            }

            for (int i = 1; i <= n; i++)
            {
                if (color[i] == -1)
                {
                    if (!dfsPossibleBipartition(adjList, color, i)) return false;
                }
            }

            return true;


        }

        public bool dfsPossibleBipartition(Dictionary<int, List<int>> adjList, int[] color, int curr)
        {
            if (color[curr] == -1) color[curr] = 1; //initialise the 1st node with 1 (or 0).

            foreach (var neighbor in adjList[curr])
            {
                if (color[neighbor] == -1)
                {
                    color[neighbor] = 1 - color[curr];
                    if (!dfsPossibleBipartition(adjList, color, neighbor)) return false;
                }
                else
                {
                    if (color[neighbor] == color[curr]) return false;
                }

            }

            return true;
        }

        public Dictionary<int, List<int>> EdgeListToAdjacencyList(int[][] edgeList, int n)
        {
            var totNumberOfNodes = n;

            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();

            //initialise the AdjList. 
            for (int i = 1; i <= totNumberOfNodes; i++)
            {
                adjList.Add(i, new List<int>());

            }

            foreach (var neighbor in edgeList)
            {
                var a = neighbor[0];
                var b = neighbor[1];
                adjList[a].Add(b);
                adjList[b].Add(a);
            }

            return adjList;

        }
    }
}
