using System;
using System.Collections.Generic;

namespace DSA.StacksAndQueues
{
    public class AreaOfLargestRectangleInHistogram
    {
        public AreaOfLargestRectangleInHistogram() { }

        public int LargestRectangleArea(int[] heights)
        {
            int len = heights.Length;
            int maxArea = 0;
            var leftSmaller = new int[len];
            var rightSmaller = new int[len];
            CalculateLeftSmaller(heights, leftSmaller);
            CalculateRightSmaller(heights, rightSmaller);
            for (int i = 0; i < len; i++)
            {
                int width = rightSmaller[i] - leftSmaller[i] - 1;
                int area = width * heights[i];
                maxArea = Math.Max(maxArea, area);
            }

            return maxArea;
        }

        private void CalculateLeftSmaller(int[] heights, int[] leftSmaller)
        {
            Stack<int> st = new Stack<int>();

            for (int i = 0; i < heights.Length; i++)
            {
                while (st.Count > 0 && heights[st.Peek()] >= heights[i])
                {
                    st.Pop();
                }

                //Stack is empty, put -1 as index of left smaller
                leftSmaller[i] = st.Count == 0 ? -1 : st.Peek();

                st.Push(i);
            }
        }

        public void CalculateRightSmaller(int[] heights, int[] rightSmaller)
        {
            //  1 key diff is If no element found smaller on Right, use last FICTIONAL element index at
            // heights.Length

            Stack<int> st = new Stack<int>();

            for (int i = heights.Length - 1; i >= 0; i--)
            {
                while (st.Count > 0 && heights[st.Peek()] >= heights[i])
                {
                    st.Pop();
                }

                rightSmaller[i] = st.Count == 0 ? heights.Length : st.Peek();

                st.Push(i);
            }
        }
    }
}
