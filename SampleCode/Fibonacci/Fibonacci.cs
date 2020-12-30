namespace SampleCode
{
    class Fibonacci
    {
        public int Fib { get; private set; }

        public int FindFib(int x)
        {
            //First three numbers:0,1,1
            if (x <= 0)
            {
                //Invalid number
                return -1;
            }
            if (x == 1)
            {
                return 0;
            }
            var i = 2;
            var prevFib = 1;
            Fib = 1;

            //Will only enter loop if x>3
            while (x > i+1)
            {
                //calculate next fib using previous and current, then reassign previous and current fib
                var nextFib = prevFib + Fib;
                prevFib = Fib;
                Fib = nextFib;
                i++;
            }
            return Fib;
        }
    }
}
