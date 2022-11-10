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
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            //stack.Clear();
            //stack.Push(6);
            //Console.WriteLine("Pop: " + stack.Pop());
            //Console.WriteLine("Pop: " + stack.Pop());
            //Console.WriteLine("Peek: " + stack.Peek());
            //int[] array = stack.ToArray();
            //foreach (int i in array)
            //{
            //    Console.Write(i);
            //}
            //Console.WriteLine(stack.Count());
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());
            foreach (int i in stack)
            {
                Console.WriteLine(i);
            }
        }
        
    }
}
