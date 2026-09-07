using System;

namespace AllAboutHeaps
{
    public class TrappingRainWater
    {
        #region Solution 1 : Brute force/ Naive
        // public int Trap(int[] height)
        // {
        //     int len = height.Length;

        //     int ans = 0;

        //     for(int i=1; i< len-1; i++)
        //     {
        //         int lmax = 0;
        //         for (int j = i; j >= 0; j--)
        //         {
        //             lmax = Math.Max(lmax,height[j]);
        //         }
        //         int rmax = 0;
        //         for (int j = i ; j < len; j++)
        //         {
        //             rmax = Math.Max(height[j],rmax);
        //         }

        //         ans = ans + (Math.Min(lmax,rmax) - height[i]);
        //     }
        //     return ans;

        // }
        #endregion

        #region Solution 2 (Pre fix Array):
         
        #endregion

        #region Solution 3 (2 Pointer): Most Optimal Soln TC: O(N), SC: O(1)
        public int Trap(int[] height)
        {
            int ans = 0;
            int len = height.Length;
            int lmax = 0; // will hold max height from left

            int rmax = 0; // will hold max height from right
            int l = 0;
            int r = len - 1; //index of last element

            while (l < r)
            {
                lmax = Math.Max(lmax, height[l]);
                rmax = Math.Max(rmax, height[r]);

                // lower maximum determines spill side
                if (lmax < rmax)
                {
                    ans += lmax - height[l];
                    l++;
                }
                else
                {
                    ans += rmax - height[r];
                    r--;
                }
            }
            return ans;
        }
        #endregion
       
       
        // public int Trap(int[] height)
        // {
        //     int len = height.Length;
        //     // Corner case
        //     if (len < 3)
        //         return 0;

        //     //Optimal SC-> O(1)  Optimal TC -> O(N)

        //     int leftMax = height[0];
        //     int rightMax = height[len - 1];

        //     int left = height[1];
        //     int right = height[len - 2];

        //     int totWaterCollected = 0;
        //     while (left < right)
        //     {
        //         //LeftMax is smaller, so max water stored will be LeftMax - height[i]
        //         if (leftMax < rightMax)
        //         {
        //             if (height[left] < leftMax)
        //             {
        //                 totWaterCollected += leftMax - height[left];
        //             }
        //             else
        //             {
        //                 leftMax = height[left];
        //             }
        //             left++;
        //         }
        //         else //Start from the right side
        //         {
        //             if (height[right] < rightMax)
        //             {
        //                 totWaterCollected += rightMax - height[right];
        //             }
        //             else
        //             {
        //                 rightMax = height[right];
        //             }
        //             right--;
        //         }
        //     }

        //     return totWaterCollected;
        // }
    }
}
