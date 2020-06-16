using System;

namespace DataStructures
{
    public class ArrayList<T> : ArrayBasedCollection<T>
    {
        #region public interface

        public ArrayList() : base() { }

        public ArrayList(int initialCapacity) : base(initialCapacity) { }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return _array[index];
            }
            set
            {
                ValidateIndex(index);
                _array[index] = value;
                if (index == Count)  // Only increase count if we aren't overriding a previous index
                {
                    Count++;
                }
            }
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(_array, item);
        }

        public void Add(T item)
        {
            if (Count == _array.Length)
            {
                Resize();
            }
            _array[Count] = item;
            Count++;
        }

        public void Add(T item, int index)
        {
            ValidateIndex(index);
            if (Count == _array.Length)
            {
                Resize();
            }
            Array.Copy(_array, index, _array, index + 1, Count - index);
            _array[index] = item;
            Count++;
        }

        public T Remove(int index)
        {
            ValidateIndex(index);
            T removedItem = _array[index];
            if (index == _array.Length - 1)
            {
                _array[index] = default(T);
            }
            Array.Copy(_array, index + 1, _array, index, Count - index - 1);
            Count--;
            return removedItem;
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

        #endregion

        #region private helpers

        private void ValidateIndex(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        #endregion
    }
}
