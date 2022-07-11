using System;
using System.Collections.Generic;

namespace AllAboutHeaps.Graphs
{
    public class EvaluateDivision
    {
        public EvaluateDivision()
        {
        }

        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            Dictionary<string, List<Tuple<string, double>>> adjList = new Dictionary<string, List<Tuple<string, double>>>();

            BuildAdjacencyList(equations, values, adjList);

            double[] retValues = new double[queries.Count];

            for (int i = 0; i < queries.Count; i++)
            {
                var s = queries[i][0];
                var d = queries[i][1];

                HashSet<string> visited = new HashSet<string>();
                retValues[i] = dfsOnQueries(s, d, adjList, visited);
            }

            return retValues;
        }

        private double dfsOnQueries(string s, string d, Dictionary<string, List<Tuple<string, double>>> adjList, HashSet<string> visited)
        {
            if (!adjList.ContainsKey(s) || !adjList.ContainsKey(d)) return -1;

            if (s == d) return 1;

            visited.Add(s);

            foreach (var neighbor in adjList[s])
            {
                if (visited.Contains(neighbor.Item1)) continue;
                var ans = dfsOnQueries(neighbor.Item1, d, adjList, visited);
                // Only if ret. value from DFS is not -1, multiple by edge wt., else that DFS result should be dropped.
                if (ans != -1.00) return ans * neighbor.Item2;
            }

            return -1;

        }

        private void BuildAdjacencyList(IList<IList<string>> equations, double[] values
                , Dictionary<string, List<Tuple<string, double>>> adjList)
        {
            // Go through equations[][] & build our Adj. List with values from Values[]
            for (int i = 0; i < equations.Count; i++)
            {
                var s = equations[i][0];
                var d = equations[i][1];

                if (!adjList.ContainsKey(s))
                {
                    adjList.Add(s, new List<Tuple<string, double>>());
                }
                adjList[s].Add(new Tuple<string, double>(d, values[i]));

                if (!adjList.ContainsKey(d))
                {
                    adjList.Add(d, new List<Tuple<string, double>>());
                }
                adjList[d].Add(new Tuple<string, double>(s, 1 / values[i]));
            }
        }
    }
}
