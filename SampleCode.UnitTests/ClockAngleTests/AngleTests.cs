using System;
using NUnit.Framework;
using Moq;

namespace SampleCode.UnitTests.ClockAngleTests
{
    [TestFixture]
    public class AngleTests
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
        [TestCase(12,0,0)]
        [TestCase(6,30,0)]
        public void CalculateAngle_MinAngleIsEqualToHourAngle_ReturnZero(int hour, int min, int expectedResult)
        {
            _clock.SetClock(hour, min);
            var angle = new Angle(_clock);

            var result = angle.CalculateAngle();
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(1, 30, 150)]
        [TestCase(2, 45, 210)]
        [TestCase(3, 45, 180)]
        public void CalculateAngle_MinAngleIsGreaterThanHourAngle_ReturnAngle(int hour, int min, int expectedResult)
        {
            _clock.SetClock(hour, min);
            var angle = new Angle(_clock);

            var result = angle.CalculateAngle();
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(7, 5, 180)]
        [TestCase(3, 5, 300)]
        [TestCase(9, 5, 120)]
        public void CalculateAngle_HourAngleIsGreaterThanMinAngle_ReturnAngle(int hour, int min, int expectedResult)
        {
            _clock.SetClock(hour, min);
            var angle = new Angle(_clock);

            var result = angle.CalculateAngle();
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
