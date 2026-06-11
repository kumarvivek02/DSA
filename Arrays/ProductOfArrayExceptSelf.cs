using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllAboutHeaps.Arrays
{
    public class ProductOfArrayExceptSelf
    {
        /*
        Input: nums = [1,2,3,4]
        Output: [24,12,8,6]
        */

        /*
        Soln 2: Optimal - O(1) space (ignoring output array space)
        Time Complexity: O(n)
        Space Complexity: O(1)
        Approach:
        1. Calculate Prefix products and store directly in result array
        2. Calculate Postfix products on the fly and multiply directly into result array
        */
        public int[] ProductExceptSelf(int[] nums)
        {
            int length = nums.Length;
            
            int[] result = new int[length];

            //Step 1 : Calculate Prefix Products directly into result array
            result[0] = 1; //no elements to the left of index 0
            for (int i = 1; i < length; i++)
            {
                result[i] = result[i - 1] * nums[i - 1];
            }
            //Step 2: Calculate Postfix Products and multiply directly into result array
            int postfixProduct = 1; //no elements to the right of last index
            for (int i = length-1; i >= 0; i--)
            {
                result[i] = result[i] * postfixProduct;
                postfixProduct = postfixProduct * nums[i];
            }
            return result;
        }




        /*
        Soln 1: Using Prefix and Postfix arrays
        Time Complexity: O(n)
        Space Complexity: O(n)
        Analysis: Calculate Prefix products and Postfix products in 
                    separate arrays and then multiply to get result
        */
        // public int[] ProductExceptSelf(int[] nums)
        // {
        //     int length = nums.Length;
        //     int[] prefixProducts = new int[length];
        //     int[] postfixProducts = new int[length];
        //     int[] result = new int[length];

        //     //Calculate Prefix Products
        //     prefixProducts[0] = 1; //no elements to the left of index 0
        //     for (int i = 1; i < length; i++)
        //     {
        //         prefixProducts[i] = prefixProducts[i - 1] * nums[i - 1];
        //     }
        //     //Calculate Postfix Products
        //     postfixProducts[length - 1] = 1; //no elements to the right of last index
        //     for (int i = length - 2; i >= 0; i--)
        //     {
        //         postfixProducts[i] = postfixProducts[i + 1] * nums[i + 1];
        //     }
        //     //Calculate Result by multiplying prefix and postfix products
        //     for (int i = 0; i < length; i++)
        //     {
        //         result[i] = prefixProducts[i] * postfixProducts[i];
        //     }
        //     return result;
        // }
    }
}