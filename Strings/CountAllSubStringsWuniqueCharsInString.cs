using System;
using System.Collections.Generic;

namespace AllAboutHeaps.Strings
{
    public class CountAllSubStringsWuniqueCharsInString
    {
        public CountAllSubStringsWuniqueCharsInString()
        {
        }

        /*
         Question is very poorly worded. I will reword  it as follows
        Count all substrings with every character occuring uniquely from String S
         */

        public int UniqueLetterString(string s)
        {
            Dictionary<char, List<int>> indexes = new Dictionary<char, List<int>>();

            // Go through every char and create list of indexes it occurs at
            for (int i = 0; i < s.Length; i++)
            {
                if (!indexes.ContainsKey(s[i]))
                {
                    indexes.Add(s[i], new List<int>());
                }
                indexes[s[i]].Add(i);
            }

            var sum = 0;
            foreach (var item in indexes)
            {
                var ch = item.Key;
                var indices = item.Value;

                for (int i = 0; i < indices.Count; i++)
                {
                    //1st index of every char in String will have a corner case
                    // You can add 1 extra left bracket before character at 0th index
                    // eg: X X L...  => Here you can add  (X (X (L
                    // So total substrings on left will be difference in 1st index of curr char - 0(for 1st char of string)  + 1
                    var left = i == 0 ? indices[i] - 0 + 1 : indices[i] - indices[i - 1];


                    // Same kind of Edge case for the last occurence of the char.
                    // Need to add an extra 1 right bracket 
                    var right = i == indices.Count - 1 ? s.Length - indices[i] : indices[i + 1] - indices[i];

                    sum += (left * right);

                }
            }

            return sum;
        }
    }
}
