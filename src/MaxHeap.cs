using System;

namespace DataStructures
{
    public class MaxHeap<T> : MinHeap<T> where T : IComparable
    {
        #region public interface

        public MaxHeap() : base() { }

        public MaxHeap(int initialCapacity) : base(initialCapacity) { }

        #endregion

        #region internal helpers

        protected override bool Precedes(int x, int y)
        {
            return _array[x].CompareTo(_array[y]) > 0;
        }

        #endregion
    }
}
