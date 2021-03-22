using System;
using NUnit.Framework;
using Moq;

namespace SampleCode.UnitTests
{
    [TestFixture]
    public class RomanNumeralsTests
    {
        private RomanNumerals _romanNumerals;
        private string _outOfRangeResponse = "Number out of range";

        [SetUp]
        public void SetUp()
        {
            _romanNumerals = new RomanNumerals();
        }

        [Test]
        [TestCase(0)]
        [TestCase(4000)]
        public void ConvertToRomanNumerals_NumberOutOfRange_OutOfRangeResponse(int num)
        {
            var result = _romanNumerals.ConvertToRomanNumerals(num);
            Assert.That(result, Is.EqualTo(_outOfRangeResponse));
        }

        [Test]
        [TestCase(1,"I")]
        [TestCase(4,"IV")]
        [TestCase(9,"IX")]
        [TestCase(11,"XI")]
        [TestCase(44,"XLIV")]
        [TestCase(99,"XCIX")]
        public void ConvertToRomanNumerals_ValidNumber_ReturnRomanNumeral(int num, string expectedResult)
        {
            var result = _romanNumerals.ConvertToRomanNumerals(num);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
