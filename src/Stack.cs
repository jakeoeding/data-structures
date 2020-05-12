﻿using System;

namespace DataStructures
{
    public class Stack<T> : ArrayBasedCollection<T>
    {
        #region public interface

        public Stack() : base() { }
         
        public Stack(int initialCapacity) : base(initialCapacity) { }

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

        // Returns an array of items from the stack in the order they would be popped off
        public override T[] ToArray()
        {
            T[] arrayCopy = new T[Count];
            Array.Copy(_array, 0, arrayCopy, 0, Count);
            Array.Reverse(arrayCopy);
            return arrayCopy;
        }

        #endregion

        #region internal helpers

        protected override void Resize()
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
