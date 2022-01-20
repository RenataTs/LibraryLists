using ListsLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ListsTests
{
    [TestFixture(typeof(ArrayList<int>))]
    public partial class Tests<T>
    {
        [Test]
        public void Add_WhenCalled_ShouldAddElementToZeroIndex()
        {
            _list.Add(10);

            Assert.AreEqual(10, _list[0]);
        }

        [TestCase(new[] { 1, 2, 3 }, new[] { 5, 4 }, new[] { 1, 2, 3, 5, 4 })]
        [TestCase(new[] { 3 }, new[] { 5, 4, 3, 1, 2 }, new[] { 3, 5, 4, 3, 1, 2 })]
        [TestCase(new[] { 5, 4, 3, 2, 3 }, new[] { 1 }, new[] { 5, 4, 3, 2, 3, 1 })]
        [TestCase(new[] { 4, 3, 6 }, new[] { 2, 4 }, new[] { 4, 3, 6, 2, 4 })]
        [TestCase(new[] { 1 }, new[] { 0 }, new[] { 1, 0 })]
        public void Add_WhenCalled_ShouldAddArrayToZeroIndex(
            int[] sourceArray, int[] addedArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.Add(addedArray);

            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new[] { 1, 2, 3 }, 5, new[] { 5, 1, 2, 3 })]
        [TestCase(new[] { 3 }, 1, new[] { 1, 3 })]
        [TestCase(new[] { 5, 4, 3, 2, 3 }, 8, new[] { 8, 5, 4, 3, 2, 3 })]
        [TestCase(new[] { 4, 3, 6 }, 2, new[] { 2, 4, 3, 6 })]
        [TestCase(new[] { 1 }, 0, new[] { 0, 1 })]
        public void AddFront_WhenCalled_ShouldAddFrontElementToZeroIndex(
            int[] sourceArray, int addedElement, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.AddFront(addedElement);

            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new[] { 1, 2, 3 }, new[] { 5, 4 }, new[] { 5, 4, 1, 2, 3 })]
        [TestCase(new[] { 3 }, new[] { 5, 4, 3, 1, 2 }, new[] { 5, 4, 3, 1, 2, 3 })]
        [TestCase(new[] { 5, 4, 3, 2, 3 }, new[] { 1 }, new[] { 1, 5, 4, 3, 2, 3 })]
        [TestCase(new[] { 4, 3, 6 }, new[] { 2, 4 }, new[] { 2, 4, 4, 3, 6 })]
        [TestCase(new[] { 1 }, new[] { 0 }, new[] { 0, 1 })]
        public void AddFront_WhenCalled_ShouldAddArrayToZeroIndex(
            int[] sourceArray, int[] addedArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.AddFront(addedArray);

            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new[] { 1, 2, 3 }, 7, 0, new[] { 7, 1, 2, 3 })]
        [TestCase(new[] { 5, 4, 9, 2, 4 }, 1, 4, new[] { 5, 4, 9, 2, 1, 4 })]
        [TestCase(new[] { 6, 3, 2, 2 }, 5, 4, new[] { 6, 3, 2, 2, 5 })]
        [TestCase(new[] { 4, 3, 2, 4, 5, 6, 4, 9, 2 }, 0, 8, new[] { 4, 3, 2, 4, 5, 6, 4, 9, 0, 2 })]
        public void AddBy_WhenIndexNotGreaterThanLength_ShouldReturnArrayWithInsertItem
            (int[] sourceArray, int insertValue, int index, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.AddBy(insertValue, index);

            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new[] { 6, 3, 2, 2 }, 5, 5)]
        [TestCase(new[] { 1, 2, 4, 3 }, 5, -2)]
        [TestCase(new[] { 3, 2, 1 }, 0, 4)]
        [TestCase(new[] { 2 }, 9, -1)]
        [TestCase(new[] { 2, 4, 2, 9, 1 }, 7, 6)]
        public void AddBy_WhenIndexGreaterThanLength_ShouldThrowIndexOutOfRangeException(
            int[] sourceArray, int insertValue, int index)
        {
            try
            {
                var instance = _list.CreateInstance(sourceArray);
                instance.AddBy(insertValue, index);
            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.AreEqual("Index should be greater or equal to zero and less than array length!", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new[] { 6, 3, 2, 2 }, new[] { 6, 3, 2, 2, 6, 3, 2, 2 })]
        [TestCase(new[] { 1, 3 }, new[] { 1, 3, 1, 3 })]
        [TestCase(new[] { 4, 2, 1 }, new[] { 4, 2, 1, 4, 2, 1 })]
        public void AddFront_WhenCalled_ShouldReturnArrayWithInsertArray
            (int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            var insertValues = _list.CreateInstance(sourceArray);
            instance.AddFront(insertValues);

            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new[] { 6, 3, 2, 2 }, new[] { 6, 3, 2, 2, 6, 3, 2, 2 })]
        [TestCase(new[] { 1, 3 }, new[] { 1, 3, 1, 3 })]
        [TestCase(new[] { 4, 2, 1 }, new[] { 4, 2, 1, 4, 2, 1 })]
        public void Add_WhenCalled_ShouldReturnArrayWithInsertArray
            (int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            var insertValues = _list.CreateInstance(sourceArray);
            instance.Add(insertValues);

            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new[] { 6, 3, 2, 2 }, 3, new[] { 6, 3, 2, 6, 3, 2, 2, 2 })]
        [TestCase(new[] { 1, 3 }, 2, new[] { 1, 3, 1, 3 })]
        [TestCase(new[] { 4, 2, 1 }, 1, new[] { 4, 4, 2, 1, 2, 1 })]
        public void AddBy_WhenIndexNotGreaterThanLength_ShouldReturnArrayWithInsertArray
            (int[] sourceArray, int index, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            var insertValues = _list.CreateInstance(sourceArray);
            instance.AddBy(insertValues, index);

            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new[] { 6, 3, 2, 2 }, new[] { 0, 3, 2 }, 10)]
        [TestCase(new[] { 2, 1 }, new[] { 0, 3, 2 }, -1)]
        [TestCase(new[] { 6 }, new[] { 2, 9 }, 4)]
        public void AddBy_WhenIndexGreaterThanLength_ShouldThrowIndexOutOfRangeException(
            int[] sourceArray, int[] insertArray, int index)
        {
            try
            {
                var instance = _list.CreateInstance(sourceArray);
                instance.AddBy(insertArray, index);
            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.AreEqual("Index should be greater or equal to zero and less than array length!", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}