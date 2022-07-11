using System;
namespace AllAboutHeaps.Arrays
{
    public class ContainerWithMostWater
    {
        public ContainerWithMostWater()
        {
        }

        public int MaxArea(int[] height)
        {

            //Area = Len * Width
            //Len = Right Index - Left Index
            //Width = Min(heigh[left],height[right]

            int left = 0;
            int right = height.Length - 1;
            int maxArea = Int32.MinValue;

            while (left < right)
            {
                var length = right - left;

                var width = Math.Min(height[left], height[right]); //Choose the min value as width

                maxArea = Math.Max(maxArea, length * width);

                if (height[left] < height[right]) left++;// We will move the side which is smaller
                else right--;


            }
            return maxArea;
        }
    }
}

