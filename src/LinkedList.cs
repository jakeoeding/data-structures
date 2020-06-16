using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class LinkedList<T> : ICollection<T>
    {
        protected class Node
        {
            public T Data {get; set;}
            public Node Next { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node _head;
        private Node _tail;

        #region public interface

        public int Count { get; protected set; }

        public LinkedList()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public void AddFirst(T item)
        {
            var newNode = new Node(item);
            newNode.Next = _head;
            _head = newNode;
            if (_tail == null)
            {
                _tail = newNode;
            }
            Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                _tail.Next = newNode;
            }
            _tail = newNode;
            Count++;
        }

        public void Add(T item, int index)
        {
            ValidateIndex(index);
            if (index == 0)
            {
                AddFirst(item);
            }
            else
            {
                var newNode = new Node(item);
                Node currentNode = _head;
                for (int i = 0; i < index - 1; i++)
                {
                    currentNode = currentNode.Next;
                }
                newNode.Next = currentNode.Next;
                currentNode.Next = newNode;
                Count++;
            }
        }

        public T RemoveFirst()
        {
            if (_head == null)
            {
                ThrowWhenEmpty();
            }

            T firstData = _head.Data;
            _head = _head.Next;
            if (_head == null)
            {
                _tail = null;
            }
            Count--;
            return firstData;
        }

        public T RemoveLast()
        {
            if (_head == null)
            {
                ThrowWhenEmpty();
            }

            if (_head == _tail)
            {
                T data = _head.Data;
                this.Clear();
                return data;
            }

            Node currentNode = _head;
            for (int i = 0; i < Count - 2; i++)
            {
                currentNode = currentNode.Next;
            }
            T lastData = currentNode.Next.Data;
            currentNode.Next = null;
            _tail = currentNode;
            Count--;
            return lastData;
        }

        public T Remove(int index)
        {
            if (_head == null)
            {
                ThrowWhenEmpty();
            }

            ValidateIndex(index);

            if (index == 0)
            {
                return RemoveFirst();
            }
            else if (index == Count - 1)
            {
                return RemoveLast();
            }
            else
            {
                Node currentNode = _head;
                for (int i = 0; i < index - 1; i++)
                {
                    currentNode = currentNode.Next;
                }
                T removalData = currentNode.Next.Data;
                currentNode.Next = currentNode.Next.Next;
                Count--;
                return removalData;
            }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index < 0)
            {
                return false;
            }
            else
            {
                Remove(index);
                return true;
            }
        }

        public int IndexOf(T item)
        {
            int index = -1;
            if (_head == null)
            {
                return index;
            }
            else
            {
                Node currentNode = _head;
                for (int i = 0; i < Count; i++)
                {
                    if (currentNode.Data.Equals(item))
                    {
                        index = i;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Next;
                    }
                }
                return index;
            }
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) > -1;
        }

        public T[] ToArray()
        {
            T[] arr = new T[Count];
            Node currentNode = _head;
            for (int i = 0; i < Count; i++)
            {
                arr[i] = currentNode.Data;
                currentNode = currentNode.Next;
            }
            return arr;
        }

        #endregion

        #region private helpers

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void ThrowWhenEmpty()
        {
            throw new InvalidOperationException("List is Empty. A removal method cannot be called.");
        }

        #endregion
    }
}
