using System;
using System.Collections.Generic;
using System.Linq;

namespace AllAboutHeaps.Strings
{
    public class FindAllAnagrams
    {
        public FindAllAnagrams()
        {
        }

        public IList<int> FindAnagrams(string s, string p)
        {
            //Given that there are 26 letters, instead of Dict<char,int> ,
            // We'll use int[26] to store count  of chars

            int[] window = new int[26];
            int[] pCounts = new int[26];

            int sLen = s.Length;
            int plen = p.Length;

            //Corner Case, if s < p , no anagram possible
            if (sLen < plen) return new int[] { };
            int l = 0, r = 0;

            //ini counts/feqs of chars in both String p & window (pulling char coutns from String s)
            while (r < plen)
            {
                // Char count in String p
                pCounts[p[r] - 'a'] += 1;

                //Initialising Char count in Window from String s for initial len = p.Length 
                window[s[r] - 'a'] += 1;

                r++;
            }

            r--; //r will be 1 ahead because of line 35
            List<int> res = new List<int>(); //Holds starting indices of every Anagram location
            while (r < sLen)
            {
                if (window.SequenceEqual(pCounts))
                {
                    res.Add(l);
                }

                r++;
                //for last char in S, r from prev line will = sLen, so line 52 only when r < sLen
                if (r < sLen)
                {
                    // Slide window to Right by 1
                    window[s[r] - 'a']++; //
                }
                // Delete element from Window pointed by l
                window[s[l] - 'a']--;
                l++;
            }

            return res.ToArray();

        }
    }
}

