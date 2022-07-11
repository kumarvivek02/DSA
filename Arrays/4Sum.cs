using System;
using System.Collections.Generic;

namespace AllAboutHeaps.Arrays
{
    public class FourSum
    {
        public FourSum()
        {
        }

        public List<List<int>> FourSum1(int[] arr, int target)
        {
            Array.Sort(arr);
            return KSumRecursive(arr, 0, 4, target);
        }

        private List<List<int>> KSumRecursive(int[] arr, int currIndex, int k, int target)
        {
            List<List<int>> res;

            if (k == 2)
            {
                var temp = TwoSum(arr, target - arr[currIndex], currIndex + 1, arr.Length - 1);

                return temp;
            }
            else
            {
                res = new List<List<int>>();
                for (int i = currIndex; i < arr.Length - k + 1; i++)
                {


                    var tempLists = KSumRecursive(arr, currIndex + 1, k - 1, target - arr[i]);

                    if (tempLists != null && tempLists.Count > 0)
                    {
                        //Add curr item to each list returned by prev. function call.
                        foreach (var list in tempLists)
                        {
                            list.Insert(0, arr[i]);
                        }

                        res.AddRange(tempLists);
                    }

                    //Ignore duplicates
                    //Remember array is sorted
                    while (i < arr.Length - 1 && arr[i] == arr[i + 1])
                        i++;

                }

            }

            return res;
        }

        private List<List<int>> TwoSum(int[] arr, int target, int start, int end)
        {
            var res = new List<List<int>>();

            while (start <= end)
            {
                if (arr[start] + arr[end] == target)
                {
                    res.Add(new List<int>() { arr[start], arr[end] });

                    start++;
                    end--;
                    while (start < end && arr[start] == arr[start - 1]) start++;


                    while (start < end && arr[end] == arr[end + 1]) end--;

                }
                else if (arr[start] + arr[end] < target)
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }
            return res;
        }




    }
}
