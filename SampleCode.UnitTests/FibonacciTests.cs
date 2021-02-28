using System;
using NUnit.Framework;
using SampleCode;
using Moq;

namespace SampleCode.UnitTests
{
    [TestFixture]
    public class FibonacciTests
    {
        private Fibonacci _fib;
        private Mock<ILogger> _logger;

        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger>();
            _fib = new Fibonacci(_logger.Object);
        }

        [Test]
        [TestCase(-1, -1)]
        [TestCase(0, -1)]
        public void FindFib_NumberIsNegativeOrZero_ReturnNegativeOne(int index, int expectedResult)
        {
            var result = _fib.FindFib(index);
            Assert.That(result, Is.EqualTo(expectedResult));           
        }

        [Test]
        public void FindFib_NumberIsOne_ReturnZero()
        {
            var result = _fib.FindFib(1);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        public void FindFib_NumberIsTwoOrThree_ReturnOne(int index, int expectedResult)
        {
            var result = _fib.FindFib(index);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(null, "The index is invalid")]
        public void FindFib_InvalidArgument_LogInvalidMessage(int? index, string expectedResult)
        {
            _fib.FindFib(index);
            _logger.Verify(l => l.Log(expectedResult));
        }

        [Test]
        [TestCase(5, 3)]
        [TestCase(10, 34)]
        [TestCase(15, 377)]
        public void FindFib_WhenCalled_ReturnFibonacciSequenceAtPosition(int index, int expectedResult)
        {
            var result = _fib.FindFib(index);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
