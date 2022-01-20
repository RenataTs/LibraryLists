using LibraryLists;
using System;
using System.Collections.Generic;

namespace ListsTest
{
    [TestFixture(typeof(ArrayList<int>))]
    public class Tests<T> where T : LibraryLists.IList<int>, new()
    {
        LibraryLists.IList<int> _list;

        [SetUp]
        public void Setup()
        {
            _list = new T();
        }

        [Test]
        public void Add_WhenCalled_ShouldAddElementToZeroIndex()
        {
            _list.Add(10);

            Assert.AreEqual(10, _list[0]);
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 })]
        public void InitializerForArray_WhenArrayPassed_ShouldFillList
            (int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);
            instance.Sort();


            CollectionAssert.AreEqual(expectedArray, instance);
        }
    }
}