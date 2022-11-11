using NUnit.Framework;
using Stack;
using System;


namespace Stack.Tests
{
    public class StackTests
    {
        private Stack<int> _stack;
        [SetUp]
        public void Setup()
        {
            _stack = new Stack<int>();
        }

        [Test]
        public void Pushing_To_Stack()
        {
            var stack = new Stack<int>();

            stack.Push(10);

            Assert.AreEqual(10, stack.Pop());
        }
    }
}