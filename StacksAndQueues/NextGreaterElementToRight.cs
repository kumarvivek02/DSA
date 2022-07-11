using System;
using System.Collections.Generic;

namespace AllAboutHeaps.StacksAndQueues
{
    public class NextGreaterElementToRight
    {
        public NextGreaterElementToRight()
        {
        }

        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            int[] res = new int[nums1.Length];
            var dict1 = NextGreaterElementToTheRight(nums2);

            for (int i = 0; i < nums1.Length; i++)
            {
                res[i] = dict1[nums1[i]];
            }
            return res;

        }

        public Dictionary<int, int> NextGreaterElementToTheRight(int[] nums2)
        {
            Stack<int> s = new Stack<int>();
            //Dictionary to store nums2[i], NGR of nums2[i]
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = nums2.Length - 1; i >= 0; i--)
            {
                //As long as Stack is NOT empty && current Top is smaller than nums2[i], keep popping
                while (s.Count > 0 && s.Peek() < nums2[i])
                {
                    s.Pop();
                }

                //After the while loop above, either Stack is Empty, in which case NGR is -1
                // OR you've found NGR at s.Peek()
                if (s.Count == 0) dict.Add(nums2[i], -1);
                else
                {
                    dict.Add(nums2[i], s.Peek());
                }

                s.Push(nums2[i]);
            }

            return dict;
        }
    }
}

