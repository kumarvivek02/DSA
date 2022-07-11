using System;
using System.Collections.Generic;

namespace AllAboutHeaps
{
    public class AlienDictionary
    {
        public AlienDictionary()
        {
        }

        public string AlienOrder(string[] words)
        {

            //Step 1 -> Build the Adjacency list
            Dictionary<char, List<char>> adjList = new Dictionary<char, List<char>>();
            Dictionary<char, bool> visited = new Dictionary<char, bool>();
            Dictionary<char, bool> dfsVisited = new Dictionary<char, bool>();

            foreach (var word in words)
            {
                foreach (var character in word)
                {
                    if (!adjList.ContainsKey(character))
                    {
                        adjList.Add(character, new List<char>());
                        visited.Add(character, false);
                        dfsVisited.Add(character, false);
                    }
                }
            }

            int len = words.Length;
            for (int i = 0; i < len - 1; i++)
            {
                var word0 = words[i];
                var word1 = words[i + 1];

                // Case when solution is invalid
                if (word1.Length < word0.Length && word0.StartsWith(word1))
                {
                    return "";
                }

                //Build adjacency list showing dependencies/ edge directions
                for (int j = 0; j < Math.Min(word0.Length, word1.Length); j++)
                {
                    if (word0[j] != word1[j])
                    {
                        adjList[word0[j]].Add(word1[j]);
                        break;
                    }
                }
            }

            Stack<char> topoSortedChars = new Stack<char>();

            foreach (var key in adjList.Keys)
            {
                if (!visited[key])
                {
                    if (dfsTopo(key, adjList, visited, dfsVisited, topoSortedChars)) return "";
                }
            }

            string res = "";

            while (topoSortedChars.Count > 0)
            {
                res += topoSortedChars.Pop();
            }

            return res;
        }

        private bool dfsTopo(char key, Dictionary<char, List<char>> adjList,
            Dictionary<char, bool> visited, Dictionary<char, bool> dfsVisited, Stack<char> topoSortedChars)
        {
            visited[key] = true;
            dfsVisited[key] = true;

            foreach (var neighbor in adjList[key])
            {
                if (!visited[neighbor])
                {
                    if (dfsTopo(neighbor, adjList, visited, dfsVisited, topoSortedChars)) return true;
                }
                else if (dfsVisited[neighbor])
                {
                    return true; // true implies Cycle detected
                }

            }

            dfsVisited[key] = false;
            topoSortedChars.Push(key);
            return false;

        }
    }
}
