using System;
using System.Data;
using NUnit.Framework;
using DataStructuresLibrary;

namespace DataStructures.Tests
{
    public class MyArrayListTests
    {
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 10, new[] { 1, 2, 3, 4, 5, 10 })]
        public void AddBack_WhenArrayNotEmpty_ShouldAddToBack
            (int[] sourceArray, int valueToAdd, int[] expectedArray)
        {
            var myArrayList = new MyArrayList(sourceArray);

            myArrayList.AddBack(valueToAdd);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 10, new[] { 1, 2, 3, 4, 5, 10, 10 })]
        public void AddBack_WhenArrayNotEmpty_ShouldAddToBackTwice
            (int[] sourceArray, int valueToAdd, int[] expectedArray)
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

        [TestCase(new[] { 5, 3, 10, -90, 5, 0 })]
        [TestCase(new[] { 5, 3, 10, 5, 0 })]
        public void RemoveBack_WhenArrayFilled_ShouldBeSmallerByOne
            (int[] sourceArray)
        {
            IMyList myList = new MyArrayList(sourceArray);
            int expected = myList.Length - 1;
            myList.RemoveBack();
            int actual = myList.Length;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveBack_WhenNotEnoughElementsToDelete_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                IMyList myList = new MyArrayList(new[] { 0 });
                myList.RemoveBack();
            });
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 2, 3, 4, 5 })]
        public void RemoveFront_WhenArrayFilled_ShouldDeleteElement
            (int[] sourceArray, int[] expectedArray)
        {
            var myList = new MyArrayList(sourceArray);

            myList.RemoveFront();

            CollectionAssert.AreEqual(expectedArray, myList.ToArray());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 1, 2, 4, 5 })]
        public void RemoveByIndex_WhenArrayFilled_ShouldDeleteElement
            (int[] sourceArray, int indexToRemove, int[] expectedArray)
        {
            var myList = new MyArrayList(sourceArray);

            myList.RemoveByIndex(indexToRemove);

            CollectionAssert.AreEqual(expectedArray, myList.ToArray());
        }

        [Test]
        public void RemoveByIndex_WhenAddOutOfRange_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                IMyList myList = new MyArrayList();
                myList.RemoveByIndex(myList.Length + 1);
            });
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, new int[0])]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, new[] { 1, 2, 3, 4, 5 })]
        public void RemoveNValuesBack_WhenArrayFilled_ShouldDeleteElements
            (int[] sourceArray, int rangeToRemove, int[] expectedArray)
        {
            var myList = new MyArrayList(sourceArray);

            myList.RemoveNValuesBack(rangeToRemove);

            CollectionAssert.AreEqual(expectedArray, myList.ToArray());
        }

        [Test]
        public void RemoveNValuesBack_WhenAddOutOfRange_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                IMyList myList = new MyArrayList(new[] { 1, 2, 3, 4, 5 });
                myList.RemoveNValuesBack(myList.Length + 1);
            });
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 4, new[] { 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 5, new int[0])]
        public void RemoveFrontNValues_WhenArrayFilled_ShouldDeleteElements
            (int[] sourceArray, int n, int[] expectedArray)
        {
            var myList = new MyArrayList(sourceArray);

            myList.RemoveNValuesFront(n);

            CollectionAssert.AreEqual(expectedArray, myList.ToArray());
        }

        [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, 3, new[] { 1, 2 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, 4, new[] { 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 3, 2, new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, 0, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, 3, new[] { 4, 5 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, 5, new int[0])]
        public void RemoveByIndexNValues_WhenArrayFilled_ShouldDeleteElements
            (int[] sourceArray, int index, int n, int[] expectedArray)
        {
            var myList = new MyArrayList(sourceArray);

            myList.RemoveNValuesByIndex(index, n);

            CollectionAssert.AreEqual(expectedArray, myList.ToArray());
        }

        [TestCase(new[] { 5, 12, 32, 4, 25 }, 32, 2)]
        [TestCase(new[] { 1, 2, -55, 4, 5 }, 5, 4)]
        [TestCase(new[] { 1, 2, -55, 4, 5 }, 1, 0)]
        public void IndexOf_WhenArrayFilled_ShouldReturnIndexOfElement
            (int[] sourceArray, int element, int expectedIndex)
        {
            var myList = new MyArrayList(sourceArray);

            myList.IndexOf(element);
        }

        [TestCase(new[] { 5, 12, 32, 4, 25 }, new[] { 25, 4, 32, 12, 5 })]
        [TestCase(new[] { 5 }, new[] { 5 })]
        [TestCase(new[] { 1, 2 }, new[] { 2, 1 })]
        public void Reverse_WhenArrayFilled_ShouldReturnIndexOfElement
            (int[] sourceArray, int[] expectedArray)
        {
            var myList = new MyArrayList(sourceArray);

            myList.Reverse();

            CollectionAssert.AreEqual(expectedArray, myList.ToArray());
        }

        [TestCase(new[] { 5, 12, 32, 4, 25 }, 32)]
        [TestCase(new[] { 1, 2, -55, 4, 5 }, 5)]
        [TestCase(new[] { 1 }, 1)]
        public void Max_WhenArrayFilled_ShouldReturnElement
            (int[] sourceArray, int expectedElement)
        {
            var myList = new MyArrayList(sourceArray);

            Assert.AreEqual(expectedElement, myList.Max());
        }

        [TestCase(new[] { 5, 12, 32, 4, 25 }, 4)]
        [TestCase(new[] { 1, 2, -55, 4, 5 }, -55)]
        [TestCase(new[] { 1 }, 1)]
        public void Min_WhenArrayFilled_ShouldReturnElement
            (int[] sourceArray, int expectedElement)
        {
            var myList = new MyArrayList(sourceArray);

            Assert.AreEqual(expectedElement, myList.Min());
        }

        [TestCase(new[] { 5, 12, 32, 4, 25 }, 2)]
        [TestCase(new[] { 1, 2, -55, 4, 5 }, 4)]
        [TestCase(new[] { 1 }, 0)]
        public void MaxIndex_WhenArrayFilled_ShouldReturnIndexOfElement
            (int[] sourceArray, int expectedIndex)
        {
            var myList = new MyArrayList(sourceArray);

            Assert.AreEqual(expectedIndex, myList.MaxIndex());
        }

        [TestCase(new[] { 5, 12, 32, 4, 25 }, 3)]
        [TestCase(new[] { 1, 2, -55, 4, 5 }, 2)]
        [TestCase(new[] { 1 }, 0)]
        public void MinIndex_WhenArrayFilled_ShouldReturnIndexOfElement
            (int[] sourceArray, int expectedIndex)
        {
            var myList = new MyArrayList(sourceArray);

            Assert.AreEqual(expectedIndex, myList.MinIndex());
        }

        [TestCase(new[] { 32, 123, 3, 21, 1 }, new[] { 1, 3, 21, 32, 123 }, true)]
        [TestCase(new[] { 5, 4, 3, 2, 1 }, new[] { 1, 2, 3, 4, 5 }, true)]
        [TestCase(new[] { -120, 3, 123, 32, -1001 }, new[] { -1001, -120, 3, 32, 123 }, true)]
        [TestCase(new[] { 2 }, new[] { 2 }, true)]
        [TestCase(new[] { 32, 123, 3, 21, 1 }, new[] { 123, 32, 21, 3, 1 }, false)]
        [TestCase(new[] { 5, 4, 3, 2, 1 }, new[] { 5, 4, 3, 2, 1 }, false)]
        [TestCase(new[] { -120, 3, 123, 32, -1001 }, new[] { 123, 32, 3, -120, -1001 }, false)]
        [TestCase(new[] { 2 }, new[] { 2 }, false)]
        public void SortAscending_WhenArrayIn_ShouldSortByOrder
            (int[] sourceArray, int[] expectedArray, bool sortBy)
        {
            var myList = new MyArrayList(sourceArray);

            myList.Sort(sortBy);

            CollectionAssert.AreEqual(expectedArray, myList.ToArray());
        }

        [TestCase(new[] { 5, 12, 32, 4, 25 }, 32, new[] { 5, 12, 4, 25 })]
        [TestCase(new[] { 5, -12 }, -12, new[] { 5 })]
        [TestCase(new[] { 1, 2 }, 1, new[] { 2 })]
        public void RemoveByValue_WhenArrayFilled_ShouldRemoveValue
            (int[] sourceArray, int value, int[] expectedArray)
        {
            var myList = new MyArrayList(sourceArray);

            myList.RemoveByValue(value);

            CollectionAssert.AreEqual(expectedArray, myList.ToArray());
        }

        [Test]
        public void RemoveByValue_WhenArrayHaveOnlyOneElement_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                IMyList myList = new MyArrayList(new[] { 1 });
                myList.RemoveByValue(1);
            });
        }

        [TestCase(new[] { 5, 12, 32, 4, 25, 32 }, 32, new[] { 5, 12, 4, 25 })]
        [TestCase(new[] { -12, 5, -12 }, -12, new[] { 5 })]
        [TestCase(new[] { 1, 2, 2, 2, 2, 1 }, 2, new[] { 1, 1 })]
        public void RemoveByValueAll_WhenArrayFilled_ShouldRemoveValue
            (int[] sourceArray, int value, int[] expectedArray)
        {
            var myList = new MyArrayList(sourceArray);

            myList.RemoveByValueAll(value);

            CollectionAssert.AreEqual(expectedArray, myList.ToArray());
        }

        [Test]
        public void RemoveByValueAll_WhenArrayHaveOnlyIdenticalElements_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                IMyList myList = new MyArrayList(new[] { 69, 69, 69, 69, 69, 69, 69, 69, 69, 69, 69, 69, 69, });
                myList.RemoveByValueAll(69);
            });
        }
        
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 }, new[] { 5, 4, 3, 2, 1, 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 1 }, new[] { -1 }, new[] { -1, 1 })]
        [TestCase(new int[0], new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 234, -12, 0, 1, 69 }, new int[0], new[] { 234, -12, 0, 1, 69 })]
        public void AddFrontIEnumerable_ArrayAreFilled_ShouldReturnArrayWithAdditionalElements
            (int[] sourceArray, int [] items, int [] expectedArray)
        {
            var myList = new MyArrayList(sourceArray);

            myList.AddFront(items);

            CollectionAssert.AreEqual(expectedArray, myList.ToArray());
        } 
        
        [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 }, new[] { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 })]
        [TestCase(new[] { 1 }, new[] { -1 }, new[] { 1 , -1})]
        [TestCase(new int[0], new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 })]
        [TestCase(new[] { 234, -12, 0, 1, 69 }, new int[0], new[] { 234, -12, 0, 1, 69 })]
        public void AddBackEnumerable_ArrayAreFilled_ShouldReturnArrayWithAdditionalElements
            (int[] sourceArray, int[] items, int[] expectedArray)
        {
            var myList = new MyArrayList(sourceArray);

            myList.AddBack(items);

            CollectionAssert.AreEqual(expectedArray, myList.ToArray());
        }
        
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, new[] { 5, 4, 3, 2, 1 }, new[] { 1, 5, 4, 3, 2, 1, 2, 3, 4, 5,  })]
        [TestCase(new[] { 1 }, 0, new[] { 222 }, new[] { 222, 1 })]
        [TestCase(new int[0], 0, new[] { 5, 4, 3, 2, 1 }, new[] { 5, 4, 3, 2, 1 })]
        [TestCase(new[] { 5, 4, 3, 2, 1 }, 0, new int[0], new[] { 5, 4, 3, 2, 1 })]
        public void AddByIndexIEnumerable_ArrayAreFilled_ShouldReturnArrayWithAdditionalElements
            (int[] sourceArray, int index, int[] items, int[] expectedArray)
        {
            var myList = new MyArrayList(sourceArray);

            myList.AddByIndex(index, items);

            CollectionAssert.AreEqual(expectedArray, myList.ToArray());
        }
    }
}