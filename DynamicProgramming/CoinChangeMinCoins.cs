using System;
namespace AllAboutHeaps.DynamicProgramming
{
    public class CoinChangeMinCoins
    {
        public CoinChangeMinCoins()
        {
        }


        //Approach 2 -> Tabulation / Bottom up
        public int CoinChange(int[] coins, int amount)
        {
            int[] counts = new int[amount + 1];

            Array.Fill(counts, Int32.MaxValue);

            //Counts[] stores min. coins needed to make Amount i, where i = index of counts []
            // So below ini means it takes 0 coins to make Amount = 0
            counts[0] = 0;

            int toCompare = 0;

            //For every denomination of coins in coins[], 
            foreach (var coin in coins)
            {
                // how many min. coins are needed to make Amount j
                for (int j = 0; j < counts.Length; j++)
                {
                    if (coin <= j)
                    {
                        // If counts[j - coin] == Int32.MaxValue, then adding 1 will mmove it Int32.Min
                        if (counts[j - coin] == Int32.MaxValue)
                        {
                            toCompare = Int32.MaxValue;
                        }
                        else
                        {
                            toCompare = counts[j - coin] + 1;
                        }

                        counts[j] = Math.Min(counts[j], toCompare);

                    }
                }
            }

            // If at counts[amount] you do not have a non Int Max value,
            // given denominations will not suffice, so ret -1
            return counts[amount] == Int32.MaxValue ? -1 : counts[amount];

        }



        //Approach 1 -> Recursion + Memoization
        /*
        int[,] t;

        public int CoinChange(int[] coins, int amount)
        {
            // Array for Memoization
            t = new int[coins.Length + 1, amount + 1];
            for (int i = 0; i <= coins.Length; i++)
            {
                for (int j = 0; j <= amount; j++)
                {
                    t[i, j] = -1; //initialise with -1
                }
            }
            var temp = CoinChangeRecursive(coins, amount, coins.Length);

            return temp == Int32.MaxValue ? -1 : temp; //If denominations are not enough to make Amount, return -1
        }

        //n => current Index of coin array / Coin number
        private int CoinChangeRecursive(int[] coins, int amount, int n)
        {

            //Base Case # 1 --> Amount == 0 , valid combinations picked, return 0
            if (amount == 0) return 0;

            // n < 0 but Amount != 0 implies invalid combination of denominations, return MaxValue
            if (n == 0) return Int32.MaxValue;

            if (t[n, amount] != -1) return t[n, amount];

            if (coins[n - 1] <= amount)
            {
                //2 choices, take or Not take
                var taken = CoinChangeRecursive(coins, amount - coins[n - 1], n) + 1;
                if (taken == Int32.MaxValue || taken == Int32.MinValue)
                {
                    taken = Int32.MaxValue;
                }

                var notTaken = CoinChangeRecursive(coins, amount, n - 1);
                if (notTaken == Int32.MaxValue || notTaken == Int32.MinValue)
                {
                    notTaken = Int32.MaxValue;
                }

                return t[n, amount] = Math.Min(taken, notTaken);
            }
            else
            {
                return t[n, amount] = CoinChangeRecursive(coins, amount, n - 1);
            }
        }
        */
    }
}

