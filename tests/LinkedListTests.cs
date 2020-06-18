using System;
using NUnit.Framework;
using DataStructures;

namespace DataStructuresTests
{
    [TestFixture]
    public class LinkedListTests
    {
        LinkedList<char> CharList;

        [SetUp]
        public void Setup()
        {
            CharList = new LinkedList<char>();
        }

        [TearDown]
        public void Teardown()
        {
            CharList = null;
        }

        #region Add tests

        [Test]
        public void AddFirstShouldAddToBeginning()
        {
            char[] testChars = { 'a', 'b', 'c' };
            foreach (char c in testChars)
            {
                CharList.AddFirst(c);
            }
            Array.Reverse(testChars);
            Assert.AreEqual(testChars, CharList.ToArray());
        }

        [Test]
        public void AddFirstShouldIncreaseCount()
        {
            char[] testChars = { 'a', 'b', 'c' };
            foreach (char c in testChars)
            {
                CharList.AddFirst(c);
            }
            Assert.AreEqual(testChars.Length, CharList.Count);
        }

        [Test]
        public void AddLastShouldAddToEnd()
        {
            char[] testChars = { 'a', 'b', 'c' };
            foreach (char c in testChars)
            {
                CharList.AddLast(c);
            }
            Assert.AreEqual(testChars, CharList.ToArray());
        }

        [Test]
        public void AddLastShouldIncreaseCount()
        {
            char[] testChars = { 'a', 'b', 'c' };
            foreach (char c in testChars)
            {
                CharList.AddLast(c);
            }
            Assert.AreEqual(testChars.Length, CharList.Count);
        }

