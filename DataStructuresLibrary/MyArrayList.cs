using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresLibrary
{
    public class MyArrayList<T> : IMyList<T> where T : IComparable<T>
    {
        private const int DefaultSize = 4;
        private const double Coef = 1.5;
        private int _count;
        private T[] _array;

        public int Capacity => _array.Length;

        public int Length => _count;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return _array[index];
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                _array[index] = value;
            }
        }

        public MyArrayList() : this(DefaultSize)
        {
        }

        private MyArrayList(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException();
            }

            size = size > DefaultSize ? (int)(size * Coef) : DefaultSize;
            _array = new T[size];
        }


        public MyArrayList(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentException();
            }

            var size = array.Length > DefaultSize ? (int)(array.Length * Coef) : DefaultSize;
            _array = new T[size];

            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }

            _count = array.Length;
        }


        public T[] ToArray()
        {
            var result = new T[Length];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = _array[i];
            }

            return result;
        }

        public void AddFront(T itemToAdd)
        {
            AddByIndex(0, itemToAdd);
        }

        public void AddByIndex(int index, T itemToAdd)
        {
            ResizeArray();
            
            T[] newArray = new T[_array.Length];

            for (int i = 0; i < index; i++)
            {
                newArray[i] = _array[i];
            }
            
            _array[index] = itemToAdd;

            for (int i = index + 1; i < _count + 1; i++)
            {
                newArray[i] = _array[i - 1];
            }

            _count++;
            _array = newArray;
        }

        public T RemoveBack()
        {
            RemoveByIndex(_count);
            return _array[_array.Length - 1];
        }

        public T RemoveFront()
        {
            RemoveByIndex(0);
            return _array[0];
        }

        public T RemoveByIndex(int index)
        {
            ResizeArray();

            T[] newArray = new T[_array.Length];

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


        public void AddBack(T itemToAdd)
        {
            AddByIndex(_count, itemToAdd);
        }

        public T[] RemoveNValuesBack(int n)
        {
            RemoveNValuesByIndex(Length, n);
            return new T[n];
        }

        public T[] RemoveNValuesFront(int n)
        {
            RemoveNValuesByIndex(0, n);
            return new T[n];
        }

        public T[] RemoveNValuesByIndex(int index, int n)
        {
            ResizeArray();

            T[] newArray = new T[_array.Length];
            int counter = 0;
            T[] deletedElements = new T[n];

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

        public int IndexOf(T element)
        {
            int result = -1;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].Equals(element))
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
            T[] newArray = new T[_array.Length];

            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _array[_count - counter];
                counter++;
            }

            _array = newArray;
        }

        public T Max()
        {
            int maxIndex = 0;

            for (int i = 1; i < _count; i++)
            {
                if (_array[i].CompareTo(_array[maxIndex]) == 1)
                {
                    maxIndex = i;
                }
            }

            return _array[maxIndex];
        }

        public T Min()
        {
            int minIndex = 0;

            for (int i = 1; i < _count; i++)
            {
                if (_array[i].CompareTo(_array[minIndex]) == -1)
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
                if (_array[i].CompareTo(_array[maxIndex]) == 1)
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
                if (_array[i].CompareTo(_array[minIndex]) == -1)
                {
                    minIndex = i;
                }
            }

            return minIndex;
        }


        public void Sort(bool ascending = true)
        {
            var coef = ascending ? 1 : -1;

            for (var i = 0; i < _count - 1; i++)
            {
                for (var j = i + 1; j < _count; j++)
                {
                    if (_array[i].CompareTo(_array[j]) == coef)
                    {
                        Swap(ref _array[i], ref _array[j]);
                    }
                }
            }
        }


        public int RemoveByValue(T value)
        {
            ResizeArray();

            T[] newArray = new T[_array.Length];
            int indexOfElement = -1;
            
            for (int i = 0; i < _count; i++)
            {
                if (_array[i].CompareTo(value) == 0)
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

        public int RemoveByValueAll(T value)
        {
            T[] newArray = new T[_array.Length];
            int countOfElements = 0;
            for (int i = 0; i < _count; i++)
            {
                if (_array[i].CompareTo(value) == 0)
                {
                    var indexOfElement = i;

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
                else if (_array[i].CompareTo(value) == 0)
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

        public void AddFront(IEnumerable<T> items)
        {
            AddByIndex(0, items);
        }

        public void AddBack(IEnumerable<T> items)
        {
            AddByIndex(_count, items);
        }

        public void AddByIndex(int index, IEnumerable<T> items)
        {
            int localCount = 0;

            foreach (T item in items)
            {
                localCount++;
            }

            T[] newArray = new T[_array.Length + localCount];
            var i = 0;

            for (int j = 0; j < index; j++)
            {
                newArray[j] = _array[j];
                i++;
            }

            foreach (T item in items)
            {
                newArray[i++] = item;
                _count++;
            }

            for (var j = i; j < _count; j++)
            {
                newArray[j] = _array[index];
                index++;
            }

            _array = newArray;
        }


        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _array[i];
            }
        }


        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        private static (T, T) Swap(ref T a, ref T b)
        {
            (a, b) = (b, a);
            return (a, b);
        }
        
        private void ResizeArray()
        {
            if (Capacity != Length) return;
            var newArray = new T[(int)(_array.Length * Coef)];
            for (var i = 0; i < _array.Length; i++)
            {
                newArray[i] = _array[i];
            }

            _array = newArray;
        }
    }
}