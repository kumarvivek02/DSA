using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class HeapsUsingPriorityQueue
    {
        // Using default implementation of min heap
        public int FindKthLargest_MinHeap()
        {
            var pq = new PriorityQueue<int, int>(new CustomComparer());
            var arr = new int[6] { 8, 2, 3, 19, 5, 7 };
            // Find Kth Largest  [2 3 5 7 8 19]  => Expected Op => 7

            int k = 3;

            for (int i = 0; i < arr.Length; i++)
            {
                pq.Enqueue(arr[i], arr[i]);
                //if (pq.Count > k)
                //{
                //    pq.Dequeue();
                //}

            }

            while (pq.Count > 0)
            {
                Console.WriteLine(pq.Dequeue());
            }

            //var res = pq.Dequeue();
            //return res;

            return 1;
        }
    }

    public class CustomComparer : IComparer<int>
    {
        // Sort in DESCENDING Order
        //public int Compare(int x, int y)
        //{
        //    if (x == y)
        //    {
        //        return 0;
        //    }
        //    else if (x < y)
        //    {
        //        return 1;
        //    }
        //    else return -1;

        //}

        // Sort in ASCENDING Order
        public int Compare(int x, int y)
        {
            if (x == y)
            {
                return 0;
            }
            else if (x > y)
            {
                return 1;
            }
            else return -1;

        }
    }
}
