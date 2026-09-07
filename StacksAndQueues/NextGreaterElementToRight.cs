using System;
using System.Collections.Generic;

namespace AllAboutHeaps.StacksAndQueues
{
    public class NextGreaterElementToRight_LeetcodeQ
    {
        //Variation 1 : Plain NextGreaterElementLogic, 1 input array provided
        //eg i/p:[6,8,0,1,3]
        //expected o/p:[8,-1,1,3,-1]
        public int[] NextGreaterElement(int[] nums)
        {
            var size = nums.Length;
            var st = new Stack<int>();
            var ans = new int[size];
            //Going R -> L
            for (int i = size - 1; i >= 0; i--)
            {
                //for each element, look through Stack to find next greater
                while(st.Count>0 && st.Peek() < nums[i])
                {
                    st.Pop();
                }

                //Once we've popped all smaller elements, 2 possible outcome

                //Stack is empty
                if(st.Count == 0) ans[i] = -1;
                else ans[i] = st.Peek();

                st.Push(nums[i]);
            }

            return ans;
        }

        //Variation 2 : From LC, 2 input arrays provided
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
                if (s.Count == 0)
                    dict.Add(nums2[i], -1);
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
