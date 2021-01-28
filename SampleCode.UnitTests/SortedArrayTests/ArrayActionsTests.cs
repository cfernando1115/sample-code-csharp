using System;
using NUnit.Framework;

namespace SampleCode.UnitTests
{
    [TestFixture]
    public class ArrayActionsTests
    {
        private ArrayActions _arrayActions;

        [SetUp]
        public void SetUp()
        {
            _arrayActions = new ArrayActions();
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 },2)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, 3.5f)]
        public void FindMedianOfSortedArrays_WhenCalled_ReturnMedianOfArrays(int[] arr1, int[] arr2, float expectedResult)
        {
            var result=_arrayActions.FindMedianOfSortedArrays(arr1, arr2);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
