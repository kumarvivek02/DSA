using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class AnalyseUserWebsitePattern
    {
        public AnalyseUserWebsitePattern()
        {
        }

        public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
        {

            //Step 1 To Unify the disparate Data structures into 1 Dictionary with username as Key
            Dictionary<string, List<Tuple<int, string>>> userMap = new Dictionary<string, List<Tuple<int, string>>>();

            for (int i = 0; i < timestamp.Length; i++)
            {
                if (!userMap.ContainsKey(username[i]))
                {
                    userMap.Add(username[i], new List<Tuple<int, string>>());
                }

                userMap[username[i]].Add(new Tuple<int, string>(timestamp[i], website[i]));
            }


            Dictionary<string, HashSet<string>> patternToUsersMap = new Dictionary<string, HashSet<string>>();
            int maxUsers = 0;
            string result = "";

            foreach (var item in userMap)
            {
                var userName = item.Key;
                var visits = item.Value;
                visits.Sort(new CustomTimeStampComparer());

                for (int i = 0; i < visits.Count - 2; i++)
                {
                    for (int j = i + 1; j < visits.Count - 1; j++)
                    {
                        for (int k = j + 1; k < visits.Count; k++)
                        {
                            string pattern = visits[i].Item2 + ":"
                                            + visits[j].Item2 + ":"
                                            + visits[k].Item2;

                            if (!patternToUsersMap.ContainsKey(pattern))
                            {
                                patternToUsersMap.Add(pattern, new HashSet<string>());
                            }
                            patternToUsersMap[pattern].Add(userName);

                            var count = patternToUsersMap[pattern].Count;
                            if (count > maxUsers)
                            {
                                maxUsers = count;
                                result = pattern;
                            }
                            else if (count == maxUsers)
                            {
                                result = String.Compare(result, pattern) < 0 ? result : pattern;
                            }
                        }
                    }
                }
            }

            return new List<string>(result.Split(":"));





        }
    }

    public class CustomTimeStampComparer : IComparer<Tuple<int, string>>
    {


        public int Compare(Tuple<int, string>? x, Tuple<int, string>? y)
        {
            return x.Item1.CompareTo(y.Item1);
        }
    }
}
