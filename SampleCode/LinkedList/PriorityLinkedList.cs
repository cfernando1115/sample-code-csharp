using System;

namespace SampleCode
{
    public class PriorityLinkedList
    {
        public Node Head;
        private string _message;
        private ILogger _logger;

        public PriorityLinkedList(ILogger logger)
        {
            _logger = logger;
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
                while (curNode.Next != null && curNode.Next.Priority <= newNode.Priority)
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
            if (Head == null)
            {
                _message = "List is empty";
            }
            else
            {
                var temp = Head;
                Head = Head.Next;
                _message = "Popped Highest Priority Node = Value: " + temp.Value + ", Priority: " + temp.Priority;
            }
            _logger.Log(_message);
        }

        public void PeekPriorityNode()
        {
            _message="Highest Priority Node = Value: " + Head.Value + ", Priority: " + Head.Priority; 
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
