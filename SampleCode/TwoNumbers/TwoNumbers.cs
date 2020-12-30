using System;
using System.Collections.Generic;

namespace SampleCode
{
    public class TwoNumbers
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public TwoNumbers(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void SwapNumbers()
        {
            X = Y + X;
            Y = X - Y;
            X = X - Y;
        }
    }
}
