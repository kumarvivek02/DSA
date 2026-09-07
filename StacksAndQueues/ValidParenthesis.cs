using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutHeaps.StacksAndQueues
{
    public class ValidParenthesis
    {
        public bool IsValid(string s)
        {
            var dict = new Dictionary<char, char>
            {
                { ')', '(' },
                { '}', '{' },
                { ']', '[' },
            };

            var stack = new Stack<char>();

            foreach (var character in s)
            {
                if (dict.TryGetValue(character, out var expectedOpen))
                {
                    if (stack.Count == 0 || stack.Pop() != expectedOpen)
                        return false;
                }
                else
                {
                    stack.Push(character);
                }
            }

            return stack.Count == 0;
        }
    }
}
