using System;
using System.Collections.Generic;
using System.Linq;

namespace AllAboutHeaps.Arrays
{
    public class MergeIntervals
    {
        public MergeIntervals()
        {
        }

        public int[][] Merge(int[][] intervals)
        {
            List<List<int>> res = new List<List<int>>();
            Array.Sort(intervals, (a, b) => { return a[0].CompareTo(b[0]); });

            foreach (var interval in intervals)
            {
                if (res.Count == 0 || res.Last()[1] < interval[0])
                {
                    res.Add(new List<int>(interval));
                }
                else
                {
                    res.Last()[1] = Math.Max(res.Last()[1], interval[1]);
                }

            }

            return res.Select(a => a.ToArray()).ToArray(); ;
        }
    }

    public class CustomIntervalComparer : IComparer<int[]>
    {
        int IComparer<int[]>.Compare(int[] x, int[] y)
        {
            return x[0].CompareTo(y[0]);
        }
    }
}
