using System;
namespace AllAboutHeaps.BinarySearch
{
    public class HIndex2
    {
        public HIndex2()
        {
        }

        /*
		 Soln 1 -> O(N) TC
		 Single traversal.
		 */
        public int HIndex(int[] citations)
        {
            int len = citations.Length;

            //Start travelling from Right to Left.
            //Array is sorted in Ascending order.
            int i = len - 1;
            while (i >= 0)
            {
                if (citations[i] < len - i) break;

                i--;
            }

            //If no h index was found from within while loop, ans will be len of array.
            //eg [100 150] => 2, since 2 elements with K>=2
            return len - i - 1;
        }
    }
}

