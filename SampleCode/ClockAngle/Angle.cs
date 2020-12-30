namespace SampleCode
{
    public class Angle
    {
        public int TotalAngle {get; private set;}
        public Clock Clock { get; private set;}

        public Angle(Clock clock)
        {
            Clock = clock;
        }

        public int CalculateAngle()
        {
            //Calculate individual angles
            var hourAngle = Clock.Hour * 30;
            var minAngle = Clock.Min * 6;

            //Example 1:30 or 6:30
            if (minAngle >= hourAngle)
            {
                TotalAngle = minAngle - hourAngle;
            }
            else
            {
                //Example 7:05
                TotalAngle = 360 + minAngle - hourAngle;

            }
            return TotalAngle;
        }
    }
}
