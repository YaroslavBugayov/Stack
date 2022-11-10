using System;
using System.Collections.Generic;

namespace Stack.Stack
{
    public class Node<T>
    {
        public Node(T data) => Data = data;
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
}
