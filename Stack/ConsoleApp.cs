using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class ConsoleApp
    {
        public static void Main()
        {
            Stack<string> stack = new Stack<string>();
            //stack.Push("1");
            //stack.Push("2");
            //stack.Push("3");
            //stack.Push("4");
            //stack.Push("5");
            //stack.Push(null);
            stack.Pop();
            //Console.WriteLine(stack.Peek());
            //Console.WriteLine(stack.Contains(2));
            //Console.WriteLine(stack.Contains(6));

            //Console.WriteLine("Count: " + stack.Count);
            //stack.Clear();
            //Console.WriteLine("Count: " + stack.Count);

            //stack.Push(6);
            //Console.WriteLine("Pop: " + stack.Pop());
            //Console.WriteLine("Pop: " + stack.Pop());
            //Console.WriteLine("Peek: " + stack.Peek());
            //Console.WriteLine(stack.Count);
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());

            //foreach (string i in stack)
            //{
            //    Console.WriteLine(i);
            //}

            //foreach (int i in stack.ToArray())
            //{
            //    Console.WriteLine(i);
            //}

            //int[] testArray = new int[stack.Count*2];
            //stack.CopyTo(testArray, 0);
            //stack.CopyTo(testArray, stack.Count);
            //foreach (int i in testArray)
            //{
            //    Console.WriteLine(i);
            //}
        }
        
    }
}
