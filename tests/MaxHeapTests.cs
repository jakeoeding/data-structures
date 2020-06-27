using NUnit.Framework;
using DataStructures;

namespace DataStructuresTests
{
    [TestFixture]
    public class MaxHeapTests
    {
        MaxHeap<int> IntMaxHeap;

        [SetUp]
        public void Setup()
        {
            IntMaxHeap = new MaxHeap<int>();
        }

        [TearDown]
        public void Teardown()
        {
            IntMaxHeap = null;
        }

        #region Add tests

        [Test]
        public void AddShouldPutMaxItemOnTop()
        {
            IntMaxHeap.Add(5);
            IntMaxHeap.Add(10);
            Assert.AreEqual(10, IntMaxHeap.Peek());
        }

        [Test]
        public void AddShouldLeaveTopUnchangedIfNewItemLesser()
        {
            IntMaxHeap.Add(10);
            IntMaxHeap.Add(5);
            Assert.AreEqual(10, IntMaxHeap.Peek());
        }

        #endregion

        #region Peek tests

        [Test]
        public void PeekShouldReturnMaxValue()
        {
            IntMaxHeap.Add(10);
            IntMaxHeap.Add(5);
            Assert.AreEqual(10, IntMaxHeap.Peek());
        }

        #endregion

        #region RemoveTop tests

         [Test]
        public void RemoveTopShouldActuallyRemoveTheTopFromHeap()
        {
            IntMaxHeap.Add(10);
            IntMaxHeap.Add(5);
            Assert.AreEqual(10, IntMaxHeap.RemoveTop());
        }

        [Test]
        public void RemoveTopShouldRemoveItemsInSortedOrder()
        {
            int[] testInts = { -3, -2, -1, 0, 1, 2, 3 };
            foreach (int testInt in testInts)
            {
                IntMaxHeap.Add(testInt);
            }
            for (int i = testInts.Length - 1; i < -1; i--)
            {
                Assert.AreEqual(testInts[i], IntMaxHeap.RemoveTop());
            }
        }

        #endregion
    }
}
