using System;
namespace AllAboutHeaps.DynamicProgramming
{
    public class EqualSubsetSumPartition
    {
        public EqualSubsetSumPartition()
        {
        }

        public bool CanPartition(int[] nums)
        {
            // Can only partition the array into 2 equal sum subsets if Sum of all numbers in nums[] is EVEN.
            // So 1st check for that

            var sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }

            if (sum % 2 != 0) return false;


            // Total sum of nums[] is Even. so question boils down to Subset sum with a given sum = S/2

            return SubsetSum(nums, sum / 2, nums.Length);
        }

        private bool SubsetSum(int[] nums, int sum, int length)
        {
            //Classic DP
            // 1st step initialisation
            bool[,] t = new bool[length + 1, sum + 1];

            //
            for (int i = 0; i <= length; i++)
            {
                for (int j = 0; j <= sum; j++)
                {
                    if (i == 0) t[i, j] = false;

                    if (j == 0) t[i, j] = true;
                }
            }


            for (int i = 1; i <= length; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    // if element is smaller than Sum, 
                    if (nums[i - 1] <= j)
                    {
                        // Choice between Can take or Cannot take
                        t[i, j] = t[i - 1, j - nums[i - 1]] || t[i - 1, j];

                    }
                    else
                    {
                        // Element bigger than sum, so cannot take this number
                        t[i, j] = t[i - 1, j];
                    }
                }
            }

            return t[length, sum];

        }
    }
}
