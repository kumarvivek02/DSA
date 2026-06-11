using System;
namespace DSA.Strings
{
    public class LongestCommonPrefix
    {
        public LongestCommonPrefix()
        {
        }

        public string longestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0) return "";

            string prefix = strs[0]; // Here we are taking Prefix as 1st string in []. Which could be longest.

            for (int i = 1; i < strs.Length; i++)
            {
                var curr = strs[i]; //Current string to compare Prefix with
                int j = 0; // Pointer in Prefix string for char by char comparison
                int k = 0; //Pointer in Current string from input[] for char by char comparison with Prefix

                while (j < prefix.Length && k < strs[i].Length && prefix[j] == curr[k])
                {
                    j++;
                    k++;
                }

                prefix = prefix.Substring(0, j);
            }

            return prefix;
        }
    }
}

