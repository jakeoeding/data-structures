using System;

namespace DataStructures
{
    public class Queue<T>
    {
        private int _head;
        private int _tail;
        private T[] _array;
        public int Count { get; private set; }
        public const int DefaultInitialCapacity = 20;
        public const int DefaultGrowthFactor = 2;

        public Queue() : this(DefaultInitialCapacity) { }
         
        public Queue(int initialCapacity)
        {
            _head = 0;
            _tail = 0;
            _array = new T[initialCapacity];
            Count = 0;
        }

        public void Enqueue(T item)
        {
            if (Count == _array.Length)
            {
                Resize();
            }
            _array[_tail] = item;
            AdvancePosition(ref _tail);
            Count++;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                ThrowWhenEmpty();
            }
            return _array[_head];
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                ThrowWhenEmpty();
            }
            T frontOfQueue = _array[_head];
            _array[_head] = default(T);
            AdvancePosition(ref _head);
            Count--;
            return frontOfQueue;
        }

        public void Clear()
        {
            Array.Clear(_array, 0, _array.Length);
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Count > 0 && Array.IndexOf(_array, item) > -1;
        }

        // Returns an array of items from the queue in the order they would be dequeued
        public T[] ToArray()
        {
            T[] arrayCopy = new T[Count];
            if (Count == 0)
            {
                return arrayCopy;
            }
            else if (_head < _tail)
            {
                // Straightforward copy
                Array.Copy(_array, _head, arrayCopy, 0, Count);
            }
            else
            {
                // Fragmented copy
                int countAfterSplit = _array.Length - _head;
                Array.Copy(_array, _head, arrayCopy, 0, countAfterSplit);
                Array.Copy(_array, 0, arrayCopy, countAfterSplit, Count - countAfterSplit);
                return arrayCopy;
            }
            return arrayCopy;
        }

        private void Resize()
        {
            T[] arrayCopy = this.ToArray();
            T[] newArray = new T[_array.Length * DefaultGrowthFactor];
            Array.Copy(arrayCopy, newArray, Count);
            _array = newArray;
            _head = 0;
            _tail = Count;
        }

        private void AdvancePosition(ref int position)
        {
            position = (position + 1) % _array.Length;
        }

        private void ThrowWhenEmpty()
        {
            throw new InvalidOperationException("Queue is empty. This operation requires at least one item to be present in Queue.");
        }
    }
}
