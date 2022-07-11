using System;
namespace AllAboutHeaps.DynamicProgramming
{
    public class DeleteOperationOn2Strings
    {
        public DeleteOperationOn2Strings()
        {
        }

        public int MinDistance(string word1, string word2)
        {
            var lcs = LongestCommonSubsequence(word1, word2);

            int numOfSteps = 0;
            numOfSteps += (word1.Length - lcs);
            numOfSteps += ((word2.Length) - lcs);

            return numOfSteps;
        }

        private int LongestCommonSubsequence(string X, string Y)
        {
            int m = X.Length;
            int n = Y.Length;

            var t = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        t[i, j] = 0;
                    }

                    else if (X[i - 1] == Y[j - 1])
                    {
                        t[i, j] = t[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        t[i, j] = Math.Max(t[i - 1, j],
                                            t[i, j - 1]);

                    }
                }
            }

            return t[m, n];

        }
    }
}
