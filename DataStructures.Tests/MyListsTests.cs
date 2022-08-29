using System;
using System.Collections.Generic;
using NUnit.Framework;
using DataStructuresLibrary;

namespace DataStructures.Tests
{
    [TestFixture(typeof(MyArrayList<int>))]
    [TestFixture(typeof(MyLinkedList<int>))]
    public class MyArrayListTests<T> where T : IMyList<int>, new()
    {
        IMyList<int> _list;
        IMyList<string> _listStrings;
        
        [SetUp]
        public void Setup()
        {
            _list = new T();
            _listStrings = new T() as IMyList<string>;
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 3 })]
        public void Add_WhenAny_ShouldAddItemToEnd(int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.AddBack(3);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 3, 1, 2 })]
        [TestCase(new int[] { }, new int[] { 3 })]
        public void AddFront_WhenAny_ShouldAddFront(int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.AddFront(3);

           Assert.AreEqual(instance.Count, expectedArray.Length);
            //CollectionAssert.AreEqual(expectedArray, instance);
        }
        
        private static readonly object[] AddByIndex_1 = { new object[] { new int[] { 1, 2 }, 1, new int[] { 1, 3, 2 } } };
        private static readonly object[] AddByIndex_2 = { new object[] { new int[] { 1, 2 }, 2, new int[] { 1, 2, 3 } } };
        [TestCaseSource(nameof(AddByIndex_1))]
        [TestCaseSource(nameof(AddByIndex_2))]
        [TestCase(new int[] { }, 0, new int[] { 3 })]
        public void AddByIndex_WhenIndexIsNotLessZeroOrIndexMoreThenSize_WhenAny_ShouldAddFront(int[] sourceArray, int index, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.AddByIndex(index, 3);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }
        
        [TestCase(-1)]
        [TestCase(1)]
        public void AddByIndex_WhenIndexLessZeroOfIndexMoreThenSize_ShouldThrowArgumentOutOfRangeException(int pos)
        {
            try
            {
                _list.AddByIndex(pos, 0);
            }
            catch (IndexOutOfRangeException)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        private static readonly object[] AddMany_1 = { new object[] { new int[] { 1, 2, 3 }, new List<int> { 4, 5 }, new int[] { 1, 2, 3, 4, 5 } } };
        private static readonly object[] AddMany_2 = { new object[] { new int[] { }, new List<int> { 1, 2, 3 }, new int[] { 1, 2, 3 } } };
        [TestCaseSource(nameof(AddMany_1))]
        [TestCaseSource(nameof(AddMany_2))]
        public void AddMany_WhenAny_ShouldAddItemsToEnd(int[] sourceArray, IEnumerable<int> additionalList, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.AddBack(additionalList);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        private static readonly object[] AddFrontMany_1 = { new object[] { new int[] { 1, 2, 3 }, new List<int> { 4, 5 }, new int[] { 4, 5, 1, 2, 3 } } };
        private static readonly object[] AddFrontMany_2 = { new object[] { new int[0], new List<int> { 1, 2, 3 }, new int[] { 1, 2, 3 } } };
        [TestCaseSource("AddFrontMany_1")]
        [TestCaseSource("AddFrontMany_2")]
        public void AddManyFront_WhenAny_ShouldAddItemsToFront(int[] sourceArray, IEnumerable<int> additionalList, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.AddFront(additionalList);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }
        
        private static readonly object[] AddManyFromIndex_1 = { new object[] { new int[0], 0, new List<int> { 1, 2, 3 }, new int[] { 1, 2, 3 } } };
        private static readonly object[] AddManyFromIndex_2 = { new object[] { new int[] { 1, 2, 3 }, 3, new List<int> { 4, 5 }, new int[] { 1, 2, 3, 4, 5 } } };
        private static readonly object[] AddManyFromIndex_3 = { new object[] { new int[] { 1, 2, 3 }, 2, new List<int> { 9, 8, 7 }, new int[] { 1, 2, 9, 8, 7, 3 } } };
        private static readonly object[] AddManyFromIndex_4 = { new object[] { new int[0], 0, new List<int> { }, new int[] { } } };
        private static readonly object[] AddManyFromIndex_5 = { new object[] { new int[] { 1, 2, 3 }, 0, new List<int>(), new int[] { 1, 2, 3 } } };
        [TestCaseSource(nameof(AddManyFromIndex_1))]
        [TestCaseSource(nameof(AddManyFromIndex_2))]
        [TestCaseSource(nameof(AddManyFromIndex_3))]
        [TestCaseSource(nameof(AddManyFromIndex_4))]
        [TestCaseSource(nameof(AddManyFromIndex_5))]
        public void AddManyFromIndex_WhenAny_ShouldAddItemsToFront(int[] sourceArray, int index, IEnumerable<int> additionalList, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.AddByIndex(index, additionalList);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void AddManyByIndex_WhenIndexLessZeroOfIndexMoreThenSize_ShouldThrowArgumentOutOfRangeException(int pos)
        {
            try
            {
                _list.AddByIndex(pos, new List<int>());
            }
            catch (IndexOutOfRangeException)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }
        
        //Constructor tests 
        [Test]
        public void CreateEmptyIMyList_WhenAny_ShpuldCreateIMyListWithCountIsZero()
        {
            Assert.AreEqual(_list.Count, 0);
            foreach (int item in _list)
            {
                Assert.AreEqual(item, 0);
            }
        }
        
        [Test]
        public void CreateIMyListFromOneElemeent_WhenElementIsNotNull_ShpuldCreateIMyListWithCountIsOne()
        {
            _list = (IMyList<int>)Activator.CreateInstance(typeof(T), 1);

            Assert.AreEqual(_list.Count, 1);
            foreach (int item in _list)
            {
                Assert.AreEqual(item, 1);
            }
        }
        
        [TestCase(new int[] { 1, 2, 4, 5, 6, 7, 8, 9 })]
        [TestCase(new int[] { 1 })]
        public void CreateIMyListFromOtherIMyList_WhenAny_ShouldCreateTheSameList(int[] expeectedResult)
        {
            _list = (IMyList<int>)Activator.CreateInstance(typeof(T), expeectedResult);

            Assert.AreEqual(_list.Count, expeectedResult.Length);
            for (int i = 0; i < _list.Count; i++)
            {
                Assert.AreEqual(_list[i], expeectedResult[i]);
            }
        }
        
        //Remove Methods Tests
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 0 }, new int[0])]
        public void RemoveBack_WhenSizeIsBiggerZero_ShouldRemoveLastItem(int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.RemoveBack();

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 0 }, new int[0])]
        public void RemoveFront_WhenSizeIsBiggerZero_ShouldRemoveFirsttItem(int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.RemoveFront();

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 1, 3 })]
        [TestCase(new int[] { 0 }, 0, new int[0])]

        public void RemoveAt_WhenSizeAndIndexIsBiggerZeroAndIndexIsLessSize_ShouldRemoveItemByIndex(int[] sourceArray, int index, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.RemoveByIndex(index);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void RemoveAt_WhenIndexLessZeroOrBiggerThanSize_ShouldThrowArgumentException(int index)
        {
            try
            {
                var instance = _list.CreateInstance(new int[] { 0 });

                instance.RemoveByIndex(index);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Wrong index", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 1, 2 })]
        [TestCase(new int[] { 0 }, 1, new int[0])]
        public void RemoveManyBack_WhenSizeIsBiggerThanQuantity_ShouldRemoveLastPointedItems(int[] sourceArray, int quantity, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.RemoveNValuesBack(quantity);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [Test]
        public void RemoveManyBack_WhenSizeIsNotBiggerThanQuantity_ShouldThrowArgumentException()
        {
            try
            {
                var instance = _list.CreateInstance(new int[] { 1 });

                _list.RemoveNValuesBack(2);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Size is 0", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 3, 4 })]
        [TestCase(new int[] { 0 }, 1, new int[0])]
        public void RemoveManyFront_WhenSizeIsBiggerThanQuantity_ShouldRemoveFromStartPointedItems(int[] sourceArray, int quantity, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.RemoveNValuesFront(quantity);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [Test]
        public void RemoveManyFront_WhenSizeIsNotBiggerThanQuantity_ShouldThrowArgumentException()
        {
            try
            {
                var instance = _list.CreateInstance(new int[] { 1 });

                _list.RemoveNValuesFront(2);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Size is 0", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 1, 2, new int[] { 1, 4 })]
        [TestCase(new int[] { 2 }, 0, 1, new int[0])]
        public void RemoveManyAt_WhenSizeIsNotBiggerThanQuantityAndIndexIsLessSize_ShouldRemoveQuantityOfItemsStartFromIndex(int[] sourceArray, int index, int quantity, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.RemoveNValuesByIndex(index, quantity);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void RemoveManyAt_WhenIndexLessZeroOrBiggerThanSize_ShouldThrowArgumentException(int index)
        {
            try
            {
                var instance = _list.CreateInstance(new int[] { 1 });

                instance.RemoveNValuesByIndex(index, 1);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Wrong index setted", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 2 }, 2, new int[0])]
        public void Remove_WhenElementIsNotNullAndSizeIsNotZero_ShouldRemovePointedElement(int[] sourceArray, int elemeent, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.RemoveByValue(elemeent);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [Test]
        public void Remove_WhenSizeIsZero_ShouldThrowArgumentException()
        {
            try
            {
                _list.RemoveByValue(0);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Size is 0", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 2 }, 2, new int[] { 1, 3 })]
        [TestCase(new int[] { 2, 2, 2 }, 2, new int[0])]
        public void RemoveAll_WhenElementIsNotNullAndSizeIsNotZero_ShouldRemovePointedElement(int[] sourceArray, int elemeent, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.RemoveByValueAll(elemeent);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [Test]
        public void RemoveAll_WhenSizeIsZero_ShouldThrowArgumentException()
        {
            try
            {
                _list.RemoveByValueAll(0);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Size is 0", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }
        
        //Remove String Method Tests
        [Test]
        public void Remove_WhenElementIsNull_ShouldThrowArgumentNullException()
        {
            try
            {
                var array = new MyArrayList<string>();
                var insetance = _listStrings.CreateInstance(array);

                insetance.RemoveByValue(null);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Item can't be null", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public void RemoveAll_WhenElementIsNull_ShouldThrowArgumentNullException()
        {
            try
            {
                _listStrings.RemoveByValue(null);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Item can't be null", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }
        
        //Search And Sort Methods Tests
         [TestCase(new int[] { 1, 2, 3, 2 }, 1, 99, new int[] { 1, 99, 3, 2 })]
        [TestCase(new int[] { 2 }, 0, 99, new int[] { 99 })]
        public void SetItemByIndex_WhenIndexMoreZeroAndLessThenSize_ShouldChengeItemByIndex(int[] sourceArray, int index, int element, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance[index] = element;

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void SetItemByIndex_WhenIndexIsZeroOrMoreThenSize_ShouldThrowArgumentException(int index)
        {
            try
            {
                var instance = _list.CreateInstance(new int[] { 1 });

                _list[index] = 2;
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Index should be less than count and more than zero", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 2 }, 1, 2)]
        [TestCase(new int[] { 2 }, 0, 2)]
        public void GetItemByIndex_WhenIndexMoreZeroAndLessThenSize_ShouldReturnItemByIndex(int[] sourceArray, int index, int expectedResult)
        {
            var instance = _list.CreateInstance(sourceArray);

            int actualResult = instance[index];

            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestCase(-1)]
        [TestCase(1)]
        public void GetItemByIndex_WhenIndexIsZeroOrMoreThenSize_ShouldThrowArgumentException(int index)
        {
            try
            {
                var instance = _list.CreateInstance(new int[] { 1 });

                int item = _list[index];
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Index should be less than count and more than zero", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3, 2 }, 2, 1)]
        [TestCase(new int[] { 2, 2, 2 }, 2, 0)]
        public void IndexOfItem_WhenItemIsNotNullAndItemExist_ShouldReturnIndex(int[] sourceArray, int element, int expectedResult)
        {
            var instance = _list.CreateInstance(sourceArray);

            int actualResult = instance.IndexOf(element);

            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestCase(new int[] { 2, 5, 4, 3 }, 5)]
        [TestCase(new int[] { 2 }, 2)]
        public void MaxItem_WhenSizeIsNotZero_ShouldReturnMaxItemValue(int[] sourceArray, int expectedResult)
        {
            var instance = _list.CreateInstance(sourceArray);
            int actualResult = instance.Max();
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void MaxItem_WhenSizeIsZero_ShouldThrowArgumentException()
        {
            try
            {
                _list.Max();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Size is 0", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 2, 5, 4, 3 }, 2)]
        [TestCase(new int[] { 2 }, 2)]
        public void MinItem_WhenSizeIsNotZero_ShouldReturnMaxItemValue(int[] sourceArray, int expectedResult)
        {
            var instance = _list.CreateInstance(sourceArray);

            int actualResult = instance.Min();

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void MinItem_WhenSizeIsZero_ShouldThrowArgumentException()
        {
            try
            {
                _list.Min();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Size is 0", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 2, 5, 4, 3 }, 1)]
        [TestCase(new int[] { 2 }, 0)]
        public void IndexOfMaxItem_WhenSizeIsNotZero_ShouldReturnMaxItemValue(int[] sourceArray, int expectedResult)
        {
            var instance = _list.CreateInstance(sourceArray);

            int actualResult = instance.MaxIndex();

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void IndexOfMaxItem_WhenSizeIsZero_ShouldThrowArgumentException()
        {
            try
            {
                _list.MaxIndex();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Size is 0", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 2, 5, 4, 3 }, 0)]
        [TestCase(new int[] { 2 }, 0)]
        public void IndexOfMinItem_WhenSizeIsNotZero_ShouldReturnMaxItemValue(int[] sourceArray, int expectedResult)
        {
            var instance = _list.CreateInstance(sourceArray);

            int actualResult = instance.MinIndex();

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void IndexOfMinItem_WhenSizeIsZero_ShouldThrowArgumentException()
        {
            try
            {
                _list.MinIndex();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Size is 0", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 2, 5, 4, 3 }, new int[] { 5, 4, 3, 2 })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        public void SortByDesc_WhenAny_ShouldSortByDesc(int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.Sort(false);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new int[] { 2, 5, 4, 3 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        public void SortByAsc_WhenAny_ShouldSortByDesc(int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.Sort(true);

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }

        [TestCase(new int[] { 2, 5, 4, 3 }, new int[] { 3, 4, 5, 2 })]
        [TestCase(new int[] { 2 }, new int[] { 2 })]
        public void Reverse_WhenAny_ShouldReverseItems(int[] sourceArray, int[] expectedArray)
        {
            var instance = _list.CreateInstance(sourceArray);

            instance.Reverse();

            Assert.AreEqual(instance.Count, expectedArray.Length);
            CollectionAssert.AreEqual(expectedArray, instance);
        }
    }
}