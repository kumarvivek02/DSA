using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutHeaps
{
    public class TwoSum_Leetcode1
    {
        public int[] TwoSum(int[] nums, int target)
        {
            //approach 1 
            // for (int i = 0; i < nums.Length; i++)
            // {
            //     for (int j = i + 1; j < nums.Length; j++)
            //     {
            //         if (nums[i] + nums[j] == target)
            //         {
            //             return new int[] { i, j };
            //         }
            //     }
            // }
            // return null;
            //approach 2 - using Dictionary
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];
                if (dict.ContainsKey(complement))
                {
                    return new int[] { dict[complement], i };
                }
                if(!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], i);
                }
            }
            return new int[] { -1, -1 };
        }
    }
}