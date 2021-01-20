using System;
using NUnit.Framework;


namespace SampleCode.UnitTests
{
    [TestFixture]
    public class TwoNumbersTests
    {
        [Test]
        public void SwapNumbers_WhenCalled_SwapTwoNumbers()
        {
            var x = 1;
            var y = 2;
            var twoNumbers = new TwoNumbers(x,y);
            twoNumbers.SwapNumbers();

            Assert.That(twoNumbers.X, Is.EqualTo(2));
            Assert.That(twoNumbers.Y, Is.EqualTo(1));
        }
    }
}
