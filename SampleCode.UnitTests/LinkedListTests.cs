using System;
using NUnit.Framework;

namespace SampleCode.UnitTests
{
    [TestFixture]
    public class LinkedListTests
    {
        private LinkedList _linkedList;
        [SetUp]
        public void SetUp()
        {
            _linkedList = new LinkedList(new Node { Value = 1 });
        }

        [Test]
        public void AddNodeToEnd_WhenCalled_AddsNodeToEndOfList()
        {
            var newNode = new Node { Value = 2 };
            _linkedList.AddNodeToEnd(newNode);
            Assert.That(_linkedList.Head.Next, Is.EqualTo(newNode));
        }

        [Test]
        public void AddNodeToStart_WhenCalled_AddsNodeToStartOfList()
        {
            var newNode = new Node { Value = 2 };
            _linkedList.AddNodeToStart(newNode);
            Assert.That(_linkedList.Head, Is.EqualTo(newNode));
        }

        [Test]
        public void RemoveNodeFromList_WhenCalled_RemovesNode()
        {
            _linkedList.RemoveNodeFromList(_linkedList.Head);
            Assert.That(_linkedList.Head, Is.EqualTo(null));
        }

        [Test]
        public void IsListCircular_NotCircular_ReturnsFalse()
        {
            var result=_linkedList.IsListCircular();
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsListCircular_Circular_ReturnsTrue()
        {
            var newNode = new Node { Value = 2, Next = _linkedList.Head };
            _linkedList.Head.Next = newNode;
            var result = _linkedList.IsListCircular();
            Assert.That(result, Is.True);
        }
    }
}