        [Test]
        public void AddShouldThrowIndexOutOfRangeExceptionForNegativeIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() => CharList.Add('a', -1));
        }

        [Test]
        public void AddShouldThrowIndexOutOfRangeExceptionForIndexGTECount()
        {
            CharList.AddLast('a');
            CharList.AddLast('b');
            Assert.Throws<IndexOutOfRangeException>(() => CharList.Add('c', 2));
        }

        [Test]
        public void AddShouldAddToHeadCorrectlyWhenIndexIsZero()
        {
            CharList.AddLast('b');
            CharList.AddLast('c');
            CharList.Add('a', 0);
            Assert.AreEqual(new char[] { 'a', 'b', 'c' }, CharList.ToArray());
        }

        [Test]
        public void AddShouldAddToProperIndexWhenIndexIsNonzero()
        {
            CharList.AddLast('a');
            CharList.AddLast('c');
            CharList.Add('b', 1);
            Assert.AreEqual(new char[] { 'a', 'b', 'c' }, CharList.ToArray());
        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            CharList.AddFirst('a');
            CharList.Add('b', 0);
            CharList.Add('c', 1);
            Assert.AreEqual(3, CharList.Count);
        }

        #endregion

        #region Remove tests

        [Test]
        public void RemoveFirstShouldThrowInvalidOperationExceptionWhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => CharList.RemoveFirst());
        }

        [Test]
        public void RemoveFirstShouldRemoveFirstItemWhenListNotEmpty()
        {
            CharList.AddLast('a');
            CharList.AddLast('b');
            CharList.AddLast('c');
            Assert.AreEqual('a', CharList.RemoveFirst(), "RemoveFirst returns incorrect value");
            Assert.AreEqual(new char[] { 'b', 'c' }, CharList.ToArray(), "RemoveFirst does not correctly mutate list");
        }

        [Test]
        public void RemoveFirstShouldDecreaseCount()
        {
            CharList.AddFirst('a');
            CharList.AddLast('b');
            CharList.RemoveFirst();
            Assert.AreEqual(1, CharList.Count);
        }

        [Test]
        public void RemoveLastShouldThrowInvalidOperationExceptionWhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => CharList.RemoveLast());
        }

        [Test]
        public void RemoveLastShouldResetListWhenOnlyContainsOneItem()
        {
            CharList.AddLast('a');
            Assert.AreEqual('a', CharList.RemoveLast(), "RemoveLast returns incorrect value");
            Assert.AreEqual(new char[] { }, CharList.ToArray());
            Assert.AreEqual(0, CharList.Count);
        }

        [Test]
        public void RemoveLastShouldRemoveLastWhenListContainsGTOneItem()
        {
            CharList.AddLast('a');
            CharList.AddLast('b');
            Assert.AreEqual('b', CharList.RemoveLast(), "RemoveLast returns incorrect value");
            Assert.AreEqual(new char[] { 'a' }, CharList.ToArray(), "RemoveLast does not correctly mutate list");
        }

        [Test]
        public void RemoveLastShouldDecreaseCount()
        {
            CharList.AddLast('a');
            CharList.AddLast('b');
            CharList.RemoveLast();
            Assert.AreEqual(1, CharList.Count);
        }

        [Test]
        public void RemoveByIndexShouldThrowInvalidOperationExceptionWhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => CharList.Remove(0));
        }

        [Test]
        public void RemoveByIndexShouldThrowIndexOutOfRangeExceptionForNegativeIndex()
        {
            CharList.AddFirst('a');
            Assert.Throws<IndexOutOfRangeException>(() => CharList.Remove(-1));
        }

        [Test]
        public void RemoveByIndexShouldThrowIndexOutOfRangeExceptionForIndexGTECount()
        {
            CharList.AddLast('a');
            CharList.AddLast('b');
            Assert.Throws<IndexOutOfRangeException>(() => CharList.Remove(2));
        }

        [Test]
        public void RemoveByIndexShouldRemoveFirstCorrectly()
        {
            char[] testChars = { 'a', 'b', 'c' };
            foreach (char c in testChars)
            {
                CharList.AddLast(c);
            }
            Assert.AreEqual('a', CharList.Remove(0));
        }

        [Test]
        public void RemoveByIndexShouldRemoveLastCorrectly()
        {
            char[] testChars = { 'a', 'b', 'c' };
            foreach (char c in testChars)
            {
                CharList.AddLast(c);
            }
            Assert.AreEqual('c', CharList.Remove(2));
        }

        [Test]
        public void RemoveByIndexShouldRemoveValidMiddleIndexCorrectly()
        {
            char[] testChars = { 'a', 'b', 'c' };
            foreach (char c in testChars)
            {
                CharList.AddLast(c);
            }
            Assert.AreEqual('b', CharList.Remove(1));
        }

        [Test]
        public void RemoveByIndexShouldDecreaseCount()
        {
            CharList.AddFirst('a');
            CharList.AddFirst('b');
            CharList.Remove(0);
            Assert.AreEqual(1, CharList.Count);
        }

        [Test]
        public void RemoveByValueShouldReturnTrueWhenListContainedItem()
        {
            CharList.AddLast('a');
            Assert.IsTrue(CharList.Remove('a'));
        }

        [Test]
        public void RemoveByValueShouldReturnFalseWhenListDidNotContainItem()
        {
            CharList.AddLast('a');
            Assert.IsFalse(CharList.Remove('b'));
        }

        #endregion

        #region IndexOf tests

        [Test]
        public void IndexOfShouldReturnNegativeOneWhenListEmpty()
        {
            Assert.AreEqual(-1, CharList.IndexOf('a'));
        }

        [Test]
        public void IndexOfShouldReturnCorrectIndexWhenItemInNonEmptyList()
        {
            CharList.AddLast('a');
            CharList.AddLast('b');
            Assert.AreEqual(1, CharList.IndexOf('b'));
        }

        [Test]
        public void IndexOfShouldReturnNegativeOneWhenItemNotInNonEmptyList()
        {
            CharList.AddLast('a');
            CharList.AddLast('b');
            Assert.AreEqual(-1, CharList.IndexOf('c'));
        }

        #endregion

        #region Clear tests

        [Test]
        public void ClearShouldResetCountToZero()
        {
            char[] testChars = { 'a', 'b', 'c', 'd', 'e' };
            foreach (char c in testChars)
            {
                CharList.AddLast(c);
            }
            CharList.Clear();
            Assert.AreEqual(0, CharList.Count);
        }

        [Test]
        public void ClearShouldRemoveAllPreviousValues()
        {
            char[] testChars = { 'a', 'b', 'c', 'd', 'e' };
            foreach (char c in testChars)
            {
                CharList.AddLast(c);
            }
            CharList.Clear();
            foreach (char c in testChars)
            {
                Assert.IsFalse(CharList.Contains(c), $"LinkedList contains \"{c}\" after Clear was called");
            }
        }

        #endregion

        #region Contains tests

        [Test]
        public void ContainsShouldReturnTrueWhenListContainsItem()
        {
            CharList.AddLast('a');
            Assert.IsTrue(CharList.Contains('a'));
        }

        [Test]
        public void ContainsShouldReturnFalseWhenListContainsItem()
        {
            CharList.AddLast('a');
            Assert.IsFalse(CharList.Contains('b'));
        }

        #endregion

        #region ToArray tests

        [Test]
        public void ToArrayShouldReturnListInOrder()
        {
            CharList.AddLast('a');
            CharList.AddLast('b');
            CharList.AddLast('c');
            Assert.AreEqual(new char[] { 'a', 'b', 'c' }, CharList.ToArray());
        }

        [Test]
        public void ToArrayShouldReturnEmptyArrayWhenEmpty()
        {
            Assert.AreEqual(new char[] { }, CharList.ToArray());
        }

        #endregion
    }
}
