using System;
using System.Linq;

namespace AllAboutHeaps.DynamicProgramming
{
    public class TargetSum
    {
        public TargetSum()
        {
        }

        //Not passing all test cases on LC. Need to debug

        public int FindTargetSumWays(int[] nums, int target)
        {
            //Calc sum of all elements of array
            int sum = 0;
            for (int k = 0; k < nums.Length; k++)
            {
                sum += nums[k];
            }

            //To reduce this problem to count of subset sum,

            int n = nums.Length;
            int s = (sum + target) / 2;
            int[,] t = new int[n + 1, s + 1];


            //initialisation, 0 sum is always possible. With {} empty set
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= s; j++)
                {
                    if (i == 0) t[i, j] = 0;
                    if (j == 0) t[i, j] = 1;
                }
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= s; j++)
                {
                    if (nums[i - 1] <= j)
                    {
                        t[i, j] = t[i - 1, j - nums[i - 1]] + t[i - 1, j];
                    }
                    else
                    {
                        t[i, j] = t[i - 1, j];
                    }
                }
            }

            return t[n, s];
        }
    }
}
