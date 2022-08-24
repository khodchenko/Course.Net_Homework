using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DataStructuresLibrary
{
    public class MyLinkedList<T> : IMyList<T> where T : IComparable<T>
    {
        private int _count;
        private MyLinkedList<T> _linkedList;
        public int Length => _count;
        private Node<T> _head = null;
        
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return _linkedList[index];
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                _linkedList[index] = value;
            }
        }

         public int IndexOf(T element)
        {
            throw new NotImplementedException();
        }
         
        public void AddByIndex(int index, T itemToAdd)
        {
            throw new NotImplementedException();
        }

        public T[] RemoveNValuesByIndex(int index, int n)
        {
            throw new NotImplementedException();
        }

        //TODO TEST
        public void AddAfter(Node<T> nodeA, Node<T> nodeB)
        {
            nodeB.Next = _linkedList.Find(nodeA.Value);
            _linkedList.Find(nodeA.Value).Next = nodeB;
            _count++;
        }

        //TODO IMPLEMENT
        public void AddBefore(Node<T> nodeA, Node<T> nodeB)
        {
            _count++;
            throw new NotImplementedException();
        }

        public T Remove(Node<T> node)
        {
            if (_head == null)
                return node.Value;

            if (_head == node)
            {
                _head = _head.Next;
                node.Next = null;
                return node.Value;
            }

            var current = _head;
            while (current.Next != null)
            {
                if (current.Next == node)
                {
                    current.Next = node.Next;
                    return node.Value;
                }

                current = current.Next;
            }

            _count--;
            return node.Value;
        }

        //TODO TEST
        public void AddFront(T itemToAdd)
        {
            if (_head == null)
            {
                _head = new Node<T> { Value = itemToAdd, Next = null };
                _head.Value = itemToAdd;
            }
            else
            {
                var temp = _head;
                _head.Value = itemToAdd;
                _head.Next = temp;
            }

            _count++;
        }


        public T RemoveBack()
        {
            throw new NotImplementedException();
        }

        public T RemoveFront()
        {
            throw new NotImplementedException();
        }

        public T RemoveByIndex(int index)
        {
            throw new NotImplementedException();
        }

        public T[] RemoveNValuesBack(int n)
        {
            throw new NotImplementedException();
        }

        public T[] RemoveNValuesFront(int n)
        {
            throw new NotImplementedException();
        }

        //TODO TEST
        public void AddBack(T itemToAdd)
        {
            var node = new Node<T> { Value = itemToAdd };

            if (_head == null)
            {
                _head = node;
            }
            else
            {
                var current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = node;
            }

            _count++;
        }

        //TODO TEST
        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        //TODO TEST
        public bool Contains(T searchedItem)
        {
            foreach (Node<T> node in _linkedList)
            {
                if (node.Value.CompareTo(searchedItem) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        //TODO TEST
        public Node<T> Find(T item)
        {
            if (_linkedList.Contains(item))
            {
                foreach (Node<T> node in _linkedList)
                {
                    if (node.Value.CompareTo(item) == 0)
                    {
                        return node;
                    }
                }
            }

            return _head;
        }

        //TODO TEST
        public Node<T> FindLast(T item)
        {
            foreach (Node<T> node in _linkedList)
            {
                if (node.Next == null)
                {
                    return node;
                }
            }

            return _head;
        }

        //TODO TEST
        public void CopyTo(T[] array, int fromIndex = 0)
        {
            for (int i = fromIndex; i < _count; i++)
            {
                foreach (Node<T> node in _linkedList)
                {
                    array[i] = node.Value;
                }
            }
        }


       
      

        public void Reverse()
        {
            throw new NotImplementedException();
        }

        public T Max()
        {
            throw new NotImplementedException();
        }

        public T Min()
        {
            throw new NotImplementedException();
        }

        public int MaxIndex()
        {
            throw new NotImplementedException();
        }

        public int MinIndex()
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

        public int RemoveByValueAll(T value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void AddFront(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void AddBack(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void AddByIndex(int index, IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }


        public void ReverseRecursive()
        {
            reverseRecursive(_head, null);
        }

        private void reverseRecursive(Node<T> current, Node<T> prev)
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

        public IEnumerator<T> Enumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            return Enumerator();
        }
    }

    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
}