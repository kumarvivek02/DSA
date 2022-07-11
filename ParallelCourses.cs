using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class ParallelCourses
    {
        public ParallelCourses()
        {
        }

        public int MinimumSemesters(int n, int[][] relations)
        {
            Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();
            int[] indegree = new int[n + 1];

            BuildAdjacencyList(n, relations, adjList, indegree);

            Queue<int> q = new Queue<int>();

            for (int i = 1; i <= n; i++)
            {
                if (indegree[i] == 0) q.Enqueue(i);
            }

            int totCount = 0;
            int totNodesVisited = 0;

            while (q.Count > 0)
            {
                totCount++;

                int size = q.Count;

                for (int i = 0; i < size; i++)
                {
                    totNodesVisited++;
                    var curr = q.Dequeue();
                    foreach (var neighbor in adjList[curr])
                    {
                        indegree[neighbor]--;
                        if (indegree[neighbor] == 0) q.Enqueue(neighbor);
                    }

                }
            }

            return totNodesVisited == n ? totCount : -1;
        }



        private void BuildAdjacencyList(int n, int[][] edges, Dictionary<int, List<int>> adjList, int[] indegree)
        {
            for (int i = 1; i <= n; i++)
            {
                adjList.Add(i, new List<int>());
            }

            foreach (var edge in edges)
            {
                var u = edge[0];
                var v = edge[1];
                indegree[v]++;
                adjList[u].Add(v);
            }
        }
    }
}
