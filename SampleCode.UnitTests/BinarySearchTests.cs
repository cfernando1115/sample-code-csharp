using System;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace SampleCode.UnitTests
{
    [TestFixture]
    public class BinarySearchTests
    {
        private Mock<ILogger> _logger;
        private Mock<ILogger> _loggerStrict;
        private BinaryNode _rootNode;
        private BinarySearchTree _binarySearchTree;
        private List<BinaryNode> _sampleNodes;

        [SetUp]
        public void SetUp()
        {
            _loggerStrict = new Mock<ILogger>(MockBehavior.Strict);
            _logger = new Mock<ILogger>();
            _rootNode = new BinaryNode(2);
            _sampleNodes = new List<BinaryNode>
            {
                new BinaryNode(1),
                new BinaryNode(3),
                new BinaryNode(5)
            };
        }

        [Test]
        public void InsertNode_NewNodeIsADuplicate_ReturnDuplicateMessage()
        {
            _binarySearchTree = new BinarySearchTree(_rootNode, _logger.Object);

            var newNode = new BinaryNode(2);

            _binarySearchTree.InsertNode(newNode);
            _logger.Verify(l => l.Log("Node key is a duplicate."));
        }

        [Test]
        public void InsertNode_NewNodeKeyIsGreaterThanRootKey_NewNodeIsInsertedOnRight()
        {
            _binarySearchTree = new BinarySearchTree(_rootNode, _logger.Object);

            var newNode = new BinaryNode(3);

            _binarySearchTree.InsertNode(newNode);
            Assert.That(_binarySearchTree.Root.Right, Is.EqualTo(newNode));
        }

        [Test]
        public void InsertNode_NewNodeKeyIsLessThanRootKey_NewNodeIsInsertedOnLeft()
        {
            _binarySearchTree = new BinarySearchTree(_rootNode, _logger.Object);

            var newNode = new BinaryNode(1);

            _binarySearchTree.InsertNode(newNode);
            Assert.That(_binarySearchTree.Root.Left, Is.EqualTo(newNode));
        }

        [Test]
        public void DeleteNode_TreeIsEmpty_ReturnEmptyTreeMessage()
        {
            _binarySearchTree = new BinarySearchTree(_rootNode, _logger.Object);

            var nodeToDelete = new BinaryNode(1);

            _binarySearchTree.DeleteNode(_rootNode);
            _binarySearchTree.DeleteNode(nodeToDelete);

            _logger.Verify(l => l.Log("Tree is empty."));
        }

        [Test]
        public void DeleteNode_NodeToDeleteIsRoot_DeleteRoot()
        {
            _binarySearchTree = new BinarySearchTree(_rootNode, _logger.Object);

            _binarySearchTree.DeleteNode(_rootNode);
            _binarySearchTree.InorderTraversal();

            _logger.Verify(l => l.Log("Tree is empty."));
        }

        [Test]
        public void DeleteNode_NodeHasNoBranches_DeleteNode()
        {
            _binarySearchTree = new BinarySearchTree(_rootNode, _logger.Object);

            var nodeToDelete = new BinaryNode(3);
            _binarySearchTree.InsertNode(nodeToDelete);

            _binarySearchTree.DeleteNode(nodeToDelete);
            _binarySearchTree.DeleteNode(nodeToDelete);

            _logger.Verify(l => l.Log("Node does not exist in tree."));
        }

        [Test]
        public void DeleteNode_NodeHasBranches_DeleteNode()
        {
            _binarySearchTree = new BinarySearchTree(_rootNode, _logger.Object);

            BuildTestTree();

            _binarySearchTree.DeleteNode(_sampleNodes[1]);
            _binarySearchTree.DeleteNode(_sampleNodes[1]);

            _logger.Verify(l => l.Log("Node does not exist in tree."));
        }

        [Test]
        public void DeleteNode_NodeHasBranch_BranchRemains()
        {
            _binarySearchTree = new BinarySearchTree(_rootNode, _logger.Object);

            BuildTestTree();

            _binarySearchTree.DeleteNode(_sampleNodes[1]);
            _binarySearchTree.InorderTraversal();

            _logger.Verify(l => l.Log("5"));
        }

        [Test]
        public void DeleteNode_NodeHasBranches_BranchesRemain()
        {
            _binarySearchTree = new BinarySearchTree(_rootNode, _logger.Object);

            BuildTestTree();

            _binarySearchTree.InsertNode(new BinaryNode(4));

            _binarySearchTree.DeleteNode(_sampleNodes[1]);
            _binarySearchTree.InorderTraversal();

            _logger.Verify(l => l.Log("4"));
            _logger.Verify(l => l.Log("5"));
        }

        [Test]
        public void InorderTraversal_TreeIsEmpty_ReturnEmptyTreeMessage()
        {
            _binarySearchTree = new BinarySearchTree(_rootNode, _logger.Object);

            _binarySearchTree.DeleteNode(_rootNode);
            _binarySearchTree.InorderTraversal();

            _logger.Verify(l => l.Log("Tree is empty."));
        }

        [Test]
        public void InorderTraversal_TreeIsNotEmpty_LogNodeKeys()
        {
            _binarySearchTree = new BinarySearchTree(_rootNode, _loggerStrict.Object);

            var sequence = new MockSequence();
            _loggerStrict.InSequence(sequence).Setup(l => l.Log("1"));
            _loggerStrict.InSequence(sequence).Setup(l => l.Log("2"));
            _loggerStrict.InSequence(sequence).Setup(l => l.Log("3"));
            _loggerStrict.InSequence(sequence).Setup(l => l.Log("5"));

            BuildTestTree();
            _binarySearchTree.InorderTraversal();

            _loggerStrict.Verify(l => l.Log("1"));
            _loggerStrict.Verify(l => l.Log("2"));
            _loggerStrict.Verify(l => l.Log("3"));
            _loggerStrict.Verify(l => l.Log("5"));
        }

        private void BuildTestTree()
        {
            _sampleNodes.ForEach(n => _binarySearchTree.InsertNode(n));
            //Order of node keys inserted (2,1,3,5)
        }
    }
}
