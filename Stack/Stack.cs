using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>, ICollection
    {
        private LinkedList<T> _data = new LinkedList<T>();

        public void Push(T elem)
        {
            _data.AddFirst(elem);
        }

        public T Peek()
        {
            return _data.First();
        }

        public T Pop()
        {
            T elem = _data.First();
            _data.RemoveFirst();
            return elem;
        }

        public int Count
        {
            get { return _data.Count; }
        }

        public T[] ToArray()
        {
            return _data.ToArray();
        }
        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var datum in _data)
            {
                yield return datum;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }
    }

}