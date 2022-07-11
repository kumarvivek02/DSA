using System;
using System.Collections.Generic;

namespace AllAboutHeaps.Strings
{
    public class BuddyString
    {
        public BuddyString()
        {
        }

        /*
         samepl test cases to consider

         
         */

        public bool BuddyStrings(string s, string goal)
        {
            // case 1 -> 2 strings unequal length
            if (s.Length != goal.Length) return false;

            // case 2 -> "ab" ,"ab"  OR "aa","aa"
            // Is S has a repeating char, then we can swap those & it won't change s
            if (s == goal)
            {
                HashSet<char> hash = new HashSet<char>();
                for (int i = 0; i < s.Length; i++)
                {
                    if (hash.Contains(s[i]))
                    {
                        return true;
                    }
                    hash.Add(s[i]);
                }
            }
            //case 3: "aaaabc" "aaaacb" --> 2 strings un equal
            else
            {
                //If they are unequal, they can only differ in at most 2 locations, and those 2 chars should be the same
                List<int> indexes = new List<int>();
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != goal[i])
                    {
                        indexes.Add(i);
                    }
                }

                if (indexes.Count == 2 && s[indexes[0]] == goal[indexes[1]] && s[indexes[1]] == goal[indexes[0]])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
