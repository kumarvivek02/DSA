using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class SlidingWindowMaximum
    {
        public SlidingWindowMaximum()
        {
        }

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            //Use LinkedList to implement a deque in C#
            LinkedList<int> dq = new LinkedList<int>(); // Store indexes of elements from nums[]
            List<int> res = new List<int>(); // Store max number from each sliding window

            // Head ------------Tail
            // Largest----------Smallest

            for (int i = 0; i < nums.Length; i++)
            {
                // If current element nums[i] is > than  tail element in dq, pop from tail until that is not true
                while (dq.Count > 0 && nums[dq.Last.Value] <= nums[i])
                {
                    dq.RemoveLast();
                }

                //After that, add current index i into dq
                dq.AddLast(i);


                //If Head element is outside the window, Pop it
                if (dq.First.Value < i - k)
                {
                    dq.RemoveFirst();
                }


                // Wait until i is at least covering window number of elements before you pick the largest into Result.
                if (i >= k - 1)
                {
                    res.Add(nums[dq.First.Value]);
                }

            }

            return res.ToArray();

        }
    }
}
