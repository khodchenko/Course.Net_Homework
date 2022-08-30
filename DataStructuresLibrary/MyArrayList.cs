using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace DataStructuresLibrary
{
    public class MyArrayList<T> : IMyList<T> where T : IComparable<T>
    {
        private const int DefaultSize = 4;
        private const double Coef = 1.33;
        private int _size;
        private T[] _array;

        public int Capacity => _array.Length;

        public int Count => _size;

        public T this[int index]
        {
            get
            {

                if (index >= Count || index < 0)
                {
                    throw new ArgumentException("Index should be less than count and more than zero");
                }

                return _array[index];
            }
            
            set
            {

                if (index >= Count || index < 0)
                {
                    throw new ArgumentException("Index should be less than count and more than zero");

                }

                _array[index] = value;
            }
        }


        public MyArrayList()
        {
            _array = new T[DefaultSize];
        }

        private MyArrayList(T element)
        {
            if (element == null)
            {
                throw new ArgumentException("Element can't be null");
            }
            
            _array = new T[DefaultSize];
            AddBack(element);
        }

        private MyArrayList(IEnumerable<T> items)
        {
            if (items == null)
            {
                throw new ArgumentException("Elements can't be null");
            }

            T[] tempArr = items.ToArray();
            _array = new T[DefaultSize];
            ResizeArray(tempArr.Length);
            _size += tempArr.Length;

            for (int i = 0; i < tempArr.Length; i++)
            {
                _array[i] = tempArr[i];
            }
        }
        
        public IMyList<T> CreateInstance(IEnumerable<T> items)
        {
            return new MyArrayList<T>(items);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddBack(T itemToAdd)
        {
            AddByIndex(_size, itemToAdd);
        }
        
        
        public void AddFront(T itemToAdd)
        {
            AddByIndex(0, itemToAdd);
        }


        public void AddFront(IEnumerable<T> items)
        {
            AddByIndex(0, items);
        }
        
        public void AddByIndex(int index, T itemToAdd)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();

            if (Capacity == _array.Length)
            {
                ResizeArray(Count + 1);
            }

            if (Count > 0 && index < Capacity)
            {
                for (int i = Count; i > index; i--)
                {
                    _array[i] = _array[i - 1];
                }
            }

            _array[index] = itemToAdd;
            _size++;
        }

        public void AddByIndex(int index, IEnumerable<T> items)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException();
            
            
            int itemsCount = items.ToArray().Count();

            if (itemsCount > 0)
            {
                var newSize = Count + itemsCount;

                if (newSize >= _array.Length)
                {
                    ResizeArray(newSize);
                }

                for (int i = Count - 1; i >= index; i--)
                {
                    _array[i + itemsCount] = _array[i];
                }

                foreach (T item in items)
                {
                    _array[index++] = item;
                }

                _size = newSize;
            }
        }
        
        public T RemoveBack()
        {
            RemoveByIndex(_size);

            return _array[_array.Length - 1];
        }

        public T RemoveFront()
        {
            RemoveByIndex(0);
            return _array[0];
        }

        public T RemoveByIndex(int index)
        {

            if (index < 0 || index >= Count) throw new ArgumentException("Wrong index");
            
            _size--;

            T[] newArray = new T[_array.Length];

            for (int i = 0; i < index; i++)
            {
                newArray[i] = _array[i];
            }

            for (int i = index; i < _size; i++)
            {
                newArray[i] = _array[i + 1];
            }

            _size--;
            _array = newArray;

            return _array[index];
        }


        public T[] RemoveNValuesBack(int n)
        {
            if (Count < n) throw new ArgumentException("Size is 0");
            
            RemoveNValuesByIndex(Count, n);

            return new T[n];
        }

        public T[] RemoveNValuesFront(int n)
        {

            if (Count < n) throw new ArgumentException("Size is 0");

            RemoveNValuesByIndex(0, n);
            return new T[n];
        }

        public T[] RemoveNValuesByIndex(int index, int n)
        {

            if (Count < n + index || index < 0) throw new ArgumentException("Wrong index setted");

            ResizeArray(Count + 1);

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


                    for (int i = index; i < _size; i++)
                    {
                        newArray[i] = _array[i + 1];
                    }

                    counter++;
                    _size--;
                    _array = newArray;
                }
            } while (counter < n);

            return deletedElements;
        }

        public int IndexOf(T element)
        {
            if (element == null)
            {
                throw new ArgumentException("Item can't be null");
            }
            
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


            for (int i = 0; i < _size; i++)
            {
                newArray[i] = _array[_size - counter];
                counter++;
            }

            _array = newArray;
        }

        public T Max()
        {
            if (Count == 0) throw new ArgumentException("Size is 0");
            
            int maxIndex = 0;
            
            for (int i = 1; i < _size; i++)

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
            if (Count == 0) throw new ArgumentException("Size is 0");
            
            int minIndex = 0;

            for (int i = 1; i < _size; i++)

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
            if (Count == 0) throw new ArgumentException("Size is 0");
            
            int maxIndex = 0;

            for (int i = 1; i < _size; i++)
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
            if (Count == 0) throw new ArgumentException("Size is 0");
            
            int minIndex = 0;

            for (int i = 1; i < _size; i++)
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

            for (var i = 0; i < _size - 1; i++)
            {
                for (var j = i + 1; j < _size; j++)
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
            int indexOfElement = -1;
            
            if (value == null)
            {
                throw new ArgumentException("Item can't be null");
            }
            
            if (value == null) throw new ArgumentException("Item can't be null");

            if (Count == 0) throw new ArgumentException("Size is 0");

            for (int i = 0; i < Count; i++)
            {
                if (_array[i].Equals(value))
                {
                    RemoveByIndex(i);
                    indexOfElement = i;
                    break;
                }
            }

            return indexOfElement;
        }

        public int RemoveByValueAll(T value)
        {
            if (value == null) throw new ArgumentException("Item can't be null");

            if (Count == 0) throw new ArgumentException("Size is 0");

            int result = 0;

            for (int i = 0; i < Count; i++)
            {
                if (_array[i].Equals(value))
                {
                    RemoveByIndex(i--);
                    result++;
                }
            }

            return result;
        }
        
        public void AddBack(IEnumerable<T> items)
        {
            AddByIndex(_size, items);
        }

       
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _array[i];
            }
        }
        
        private static (T, T) Swap(ref T a, ref T b)
        {
            (a, b) = (b, a);
            return (a, b);
        }

        private void ResizeArray(int min)
        {
            if (min < Count) throw new ArgumentException("Capacity shouldn't be resized!");

            if (_array.Length < min)
            {
                int newCapacity = (int)(_array.Length * Coef);

                if (newCapacity < min)
                {
                    newCapacity = min;
                }

                T[] newItems = new T[newCapacity];

                if (Count > 0)
                {
                    Array.Copy(_array, newItems, Count);
                }

                _array = newItems;
            }
        }
    }
}