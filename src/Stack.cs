using System;

namespace DataStructures
{
    public class Stack<T>
    {
        private T[] _array;
        public int Count { get; private set; }
        public const int DefaultInitialCapacity = 5;
        public const int DefaultGrowthFactor = 2;

        #region public interface

        public Stack() : this(DefaultInitialCapacity) { }
         
        public Stack(int initialCapacity)
        {
            _array = new T[initialCapacity];
            Count = 0;
        }

        public void Push(T item)
        {
            if (_array.Length == Count)
            {
                Resize();
            }
            _array[Count] = item;
            Count++;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                ThrowWhenEmpty();
            }
            return _array[Count - 1];
        }

        public T Pop()
        {
            if (Count == 0)
            {
                ThrowWhenEmpty();
            }
            Count--;
            T topOfStack = _array[Count];
            _array[Count] = default(T);
            return topOfStack;
        }

        public void Clear()
        {
            Array.Clear(_array, 0, Count);
            Count = 0;
        }

        // Returns an array of items from the stack in the order they would be popped off
        public T[] ToArray()
        {
            T[] arrayCopy = new T[Count];
            Array.Copy(_array, 0, arrayCopy, 0, Count);
            Array.Reverse(arrayCopy);
            return arrayCopy;
        }

        public bool Contains(T item)
        {
            return Count > 0 && Array.IndexOf(_array, item) > -1;
        }

        #endregion

        #region private helpers

        private void Resize()
        {
            Array.Resize<T>(ref _array, _array.Length * DefaultGrowthFactor);
        }

        private void ThrowWhenEmpty()
        {
            throw new InvalidOperationException("Stack is empty. This operation requires at least one item to be present in Stack.");
        }

        #endregion
    }
}
