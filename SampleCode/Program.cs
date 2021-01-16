using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Threading.Tasks;
using System;

namespace SampleCode
{


    class Program
    {
        static void Main(string[] args)
        {
            //LinkedList
            /*
            var linkedList = new LinkedList(new Node { Next = null , Value=1});
            linkedList.AddNodeToEnd(new Node { Next = null, Value = 2 });
            linkedList.AddNodeToStart(new Node { Value = 3 });
            linkedList.LogNodeList();
            var node1 = new Node { Next = null, Value = 4 };
            var node2 = new Node { Next = node1, Value = 5 };
            linkedList.AddNodeToEnd(node1);
            linkedList.AddNodeToEnd(node2);
            Console.WriteLine("Does the linked list contain a circle? {0}",linkedList.IsListCircular());
            var node3 = new Node { Value = 6 };
            var node4 = new Node { Value = 7 };
            linkedList.AddNodeToStart(node3);
            linkedList.AddNodeToStart(node4);
            linkedList.RemoveNodeFromList(node3);
            linkedList.LogNodeList();
            */

            //TwoNumbers
            /*
            var numbers = new TwoNumbers(1, 2);
            numbers.SwapNumbers();
            Console.WriteLine("X={0}, Y={1}", numbers.X, numbers.Y);
            */

            //ClockAngle
            /*var angle = new Angle(new Clock(7,10));
            var result=angle.CalculateAngle();
            Console.WriteLine(result);
            */


            //Fibonacci
            /*var fib = new Fibonacci();
            var result=fib.FindFib(5);
            Console.WriteLine(result);
            */

            //RomanNumerals
            /*
            var romanNumerals = new RomanNumerals();
            Console.WriteLine(romanNumerals.ConvertToRomanNumerals(5000));
            Console.WriteLine(romanNumerals.ConvertToRomanNumerals(35));
            */

            //PriorityLinkedList
            /*var list = new PriorityLinkedList(new Node { Value = 1, Priority = 3 });
            list.PushPriorityNode(new Node { Value = 2, Priority = 2 });
            list.PushPriorityNode(new Node { Value = 4, Priority = 10 });
            list.PushPriorityNode(new Node { Value = 10, Priority = 4 });
            list.LogPriorityLinkedList();
            list.PeekPriorityNode();*/

            //SortedArray
            /*var arrayActions = new ArrayActions();
            arrayActions.FindMedianOfSortedArrays(new IntArray("3,1,2").SortedArray, new IntArray("1,2,3").SortedArray);*/

            //BinarySearch
            /*var node1 = new Node { Key = 1 };
            var node2 = new Node { Key = 2 };
            var node3 = new Node { Key = 3 };
            var node4 = new Node { Key = 4 };
            var node5 = new Node { Key = 5 };

            node4.Left = node2;
            node4.Right = node5;
            node2.Left = node1;
            node2.Right = node3;

            //var binaryTree = new BinarySearchTree(node4);
            //binaryTree.InsertNode(new Node { Key = 6 });
            //binaryTree.InorderTraversal();

            var node6 = new BinaryNode(6);
            var node2 = new BinaryNode(2);
            var node1 = new BinaryNode(1);
            var node3 = new BinaryNode(3);
            var node11 = new BinaryNode(11);
            var node9 = new BinaryNode(9);
            var node13 = new BinaryNode(13);
            var node15 = new BinaryNode(15);
            var node16 = new BinaryNode(16);
            var node10 = new BinaryNode(10);

            var binaryTree = new BinarySearchTree(node6);
            //InsertNode()
            binaryTree.InsertNode(node2);
            binaryTree.InsertNode(node11);
            binaryTree.InsertNode(node1);
            binaryTree.InsertNode(node3);
            binaryTree.InsertNode(node9);
            binaryTree.InsertNode(node13);
            binaryTree.InsertNode(node15);
            binaryTree.InsertNode(node16);
            binaryTree.InsertNode(node10);

            //binaryTree.InorderTraversal();

            var node12 = new BinaryNode(12);
            //InsertNode()
            binaryTree.InsertNode(node12);
            //DeleteNode()
            binaryTree.DeleteNode(node11);*/
        }

    }
}
