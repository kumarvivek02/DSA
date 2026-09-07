using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutHeaps.StacksAndQueues
{
    public class Solution
    {
        public int[] FinalPrices(int[] prices)
        {
            int len = prices.Length;
            var ans = new int[len];
            var st = new Stack<int>();

            for (int i = len - 1; i >= 0; i--)
            {
                while (st.Count > 0 && prices[st.Peek()] >= prices[i])
                {
                    st.Pop();
                }

                ans[i] = st.Count == 0 ? prices[i] : prices[i] - prices[st.Peek()];
                st.Push(i);
            }
            return ans;
        }
    }
}
