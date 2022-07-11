using System;
using System.Collections.Generic;

namespace AllAboutHeaps.Arrays
{
    public class LongestSubstringWithoutRepeatingChars
    {
        public LongestSubstringWithoutRepeatingChars()
        {
        }

        public int LengthOfLongestSubstring(string s)
        {

            int l = 0;
            int r = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();

            int len = s.Length;
            int maxLength = 0; //to hold max length of substring without repeating chars

            while (r < len)
            {
                //Character of the String s pointed at index r
                var character = s[r];
                if (dict.ContainsKey(character))
                {
                    l = Math.Max(l, dict[character] + 1);
                    dict.Remove(character); // Only deleting here so line 32 doesn't need extra logic to Update if exists
                }

                dict.Add(s[r], r);
                maxLength = Math.Max(maxLength, r - l + 1);
                r++;

            }

            return maxLength;
        }
    }
}

