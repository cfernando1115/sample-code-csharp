using System;
using System.Threading.Tasks;

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
        }
    }
}
