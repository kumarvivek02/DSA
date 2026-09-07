using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutHeaps.Strings
{
    public class ValidPalindrome
    {
        public bool IsPalindrome(string s)
        {
            //2 pointer
            int i = 0;
            int j = s.Length - 1;

            while (i < j)
            {
                //trying to skip whitespace & Char not letter or Number
                while (i < j && !Char.IsLetterOrDigit(s[i]))
                {
                    i++;
                }

                while (i < j && !Char.IsLetterOrDigit(s[j]))
                {
                    j--;
                }

                if (char.ToLower(s[i]) != char.ToLower(s[j]))
                    return false;

                i++;
                j--;
            }
            return true;
        }
    }
}
