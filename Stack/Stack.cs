using System;
using System.Collections;

namespace Stack
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

            if (_current == null) { 
                _current = node;
                _current.Next = null; 
            }
            else {
                var temp = _current;
                _current = node;
                _current.Next = temp;
            }
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
            var temp = _current.Data;
            _current = _current.Next;
            _count--;
            return temp;
        }

        public int Count
        {
            get { return _count; }
        }

        public Array ToArray()
        {
            T[] nodes = new T[_count];
            Node<T> tempNode = _current;
            int i = 0;
            while (tempNode != null)
            {
                nodes[i] = tempNode.Data;
                tempNode = tempNode.Next;
                i++;
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
            if (data == null) { throw new ArgumentNullException("data"); }
            Node<T> tempNode = _current;
            bool isContain = false;
            while (tempNode != null)
            {
                if (tempNode.Data.Equals(data))
                {
                    isContain = true;
                }
                tempNode = tempNode.Next;
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
            if (array.Rank != 1) { throw new ArgumentException("rank"); }
            if (index < 0) { throw new ArgumentOutOfRangeException ("index"); }
            if (array.Length - index < _count) { throw new ArgumentOutOfRangeException("index"); }

            Node<T> tempNode = _current;
            while (tempNode != null)
            {
                array.SetValue(tempNode.Data, index++);
                tempNode = tempNode.Next;
            }        
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = _current;
            while (node != null)
            {
                yield return node.Data;
                node = node.Next;
            }
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