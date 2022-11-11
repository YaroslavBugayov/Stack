using System;
using System.Threading;
using Stack;

namespace ConsoleApp
{
    internal class ConsoleApp
    {
        public static void Main()
        {
            // Initialization
            var stack = new Stack.Stack<int>();

            // Filling an array
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            // Output array
            PrintArray(stack);

            // Peek last element
            Console.WriteLine("Peek: " + stack.Peek());

            // Is contain
            Console.WriteLine("Array contains 5? " + stack.Contains(5));
            Console.WriteLine("Array contains 6? " + stack.Contains(6));

            // Pop element
            Console.WriteLine("Pop: " + stack.Pop());
            Console.WriteLine("Array contains 5? " + stack.Contains(5));
            Console.WriteLine("Pop: " + stack.Pop());
            PrintArray(stack);

            // Clear array
            Console.WriteLine("Count: " + stack.Count);
            stack.Clear();
            Console.WriteLine("Clear");
            Console.WriteLine("Count: " + stack.Count);

            // Filling an array
            Console.WriteLine("Push some elements");
            stack.Push(6);
            stack.Push(7);
            stack.Push(8);
            stack.Push(9);
            stack.Push(10);

            // New array
            var array = stack.ToArray();
            Console.WriteLine("New array:");
            PrintArray(array);

            // Double Copy to
            Console.WriteLine("Copied array:");
            var copiedArray = new int[stack.Count * 2];
            stack.CopyTo(copiedArray, 0);
            stack.CopyTo(copiedArray, stack.Count);
            PrintArray(copiedArray);
        }

        static void PrintArray(Stack.Stack<int> stack)
        {
            Console.WriteLine("Array: ");
            foreach (int i in stack)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        static void PrintArray(Array array)
        {
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

    }
}
