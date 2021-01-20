using System;
using NUnit.Framework;
using Moq;

namespace SampleCode.UnitTests
{
    [TestFixture]
    public class LinkedListTests
    {
        private LinkedList _linkedList;
        private Mock<ILogger> _logger;

        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger>();
            _linkedList = new LinkedList(_logger.Object);
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
        public void RemoveNodeFromList_ListIsEmpty_LogEmptyListMessage()
        {
            _linkedList.RemoveNodeFromList(_linkedList.Head);

            _logger.Verify(l => l.Log("List is empty"));
        }

        [Test]
        public void RemoveNodeFromList_NodeDoesNotExistInList_LogNodeDoesNotExistMessage()
        {
            PopulateList();
            var node = new Node { Value = 2 };

            _linkedList.RemoveNodeFromList(node);

            _logger.Verify(l => l.Log("Node does not exist in list"));
        }

        [Test]
        public void RemoveNodeFromList_NodeExistsInList_RemoveNode()
        {
            var node = new Node { Value = 2 };
            _linkedList.AddNodeToStart(node);

            _linkedList.RemoveNodeFromList(node);

            Assert.That(_linkedList.Head, Is.EqualTo(null));
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
