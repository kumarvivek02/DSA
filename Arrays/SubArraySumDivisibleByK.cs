using System;
using System.Collections.Generic;

namespace AllAboutHeaps.Arrays
{
    public class SubArraySumDivisibleByK
    {
        public SubArraySumDivisibleByK()
        {
        }

        public int SubarraysDivByK(int[] nums, int k)
        {
            int len = nums.Length;
            int count = 0;
            int sum = 0;
            int remainder = 0;

            // Dict to store Remainder & it's count
            Dictionary<int, int> dict = new Dictionary<int, int>();

            //initalise 0 as remainder with Count 1,
            //This is so that 1st time you have a number fully dividing k, you have pre saved Remaineder 0 with Count 1
            // So your tot. count can immediately increment by 1
            // Other cases, only if you see the remainder the 2nd time, does it imply you've crossed a range (i,j)
            //which is divisible by k

            dict.Add(0, 1);

            for (int i = 0; i < len; i++)
            {
                sum += nums[i];  //Prefix Sum

                remainder = sum % k;

                // Array has -ve numbers, so sum can be -ve
                //If Remainder is < 0, add K to make it positive
                if (remainder < 0)
                {
                    remainder = remainder + k;
                }

                if (dict.ContainsKey(remainder))
                {
                    count += dict[remainder];

                    dict[remainder]++;
                }
                else
                {
                    dict.Add(remainder, 1);
                }


            }
            return count;
        }
    }
}

