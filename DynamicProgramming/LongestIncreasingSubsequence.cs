using System;
namespace AllAboutHeaps.DynamicProgramming
{
    public class LongestIncreasingSubsequence
    {
        public LongestIncreasingSubsequence()
        {
        }

        public int LengthOfLIS(int[] nums)
        {
            int len = nums.Length;
            int[] dp = new int[len];

            Array.Fill(dp, 1);// All numbers can form LIS of length 1 by themselves

            int longest = Int32.MinValue;
            // i -> leading pointer
            // j -> trailing pointer
            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    //If number is monotonically increasing
                    if (nums[j] < nums[i])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                        longest = Math.Max(longest, dp[i]);
                    }
                }
            }

            //Ternary only for when i/p = [7,7,7,7], here the default LIS of 1 that each dp[] has should
            // be returned. It would never enter the 
            return longest != 0 ? longest : 1;
        }
    }
}

