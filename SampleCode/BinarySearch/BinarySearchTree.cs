using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode
{
    public class BinarySearchTree
    {
        public BinaryNode Root;
        public Stack<BinaryNode> Stack = new Stack<BinaryNode>();
        private ILogger _logger;
        public BinarySearchTree(BinaryNode root, ILogger logger)
        {
            Root = root;
            _logger = logger;
        }

        public void InsertNode(BinaryNode node)
        {
            if (Root == null)
            {
                Root = node;
                return;
            }
            var curNode = Root;
            while (true)
            {
                if (curNode.Key == node.Key)
                {
                    _logger.Log("Node key is a duplicate.");
                    break;
                }
                while (curNode.Key > node.Key && curNode.Left != null)
                {
                    curNode = curNode.Left;
                }
                while (curNode.Key < node.Key && curNode.Right != null)
                {
                    curNode = curNode.Right;
                }
                if (node.Key < curNode.Key && curNode.Left == null)
                {
                    curNode.Left = node;
                    break;
                }
                if (node.Key > curNode.Key && curNode.Right == null)
                {
                    curNode.Right = node;
                    break;
                }
            }
        }

        public void DeleteNode(BinaryNode node)
        {
            if (Root == null)
            {
                _logger.Log("Tree is empty.");
                return;
            }
            var curNode = Root;
            var parent = Root;
            while (true)
            {
                if (curNode.Key < node.Key)
                {
                    parent = curNode;
                    curNode = curNode.Right;
                }
                if (curNode.Key > node.Key)
                {
                    parent = curNode;
                    curNode = curNode.Left;
                }
                if (curNode == null)
                {
                    _logger.Log("Node does not exist in tree.");
                    return;
                }
                if (curNode == node)
                {
                    if (curNode.Right != null)
                    {
                        parent.Right = curNode.Right;
                    }
                    InsertNode(curNode.Left);
                    break;

                }
            }
        }

        public void InorderTraversal()
        {
            if (Root == null)
            {
                _logger.Log("Tree is empty.");
                return;
            }
            var curNode = Root;

            while (true)
            {
                while (curNode != null)
                {
                    Stack.Push(curNode);
                    curNode = curNode.Left;
                }

                if (Stack.Count == 0)
                {
                    return;
                }

                curNode = Stack.Pop();
                _logger.Log(curNode.Key.ToString());
                curNode = curNode.Right;
            }
        }
    }
}

