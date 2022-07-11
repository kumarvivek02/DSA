using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    /*
     
      public static int EarliestAcq(int[][] logs, int n)
        {
            UnionFind unionFind = new UnionFind(n);

            Array.Sort(logs, new CustomCompare());

            int time = -1;

            foreach (var edge in logs)
            {
                time = edge[0];
                var x = edge[1];
                var y = edge[2];

                unionFind.Union(x, y);

                if (unionFind.GetCount() == 1) break;
            }

            return time;
        }
     */
    public class EarliestTimeWhenAllBecameFriends
    {
        public EarliestTimeWhenAllBecameFriends()
        {
        }
    }

    public class CustomCompare : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            var time1 = x[0];

            var time2 = y[0];

            if (time1 < time2)
                return -1;
            else
                return 1;
        }
    }
}
