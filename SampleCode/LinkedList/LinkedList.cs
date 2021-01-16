using System;
using System.Collections.Generic;

namespace SampleCode
{

    public class LinkedList
    {
        public Node Head;

        public LinkedList(Node head=null)
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

        public int RemoveNodeFromList(Node node)
        {
            if (Head == null)
            {
                return -1;
            }
            if (Head == node)
            {
                Head=Head.Next;
                return 1;
            }
            else
            {
                var curNode = Head;
                while (curNode.Next != null)
                {
                    if (curNode.Next == node)
                    {
                        curNode.Next = node.Next;
                        return 1;
                    }
                    curNode = curNode.Next;
                }
                return -1;
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
