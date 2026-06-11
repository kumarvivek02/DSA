using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutHeaps.Arrays
{
    public class MaximumSubArray
    {
        public int MaxSubArray(int[] nums)
        {
            //1 pass using Kadane's Algorithm
            int localSum = 0;
            int globalSum = Int32.MinValue;

            for(int i=0; i< nums.Length; i++)
            {
                localSum += nums[i];
                globalSum = Math.Max(globalSum, localSum);
                if(localSum < 0) localSum = 0;
            }
            return globalSum;
        }
    }
}