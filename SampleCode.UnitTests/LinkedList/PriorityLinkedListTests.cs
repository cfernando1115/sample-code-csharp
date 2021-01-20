using System;
using NUnit.Framework;
using Moq;

namespace SampleCode.UnitTests
{
    [TestFixture]
    public class PriorityLinkedListTests
    {
        private PriorityLinkedList _priorityLinkedList;
        private Mock<ILogger> _logger;

        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger>();
            _priorityLinkedList = new PriorityLinkedList(_logger.Object);
        }

        [Test]
        public void PushPriorityNode_NewNodeHasHigherPriorityThanHead_NewNodeBecomesHead()
        {
            PopulateList();
            var newNode = new Node { Value=1, Priority = 1 };

            _priorityLinkedList.PushPriorityNode(newNode);

            Assert.That(_priorityLinkedList.Head, Is.EqualTo(newNode));
        }

        [Test]
        public void PushPriorityNode_NewNodeDoesNotHaveHighestPriority_InsertInCorrectPriorityLocation()
        {
            PopulateList();
            var newNode = new Node { Value=3, Priority = 3 };

            _priorityLinkedList.PushPriorityNode(newNode);

            Assert.That(_priorityLinkedList.Head.Next, Is.EqualTo(newNode));
        }

        [Test]
        public void PushPriorityNode_NewNodeHasSamePriorityAsExistingNode_NewNodePlacedBehindExistingNode()
        {
            PopulateList();
            var newNode = new Node { Value=2, Priority = 2 };

            _priorityLinkedList.PushPriorityNode(newNode);

            Assert.That(_priorityLinkedList.Head.Next, Is.EqualTo(newNode));
        }

        [Test]
        public void PopPriorityNode_ListIsEmpty_LogEmptyListMessage()
        {
            _priorityLinkedList.PopPriorityNode();

            _logger.Verify(l => l.Log("List is empty"));
        }

        [Test]
        public void PopPriorityNode_WhenCalled_LogHighestPriorityNodeMessage()
        {
            PopulateList();
            var newNode = new Node { Value=1, Priority = 1 };
            _priorityLinkedList.PushPriorityNode(newNode);

            _priorityLinkedList.PopPriorityNode();

            _logger.Verify(l => l.Log("Popped Highest Priority Node = Value: 1, Priority: 1"));
        }

        [Test]
        public void PopPriorityNode_WhenCalled_RemovesHighestPriorityNodeFromList()
        {
            PopulateList();
            var newNode = new Node { Value = 1, Priority = 1 };
            _priorityLinkedList.PushPriorityNode(newNode);

            _priorityLinkedList.PopPriorityNode();

            Assert.That(_priorityLinkedList.Head, Is.Not.EqualTo(newNode));
        }

        private void PopulateList()
        {
            _priorityLinkedList.Head = new Node { Value=2, Priority = 2 };
        }
    }
}
