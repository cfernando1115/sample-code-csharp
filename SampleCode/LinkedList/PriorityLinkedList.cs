using System;

namespace SampleCode
{
    public class PriorityLinkedList
    {
        public Node Head;

        public PriorityLinkedList(Node node)
        {
            Head = node;
        }

        public void PushPriorityNode(Node newNode)
        {
            if (Head.Priority > newNode.Priority)
            {
                newNode.Next = Head;
                Head = newNode;
            }
            else
            {
                var curNode = Head;
                while (curNode.Next != null && curNode.Next.Priority < newNode.Priority)
                {
                    curNode = curNode.Next;
                }
                var tempNode = curNode.Next;
                curNode.Next = newNode;
                newNode.Next = tempNode;
            }
        }

        public void PopPriorityNode()
        {
            var temp = Head;
            Head = Head.Next;
            Console.WriteLine("Popped Highest Priority Node = Value: {0}, Priority: {1}", temp.Value, temp.Priority);
        }

        public void PeekPriorityNode()
        {
            Console.WriteLine("Highest Priority Node = Value: {0}, Priority: {1}", Head.Value, Head.Priority);
        }

        public void LogPriorityLinkedList()
        {
            var curNode = Head;
            while (curNode != null)
            {
                Console.WriteLine("Value: {0}, Priority: {1}", curNode.Value, curNode.Priority);
                curNode = curNode.Next;
            }
        }
    }
}
