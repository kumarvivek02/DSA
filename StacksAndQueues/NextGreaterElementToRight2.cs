using System;
using System.Collections.Generic;

namespace AllAboutHeaps.StacksAndQueues
{
    public class NextGreaterElementToRight2
    {
        public NextGreaterElementToRight2() { }

        //Builds off of NGER-1, here input arr[] is circular
        public int[] NextGreaterElements(int[] nums)
        {
            var len = nums.Length;
            var ans = new int[len];

            //Stack to hold monotonically increasing numbers (to RIght)
            var st = new Stack<int>();

            for (int i = (2 * len - 1); i >= 0; i--)
            {
                //As long as Stack is NOT empty, keep popping smaller elements
                // Because, once curr larger element goes into Stack, those smaller elements will
                // No longer be used for any element to left of current element.
                while (st.Count > 0 && nums[st.Peek()] <= nums[i % len])
                {
                    st.Pop();
                }

                ans[i % len] = st.Count == 0 ? -1 : nums[st.Peek()];

                //Always push the curent element as the last step
                st.Push(i % len);
            }

            return ans;
        }
    }
}
