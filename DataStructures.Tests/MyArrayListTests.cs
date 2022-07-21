using System;
using System.Data;
using NUnit.Framework;
using DataStructuresLibrary;

namespace DataStructures.Tests
{
    public class MyArrayListTests
    {
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 10, new[] { 1, 2, 3, 4, 5, 10 })]
        public void Test1(int[] sourceArray, int valueToAdd, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.AddBack(valueToAdd);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 10, new[] { 1, 2, 3, 4, 5, 10, 10 })]
        public void Test2(int[] sourceArray, int valueToAdd, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.AddBack(valueToAdd);
            myArrayList.AddBack(valueToAdd);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 65 }, 0, 65)]
        [TestCase(new[] { 5, 21 }, 1, 21)]
        [TestCase(new[] { 5, 3, 10, -90, 5, 0 }, 3, -90)]
        [TestCase(new[] { 5, 3, 10, -90, 5, 0 }, 0, 5)]
        [TestCase(new[] { 5, 3, 10, -90, 5, 0 }, 5, 0)]
        public void IndexerGet_WhenValidIndexAndArrayFilled_ShouldReturnValueByIndex
            (int[] sourceArray, int index, int expected)
        {
            IMyList myList = new MyArrayList(sourceArray);

            int actual = myList[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[0])]
        public void IndexerGet_WhenEmptyArray_ShouldThrowIndexOutOfRange
            (int[] sourceArray)
        {
            IMyList myList = new MyArrayList(sourceArray);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var item = myList[0];
            });
        }

        [TestCase(new[] { 1 }, 2)]
        [TestCase(new[] { 1 }, -1)]
        [TestCase(new[] { 1, 6, 3, 4, 1 }, 5)]
        [TestCase(new[] { 1, 6, 3, 4, 1 }, -10)]
        public void IndexerGet_WhenInvalidIndex_ShouldThrowIndexOutOfRange
            (int[] sourceArray, int index)
        {
            IMyList myList = new MyArrayList(sourceArray);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var item = myList[index];
            });
        }

        [Test]
        public void ArrayConstructor_WhenNullPassed_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                IMyList myList = new MyArrayList(null);
            });
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 69, 0, 69)]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, -5190293, 0, -5190293)]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, 5, 5)]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, 3, 3)]
        public void AddElementFront_WhenCorrectValue_ShouldReturnValueByIndex
            (int[] sourceArray, int addFrontElement, int checkByIndex, int expected)
        {
            IMyList myList = new MyArrayList(sourceArray);
            myList.AddFront(addFrontElement);
            Assert.AreEqual(expected, myList[checkByIndex]);
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, 6)]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, 324)]
        public void AddElementByIndex_WhenCorrectValue_ShouldReturnValueByIndex
            (int[] sourceArray, int addToIndex, int addElement)
        {
            IMyList myList = new MyArrayList(sourceArray);
            myList.AddByIndex(addToIndex, addElement);
            Assert.AreEqual(addElement, myList[addToIndex]);
        }

        [Test]
        public void AddElementByIndex_WhenAddOutOfRange_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                IMyList myList = new MyArrayList();
                myList.AddByIndex(-1, 1);
            });
        }
    }
}