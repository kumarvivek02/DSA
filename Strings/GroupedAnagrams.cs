using System;
using System.Collections.Generic;

namespace DSA.Strings
{
    public class GroupedAnagrams
    {
        public GroupedAnagrams()
        {
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            //Method 1 : Use sorted strings as Keys
            Dictionary<string, List<string>> sortedSets = new Dictionary<string, List<string>>();
            List<IList<string>> res = new List<IList<string>>();

            foreach (var str in strs)
            {
                var sorted = str.ToCharArray();
                Array.Sort(sorted);
                var sortedStr = new String(sorted);
                if (!sortedSets.ContainsKey(sortedStr))
                {
                    sortedSets.Add(sortedStr, new List<string>());
                }
                sortedSets[sortedStr].Add(str);
            }

            foreach (var key in sortedSets.Keys)
            {
                res.Add(sortedSets[key]);
            }

            return res;
        }
    }
}

