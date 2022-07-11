using System;
using System.Collections.Generic;

namespace AllAboutHeaps.BinarySearch
{
    public class MostProfitAssigningWork
    {
        public MostProfitAssigningWork()
        {
        }

        public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
        {
            List<List<int>> jobs = new List<List<int>>();
            for (int j = 0; j < difficulty.Length; j++)
            {
                jobs.Add(new List<int> { difficulty[j], profit[j] });
            }

            jobs.Sort((x, y) => { return x[0].CompareTo(y[0]); });

            Array.Sort(worker);

            int maxProfit = 0; int result = 0; int i = 0;
            foreach (var w in worker)
            {

                while (i < jobs.Count && jobs[i][0] <= w)
                {
                    maxProfit = Math.Max(maxProfit, jobs[i++][1]);
                }

                result += maxProfit;
            }


            return result;
        }

        private int FindClosestJobIndex(List<List<int>> jobs, int[] workerDifficulty, int currentWorker)
        {
            int start = 0;
            int end = jobs.Count - 1;

            int maxProfit = Int32.MinValue;
            int res = -1;
            while (start <= end)
            {
                var mid = start + (end - start) / 2;

                if (jobs[mid][0] == workerDifficulty[currentWorker])
                {
                    return mid;
                }
                else if (jobs[mid][0] < workerDifficulty[currentWorker])
                {
                    start = mid + 1;
                    res = mid;// contender
                    maxProfit = Math.Max(maxProfit, jobs[mid][1]);
                }
                else if (jobs[mid][0] > workerDifficulty[currentWorker])
                {
                    end = mid - 1;

                }
            }

            return res == -1 ? 0 : maxProfit;
        }
    }
}
