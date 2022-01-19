using ListsLibrary;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ListsTests
{
    [TestFixture(typeof(ArrayList<int>))]
    public partial class Tests<T> where T : ListsLibrary.IList<int>, new()
    {
        ListsLibrary.IList<int> _list;

        [SetUp]
        public void Setup()
        {
            _list = new T();
        }

        [TestCase(new[] { 1, 2, 3 }, 3)]
        [TestCase(new[] { 4, 3, 9, 3, 2 }, 5)]
        [TestCase(new[] { 4, 2, 4, 2, 7, 4, 2 }, 7)]
        [TestCase(new[] { 2, 4, 6, 1 }, 4)]
        public void Length_WhenArrayPassed_ShouldReturnArrayLength
              (int[] sourceArray, int expectedLegth)
        {
            var instance = _list.CreateInstance(sourceArray);
            var actualReault = instance.Count;

            Assert.AreEqual(expectedLegth, actualReault);
        }

        [TestCase(new[] { 1, 2, 3 }, 0, 1)]
        [TestCase(new[] { 4, 3, 9, 3, 2 }, 1, 3)]
        [TestCase(new[] { 4, 2, 4, 2, 7 }, 4, 7)]
        [TestCase(new[] { 2, 4, 6, 1, 3 }, 0, 2)]
        public void ItemBy_WhenArrayPassed_ShouldReturnItemByIndex
            (int[] sourceArray, int index, int expectedItem)
        {
            var instance = _list.CreateInstance(sourceArray);
            var actualReault = instance[index];

            Assert.AreEqual(expectedItem, actualReault);
        }

        [TestCase(new[] { 1, 2, 3 }, 1, 0)]
        [TestCase(new[] { 4, 3, 9, 3, 2 }, 3, 1)]
        [TestCase(new[] { 4, 2, 4, 2, 7 }, 7, 4)]
        [TestCase(new[] { 2, 4, 6, 1, 3 }, 2, 0)]
        public void IndexByItem_WhenArrayPassed_ShouldReturnIndexByItem
            (int[] sourceArray, int item, int expectedItemIndex)
        {
            var instance = _list.CreateInstance(sourceArray);
            var actualReault = instance.IndexByItem(item);

            Assert.AreEqual(expectedItemIndex, actualReault);
        }

        [TestCase(new[] { 1, 2, 3 }, 3, 5, new[] { 1, 2, 5 })]
        [TestCase(new[] { 4, 3, 9, 3, 2 }, 9, 8, new[] { 4, 3, 8, 3, 2 })]
        [TestCase(new[] { 4, 2, 4, 2, 7 }, 4, 7, new[] { 7, 2, 4, 2, 7 })]
        [TestCase(new[] { 2, 4, 6, 1, 3 }, 2, 0, new[] { 0, 4, 6, 1, 3 })]
        [TestCase(new[] { 2, 4, 6, 1, 3 }, 9, 0, new[] { 2, 4, 6, 1, 3 })]
        public void ReplaceByItem_WhenArrayPassed_ShouldReplaceItemByNewItem
            (int[] sourceArray, int item, int newItem, int[] expectedeArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.ReplaceByItem(item, newItem);

            Assert.AreEqual(expectedeArray, instance);
        }

        [TestCase(new[] { 1, 2, 3 }, 0, 5, new[] { 5, 2, 3 })]
        [TestCase(new[] { 4, 3, 9, 3, 2 }, 2, 9, new[] { 4, 3, 9, 3, 2 })]
        [TestCase(new[] { 4, 2, 4, 2, 7 }, 4, 6, new[] { 4, 2, 4, 2, 6 })]
        [TestCase(new[] { 2, 4, 6, 1, 3 }, 2, 0, new[] { 2, 4, 0, 1, 3 })]
        [TestCase(new[] { 2, 4, 6, 1, 3 }, 3, 2, new[] { 2, 4, 6, 2, 3 })]
        public void ReplaceBy_WhenArrayPassed_ShouldReplaceItemByNewItem
             (int[] sourceArray, int index, int newItem, int[] expectedeArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.ReplaceBy(index, newItem);

            Assert.AreEqual(expectedeArray, instance);
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 })]
        [TestCase(new[] { 3 }, new[] { 3 })]
        [TestCase(new[] { 4, 3, 7, 5 }, new[] { 5, 7, 3, 4 })]
        [TestCase(new[] { 5, 4, 5, 3, 9 }, new[] { 9, 3, 5, 4, 5 })]
        [TestCase(new[] { 9, 4, 3 }, new[] { 3, 4, 9 })]
        public void Reverse_WhenArrayPassed_ShouldToReverceArray
            (int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.Reverse();

            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new[] { 3, 4, 2 }, true, new[] { 2, 3, 4 })]
        [TestCase(new[] { 3, 3, 1, -2, 0, 1 }, false, new[] { 3, 3, 1, 1, 0, -2 })]
        [TestCase(new[] { 4, 3, 8, 5 }, true, new[] { 3, 4, 5, 8 })]
        [TestCase(new[] { 3, 0, 8, 1, 3 }, false, new[] { 8, 3, 3, 1, 0 })]
        [TestCase(new[] { 2 }, false, new[] { 2 })]
        public void Sort_WhenArrayPassed_ShouldSortList
            (int[] sourceArray, bool coef, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.Sort(coef);

            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new[] { 1, 2, 3 }, -2, 5)]
        [TestCase(new[] { 4, 3, 9, 3, 2 }, 12, 9)]
        [TestCase(new[] { 4, 2, 4, 2, 7 }, -3, 6)]
        [TestCase(new[] { 2, 4, 6, 1, 3 }, 11, 0)]
        [TestCase(new[] { 2, 4, 6, 1, 3 }, -5, 2)]
        public void ReplaceByIndex_WhenArrayPassed_ShouldThrowIndexOutOfRangeException(
            int[] sourceArray, int index, int newItem)
        {
            try
            {
                var instance = _list.CreateInstance(sourceArray);
                instance.ReplaceBy(index, newItem);
            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.AreEqual("Index should be greater or equal to zero and less than array length!", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 })]
        public void InitializerForArray_WhenArrayPassed_ShouldFillList
            (int[] sourceArray, int[] expectedArray)
        {
            _list = (ListsLibrary.IList<int>)Activator.CreateInstance(typeof(T), sourceArray);
            var instance = _list.CreateInstance(sourceArray);

            CollectionAssert.AreEqual(expectedArray, instance);
        }
    }
}