using System;
using System.Collections.Generic;

namespace SampleCode
{

    public class LinkedList
    {
        public Node Head;
        private string _message;
        private ILogger _logger;

        public LinkedList(ILogger logger)
        {
            _logger = logger;
        }

        public LinkedList(Node head=null)
        {
            Head = head;
        }
        public void AddNodeToEnd(Node newNode)
        {
            if (Head == null)
            {
                Head = newNode;
            }
            var curNode = Head;
            while (curNode.Next != null)
            {
                curNode = curNode.Next;
            }
            curNode.Next = newNode;
        }

        public void AddNodeToStart(Node newNode)
        {
            if (Head!= null)
            {
                newNode.Next = Head;
            }
            Head = newNode;
        }
        public void LogNodeList()
        {
            if (HasCycle())
            {
                var nodeList = new List<Node>();
                nodeList.Add(Head);
                var curNode = Head.Next;
                var lastNode = false;
                while (!lastNode)
                {
                    foreach (var node in nodeList)
                    {
                        if (curNode.Next == node)
                        {
                            lastNode = true;
                        }
                    }
                    nodeList.Add(curNode);
                    curNode = curNode.Next;
                }
                foreach(var node in nodeList)
                {
                    Console.WriteLine("Node Value: {0}", node.Value);
                }
            }
            else
            {
                var curNode = Head;
                while (curNode != null)
                {
                    Console.WriteLine("Node Value: {0}", curNode.Value);
                    curNode = curNode.Next;
                }
            }
        }

        public void RemoveNodeFromList(Node node)
        {
            if (Head == null)
            {
                _message="List is empty";
                _logger.Log(_message);
                return;
            }
            if (Head == node)
            {
                Head=Head.Next;
            }
            else
            {
                var curNode = Head;
                while (curNode.Next != null)
                {
                    if (curNode.Next == node)
                    {
                        curNode.Next = node.Next;
                    }
                    curNode = curNode.Next;
                }
                _message="Node does not exist in list";
                _logger.Log(_message);
            }
        }

        public bool HasCycle()
        {
            if (Head == null)
            {
                return false;
            }
            var nodeList = new List<Node>();
            nodeList.Add(Head);
            var curNode = Head;
            while (curNode.Next != null)
            {
                foreach(var node in nodeList)
                {
                    if (curNode.Next == node)
                    {
                        return true;
                    }
                }
                nodeList.Add(curNode);
                curNode = curNode.Next;
            }
            return false;
        }
    }
}
