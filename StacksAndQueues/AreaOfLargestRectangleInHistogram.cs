using System;
using System.Collections.Generic;

namespace DSA.StacksAndQueues
{
    public class AreaOfLargestRectangleInHistogram
    {
        public AreaOfLargestRectangleInHistogram()
        {
        }

        public int LargestRectangleArea(int[] heights)
        {
            //Find smaller to the left and to the right

            //Step 1 (left smaller[] with indexes as values
            int[] ls = new int[heights.Length];
            CalculateLeftSmaller(heights, ls);

            //Step 2 (right smaller with indexes as values
            int[] rs = new int[heights.Length];
            CalculateRightSmaller(heights, rs);

            int maxArea = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                int width = rs[i] - ls[i] - 1;
                int tempArea = width * heights[i];
                maxArea = Math.Max(maxArea, tempArea);

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
                if (st.Count == 0)
                {
                    leftSmaller[i] = -1; // 
                }
                else
                {
                    leftSmaller[i] = st.Peek();// Don't remove the element, just record it's index
                }

                st.Push(i);
            }
        }

        public void CalculateRightSmaller(int[] heights, int[] rightSmaller)
        {
            //  1key diff is If no element found smaller on Right, use last FICTIONAL element index at
            // heights.Length + 1

            Stack<int> st = new Stack<int>();

            for (int i = heights.Length - 1; i >= 0; i--)
            {
                while (st.Count > 0 && heights[st.Peek()] >= heights[i])
                {
                    st.Pop();
                }


                if (st.Count == 0)
                {                   //index of last element  + 1
                    rightSmaller[i] = (heights.Length - 1) + 1; // index of last element + 1
                }
                else
                {
                    rightSmaller[i] = st.Peek();

                }
                st.Push(i);
            }
        }
    }
}

