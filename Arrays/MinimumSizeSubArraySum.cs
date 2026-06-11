using System;
namespace DSA.Arrays
{
    public class MinimumSizeSubArraySum
    {
        public MinimumSizeSubArraySum()
        {
        }

        public int MinSubArrayLen(int target, int[] nums)
        {
            // Simple 2 pointer sliding window approach
            int currSum = 0;
            int left = 0;
            int minSubArraySize = Int32.MaxValue; //don't ini with 0 since 0 can be a valid answer

            for (int right = 0; right < nums.Length; right++)
            {
                currSum += nums[right];

                while (currSum >= target)
                {
                    //Found contender, compare with curr min. and update
                    minSubArraySize = Math.Min(minSubArraySize, right + 1 - left); //since array is 0 indexed

                    currSum -= nums[left];
                    left++;
                }
            }

            return minSubArraySize != Int32.MaxValue ? minSubArraySize : 0;
        }
    }
}

