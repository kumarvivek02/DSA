using System;
using System.Collections.Generic;

namespace AllAboutHeaps.StacksAndQueues
{
    public class NextGreaterElementToRight2
    {
        public NextGreaterElementToRight2()
        {
        }

        //Builds off of NGER-1, here input arr[] is circular
        public int[] NextGreaterElements(int[] nums)
        {
            var len = nums.Length;
            var res = new int[len];

            //Stack to hold monotonically increasing numbers (to RIght)
            Stack<int> st = new Stack<int>();

            for (int i = (2 * len - 1); i >= 0; i--)
            {
                //As long as Stack is NOT empty, keep popping smaller elements
                // Because, once curr larger element goes into Stack, those smaller elements will
                // No longer be used for any element to left of current element.
                while (st.Count > 0 && st.Peek() <= nums[i % len])
                {
                    st.Pop();
                }

                //At this point, We've pre populated Stack with some elements from len --> 2*len -1
                if (i < len)
                {
                    //either Stack is empty
                    if (st.Count == 0)
                    {
                        res[i] = -1;
                    }
                    //Or top most element is larger than curr.
                    else
                    {
                        res[i] = st.Peek();
                    }
                }

                //Always push the curent element as the last step
                st.Push(nums[i % len]);
            }

            return res;
        }


    }
}

