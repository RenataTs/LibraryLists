using ListsLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ListsTests
{
    [TestFixture(typeof(ArrayList<int>))]
    public partial class Tests<T>
    {
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2 })]
        [TestCase(new[] { 3, 2 }, new[] { 3 })]
        [TestCase(new[] { 5, 4, 3, 2, 3 }, new[] { 5, 4, 3, 2 })]
        [TestCase(new[] { 4, 3, 6 }, new[] { 4, 3 })]
        public void RemoveLastItem_WhenCalled_ShouldRemoveLastItemInArray(
            int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.RemoveLastItem();

            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new[] { 1, 2, 3 }, new[] { 2, 3 })]
        [TestCase(new[] { 3, 2 }, new[] { 2 })]
        [TestCase(new[] { 5, 4, 3, 2, 3 }, new[] { 4, 3, 2, 3 })]
        [TestCase(new[] { 4, 3, 6 }, new[] { 3, 6 })]
        public void RemoveFirstItem_WhenCalled_ShouldRemoveFirstItemInArray(
            int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.RemoveFirstItem();

            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new[] { 3, 4, 2 }, 2, new[] { 3, 4 })]
        [TestCase(new[] { 3, 2, 2, 1, 4 }, 0, new[] { 2, 2, 1, 4 })]
        [TestCase(new[] { 6, 4, 3, 7, 3, 2 }, 4, new[] { 6, 4, 3, 7, 2 })]
        [TestCase(new[] { 3, 2, 2, 1, 4 }, 1, new[] { 3, 2, 1, 4 })]
        [TestCase(new[] { 6, 4, 3, 7, 3, 2 }, 5, new[] { 6, 4, 3, 7, 3 })]
        public void RemoveBy_WhenIndexNotGreaterThanLength_ShouldRemoveItem
            (int[] sourceArray, int index, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.RemoveBy(index);

            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new[] { 3, 4, 2 }, -2)]
        [TestCase(new[] { 3, 2, 2, 1, 4 }, 10)]
        [TestCase(new[] { 6, 4, 3, 7, 3, 2 }, -4)]
        public void RemoveByIndex_WhenIndexGreaterThanLength_ShouldThrowIndexOutOfRangeException
            (int[] sourceArray, int index)
        {
            try
            {
                var instance = _list.CreateInstance(sourceArray);
                instance.RemoveBy(index);
            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.AreEqual("Index should be greater or equal to zero and less than array length!", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new[] { 3, 4, 2 }, 2, new[] { 3 })]
        [TestCase(new[] { 3, 2, 2, 1, 4 }, 0, new[] { 3, 2, 2, 1, 4 })]
        [TestCase(new[] { 6, 4, 3, 7, 3, 2 }, 4, new[] { 6, 4 })]
        [TestCase(new[] { 3, 2, 2, 1, 4 }, 1, new[] { 3, 2, 2, 1 })]
        [TestCase(new[] { 6, 4, 3, 7, 3, 2 }, 5, new[] { 6 })]
        public void LastNItemsRemove_WhenCalled_ShouldRemoveNLastItems
            (int[] sourceArray, int count, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.LastNItemsRemove(count);

            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new[] { 3, 4, 2 }, 2, new[] { 2 })]
        [TestCase(new[] { 3, 2, 2, 1, 4 }, 0, new[] { 3, 2, 2, 1, 4 })]
        [TestCase(new[] { 6, 4, 3, 7, 3, 2 }, 4, new[] { 3, 2 })]
        [TestCase(new[] { 3, 2, 2, 1, 4 }, 1, new[] { 2, 2, 1, 4 })]
        [TestCase(new[] { 6, 4, 3, 7, 3, 2 }, 5, new[] { 2 })]
        public void FirstNItemsRemove_WhenCalled_ShouldRemoveNFirstItems
              (int[] sourceArray, int count, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.FirstNItemsRemove(count);

            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new[] { 3, 4, 2 }, 2, 1, new[] { 3 })]
        [TestCase(new[] { 3, 2, 2, 1, 4 }, 0, 4, new[] { 3, 2, 2, 1, 4 })]
        [TestCase(new[] { 6, 4, 3, 7, 3, 2 }, 0, 4, new[] { 6, 4, 3, 7, 3, 2 })]
        [TestCase(new[] { 3, 2, 2, 1, 4 }, 1, 3, new[] { 3, 2, 2, 4 })]
        [TestCase(new[] { 6, 4, 3, 7, 3, 2 }, 3, 3, new[] { 6, 4, 3 })]
        public void NItemsDeleteBy_WhenIndexNotGreaterThanLength_ShouldRemoveNFirstItems
            (int[] sourceArray, int count, int index, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.NItemsDeleteBy(count, index);

            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new[] { 3, 4, 2 }, 2, -3)]
        [TestCase(new[] { 3, 2, 2, 1, 4 }, 9, 8)]
        [TestCase(new[] { 6, 4, 3, 7, 3, 2 }, 4, -3)]
        public void NItemsDeleteBy_WhenIndexGreaterThanLength_ShouldThrowIndexOutOfRangeException
            (int[] sourceArray, int count, int index)
        {
            try
            {
                var instance = _list.CreateInstance(sourceArray);
                instance.NItemsDeleteBy(count, index);
            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.AreEqual("Index should be greater or equal to zero and less than array length!", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new[] { 3, 4, 2 }, 2, 2)]
        [TestCase(new[] { 3, 2, 2, 1, 4 }, 1, 3)]
        [TestCase(new[] { 6, 4, 3, 7, 3, 2 }, 3, 2)]
        [TestCase(new[] { 3, 2, 2, 1, 4 }, 2, 1)]
        [TestCase(new[] { 6, 4, 3, 7, 3, 2 }, 3, 2)]
        public void RemoveItemByValue_WhenCalled_ShouldReturnIndex
            (int[] sourceArray, int item, int expectedIndex)
        {
            var instance = _list.CreateInstance(sourceArray);
            int actualIndex = instance.RemoveItemByValue(item);

            Assert.AreEqual(actualIndex, expectedIndex);
        }

        [TestCase(new[] { 3, 4, 2 }, 2, 1)]
        [TestCase(new[] { 3, 2, 2, 1, 4 }, 1, 1)]
        [TestCase(new[] { 6, 4, 3, 7, 3, 2 }, 3, 2)]
        [TestCase(new[] { 2, 2, 2, 1, 2 }, 2, 4)]
        [TestCase(new[] { 6, 4, 3, 7, 3, 2 }, 3, 2)]
        public void RemoveAllItemsByValue_WhenIndexCalled_ShouldRemoveAllItemByValue
            (int[] sourceArray, int item, int expectedCount)
        {
            var instance = _list.CreateInstance(sourceArray);
            int actualCount = instance.RemoveAllItemsByValue(item);

            Assert.AreEqual(actualCount, expectedCount);
        }
    }
}