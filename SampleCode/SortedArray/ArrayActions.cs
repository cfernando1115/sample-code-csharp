using System;

namespace SampleCode
{
    public class ArrayActions
    {
        public void FindMedianOfSortedArrays(int[] arr1,int[] arr2)
        {
            var sortedArray = new int[arr1.Length + arr2.Length];

            var i = 0;
            var y = 0;
            var k = 0;

            //While neither array has been completely added to sorted array
            while (y < arr1.Length && k < arr2.Length)
            {
                if (arr1[y] <= arr2[k])
                {
                    sortedArray[i] = arr1[y];
                    y++;
                }
                else
                {
                    sortedArray[i] = arr2[k];
                    k++;
                }
                i++;
            }

            //After one array has been added to sorted array
            while (i < sortedArray.Length)
            {
                if (y == arr1.Length)
                {
                    sortedArray[i] = arr2[k];
                    k++;
                }
                else
                {
                    sortedArray[i] = arr1[y];
                    y++;
                }
                i++;
            }

            //Determine if array has an odd or even number of elements to find median
            var sortedArrayLength = sortedArray.Length;
            var mid = sortedArrayLength / 2;
            if (sortedArrayLength % 2 == 0)
            {
                //Convert to double to account for division of two elements
                var median = ((double)sortedArray[mid] + sortedArray[mid - 1]) / 2;
                Console.WriteLine(median);
            }
            else
            {
                var median = sortedArray[mid];
                Console.WriteLine(median);
            }

        }
    }
}
