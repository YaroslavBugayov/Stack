using System.Collections;
using System.Collections.Generic;

namespace Stack.Stack
{
    public class Stack<T> : IEnumerable<T>, ICollection
    {
        private object _syncRoot;
        private Node<T> _current;
        private int _count;

        public void Push(T data)
        {
            if (data == null) { throw new ArgumentNullException("data"); }
            Node<T> node = new Node<T>(data);

            _current.Next = _current;
            _current = node;
            _count++;
            OnPush(node);
        }

        public T Peek()
        {
            if (_count == 0) { throw new InvalidOperationException("empty"); }
            return _current.Data;
        }

        public T Pop()
        {
            if (_count == 0) { throw new InvalidOperationException("empty"); }
            OnPop(_current);
            _current = _current.Next;
            _count--;
            return _current.Data;
        }

        public int Count
        {
            get { return _count; }
        }

        public Array ToArray()
        {
            T[] nodes = new T[_count];
            Node<T> tempNode = _current;
            while(_current != null)
            {
                nodes.Append(tempNode.Data);
                tempNode = _current.Next;
            }
            return nodes;
        }

        public void Clear()
        {
            _current = null;
            _count = 0;
            OnClear();
        }

        public bool Contains(T data)
        {
            if (data != null) { throw new ArgumentNullException("data"); }
            Node<T> tempNode = _current;
            bool isContain = false;
            while (_current != null)
            {
                if (_current.Data.Equals(data))
                {
                    isContain = true;
                }
                tempNode = _current.Next;
            }
            return isContain;
        }

        public bool IsSynchronized
        {
            get { return false; }
        }
        
        public object SyncRoot
        {
            get
            {
                Interlocked.CompareExchange(ref _syncRoot, new object(), null);
                return _syncRoot;
            }
        }

        public void CopyTo(Array array, int index)
        {
            if (array == null) { throw new ArgumentNullException("array"); }
            if (index < 0) { throw new ArgumentNullException ("index"); }
            if (array.Rank != 1) { throw new ArgumentException("rank"); }
            if (_current == null) { throw new InvalidOperationException("empty"); }
            if (array.Length - index < _count) { throw new ArgumentOutOfRangeException("array"); }

            Node<T> tempNode = _current;
            while (_current != null)
            {
                array.SetValue(tempNode.Data, index++);
                tempNode = _current.Next;
            }        
        }

        public IEnumerator GetEnumerator()
        {
            Node<T> node = _current;
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

        public event EventHandler<Node<T>> EventPush = delegate { };
        public event EventHandler<Node<T>> EventPop = delegate { };
        public event Action EventClear = delegate { };

        protected virtual void OnPush(Node<T> data)
        {
            EventPush.Invoke(this, data);
        }

        protected virtual void OnPop(Node<T> data)
        {
            EventPop.Invoke(this, data);
        }

        protected virtual void OnClear()
        {
            EventClear.Invoke();
        }
    }

}