using System.Collections;
using System.Collections.Generic;

namespace Stack.Stack
{
    public class Stack<T> : IEnumerable<T>, ICollection
    {
        Node<T> current;
        int count;

        public void Push(T data)
        {
            Node<T> node = new Node<T>(data);

            current.Next = current;
            current = node;
            count++;
        }

        public T Peek()
        {
            return current.Data;
        }

        public T Pop()
        {
            current = current.Next;
            count--;
            return current.Data;
        }

        public int Count
        {
            get { return count; }
        }

        public T[] ToArray()
        {
            return new T[0];
        }

        public void Clear()
        {
            current = null;
            count = 0;
        }

        public void TrimExcess()
        {
            
        }

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            Node<T> node = current;
            while (node != null)
            {
                yield return node.Data;
                node = node.Next;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }
    }

}