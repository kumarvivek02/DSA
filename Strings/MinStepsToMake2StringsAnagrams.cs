using System;
using System.Collections.Generic;

namespace AllAboutHeaps.Strings
{
    public class MinStepsToMake2StringsAnagrams
    {
        public MinStepsToMake2StringsAnagrams()
        {
        }

        public int MinSteps(string s, string t)
        {

            Dictionary<char, int> dict1 = new Dictionary<char, int>();
            Dictionary<char, int> dict2 = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!dict1.ContainsKey(s[i]))
                {
                    dict1.Add(s[i], 0);
                }

                dict1[s[i]]++;

                if (!dict2.ContainsKey(t[i]))
                {
                    dict2.Add(t[i], 0);
                }
                dict2[t[i]]++;
            }


            int count = 0;
            foreach (var keyItem in dict2)
            {
                var item = keyItem;

                if (!dict1.ContainsKey(item.Key))
                {
                    count += item.Value;
                }

                else
                {
                    int count1 = dict1[item.Key];

                    int count2 = dict2[item.Key];

                    if (count1 < count2)
                    {
                        count += (count2 - count1);
                    }
                }
            }
            return count;
        }
    }
}
