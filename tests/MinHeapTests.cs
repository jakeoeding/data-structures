using System;
using NUnit.Framework;
using DataStructures;
using NUnit.Framework.Internal;

namespace DataStructuresTests
{
    [TestFixture]
    public class MinHeapTests
    {
        MinHeap<int> IntMinHeap;

        [SetUp]
        public void Setup()
        {
            IntMinHeap = new MinHeap<int>();
        }

        [TearDown]
        public void Teardown()
        {
            IntMinHeap = null;
        }

        #region Add tests

        [Test]
        public void AddShouldPutMinItemOnTop()
        {
            IntMinHeap.Add(10);
            IntMinHeap.Add(5);
            Assert.AreEqual(5, IntMinHeap.Peek());
        }

        [Test]
        public void AddShouldLeaveTopUnchangedIfNewItemGreater()
        {
            IntMinHeap.Add(5);
            IntMinHeap.Add(10);
            Assert.AreEqual(5, IntMinHeap.Peek());
        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            IntMinHeap.Add(5);
            Assert.AreEqual(1, IntMinHeap.Count);
        }

        #endregion

        #region Peek tests

        [Test]
        public void PeekShouldThrowInvalidOperationExceptionWhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => IntMinHeap.Peek());
        }

        [Test]
        public void PeekShouldReturnMinValue()
        {
            IntMinHeap.Add(10);
            IntMinHeap.Add(5);
            Assert.AreEqual(5, IntMinHeap.Peek());
        }

        [Test]
        public void PeekShouldNotMutateCount()
        {
            IntMinHeap.Add(10);
            IntMinHeap.Peek();
            Assert.AreEqual(1, IntMinHeap.Count);
        }

        #endregion

        #region RemoveTop tests

        [Test]
        public void RemoveTopShouldThrowInvalidOperationExceptionWhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => IntMinHeap.RemoveTop());
        }

        [Test]
        public void RemoveTopShouldActuallyRemoveTheTopFromHeap()
        {
            IntMinHeap.Add(10);
            IntMinHeap.Add(5);
            Assert.AreEqual(5, IntMinHeap.RemoveTop());
        }

        [Test]
        public void RemoveTopShouldReduceCount()
        {
            IntMinHeap.Add(10);
            IntMinHeap.Add(5);
            IntMinHeap.RemoveTop();
            Assert.AreEqual(1, IntMinHeap.Count);
        }

        [Test]
        public void RemoveTopShouldRemoveItemsInSortedOrder()
        {
            int[] testInts = { 3, 2, 1, 0, -1, -2, -3 };
            for (int i = testInts.Length - 1; i < -1; i--)
            {
                Assert.AreEqual(testInts[i], IntMinHeap.RemoveTop());
            }
        }

        #endregion

        #region Clear tests

        [Test]
        public void ClearShouldReduceCountToZero()
        {
            IntMinHeap.Add(10);
            IntMinHeap.Add(5);
            IntMinHeap.Clear();
            Assert.AreEqual(0, IntMinHeap.Count);
        }

        [Test]
        public void ClearShouldRemoveAllPreviousValues()
        {
            int[] testInts = { 3, 2, 1, 0, -1, -2, -3 };
            foreach (int testInt in testInts)
            {
                IntMinHeap.Add(testInt);
            }
            IntMinHeap.Clear();
            foreach (int testInt in testInts)
            {
                Assert.IsFalse(IntMinHeap.Contains(testInt));
            }
        }

        #endregion region 

        #region Contains tests

        [Test]
        public void ContainsShouldReturnTrueForValueInHeap()
        {
            IntMinHeap.Add(10);
            Assert.IsTrue(IntMinHeap.Contains(10));
        }

        [Test]
        public void ContainsShouldReturnFalseForValueNotInHeap()
        {
            IntMinHeap.Add(20);
            Assert.IsFalse(IntMinHeap.Contains(10));
        }

        #endregion

        #region ToArray tests

        [Test]
        public void ToArrayShouldReturnAnArrayWithAllItemsFromHeap()
        {
            int[] testInts = { 3, 2, 1, 0, -1, -2, -3 };
            foreach (int testInt in testInts)
            {
                IntMinHeap.Add(testInt);
            }
            int[] returnValue = IntMinHeap.ToArray();
            Array.Sort(testInts);
            Array.Sort(returnValue);
            Assert.AreEqual(testInts, returnValue);
        }

        #endregion
    }
}
