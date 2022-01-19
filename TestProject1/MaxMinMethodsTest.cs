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

        [TestCase(new[] { 1, 2, 3 }, 3)]
        [TestCase(new[] { 4, 3, 9, 3, 2 }, 9)]
        [TestCase(new[] { 5, 4, 3, 2, 1 }, 5)]
        [TestCase(new[] { 2 }, 2)]
        [TestCase(new[] { 3, 3, 3 }, 3)]
        public void MaxValue_WhenArrayPassed_ShouldReturnArrayMaxValue
            (int[] sourceArray, int expectedResult)
        {
            var instance = _list.CreateInstance(sourceArray);
            var actualReault = instance.MaxValue();

            Assert.AreEqual(expectedResult, actualReault);
        }

        [TestCase(new[] { 1, 2, 3 }, 1)]
        [TestCase(new[] { 4, 3, 9, 3, 2 }, 2)]
        [TestCase(new[] { 9, 2, -3, 2, -1, -8 }, -8)]
        [TestCase(new[] { 4, 2, 7, 2, 9, 3, 2 }, 2)]
        public void MinValue_WhenArrayPassed_ShouldReturnArrayMinValue
            (int[] sourceArray, int expectedResult)
        {
            var instance = _list.CreateInstance(sourceArray);
            var actualReault = instance.MinValue();

            Assert.AreEqual(expectedResult, actualReault);
        }

        [TestCase(new[] { 1, 2, 3 }, 2)]
        [TestCase(new[] { 4, 3, 2, 9, 2 }, 3)]
        [TestCase(new[] { 8, 2, 1, 3, 0, 2 }, 0)]
        [TestCase(new[] { 1, 2, 2, 4, 3 }, 3)]
        public void MaxValueIndex_WhenArrayPassed_ShouldReturnArrayMaxValueIndex
            (int[] sourceArray, int expectedResult)
        {
            var instance = _list.CreateInstance(sourceArray);
            var actualReault = instance.MaxValueIndex();

            Assert.AreEqual(expectedResult, actualReault);
        }

        [TestCase(new[] { 1, 2, 3 }, 0)]
        [TestCase(new[] { 4, 3, 9, 3, 2 }, 4)]
        [TestCase(new[] { 9, 2, -3, 2, -1, -8 }, 5)]
        [TestCase(new[] { 4, 2, 7, 2, 9, 3, 2 }, 1)]
        public void MinValueIndex_WhenArrayPassed_ShouldReturnArrayMinValueIndex
            (int[] sourceArray, int expectedResult)
        {
            var instance = _list.CreateInstance(sourceArray);
            var actualReault = instance.MinValueIndex();

            Assert.AreEqual(expectedResult, actualReault);
        }
    }
}