using System;
using NUnit.Framework;
using Moq;

namespace SampleCode.UnitTests
{
    [TestFixture]
    public class BinarySearchTests
    {
        private Mock<ILogger> _logger;
        private BinaryNode _rootNode;
        private BinarySearchTree _binarySearchTree;

        [SetUp]
        public void SetUp()
        {
            _logger = new Mock<ILogger>();
            _rootNode = new BinaryNode(2);
            _binarySearchTree = new BinarySearchTree(_rootNode, _logger.Object);
        }

        [Test]
        public void InsertNode_NewNodeIsADuplicate_ReturnDuplicateMessage()
        {
            var newNode = new BinaryNode(2);

            _binarySearchTree.InsertNode(newNode);
            _logger.Verify(l => l.Log("Node key is a duplicate."));
        }

        [Test]
        public void InsertNode_NewNodeKeyIsGreaterThanRootKey_NewNodeIsInsertedOnRight()
        {
            var newNode = new BinaryNode(3);

            _binarySearchTree.InsertNode(newNode);
            Assert.That(_binarySearchTree.Root.Right, Is.EqualTo(newNode));
        }

        [Test]
        public void InsertNode_NewNodeKeyIsLessThanRootKey_NewNodeIsInsertedOnLeft()
        {
            var newNode = new BinaryNode(1);

            _binarySearchTree.InsertNode(newNode);
            Assert.That(_binarySearchTree.Root.Left, Is.EqualTo(newNode));
        }
    }
}
