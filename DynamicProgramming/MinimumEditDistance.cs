using System;
namespace AllAboutHeaps.DynamicProgramming
{
    public class MinimumEditDistance
    {
        public MinimumEditDistance()
        {
        }

        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;

            int[,] dp = new int[m + 1, n + 1];

            /* Rules
			 * Insert/ Replace/ Remove operations allowed when chars do NOT match
			 * 
			 * 1) if word1[m-1] == word2[n-1], dp[i,j] = dp[i-1,j-1] + 0 // No cost 
			 * 2) if word1[m-1] != word2[n-1], dp[i,j] = Min ( Insert, Replace, Remove)
			 
			 */

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {

                    // initialisation; when word1 = " ",then number of operations needed to make word1 = word2
                    // is number of characters of word2 to be Inserted
                    if (i == 0)
                    {
                        dp[i, j] = j;
                    }

                    //If word2 = "", only option is to remove all chars from 2nd string
                    else if (j == 0)
                    {
                        dp[i, j] = i;
                    }

                    //If last chars are Equal, do nothing
                    else if (word1[i - 1] == word2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }

                    // UnEqual lastchar means at least 1 operation needs to be done
                    // Consider all 3, find minimum amongst them
                    else if (word1[i - 1] != word2[j - 1])
                    {
                        dp[i, j] = 1 + Math.Min(dp[i, j - 1], //Insert
                                            Math.Min(dp[i - 1, j],  //Remove
                                                    dp[i - 1, j - 1])); //Replace						

                    }
                }
            }

            return dp[m, n];
        }
    }
}

