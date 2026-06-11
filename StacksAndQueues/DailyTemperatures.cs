using System;
using System.Collections.Generic;

namespace DSA.StacksAndQueues
{
    public class DailyTemperature
    {
        public DailyTemperature()
        {
        }

        public int[] DailyTemperatures(int[] temperatures)
        {
            //Tuple.Item1 => index
            //Tuple.Item2 => temperature[i]
            Stack<Tuple<int, int>> st = new Stack<Tuple<int, int>>();

            int[] res = new int[temperatures.Length];


            for (int i = temperatures.Length - 1; i >= 0; i--)
            {
                while (st.Count > 0 && st.Peek().Item2 <= temperatures[i])
                {
                    // Go on popping till you find temp. larger than current
                    st.Pop();
                }

                if (st.Count == 0)
                {
                    res[i] = 0;
                }
                else
                {
                    res[i] = st.Peek().Item1 - i;
                }
                st.Push(new Tuple<int, int>(i, temperatures[i]));
            }

            return res;
        }
    }
}

