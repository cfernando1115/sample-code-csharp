using System;
namespace SampleCode
{
    public class Clock
    {
        private ILogger _logger;
        public int Hour{get; private set;}
        public int Min{get;private set;}

        public Clock(ILogger logger)
        {
            _logger = logger;
        }

        public void SetClock(int hour, int min)
        {
            if (hour > 12 || hour < 1)
            {
                _logger.Log("Invalid hour");
                return;
            }
            if (min > 59 || min < 0)
            {
                _logger.Log("Invalid minute");
                return;
            }
            Hour = hour;
            Min = min;
        }
    }
}
