using System;
using System.Collections.Generic;

namespace AllAboutHeaps.DynamicProgramming
{
    public class GridTraveler
    {
        public GridTraveler()
        {
        }

        public int UniquePaths(int m, int n)
        {
            Dictionary<string, int> memo = new Dictionary<string, int>();
            return UniquePathsRecursive(m, n, memo);
        }

        private int UniquePathsRecursive(int m, int n, Dictionary<string, int> memo)
        {
            string key = m.ToString() + "," + n.ToString();
            if (memo.ContainsKey(key)) return memo[key];

            //Base Case #1
            //Robot can move through a 1x1 grid in exactly 1 way
            if (m == 1 && n == 1) return 1;
            //Base Case #2
            //If m or n is 0, then it's not a valid grid & return 0
            if (m == 0 || n == 0) return 0;

            //Can move right or down
            return memo[key] = UniquePathsRecursive(m - 1, n, memo) + UniquePathsRecursive(m, n - 1, memo);
        }
    }
}
