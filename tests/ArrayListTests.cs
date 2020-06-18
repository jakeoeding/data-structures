using System;
using NUnit.Framework;
using DataStructures;

namespace DataStructuresTests
{
    [TestFixture]
    public class ArrayListTests
    {
        ArrayList<string> StringList;

        [SetUp]
        public void Setup()
        {
            StringList = new ArrayList<string>();
        }

        [TearDown]
        public void Teardown()
        {
            StringList = null;
        }

        #region Indexer tests

        [Test]
        public void SetIndexerShouldThrowIndexOutOfRangeExceptionForNegativeIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() => StringList[-1] = "testing");
        }

        [Test]
        public void SetIndexerShouldThrowIndexOutOfRangeExceptionForIndexGreaterThanCount()
        {
            Assert.Throws<IndexOutOfRangeException>(() => StringList[40] = "testing");
        }

        [Test]
        public void SetIndexerShouldSetAppropriateValueForValidIndex()
        {
            StringList[0] = "testing";
            Assert.AreEqual("testing", StringList[0]);
        }

        [Test]
        public void SetIndexerShouldNotIncreaseCountWhenOverridingIndex()
        {
            StringList[0] = "testing";
            StringList[0] = "indexer";
            Assert.AreEqual(1, StringList.Count);
        }

        [Test]
        public void SetIndexerShouldIncreaseCountForNewIndex()
        {
            StringList[0] = "testing";
            StringList[1] = "indexer";
            Assert.AreEqual(2, StringList.Count);
        }

        [Test]
        public void GetIndexerShouldThrowIndexOutOfRangeExceptionForNegativeIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() => StringList[-1].ToUpper());
        }

        [Test]
        public void GetIndexerShouldThrowIndexOutOfRangeExceptionForIndexGreaterThanCount()
        {
            Assert.Throws<IndexOutOfRangeException>(() => StringList[3].ToUpper());
        }

        [Test]
        public void GetIndexerShouldReturnAppropriateValueForValidIndex()
        {
            StringList[0] = "testing";
            StringList[1] = "indexer";
            Assert.AreEqual("indexer", StringList[1]);
        }

        #endregion

        #region IndexOf tests

        [Test]
        public void IndexOfShouldReturnMinusOneForInvalidItem()
        {
            StringList[0] = "will this work?";
            Assert.AreEqual(-1, StringList.IndexOf("yes it will"));
        }

        [Test]
        public void IndexOfShouldReturnCorrectIndexOfValidItem()
        {
            StringList[0] = "will this work?";
            StringList[1] = "yes it will";
            Assert.AreEqual(1, StringList.IndexOf("yes it will"));
        }

        #endregion

        #region Add tests

        [Test]
        public void AddByValueShouldAddToEndOfList()
        {
            string[] testStrings = { "1", "giraffe", "flames", "octopus", "syrup" };
            foreach (string str in testStrings)
            {
                StringList.Add(str);
            }
            for (int i = 0; i < testStrings.Length; i++)
            {
                Assert.AreEqual(testStrings[i], StringList[i], $"Index {i} did not match expectation");
            }
        }

        [Test]
        public void AddByValueShouldIncreaseCount()
        {
            string[] testStrings = { "1", "giraffe", "flames", "octopus", "syrup" };
            foreach (string str in testStrings)
            {
                StringList.Add(str);
            }
            Assert.AreEqual(testStrings.Length, StringList.Count);
        }

        [Test]
        public void AddByIndexShouldThrowIndexOutOfRangeExceptionForNegativeIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() => StringList.Add("testing", -1));
        }

        [Test]
        public void AddByIndexShouldThrowIndexOutOfRangeExceptionForIndexGreaterThanCount()
        {
            Assert.Throws<IndexOutOfRangeException>(() => StringList.Add("testing", 50));
        }

        [Test]
        public void AddByIndexShouldAddAtCorrectIndexForValidIndex()
        {
            StringList.Add("testing", 0);
            Assert.AreEqual("testing", StringList[0]);
        }

        [Test]
        public void AddByIndexShouldIncreaseCount()
        {
            string[] testStrings = { "1", "giraffe", "flames", "octopus", "syrup" };
            foreach (string str in testStrings)
            {
                StringList.Add(str, 0);
            }
            Assert.AreEqual(testStrings.Length, StringList.Count);
        }

        #endregion

        #region Remove tests

        [Test]
        public void RemoveByIndexShouldThrowIndexOutOfRangeExceptionForNegativeIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() => StringList.Remove(-1));
        }

        [Test]
        public void RemoveByIndexShouldThrowIndexOutOfRangeExceptionForIndexGreaterThanCount()
        {
            Assert.Throws<IndexOutOfRangeException>(() => StringList.Remove(50));
        }

        [Test]
        public void RemoveByIndexShouldReturnValueAtValidIndex()
        {
            string[] testStrings = { "1", "giraffe", "flames", "octopus", "syrup" };
            foreach (string str in testStrings)
            {
                StringList.Add(str);
            }
            Assert.AreEqual("flames", StringList.Remove(2));
        }

        [Test]
        public void RemoveByIndexShouldRemoveValueAtValidIndex()
        {
            string[] testStrings = { "1", "giraffe", "flames", "octopus", "syrup" };
            foreach (string str in testStrings)
            {
                StringList.Add(str);
            }
            StringList.Remove(2);
            Assert.AreEqual(new string[] { "1", "giraffe", "octopus", "syrup" }, StringList.ToArray());
        }

        [Test]
        public void RemoveByIndexShouldDecreaseCount()
        {
            string[] testStrings = { "1", "giraffe", "flames", "octopus", "syrup" };
            foreach (string str in testStrings)
            {
                StringList.Add(str);
            }
            StringList.Remove(2);
            Assert.AreEqual(testStrings.Length - 1, StringList.Count);
        }

        [Test]
        public void RemoveByValueShouldReturnTrueWhenContainsValue()
        {
            StringList.Add("testing");
            Assert.IsTrue(StringList.Remove("testing"));
        }

        [Test]
        public void RemoveByValueShouldReturnFalseWhenDoesNotContainValue()
        {
            StringList.Add("testing");
            Assert.IsFalse(StringList.Remove("value not contained"));
        }

        #endregion

        #region Clear tests

        [Test]
        public void ClearShouldResetCountToZero()
        {
            string[] testStrings = { "1", "giraffe", "flames", "octopus", "syrup" };
            foreach (string str in testStrings)
            {
                StringList.Add(str);
            }
            StringList.Clear();
            Assert.AreEqual(0, StringList.Count);
        }

        [Test]
        public void ClearShouldRemoveAllPreviousValues()
        {
            string[] testStrings = { "1", "giraffe", "flames", "octopus", "syrup" };
            foreach (string str in testStrings)
            {
                StringList.Add(str);
            }
            StringList.Clear();
            foreach (string str in testStrings)
            {
                Assert.IsFalse(StringList.Contains(str), $"ArrayList contains \"{str}\" after Clear was called");
            }
        }

        #endregion

        #region Contains tests
        [Test]
        public void ContainsShouldReturnFalseWhenCountIsZero()
        {
            Assert.IsFalse(StringList.Contains("a test string"));
        }

        [Test]
        public void ContainsShouldReturnTrueWhenListContainsValue()
        {
            StringList[0] = "a string for this test";
            Assert.IsTrue(StringList.Contains("a string for this test"));
        }

        [Test]
        public void ContainsShouldReturnFalseWhenListDoesntContainValue()
        {
            StringList[0] = "a string for this test";
            Assert.IsFalse(StringList.Contains("a string for this test".ToUpper()));
        }

        #endregion

        #region ToArray tests

        [Test]
        public void ToArrayShouldReturnListInOrder()
        {
            StringList.Add("test1");
            StringList.Add("test2");
            Assert.AreEqual(new string[] { "test1", "test2" }, StringList.ToArray());
        }

        [Test]
        public void ToArrayShouldReturnEmptyArrayWhenEmpty()
        {
            Assert.AreEqual(new string[] { }, StringList.ToArray());
        }

        #endregion
    }
}
