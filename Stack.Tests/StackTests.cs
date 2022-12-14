using NUnit.Framework;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Stack.Tests
{
    public class StackTests
    {

        [Test]
        public void Push_Push10andPopLastItem_Return10()
        {
            var stack = new Stack<int>();

            stack.Push(10);

            stack.Pop().Should().Be(10);
        }

        [Test]
        public void Push_PushNull_ThrowArgumentNullExceptionWithParameterData()
        {
            var stack = new Stack<string>();

            Action act = () => stack.Push(null);

            act.Should().Throw<ArgumentNullException>().WithParameterName("data");
        }

        [Test]
        public void Push_Push5And2AndPopLastElem_Return2() { 
            var stack = new Stack<int>();

            stack.Push(5);
            stack.Push(2);

            stack.Pop().Should().Be(2);
        }

        [Test]
        public void Peek_Push0AndPeekLastElem_Return0()
        {
            var stack = new Stack<int>();

            stack.Push(0);

            stack.Peek().Should().Be(0);
        }

        [Test]
        public void Peek_PeekInEmptyStack_ThrowInvalidOperationExceptionWithMessageEmpty()
        {
            var stack = new Stack<int>();

            Action act = () => stack.Peek();

            act.Should().Throw<InvalidOperationException>().WithMessage("empty");
        }

        [Test]
        public void Pop_PopInEmptyStack_ThrowInvalidOperationExceptionWithMessageEmpty()
        {
            var stack = new Stack<int>();

            Action act = () => stack.Pop();

            act.Should().Throw<InvalidOperationException>().WithMessage("empty");
        }

        [Test]
        public void Count_Push2Elements_Return2()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);

            stack.Count.Should().Be(2);
        }

        [Test]
        public void Clear_GetCount_Return0()
        {
            var stack = new Stack<int>();

            stack.Push(0);
            stack.Clear();

            stack.Count.Should().Be(0);
        }

        [Test]
        public void ToArray_CopyStackToArray_CopiedArrayHasExpectedValue()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Array array = stack.ToArray();

            array.Should().BeEquivalentTo(new[] {1, 2, 3});
        }

        [Test]
        public void Contains_Push5Contains5_ReturnTrue()
        {
            var stack = new Stack<int>();

            stack.Push(5);

            stack.Contains(5).Should().BeTrue();
        }

        [Test]
        public void Contains_ContainsNull_ThrowArgumentNullExceptionWithParameterData() 
        {
            var stack = new Stack<string>();

            Action act = () => stack.Contains(null);

            act.Should().Throw<ArgumentNullException>().WithParameterName("data");
        }

        [Test]
        public void IsSynchronized_ReturnFalse()
        {
            var stack = new Stack<int>();

            var isSynchronized = stack.IsSynchronized;

            isSynchronized.Should().BeFalse();
        }

        [Test]
        public void SyncRoot_ReturnSyncRoot()
        {
            var stack = new Stack<int>();

            var actual = stack.SyncRoot;
            var expected = stack.SyncRoot;

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void CopyTo_CopyStackToArray_ArrayEquivalentToExpected()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            var array = new int[stack.Count];

            stack.CopyTo(array, 0);

            array.Should().BeEquivalentTo(new[] {1, 2, 3});
        }

        [Test]
        public void CopyTo_StackEmpty_ArrayEmpty()
        {
            var stack = new Stack<int>();
            var array = new int[stack.Count];

            stack.CopyTo(array, 0);

            array.Should().BeEmpty();
        }

        [Test]
        public void CopyTo_ArrayEmpty_ThrowArgumentNullExceptionWithParameterArray()
        {
            var stack = new Stack<int>();
            int[] array = null;

            Action act = () => stack.CopyTo(array, 0);

            act.Should().Throw<ArgumentNullException>().WithParameterName("array");
        }

        [Test]
        public void CopyTo_IndexLessThen0_ThrowArgumentOutOfRangeExceptionWithParameterIndex()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            var array = new int[stack.Count];

            Action act = () => stack.CopyTo(array, -1);

            act.Should().Throw<ArgumentOutOfRangeException>().WithParameterName("index");
        }

        [Test]
        public void CopyTo_RankNotEqual1_ThrowArgumentExceptionWithParameterRank()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            var array = new int[stack.Count, 2];

            Action act = () => stack.CopyTo(array, 0);

            act.Should().Throw<ArgumentException>().WithMessage("rank");
        }

        [Test]
        public void CopyTo_LengthOfArrayMinusIndexLessThen0_ThrowArgumentOutOfRangeExceptionWithParameterIndex()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            var array = new int[stack.Count];

            Action act = () =>
            {
                stack.CopyTo(array, 0);
                stack.CopyTo(array, 1);
            };

            act.Should().Throw<ArgumentOutOfRangeException>().WithParameterName("index");
        }

        [Test]
        public void GetEnumerator_Push1And2_Return1()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            IEnumerator e = ((IEnumerable)stack).GetEnumerator();
            e.MoveNext();
            e.MoveNext();
            object obj = e.Current;

            obj.Should().Be(1);
        }

        [Test]
        public void GetEnumerator_EmptyStack_ReturnNull()
        {
            var stack = new Stack<int>();

            IEnumerator e = ((IEnumerable)stack).GetEnumerator();
            e.MoveNext();
            object obj = e.Current;

            obj.Should().Be(0);
        }

        [Test]
        public void GetEnumeratorGeneric_Push1ToStack_Return1()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            IEnumerator<int> e = stack.GetEnumerator();
            e.MoveNext();
            object obj = e.Current;

            obj.Should().Be(1);
        }
    }
}