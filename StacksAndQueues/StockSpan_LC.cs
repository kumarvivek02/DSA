using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutHeaps.StacksAndQueues
{
    public class StockSpanner
    {
        //Eg: input = [100, 80, 60, 70, 60, 75, 85]
        //output = [1, 1, 1, 2, 1, 4, 6]
        //Tuple Value
        Stack<(int price, int span)> st;

        public StockSpanner()
        {            
            st = new Stack<(int price, int span)>();
        }

        public int Next(int price)
        {
            int span = 1;
            while (st.Count > 0 && st.Peek().Item1 <= price)
            {
                span += st.Peek().Item2;
                st.Pop();
            }
            st.Push((price, span));
            return span;
        }
    }

    /**
     * Your StockSpanner object will be instantiated and called as such:
     * StockSpanner obj = new StockSpanner();
     * int param_1 = obj.Next(price);
     */
}
