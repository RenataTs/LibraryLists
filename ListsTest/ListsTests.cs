using LibraryLists;
using NUnit.Framework;
using System.Collections.Generic;

namespace ListsTest
{
    [TestFixture(typeof(ArrayList<int>))]
    public class Tests<T> where T : IList<int>, new()
    {
        IList<int> _list;

        [SetUp]
        public void Setup()
        {
            _list = new T();
        }

        [Test]
        public void Add_WhenCalled_ShouldAddElementToZeroIndex()
        {
            _list.Add(10);
            _list.Add(2);

            Assert.AreEqual(10, _list[0]);
            Assert.AreEqual(2, _list[1]);
        }

    }
}