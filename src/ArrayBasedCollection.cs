using System;

namespace DataStructures
{
    public abstract class ArrayBasedCollection<T> : ICollection<T>
    {
        protected T[] _array;
        public const int DefaultInitialCapacity = 10;
        public const int DefaultGrowthFactor = 2;
        public int Count { get; protected set; }

        public ArrayBasedCollection() : this(DefaultInitialCapacity) { }

        public ArrayBasedCollection(int initialCapacity)
        {
            _array = new T[initialCapacity];
            Count = 0;
        }

        public virtual void Clear()
        {
            Array.Clear(_array, 0, _array.Length);
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Count > 0 && Array.IndexOf(_array, item) > -1;
        }

        public abstract T[] ToArray();

        protected virtual void Resize()
        {
            Array.Resize<T>(ref _array, _array.Length * DefaultGrowthFactor);
        }
    }
}
