using System.Collections.Generic;

namespace DataStructuresLibrary
{
    public interface IMyLinkedList<T> : IEnumerable<T>
    {
        void AddAfter(MyNode<T> myNodeA, MyNode<T> myNodeB);

        void AddBefore(MyNode<T> myNodeA, MyNode<T> myNodeB);

        void AddFront(T itemToAdd);

        void AddBack(T itemToAdd);

        void Clear();

        bool Contains(T searchedItem);

        MyNode<T> Find(T item);

        MyNode<T> FindLast(T item);
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