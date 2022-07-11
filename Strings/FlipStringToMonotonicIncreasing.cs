using System;
namespace AllAboutHeaps.Strings
{
    /*
     LC 926 https://leetcode.com/problems/flip-string-to-monotone-increasing/
     */
    public class FlipStringToMonotonicIncreasing
    {
        public FlipStringToMonotonicIncreasing()
        {
        }

        // Note that the number of 1s coming after a 0 are the POTENTIAL number of positions you'll need to flip
        // All the 0s coming after a 1 are the ACTUAL number of flips you'll need to do.
        public int MinFlipsMonoIncr(string s)
        {
            // 0 0 0 1 1 0 0 0

            var numOnes = 0;
            var numFlips = 0; // Actual number of flips you need to perform to make monotonic increasing

            for (int i = 0; i < s.Length; i++)
            {
                var ch = s[i];

                if (ch == '1')
                {
                    numOnes++;
                }
                else if (ch == '0' && numOnes > 0)
                {
                    numFlips++;
                    numOnes--;
                }

            }

            return numFlips;
        }
    }
}
