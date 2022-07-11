using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class MinCostToConnectAllPoints
    {
        public MinCostToConnectAllPoints()
        {
        }

        public int MinCostConnectPoints(int[][] points)
        {
            if (points == null || points.Length == 0)
            {
                return 0;
            }

            int size = points.Length;
            int totCost = 0;

            UnionFind unionFind = new UnionFind(size);

            PriorityQueue<Edge, int> pq = new PriorityQueue<Edge, int>();

            for (int i = 0; i < size; i++)
            {

                for (int j = i + 1; j < size; j++)
                {
                    var aX = points[i][0];
                    var aY = points[i][1];

                    var bX = points[j][0];
                    var bY = points[j][1];

                    var cost = Math.Abs(bX - aX) + Math.Abs(bY - aY);
                    pq.Enqueue(new Edge(i, j, cost), cost);

                }

            }

            int countOfEdges = size - 1;

            while (pq.Count > 0)
            {
                var top = pq.Dequeue();

                if (!unionFind.IsConnected(top.src, top.dst))
                {
                    unionFind.Union(top.src, top.dst);

                    totCost += top.cost;
                    countOfEdges--;

                    if (countOfEdges == 0) break;

                }


            }

            return totCost;
        }
    }

    public class Edge
    {
        public int src;
        public int dst;
        public int cost;

        public Edge(int x, int y, int cost)
        {
            src = x;
            dst = y;
            this.cost = cost;

        }
    }


}
