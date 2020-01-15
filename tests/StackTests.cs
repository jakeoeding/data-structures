using System;
using NUnit.Framework;
using DataStructures;

namespace DataStructuresTests
{
    [TestFixture]
    public class StackTests
    {
        Stack<int> IntStack;

        [SetUp]
        public void Setup()
        {
            IntStack = new Stack<int>();
        }

        [TearDown]
        public void Teardown()
        {
            IntStack = null;
        }

        #region Push tests

        [Test]
        public void PushShouldIncreaseCountByOne()
        {
            int initialCount = IntStack.Count;
            IntStack.Push(1);
            Assert.AreEqual(initialCount + 1, IntStack.Count);
        }

        #endregion

        #region Peek tests

        [Test]
        public void PeekShouldThrowInvalidOperationExceptionWhenStackEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => IntStack.Peek());
        }

        [Test]
        public void PeekShouldReturnTopValueOnStack()
        {
            IntStack.Push(1);
            IntStack.Push(2);
            Assert.AreEqual(IntStack.Peek(), 2);
        }

        [Test]
        public void PeekShouldNotAffectCount()
        {
            IntStack.Push(1);
            IntStack.Push(2);
            IntStack.Peek();
            Assert.AreEqual(IntStack.Count, 2);
        }

        #endregion

        #region Pop tests

        [Test]
        public void PopShouldThrowInvalidOperationExceptionWhenStackEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => IntStack.Pop());
        }

        [Test]
        public void PopShouldReturnTopValueOnStack()
        {
            IntStack.Push(1);
            IntStack.Push(2);
            Assert.AreEqual(IntStack.Pop(), 2);
        }

        [Test]
        public void PopShouldReduceCountByOne()
        {
            IntStack.Push(1);
            IntStack.Push(2);
            IntStack.Pop();
            Assert.AreEqual(IntStack.Count, 1);
        }

        #endregion

        #region Clear tests

        [Test]
        public void ClearShouldResetCountToZero()
        {
            for (int i = 1; i < 4; i++)
            {
                IntStack.Push(i);
            }
            IntStack.Clear();
            Assert.AreEqual(IntStack.Count, 0);
        }

        #endregion

        #region ToArray tests

        [Test]
        public void ToArrayShouldNotChangeCount()
        {
            IntStack.Push(1);
            IntStack.Push(2);
            IntStack.ToArray();
            Assert.AreEqual(IntStack.Count, 2);
        }

        [Test]
        public void ToArrayShouldReturnStackInPopOrder()
        {
            IntStack.Push(1);
            IntStack.Push(2);
            Assert.AreEqual(IntStack.ToArray(), new int[] { 2, 1 });
        }

        [Test]
        public void ToArrayShouldReturnEmptyArrayWhenEmpty()
        {
            Assert.AreEqual(IntStack.ToArray(), new int[] {});
        }

        #endregion

        #region Contains tests

        [Test]
        public void ContainsShouldReturnTrueWhenStackContainsValue()
        {
            IntStack.Push(5);
            Assert.IsTrue(IntStack.Contains(5));
        }

        [Test]
        public void ContainsShouldReturnFalseWhenStackDoesntContainValue()
        {
            IntStack.Push(0);
            Assert.IsFalse(IntStack.Contains(5));
        }

        [Test]
        public void ContainsShouldReturnFalseWhenCountIsZero()
        {
            Assert.IsFalse(IntStack.Contains(5));
        }

        #endregion
    }
}