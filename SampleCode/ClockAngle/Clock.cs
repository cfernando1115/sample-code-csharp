namespace SampleCode
{
    public class Clock
    {
        public int Hour{get; private set;}
        public int Min{get;private set;}

        public Clock(int hour, int min)
        {
            Hour=hour;
            Min=min;
        }
    }
}
