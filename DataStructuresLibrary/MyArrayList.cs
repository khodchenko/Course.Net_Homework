using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresLibrary
{
    public class MyArrayList : IMyList, IEnumerable<int>
    {
        private const int DefaultSize = 4;
        private const double Coef = 1.5;
        private int _count;
        private int[] _array;

        public int Capacity => _array.Length;
        public int Length => _count;

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return _array[index];
            }
            set => throw new NotImplementedException();
        }

        public MyArrayList() : this(DefaultSize)
        {
        }

        public MyArrayList(int size)
        {
            size = size > DefaultSize ? (int)(size * Coef) : DefaultSize;
            _array = new int[size];
        }

        public MyArrayList(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentException();
            }

            int size = array.Length > DefaultSize ? (int)(array.Length * Coef) : DefaultSize;
            _array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }

            _count = array.Length;
        }

        public void AddBack(int itemToAdd)
        {
            AddByIndex(_count, itemToAdd);
        }

        public int[] ToArray()
        {
            int[] result = new int[Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = _array[i];
            }

            return result;
        }

        public void AddFront(int itemToAdd)
        {
            AddByIndex(0, itemToAdd);
        }

        public void AddByIndex(int index, int itemToAdd)
        {
            if (index > Length)
            {
                throw new IndexOutOfRangeException();
            }

            int[] newArray = new int[(int)(_array.Length + 1)];

            for (int i = 0; i < index; i++)
            {
                newArray[i] = _array[i];
            }

            for (int i = index + 1; i < _count + 1; i++)
            {
                newArray[i] = _array[i - 1];
            }

            _count++;
            _array = newArray;
            _array[index] = itemToAdd;
        }

        public int RemoveBack()
        {
            if (Length < 2)
            {
                throw new ArgumentException();
            }

            RemoveByIndex(_count);
            return _array[_array.Length - 1];
        }

        public int RemoveFront()
        {
            RemoveByIndex(0);
            return _array[0];
        }

        public int RemoveByIndex(int index)
        {
            if (index > Length)
            {
                throw new IndexOutOfRangeException();
            }

            int[] newArray = new int[(int)(_array.Length)];

            for (int i = 0; i < index; i++)
            {
                newArray[i] = _array[i];
            }

            for (int i = index; i < _count; i++)
            {
                newArray[i] = _array[i + 1];
            }

            _count--;
            _array = newArray;

            return _array[index];
        }

        public int[] RemoveNValuesBack(int n)
        {
            RemoveNValuesByIndex(Length, n);
            return new int[n];
        }

        public int[] RemoveNValuesFront(int n)
        {
            RemoveNValuesByIndex(0, n);
            return new int[n];
        }

        public int[] RemoveNValuesByIndex(int index, int n)
        {
            if (n > Length)
            {
                throw new ArgumentException("You trying to delete more than you have!");
            }

            int[] newArray = new int[(int)(_array.Length)];
            int counter = 0;
            int[] deletedElements = new int[n];

            do
            {
                if (n > 0)
                {
                    deletedElements[counter] = _array[index];

                    for (int i = 0; i < index; i++)
                    {
                        newArray[i] = _array[i];
                    }

                    for (int i = index; i < _count; i++)
                    {
                        newArray[i] = _array[i + 1];
                    }

                    counter++;
                    _count--;
                    _array = newArray;
                }
            } while (counter < n);

            return deletedElements;
        }

        public int IndexOf(int element)
        {
            int result = -1;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == element)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        public void Reverse()
        {
            int counter = 1;
            int[] newArray = new int[_array.Length];

            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _array[_count - counter];
                counter++;
            }

            _array = newArray;
        }

        public int Max()
        {
            int maxIndex = 0;

            for (int i = 1; i < _count; i++)
            {
                if (_array[i] > _array[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return _array[maxIndex];
        }

        public int Min()
        {
            int minIndex = 0;

            for (int i = 1; i < _count; i++)
            {
                if (_array[i] < _array[minIndex])
                {
                    minIndex = i;
                }
            }

            return _array[minIndex];
        }

        public int MaxIndex()
        {
            int maxIndex = 0;

            for (int i = 1; i < _count; i++)
            {
                if (_array[i] > _array[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        public int MinIndex()
        {
            int minIndex = 0;

            for (int i = 1; i < _count; i++)
            {
                if (_array[i] < _array[minIndex])
                {
                    minIndex = i;
                }
            }

            return minIndex;
        }


        public void Sort(bool ascending = true)
        {
            int coef = ascending ? 1 : -1;

            for (int i = 0; i < _count - 1; i++)
            {
                for (int j = i + 1; j < _count; j++)
                {
                    if (_array[i].CompareTo(_array[j]) == coef)
                    {
                        Swap(ref _array[i], ref _array[j]);
                    }
                }
            }
        }

        public int RemoveByValue(int value)
        {
            if (Length <= 1)
            {
                throw new ArgumentException("Array is dont have enough elements to delete!");
            }

            int[] newArray = new int[_array.Length];
            int indexOfElement = -1;
            for (int i = 0; i < _count; i++)
            {
                if (_array[i] == value)
                {
                    indexOfElement = i;

                    for (int j = 0; j < indexOfElement; j++)
                    {
                        newArray[j] = _array[j];
                    }

                    for (int j = indexOfElement; j < _count; j++)
                    {
                        newArray[j] = _array[j + 1];
                    }

                    _array = newArray;
                    _count--;
                    break;
                }
            }

            return indexOfElement;
        }

        public int RemoveByValueAll(int value)
        {
            int[] newArray = new int[_array.Length];
            int indexOfElement;
            int countOfElements = 0;
            for (int i = 0; i < _count; i++)
            {
                if (_array[i] == value)
                {
                    indexOfElement = i;

                    for (int j = 0; j < indexOfElement; j++)
                    {
                        newArray[j] = _array[j];
                    }

                    for (int j = indexOfElement; j < _count; j++)
                    {
                        newArray[j] = _array[j + 1];
                    }

                    _array = newArray;
                    _count--;
                    i--;
                    countOfElements++;
                }
                else if (_array[0] == value)
                {
                    countOfElements++;
                    break;
                }
            }

            if (countOfElements == 0)
            {
                countOfElements = -1;
            }

            if (Length < 1)
            {
                throw new ArgumentException("Array have only identical elements!");
            }

            return countOfElements;
        }

        public void AddFront(IEnumerable<int> items)
        {
            int localCounter = 0;

            foreach (int item in items)
            {
                localCounter++;
                _count++;
            }

            int[] newArray = new int[_array.Length + localCounter];
            int i = 0;

            foreach (int item in items)
            {
                newArray[i++] = item;
            }

            foreach (int item in _array)
            {
                newArray[i++] = item;
            }

            _array = newArray;
        }

        public void AddBack(IEnumerable<int> items)
        {
            int localCount = 0;

            foreach (int item in items)
            {
                localCount++;
            }

            int[] newArray = new int[_array.Length + localCount];
            int i = 0;

            for (int j = 0; j < _count; j++)
            {
                newArray[j] = _array[j];
                i++;
            }

            foreach (int item in items)
            {
                newArray[i++] = item;
                _count++;
            }

            _array = newArray;
        }

        public void AddByIndex(int index, IEnumerable<int> items)
        {
            int localCount = 0;

            foreach (int item in items)
            {
                localCount++;
            }

            int[] newArray = new int[_array.Length + localCount];
            int i = 0;

            for (int j = 0; j < index; j++)
            {
                newArray[j] = _array[j];
                i++;
            }

            foreach (int item in items)
            {
                newArray[i++] = item;
                _count++;
            }

            for (int j = i; j < _count; j++)
            {
                newArray[j] = _array[index];
                index++;
            }

            _array = newArray;
        }


        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                yield return _array[i];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        private static (int, int) Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
            return (a, b);
        }
    }
}