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
            Assert.AreEqual(2, IntStack.Peek());
        }

        [Test]
        public void PeekShouldNotAffectCount()
        {
            IntStack.Push(1);
            IntStack.Push(2);
            IntStack.Peek();
            Assert.AreEqual(2, IntStack.Count);
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
            Assert.AreEqual(2, IntStack.Pop());
        }

        [Test]
        public void PopShouldReduceCountByOne()
        {
            IntStack.Push(1);
            IntStack.Push(2);
            IntStack.Pop();
            Assert.AreEqual(1, IntStack.Count);
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
            Assert.AreEqual(0, IntStack.Count);
        }

        [Test]
        public void ClearShouldRemoveAllPreviousValues()
        {
            for (int i = 1; i < 4; i++)
            {
                IntStack.Push(i);
            }
            IntStack.Clear();
            for (int i = 1; i < 4; i++)
            {
                Assert.IsFalse(IntStack.Contains(i), $"Stack contains value {i} after call to Clear");
            }
        }

        #endregion

        #region ToArray tests

        [Test]
        public void ToArrayShouldNotChangeCount()
        {
            IntStack.Push(1);
            IntStack.Push(2);
            IntStack.ToArray();
            Assert.AreEqual(2, IntStack.Count);
        }

        [Test]
        public void ToArrayShouldReturnStackInPopOrder()
        {
            IntStack.Push(1);
            IntStack.Push(2);
            Assert.AreEqual(new int[] { 2, 1 }, IntStack.ToArray());
        }

        [Test]
        public void ToArrayShouldReturnEmptyArrayWhenEmpty()
        {
            Assert.AreEqual(new int[] { }, IntStack.ToArray());
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