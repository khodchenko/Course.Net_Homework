using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DataStructuresLibrary
{
    public class MyLinkedList<T> : IMyList<T> where T : IComparable<T>
    {
        private Node<T> _head = null;

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

            return node.Value;
        }

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

                current.Next = node; //new head
            }
        }

        public void AddFront(T itemToAdd)
        {
            throw new NotImplementedException();
        }

        public void AddByIndex(int index, T itemToAdd)
        {
            throw new NotImplementedException();
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

        public T[] RemoveNValuesByIndex(int index, int n)
        {
            throw new NotImplementedException();
        }

        public int Length { get; }

        public T this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public int IndexOf(T element)
        {
            throw new NotImplementedException();
        }

        public void Reverse()
        {
            Node<T> prev = null;
            var current = _head;

            if (current == null)
                return;

            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            _head = prev;
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