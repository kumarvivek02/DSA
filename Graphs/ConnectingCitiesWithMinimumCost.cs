using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class ConnectingCitiesWithMinimumCost
    {
        public ConnectingCitiesWithMinimumCost()
        {
        }

        public int MinimumCost(int n, int[][] connections)
        {

            var len = n;
            UnionFind unionFind = new UnionFind(n + 1);

            PriorityQueue<Tuple<int, int, int>, int> pq = new PriorityQueue<Tuple<int, int, int>, int>();

            foreach (var connection in connections)
            {
                var src = connection[0];
                var dst = connection[1];
                var cost = connection[2];

                pq.Enqueue(new Tuple<int, int, int>(src, dst, cost), cost);



            }

            int totConnections = n - 1;
            int totCost = 0;
            while (pq.Count > 0)
            {
                var top = pq.Dequeue();

                if (!unionFind.IsConnected(top.Item1, top.Item2))
                {
                    unionFind.Union(top.Item1, top.Item2);
                    totCost += top.Item3;
                    totConnections--;
                    if (totConnections == 0) break;
                }
            }

            if (totConnections == 0) return totCost;
            else return -1;

        }
    }
}
