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
        public void CountShouldIncreaseByOneWhenPushCalled()
        {
            int initialCount = IntStack.Count;
            IntStack.Push(1);
            int currentCount = IntStack.Count;
            Assert.AreEqual(initialCount + 1, currentCount);
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
            IntStack.Clear();
            Assert.AreEqual(IntStack.Count, 0);
        }

        #endregion

        #region ToArray tests

        [Test]
        public void ToArrayDoesntChangeCount()
        {
            IntStack.Push(1);
            IntStack.Push(2);
            IntStack.ToArray();
            Assert.AreEqual(IntStack.Count, 2);
        }

        [Test]
        public void ToArrayReturnsStackInPopOrder()
        {
            IntStack.Push(1);
            IntStack.Push(2);
            Assert.AreEqual(IntStack.ToArray(), new int[] { 2, 1 });
        }

        [Test]
        public void ToArrayReturnsEmptyArrayWhenEmpty()
        {
            Assert.AreEqual(IntStack.ToArray(), new int[] {});
        }

        #endregion

        #region Contains tests

        [Test]
        public void ContainsReturnsTrueWhenStackContainsValue()
        {
            IntStack.Push(5);
            Assert.IsTrue(IntStack.Contains(5));
        }

        [Test]
        public void ContainsReturnsFalseWhenStackDoesntContainValue()
        {
            IntStack.Push(0);
            Assert.IsFalse(IntStack.Contains(5));
        }

        [Test]
        public void ContainsReturnsFalseWhenCountIsZero()
        {
            Assert.IsFalse(IntStack.Contains(5));
        }

        #endregion
    }
}