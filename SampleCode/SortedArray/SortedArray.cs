using System;
using System.Linq;

namespace SampleCode
{
    public class IntArray
    {
        public int[] SortedArray;

        public IntArray(string numbers)
        {
            //Sorts string of comma-separated numbers
            SortedArray = numbers.Split(',')
                .Select(n => Convert.ToInt32(n))
                .OrderBy(n=>n)
                .ToArray();
        }
    }
}
