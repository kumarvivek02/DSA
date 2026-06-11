using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutHeaps
{
    public class BestTimeToBuyAndSellStock
    {
        public int MaxProfit(int[] prices)
        {
            int maxP = 0;
            int buy = 0;
            for (int sell = buy + 1; sell < prices.Length; sell++)
            {
                int profit = prices[sell] - prices[buy];
                maxP = Math.Max(maxP, profit);
                if (profit < 0) buy = sell;

            }
            return maxP;
        }
    }
}