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
            _linkedList = new LinkedList();
        }

        [Test]
        public void AddNodeToEnd_WhenCalled_AddNodeToEndOfList()
        {
            PopulateList();
            var newNode = new Node { Value = 2 };
            _linkedList.AddNodeToEnd(newNode);
            Assert.That(_linkedList.Head.Next, Is.EqualTo(newNode));
        }

        [Test]
        public void AddNodeToStart_WhenCalled_AddNodeToStartOfList()
        {
            PopulateList();
            var newNode = new Node { Value = 2 };
            _linkedList.AddNodeToStart(newNode);
            Assert.That(_linkedList.Head, Is.EqualTo(newNode));
        }

        [Test]
        public void RemoveNodeFromList_ListIsEmpty_ReturnNegativeOne()
        {
            var result=_linkedList.RemoveNodeFromList(_linkedList.Head);
            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void RemoveNodeFromList_NodeDoesNotExistInList_ReturnNegativeOne()
        {
            PopulateList();
            var node = new Node { Value = 2 };
            var result = _linkedList.RemoveNodeFromList(node);
            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void HasCycle_ListIsEmpty_ReturnFalse()
        {
            var result = _linkedList.HasCycle();
            Assert.That(result, Is.False);
        }

        [Test]
        public void HasCycle_ListHasNoCycle_ReturnFalse()
        {
            PopulateList();
            var result=_linkedList.HasCycle();
            Assert.That(result, Is.False);
        }

        [Test]
        public void HasCycle_ListHasCycle_ReturnTrue()
        {
            PopulateList();
            var newNode = new Node { Value = 2, Next = _linkedList.Head };
            _linkedList.Head.Next = newNode;
            var result = _linkedList.HasCycle();
            Assert.That(result, Is.True);
        }

        private void PopulateList()
        {
            _linkedList.Head = new Node { Value = 1 };
        }
    }
}
