using System;
namespace AllAboutHeaps
{
    public class TrappingRainWater
    {
        public TrappingRainWater()
        {
        }

        public int Trap(int[] height)
        {
            int len = height.Length;
            // Corner case
            if (len < 3) return 0;

            //Optimal SC-> O(1)  Optimal TC -> O(N)

            int leftMax = height[0];
            int rightMax = height[len - 1];

            int left = height[1];
            int right = height[len - 2];

            int totWaterCollected = 0;
            while (left < right)
            {
                //LeftMax is smaller, so max water stored will be LeftMax - height[i]
                if (leftMax < rightMax)
                {
                    if (height[left] < leftMax)
                    {
                        totWaterCollected += leftMax - height[left];

                    }
                    else
                    {
                        leftMax = height[left];
                    }
                    left++;
                }
                else //Start from the right side
                {
                    if (height[right] < rightMax)
                    {
                        totWaterCollected += rightMax - height[right];
                    }
                    else
                    {
                        rightMax = height[right];
                    }
                    right--;
                }
            }

            return totWaterCollected;
        }
    }
}

