using System;
using NUnit.Framework;
using DataStructures;

namespace DataStructuresTests
{
    [TestFixture]
    public class QueueTests
    {
        Queue<int> IntQueue;

        [SetUp]
        public void Setup()
        {
            IntQueue = new Queue<int>();
        }

        [TearDown]
        public void Teardown()
        {
            IntQueue = null;
        }

        #region Enqueue tests

        [Test]
        public void EnqueueShouldIncreaseCountByOne()
        {
            int initialCount = IntQueue.Count;
            IntQueue.Enqueue(1);
            Assert.AreEqual(initialCount + 1, IntQueue.Count);
        }

        #endregion

        #region Peek tests

        [Test]
        public void PeekShouldThrowInvalidOperationExceptionWhenQueueEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => IntQueue.Peek());
        }

        [Test]
        public void PeekShouldReturnFirstValueInQueue()
        {
            IntQueue.Enqueue(1);
            IntQueue.Enqueue(2);
            Assert.AreEqual(1, IntQueue.Peek());
        }

        [Test]
        public void PeekShouldNotAffectCount()
        {
            IntQueue.Enqueue(1);
            IntQueue.Enqueue(2);
            IntQueue.Peek();
            Assert.AreEqual(2, IntQueue.Count);
        }

        #endregion

        #region Dequeue tests

        [Test]
        public void DequeueShouldThrowInvalidOperationExceptionWhenQueueEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => IntQueue.Dequeue());
        }

        [Test]
        public void DequeueShouldReturnFirstValueInQueue()
        {
            IntQueue.Enqueue(1);
            IntQueue.Enqueue(2);
            Assert.AreEqual(1, IntQueue.Dequeue());
        }

        [Test]
        public void DequeueShouldDecreaseCountByOne()
        {
            IntQueue.Enqueue(1);
            IntQueue.Enqueue(2);
            IntQueue.Dequeue();
            Assert.AreEqual(1, IntQueue.Count);
        }

        #endregion

        #region Clear tests

        [Test]
        public void ClearShouldResetCountToZero()
        {
            for (int i = 1; i < 4; i++)
            {
                IntQueue.Enqueue(i);
            }
            IntQueue.Clear();
            Assert.AreEqual(0, IntQueue.Count);
        }

        [Test]
        public void ClearShouldRemoveAllPreviousValues()
        {
            for (int i = 1; i < 4; i++)
            {
                IntQueue.Enqueue(i);
            }
            IntQueue.Clear();
            for (int i = 1; i < 4; i++)
            {
                Assert.IsFalse(IntQueue.Contains(i), $"Queue contains the value {i} after call to Clear");
            }
        }

        #endregion

        #region Contains tests

        [Test]
        public void ContainsShouldReturnTrueWhenQueueContainsValue()
        {
            IntQueue.Enqueue(10);
            Assert.IsTrue(IntQueue.Contains(10));
        }

        [Test]
        public void ContainsShouldReturnFalseWhenStackDoesntContainValue()
        {
            IntQueue.Enqueue(10);
            Assert.IsFalse(IntQueue.Contains(15));
        }

        [Test]
        public void ContainsShouldReturnFalseWhenCountIsZero()
        {
            Assert.IsFalse(IntQueue.Contains(10));
        }

        #endregion

        #region ToArray tests
        [Test]
        public void ToArrayShouldReturnEmptyWhenQueueEmpty()
        {
            Assert.AreEqual(new int[0], IntQueue.ToArray());
        }

        [Test]
        public void ToArrayShouldReturnCorrectOrderWhenStraightforwardCopyFromIndexZero()
        {
            int[] expectedOutput = new int[8];
            for (int i = 1; i <= 8; i++)
            {
                IntQueue.Enqueue(i);
                expectedOutput[i - 1] = i;
            }
            int[] testArray = IntQueue.ToArray();
            Assert.AreEqual(expectedOutput, testArray);
        }

        [Test]
        public void ToArrayShouldReturnCorrectOrderWhenStraightforwardCopyFromNonZeroIndex()
        {
            // Advance head from index 0
            for (int i = 0; i < 2; i++)
            {
                IntQueue.Enqueue(0);
                IntQueue.Dequeue();
            }

            int[] expectedOutput = new int[8];
            for (int i = 1; i <= 8; i++)
            {
                IntQueue.Enqueue(i);
                expectedOutput[i - 1] = i;
            }
            int[] testArray = IntQueue.ToArray();
            Assert.AreEqual(expectedOutput, testArray);
        }

        [Test]
        public void ToArrayShouldReturnCorrectOrderWhenFragmentedCopy()
        {
            int capacity = Queue<int>.DefaultInitialCapacity;

            // Set up so tail will wrap around to beginning
            IntQueue.Enqueue(1);
            IntQueue.Dequeue();

            int[] expectedOutput = new int[capacity];
            for (int i = 1; i <= capacity; i++)
            {
                IntQueue.Enqueue(i);
                expectedOutput[i - 1] = i;
            }
            int[] testArray = IntQueue.ToArray();
            Assert.AreEqual(expectedOutput, testArray);
        }
        #endregion
    }
}
