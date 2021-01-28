using System;
using NUnit.Framework;

namespace SampleCode.UnitTests.SortedArrayTests
{
    [TestFixture]
    public class IntArrayTests
    {
        private IntArray _intArray;

        [SetUp]
        public void SetUp()
        {
            _intArray = new IntArray();
        }
        [Test]
        public void SortArray_WhenCalled_SortArrayInAscendingOrder()
        {
            _intArray.SortArray("1,3,2");

            Assert.That(_intArray.SortedArray, Is.EqualTo(new int[]{1, 2, 3}));           
            
        }
    }
}
