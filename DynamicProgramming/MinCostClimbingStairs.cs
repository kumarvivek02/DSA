using System;
namespace AllAboutHeaps.DynamicProgramming
{
    public class MinimumCostClimbingStairs
    {
        public MinimumCostClimbingStairs()
        {
        }

        int[] t;

        public int MinCostClimbingStairs(int[] cost)
        {
            var len = cost.Length + 1;
            t = new int[len];

            for (int i = 2; i < cost.Length + 1; i++)
            {
                t[i] = Math.Min(t[i - 1] + cost[i - 1],
                                t[i - 2] + cost[i - 2]);
            }

            return t[cost.Length + 1];
            // return DP(cost, cost.Length);
        }

        private int DP(int[] cost, int stairNumber)
        {
            //Base case
            if (stairNumber == 0) return cost[stairNumber];

            if (stairNumber == 1) return cost[stairNumber];

            return Math.Min(DP(cost, cost.Length - 1) + cost[cost.Length - 1],
                            DP(cost, cost.Length - 2) + cost[cost.Length - 2]);
        }
    }
}
