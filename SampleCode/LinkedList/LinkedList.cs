using System;
using System.Collections.Generic;

namespace SampleCode
{

    public class LinkedList
    {
        public Node Head;

        public LinkedList(Node head)
        {
            Head = head;
        }
        public void AddNodeToEnd(Node newNode)
        {
            var curNode = Head;
            while (curNode.Next != null)
            {
                curNode = curNode.Next;
            }
            curNode.Next = newNode;
        }

        public void AddNodeToStart(Node newNode)
        {
            newNode.Next = Head;
            Head = newNode;
        }
        public void LogNodeList()
        {
            if (IsListCircular())
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
                        break;
                    }
                    curNode = curNode.Next;
                }
            }
        }

        public bool IsListCircular()
        {
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
