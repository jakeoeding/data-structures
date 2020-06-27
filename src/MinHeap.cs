using System;

namespace DataStructures
{
    public class MinHeap<T> : ArrayBasedCollection<T> where T : IComparable
    {
        #region public interface

        public MinHeap() : base() { }

        public MinHeap(int initialCapacity) : base(initialCapacity) { }

        public void Add(T item)
        {
            if (Count == _array.Length)
            {
                Resize();
            }
            _array[Count] = item;
            BubbleUp(Count);
            Count++;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                ThrowWhenEmpty();
            }
            return _array[0];
        }

        public T RemoveTop()
        {
            if (Count == 0)
            {
                ThrowWhenEmpty();
            }

            T top = _array[0];
            _array[0] = _array[Count - 1];
            _array[Count - 1] = default(T);
            Count--;
            BubbleDown(0);
            return top;
        }

        #endregion

        #region internal helpers

        protected bool Precedes(int x, int y)
        {
            return _array[x].CompareTo(y) < 0;
        }

        private void BubbleUp(int index)
        {
            if (index == 0)
            {
                return;
            }
            int parentIndex = GetParentIndex(index);
            if (Precedes(parentIndex, index))
            {
                return;
            }
            else
            {
                Swap(index, parentIndex);
                BubbleUp(parentIndex);
            }
        }

        private void BubbleDown(int index)
        {
            int precedingChildIndex;
            int leftChildIndex = GetLeftChildIndex(index);
            int rightChildIndex = GetRightChildIndex(index);

            if (rightChildIndex < Count && Precedes(rightChildIndex, leftChildIndex))
            {
                precedingChildIndex = rightChildIndex;
            }
            else if (leftChildIndex < Count)
            {
                precedingChildIndex = leftChildIndex;
            }
            else
            {
                return;
            }

            if (Precedes(precedingChildIndex, index))
            {
                Swap(precedingChildIndex, index);
                BubbleDown(precedingChildIndex);
            }
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetLeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return index * 2 + 2;
        }

        private void Swap(int i, int j)
        {
            T temp = _array[i];
            _array[i] = _array[j];
            _array[j] = temp;
        }

        private void ThrowWhenEmpty()
        {
            throw new InvalidOperationException("Heap is Empty. This operation requires at least one item to be present in the Heap.");
        }

        #endregion
    }
}
