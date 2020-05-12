using System;

namespace DataStructures
{
    public class Queue<T> : ArrayBasedCollection<T>
    {
        private int _head;
        private int _tail;

        #region public interface

        public Queue() : base() { }
         
        public Queue(int initialCapacity) : base(initialCapacity)
        {
            _head = 0;
            _tail = 0;
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

        public override void Clear()
        {
            base.Clear();
            _head = 0;
            _tail = 0;
        }

        // Returns an array of items from the queue in the order they would be dequeued
        public override T[] ToArray()
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

        #endregion

        #region internal helpers

        protected override void Resize()
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

        #endregion
    }
}
