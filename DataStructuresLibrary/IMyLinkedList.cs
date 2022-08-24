using System.Collections.Generic;

namespace DataStructuresLibrary
{
    public interface IMyLinkedList<T> : IEnumerable<T>
    {
        void AddAfter(Node<T> nodeA, Node<T> nodeB);

        void AddBefore(Node<T> nodeA, Node<T> nodeB);

        void AddFront(T itemToAdd);

        void AddBack(T itemToAdd);

        void Clear();

        bool Contains(T searchedItem);

        Node<T> Find(T item);

        Node<T> FindLast(T item);
        void CopyTo(T[] array, int fromIndex = 0);

        int Length { get; }
        T this[int index] { get; set; }

        void Reverse();
        bool Remove(T item);
        void AddFront(IEnumerable<T> items);
        void AddBack(IEnumerable<T> items);
        void AddByIndex(int index, IEnumerable<T> items);
    }
}