using System;
using System.Collections.Generic;

namespace AllAboutHeaps.DynamicProgramming
{
    public class MaximumProfitJobScheduling
    {

        public MaximumProfitJobScheduling()
        {
        }

        // Following is the tabulation (bottom up) from GFG
        public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            List<List<int>> jobs = new List<List<int>>();

            int len = startTime.Length;// Can query Length on any of the 3 arrays given..

            //Combine all 3 arrays into 1 combined data structure.
            for (int i = 0; i < len; i++)
            {
                var start = startTime[i];
                var end = endTime[i];
                var profitMade = profit[i];

                jobs.Add(new List<int> { start, end, profitMade });
            }

            // Sort this by the EndTime ofthe jobs
            jobs.Sort((x, y) => { return x[1].CompareTo(y[1]); });

            return ComputeMaxProfit(jobs, len);

        }

        private int ComputeMaxProfit(List<List<int>> jobs, int len)
        {
            int[] dp = new int[len];


            // This means, if you only have 1 job in your Jobs collection, then max profit you can make is
            // that 1 job's profit
            dp[0] = jobs[0][2];

            // Iterate through the rest
            for (int i = 1; i < len; i++)
            {
                int include = jobs[i][2]; //Profit for the current job;
                int prevJobPossible = FindPrevJob(jobs, i);
                if (prevJobPossible != -1)
                {
                    include += dp[prevJobPossible];
                }

                int exclude = dp[i - 1];

                dp[i] = Math.Max(include, exclude);
            }

            return dp[len - 1];
        }

        private int FindPrevJob(List<List<int>> jobs, int currJob)
        {

            // Linear scanning the array
            //int prevJob = -1;

            //for (int i = currJob-1; i >= 0; i--)
            //{
            //    if(jobs[i][1] <= jobs[currJob][0])
            //    {
            //        return prevJob = i;
            //    }
            //}

            //Binary search
            var start = 0;
            var end = jobs.Count;
            var prevJobIndex = -1;
            while (start <= end)
            {
                var mid = start + (end - start) / 2;

                if (jobs[mid][1] <= jobs[currJob][0])
                {
                    start = mid + 1;
                    prevJobIndex = mid;
                }
                else
                {
                    end = mid - 1;
                }

            }


            return prevJobIndex;
        }

        /*
         // The below soln. gives Stack Overflow, based this off of offical LC soln for Recursion + Memoization
         
         

        int[] t = new int[50001];
        public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            t = new int[50001];
            Array.Fill(t, -1); // initialise with -1

            List<List<int>> jobs = new List<List<int>>();

            //Combine all 3 arrays into 1 combined data structure.
            for (int i = 0; i < startTime.Length; i++)
            {
                var start = startTime[i];
                var end = endTime[i];
                var profitMade = profit[i];

                jobs.Add(new List<int> { start, end, profitMade });
            }

            // Sort this by the StartTime ofthe job
            jobs.Sort((x, y) => { return x[0].CompareTo(y[0]); });

            // Storing all the sorted Start Times into a separate list
            List<int> listOfStartTimes = new List<int>();
            for (int i = 0; i < startTime.Length; i++)
            {
                listOfStartTimes.Add(jobs[i][0]);
            }


            return MaxProfitCalculator(jobs, startTime, startTime.Length, 0);

        }

        private int MaxProfitCalculator(List<List<int>> jobs, int[] startTime, int totalN, int position)
        {
            //Base Case
            if (position == totalN) return 0; // No more  jobs to look at, so total profit at that point is 0

            if (t[position] != -1) return t[position]; // Result has been pre computed, so use that

            int nextJobIndex = CalcNextJobIndex(startTime, jobs[position][1]); //Next job index We can pick, pass in curr Job Endtime

            int tempJobProfit = Math.Max(
                                          // Take the current Job
                                          jobs[position][2] + MaxProfitCalculator(jobs, startTime, totalN, nextJobIndex),

                                          MaxProfitCalculator(jobs, startTime, totalN, position + 1)// Don't take current job
                    );
            return t[position] = tempJobProfit;

        }

        private int CalcNextJobIndex(int[] startTime, int target)
        {
            int start = 0;
            int end = startTime.Length - 1;

            var res = startTime.Length;  //For those end times that are past the last startTime, we can't take any more jobs, so
                                         // ini. with len(StartTime) so when value is returned, it'll hit base case

            while (start <= end)
            {
                var mid = start + (end - start) / 2;

                if (startTime[mid] >= target)
                {
                    end = mid - 1;
                    res = mid;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return res;
        }
        */
    }
}
