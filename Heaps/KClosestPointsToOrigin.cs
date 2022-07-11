using System;
using System.Collections.Generic;
using System.Linq;

namespace AllAboutHeaps.Heaps
{
    public class KClosestPointsToOrigin
    {
        public KClosestPointsToOrigin()
        {
        }

        public int[][] KClosest(int[][] points, int k)
        {
            var pq = new PriorityQueue<Tuple<int, int, double>, double>(new CustomComparerKClosestPoints());

            int len = points.Length;
            for (int i = 0; i < len; i++)
            {
                var x = points[i][0];
                var y = points[i][1];
                var distToOrigin = Math.Pow((x - 0), 2) + Math.Pow((y - 0), 2);

                pq.Enqueue(new Tuple<int, int, double>(x, y, distToOrigin), distToOrigin);

                if (pq.Count > k)
                {
                    pq.Dequeue();
                }
            }

            var tot = pq.Count;
            //int[,] res = new int[tot,2];
            //int index = 0;
            List<List<int>> res = new List<List<int>>();
            while (pq.Count > 0)
            {
                var front = pq.Dequeue();
                res.Add(new List<int> { front.Item1, front.Item2 });
            }

            return res.Select(x => x.ToArray()).ToArray();
        }
    }

    public class CustomComparerKClosestPoints : IComparer<double>
    {
        public int Compare(double x, double y)
        {

            if (x == y) return 0;
            else if (x > y) return -1;

            else return 1;
        }
    }
}

