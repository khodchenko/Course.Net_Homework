using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataStructuresLibrary
{
    public class MyLinkedList<T> : IMyList<T> where T : IComparable<T>
    {
        private int _size;
        private MyLinkedList<T> _linkedList;
        public int Length => _size;
        private MyNode<T> _head;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return GetNodeByIndex(index).Value;
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                GetNodeByIndex(index).Value = value;
            }
        }

        public MyLinkedList()
        {
        }

        public MyLinkedList(T element)
        {
            if (element == null)
            {
                throw new NullReferenceException();
            }

            if (element != null)
            {
                AddBack(element);
            }
        }

        public MyLinkedList(IEnumerable<T> elements)
        {
            if (elements == null)
            {
                throw new NullReferenceException();
            }

            foreach (var item in elements)
            {
                AddBack(item);
            }
        }

        public IMyList<T> CreateInstance(IEnumerable<T> items)
        {
            return new MyLinkedList<T>(items);
        }

        public IEnumerator<T> GetEnumerator()
        {
            MyNode<T> temp = _head;
            for (int i = 0; i < Length; i++)
            {
                yield return temp.Value;
                temp = temp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //todo test
        public int IndexOf(T element)
        {
            int result = -1;
            for (int i = 0; i < _linkedList.Length; i++)
            {
                if (_linkedList[i].Equals(element))
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
        
        //todo test
        public int MaxIndex()
        {
            if (Length == 0) throw new ArgumentException("Size is 0");

            int result = 0;

            for (int i = 1; i < Length; i++)
            {
                if (GetNodeByIndex(i).Value.CompareTo(GetNodeByIndex(result).Value) == 1)
                {
                    result = i;
                }
            }

            return result;
        }
        
        //todo test
        public int MinIndex()
        {
            if (Length == 0) throw new ArgumentException("Size is 0");

            int result = 0;

            for (int i = 1; i < Length; i++)
            {
                if (GetNodeByIndex(i).Value.CompareTo(GetNodeByIndex(result).Value) == -1)
                {
                    result = i;
                }
            }

            return result;
        }
        
        //todo test
        public T Max()
        {
            if (Length == 0) throw new ArgumentException("Size is 0");

            T result = GetNodeByIndex(0).Value;

            for (int i = 1; i < Length; i++)
            {
                if (GetNodeByIndex(i).Value.CompareTo(result) == 1)
                {
                    result = GetNodeByIndex(i).Value;
                }
            }

            return result;
        }
        
        //todo test
        public T Min()
        {
            if (Length == 0) throw new ArgumentException("Size is 0");

            T result = GetNodeByIndex(0).Value;

            for (int i = 1; i < Length; i++)
            {
                if (GetNodeByIndex(i).Value.CompareTo(result) == -1)
                {
                    result = GetNodeByIndex(i).Value;
                }
            }

            return result;
        }
        
        //todo test
        public void AddBack(T element)
        {
            if (_head != null)
            {
                GetNodeByIndex(Length - 1).Next = new MyNode<T> { Value = element };
            }
            else
            {
                _head = new MyNode<T> { Value = element };
            }

            ++_size;
        }

        public void AddFront(T itemToAdd)
        {
            if (_head == null)
            {
                //todo test this 
                _head = new MyNode<T> { Value = itemToAdd, Next = _head };
            }
            else
            {
                _head = new MyNode<T> { Value = itemToAdd };
            }

            _size++;
        }

        //todo test
        public void AddByIndex(int index, T itemToAdd)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (_head != null)
            {
                GetNodeByIndex(index - 1).Next = new MyNode<T> { Value = itemToAdd, Next = GetNodeByIndex(index) };
            }
            else
            {
                _head = new MyNode<T> { Value = itemToAdd };
            }

            ++_size;
        }

        //todo test
        public void AddBack(IEnumerable<T> items)
        {
            int itemIndex = 0;

            foreach (var item in items)
            {
                if (_head != null)
                {
                    GetNodeByIndex(Length - 1).Next = new MyNode<T> { Value = item };
                }
                else
                {
                    _head = new MyNode<T> { Value = item };
                }

                itemIndex++;
                ++_size;
            }
        }

        //todo test
        public void AddFront(IEnumerable<T> items)
        {
            AddByIndex(0, items);
        }

        //todo test
        public void AddByIndex(int pos, IEnumerable<T> items)
        {
            if (pos < 0 || pos > Length)
            {
                throw new ArgumentException("Position should be less than count and more than zero");
            }

            int itemsCount = 0;

            foreach (var item in items)
            {
                itemsCount++;
            }

            if (itemsCount != 0)
            {
                MyNode<T> change = GetNodeByIndex(pos);

                foreach (var item in items)
                {
                    if (_head != null && pos > 0)
                    {
                        GetNodeByIndex(pos - 1).Next = new MyNode<T> { Value = item };
                    }
                    else
                    {
                        _head = new MyNode<T> { Value = item };
                    }

                    pos++;
                    ++_size;
                }

                GetNodeByIndex(pos - 1).Next = change;
            }
        }

        //todo test
        public int Remove(T item)
        {
            int result = -1;

            if (item == null)
            {
                throw new NullReferenceException();
            }

            if (Length == 0)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < Length; i++)
            {
                if (GetNodeByIndex(i).Value.Equals(item))
                {
                    GetNodeByIndex(i - 1).Next = GetNodeByIndex(i + 1);
                    result = i;
                    _size--;
                    break;
                }
            }

            return result;
        }

        //todo test
        public T Remove(MyNode<T> myNode)
        {
            if (_head == null)
                return myNode.Value;

            if (_head == myNode)
            {
                _head = _head.Next;
                myNode.Next = null;
                return myNode.Value;
            }

            var current = _head;
            while (current.Next != null)
            {
                if (current.Next == myNode)
                {
                    current.Next = myNode.Next;
                    return myNode.Value;
                }

                current = current.Next;
            }

            _size--;
            return myNode.Value;
        }
        
        //todo test
        public int RemoveByValueAll(T value)
        {
            if (value == null) throw new NullReferenceException();

            if (Length == 0) throw new ArgumentException();

            int result = 0;

            for (int i = 0; i < Length; i++)
            {
                if (GetNodeByIndex(i).Value.Equals(value))
                {
                    GetNodeByIndex(i - 1).Next = GetNodeByIndex(i + 1);
                    i--;
                    _size--;
                }
            }

            return result;
        }

        //todo test
        public T RemoveByIndex(int index)
        {
            if (Length == 0) throw new ArgumentException("Size is 0");

            if (index < 0 || index >= Length) throw new ArgumentException("Wrong index");

            GetNodeByIndex(index - 1).Next = GetNodeByIndex(index + 1);
            --_size;

            return GetNodeByIndex(index).Value;
        }

        //todo test
        public T[] RemoveNValuesByIndex(int index, int n)
        {
            var array = new T[n];
            if (Length == 0) throw new ArgumentException("Size is 0");

            if (Length < n + index || index < 0) throw new ArgumentException("Wrong index setted");

            GetNodeByIndex(index - 1).Next = GetNodeByIndex(index + n);
            _size -= n;
            _linkedList.CopyToArray(array, index, n);
            return array;
        }
        
        //todo test
        public T RemoveBack()
        {
            if (Length == 0) throw new ArgumentException("Size is 0");
            _size--;
            var deleted = GetNodeByIndex(Length - 1).Value;
            GetNodeByIndex(Length - 1).Next = null;
            return deleted;
        }
        
        //todo test
        public T[] RemoveNValuesBack(int n)
        {
            if (Length < n) throw new ArgumentException("Size is 0");
            
            //todo fix this
            var deletedElements = Array.Empty<T>();
            GetNodeByIndex(Length - n - 1).Next = null;
            _size -= n;
            return deletedElements;
        }
        
        //todo test
        public T RemoveFront()
        {
            if (Length == 0) throw new ArgumentException("Size is 0");

            var deletedElement = GetNodeByIndex(0).Value;
            _head = GetNodeByIndex(1);
            _size--;
            return deletedElement;
        }
        
        //todo test
        public T[] RemoveNValuesFront(int n)
        {
            if (Length == 0) throw new ArgumentException("Size is 0");
            //todo fix
            var deletedElements = Array.Empty<T>();
            _head = GetNodeByIndex(n);
            _size -= n;
            return deletedElements;
        }

        //TODO TEST
        public bool Contains(T searchedItem)
        {
            for (int j = 0; j < _size; j++)
            {
                if (GetNodeByIndex(j).Value.CompareTo(searchedItem) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        //TODO TEST
        public MyNode<T> Find(T item)
        {
            if (_linkedList.Contains(item))
            {
                throw new NotImplementedException();
            }

            return _head;
        }

        //TODO TEST
        public MyNode<T> FindLast(T item)
        {
            foreach (var i in _linkedList)
            {
                throw new NotImplementedException();
            }

            return _head;
        }

        //TODO TEST
        public void CopyToArray(T[] array, int fromIndex = 0, int toIndex = 0)
        {
            for (int i = fromIndex; i < toIndex; i++)
            {
                throw new NotImplementedException();
            }
        }
        
        public void Reverse()
        {
            throw new NotImplementedException();
        }

        public void Sort(bool ascending = true)
        {
            throw new NotImplementedException();
        }

        public int RemoveByValue(T value)
        {
            throw new NotImplementedException();
        }

        public void ReverseRecursive()
        {
            reverseRecursive(_head, null);
        }

        private void reverseRecursive(MyNode<T> current, MyNode<T> prev)
        {
            if (current.Next == null)
            {
                _head = current;
                _head.Next = prev;
                return;
            }

            var next = current.Next;
            current.Next = prev;
            reverseRecursive(next, current);
        }
        
        //TODO TEST
        public void AddAfter(MyNode<T> myNodeA, MyNode<T> myNodeB)
        {
            myNodeB.Next = _linkedList.Find(myNodeA.Value);
            _linkedList.Find(myNodeA.Value).Next = myNodeB;
            _size++;
        }

        //TODO IMPLEMENT
        public void AddBefore(MyNode<T> myNodeA, MyNode<T> myNodeB)
        {
            _size++;
            throw new NotImplementedException();
        }
        
        private MyNode<T> GetNodeByIndex(int index)
        {
            MyNode<T> temp = _head;

            if (index < 0)
            {
                temp = new MyNode<T>();
            }

            for (int i = 0; i < index; i++)
            {
                temp = temp.Next;
            }

            return temp;
        }
        
        private void Swap(int i, int j)
        {
            T temp = GetNodeByIndex(i).Value;
            GetNodeByIndex(i).Value = GetNodeByIndex(j).Value;
            GetNodeByIndex(j).Value = temp;
        }
    }

    public class MyNode<T>
    {
        public T Value { get; set; }
        public MyNode<T> Next { get; set; }
    }
}