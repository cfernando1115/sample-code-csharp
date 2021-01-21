using System;
using NUnit.Framework;
using Moq;

namespace SampleCode.UnitTests
{
    [TestFixture]
    public class ClockTests
    {
        private Clock _clock;
        private Mock<ILogger> _logger;

        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger>();
            _clock = new Clock(_logger.Object);
        }

        [Test]
        [TestCase(0,1)]
        [TestCase(13,1)]
        public void SetClock_HourIsNotBetween1And12_LogsInvalidHour(int hour, int min)
        {
            _clock.SetClock(hour, min);

            _logger.Verify(l => l.Log("Invalid hour"));
        }

        [Test]
        [TestCase(1, -1)]
        [TestCase(1, 60)]
        public void SetClock_MinuteIsNotBetween0And59_LogsInvalidMinute(int hour, int min)
        {
            _clock.SetClock(hour, min);

            _logger.Verify(l => l.Log("Invalid minute"));
        }
    }
}
