using System;
using System.Collections.Generic;

namespace AllAboutHeaps.Trie
{
    public class DesignFileSystem
    {
        public DesignFileSystem()
        {
        }


    }

    public class FileSystem
    {
        TrieNode root;

        public FileSystem()
        {
            root = new TrieNode("");
        }

        public bool CreatePath(string path, int value)
        {
            var paths = path.Split('/');

            //ini. and start traversal from Root node
            TrieNode curr = root;

            //Split returns empty string for char before 1st /, so start i from 1; Parse & go through all 
            for (int i = 1; i < paths.Length; i++)
            {
                string ch = paths[i];
                if (!curr.dict.ContainsKey(ch))
                {
                    if (i == paths.Length - 1)
                    {
                        curr.dict.Add(ch, new TrieNode(ch));
                    }
                    else
                    {
                        return false;
                    }
                }

                // Value exists, so advance Curr to next node
                curr = curr.dict[ch];

            }

            // Made it to here could be
            //1) Node you're being asked to Create already exists
            //2) Node you're being asked to Create does not exist
            // Value not equal to -1 means the path already exists in the trie.
            if (curr.val != -1)
            {
                return false;
            }
            else
            {
                curr.val = value;
            }
            return true;

        }

        public int Get(string path)
        {
            var paths = path.Split('/');

            //ini. and start traversal from Root node
            TrieNode curr = root;

            for (int i = 1; i < paths.Length; i++)
            {
                var ch = paths[i];

                if (!curr.dict.ContainsKey(ch))
                {
                    return -1;
                }
                curr = curr.dict[ch];
            }

            return curr.val;
        }
    }

    public class TrieNode
    {
        public string path;
        public int val;
        public Dictionary<string, TrieNode> dict;

        public TrieNode(string path)
        {
            this.path = path;
            val = -1;
            dict = new Dictionary<string, TrieNode>();
        }
    }
}
