using System;
namespace AllAboutHeaps.Bit_Manipulation
{
    public class ReversingBits
    {
        /*
        Input: n = 00000010100101000001111010011100
        Output:    00111001011110000010100101000000
        Explanation: The input binary string 00000010100101000001111010011100 represents the unsigned integer 43261596, so return 964176192 which its binary representation is 00111001011110000010100101000000.
        */

        public int ReverseBits(int n)
        {
            int result = 0;

            for(int i = 0; i < 32; i++)
            {
                var temp = n & 1; //Get last bit
                result = result <<1;
                result = result + temp;
                n = n >> 1;
            }
            return result;
        }
    }
}