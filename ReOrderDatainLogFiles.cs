using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class ReOrderDataInLogFiles
    {
        public ReOrderDataInLogFiles()
        {
        }

        public string[] ReorderLogFiles(string[] logs)
        {
            SortedDictionary<string, SortedSet<string>> letterLogs = new SortedDictionary<string, SortedSet<string>>();
            List<string> numberLogs = new List<string>();

            var result = new List<string>();


            foreach (var item in logs)
            {
                if (item[item.IndexOf(' ') + 1] >= 'a' && item[item.IndexOf(' ') + 1] <= 'z')
                {
                    //letterLogs.Add(item.Substring(item.IndexOf(' ') + 1), item);
                    if (letterLogs.ContainsKey(item.Substring(item.IndexOf(' ') + 1)))
                    {
                        letterLogs[item.Substring(item.IndexOf(' ') + 1)].Add(item);
                    }
                    else
                    {
                        letterLogs.Add(item.Substring(item.IndexOf(' ') + 1), new SortedSet<string> { item });
                    }
                }
                else
                {
                    numberLogs.Add(item);
                }
            }


            foreach (var item in letterLogs)
            {
                result.AddRange(item.Value);
            }
            foreach (var item in numberLogs)
            {
                result.Add(item);
            }

            return result.ToArray();
        }
    }


    #region How to use IComparer
    public class LogsComparer : IComparer<string>
    {
        public int Compare(string first, string second)
        {
            int num1;
            int num2;
            var comps1 = first.Split(' ');
            var comps2 = second.Split(' ');

            var is1Num = Int32.TryParse(comps1[1], out num1);

            var is2Num = Int32.TryParse(comps2[1], out num2);

            string logTypeFirst = is1Num ? "dig" : "let";

            string logTypeSecond = is2Num ? "dig" : " let";

            if (logTypeFirst == "dig" && logTypeSecond == "let")
            {
                return 1;
            }
            else if (logTypeFirst == "let" && logTypeSecond == "dig")
            {
                return -1;
            }

            else if (logTypeFirst == "let" && logTypeSecond == "let")
            {
                if (first.Substring(comps1.Length, first.Length - 1).CompareTo(second.Substring(comps2.Length, second.Length - 1)) == 0)
                {
                    return first.Substring(0, comps1.Length - 1).CompareTo(second.Substring(0, comps2.Length - 1));
                }
                else
                {
                    return first.Substring(comps1.Length, first.Length - 1).CompareTo(second.Substring(comps2.Length, second.Length - 1)) < 0 ? -1 : 1;
                }
            }
            else //if (logTypeFirst == "dig" && logTypeSecond == "dig")
            {
                return 0;
            }
        }
    }
    #endregion
}
