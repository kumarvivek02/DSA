using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutHeaps.HashSet
{
    public class LongestConsecutiveSequence
    {
        public int LongestConsecutive(int[] nums)
        {
            HashSet<int> hashSet = new HashSet<int>(nums);

            int count = hashSet.Count;
            int longestGlobalSequence = 0;

            foreach (var num in nums)
            {
                if (!hashSet.Contains(num - 1))
                {
                    int currNumber = num;
                    int longestLocalSequence = 1;
                    while (hashSet.Contains(currNumber + 1))
                    {
                        longestLocalSequence += 1;
                        currNumber = currNumber + 1;
                        
                    }
                    longestGlobalSequence = Math.Max(
                            longestGlobalSequence,
                            longestLocalSequence
                        );
                }
            }
            return longestGlobalSequence;
        }
    }
}
