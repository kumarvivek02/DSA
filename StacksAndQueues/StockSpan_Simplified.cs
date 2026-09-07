using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutHeaps.StacksAndQueues
{
    public class StockSpan
    {
        //eg: stockPrices=[100,80,60,70,60,75,85]
        public int[] CalcuateStockSpan(int[] stockPrices)
        {
            //store indexes in the Stack, not the actual price 
            var st = new Stack<int>();
            var count = stockPrices.Length;
            var answers = new int[count];
            
            for (int i = 0; i < count; i++)
            {
                while(st.Count >0 && stockPrices[st.Peek()] <= stockPrices[i])
                {
                    st.Pop();
                }

                if(st.Count == 0) answers[i] = i+1;
                else
                {
                    answers[i] = i - st.Peek();
                }
                st.Push(i);
            }
            return answers;
        }
    }
}
