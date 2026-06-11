using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutHeaps.Maths
{
    /*
    Given an integer n, return the number of prime numbers that are strictly 
    less than n.
    */
    public class CountAllPrimes
    {

        public int CountPrimes(int n)
        {
            if (n <= 2) return 0;
            int count = 0;
            bool[] primeArray = Enumerable.Repeat(true, n).ToArray(); //initialise all True
            for (int i = 2; i < n; i++)
            {
                if (primeArray[i])
                {
                    count++;
                    //Mark it's multiples as false
                    for (int j = i * 2; j < n; j += i)
                    {
                        primeArray[j] = false;
                    }
                }
            }
            return count;
        }


    }
}