using System.Collections.Generic;

namespace DataStructuresLibrary
{
    public interface IMyLinkedList<T> : IEnumerable<T>
    {
        void AddAfter(Node <T> nodeA, Node <T> nodeB);

        void AddFront(T itemToAdd);

        void AddByIndex(int index, T itemToAdd);

        T RemoveBack();

        T RemoveFront();

        T RemoveByIndex(int index);

        T[] RemoveNValuesBack(int n);
        T[] RemoveNValuesFront(int n);
        T[] RemoveNValuesByIndex(int index, int n);
        int Length { get; }
        T this[int index] { get; set; }
        int IndexOf(T element);
        void Reverse();
        T Max();
        T Min();
        int MaxIndex();
        int MinIndex();
        void Sort(bool ascending = true);
        int RemoveByValue(T value);
        int RemoveByValueAll(T value);
        void AddFront(IEnumerable<T> items);
        void AddBack(IEnumerable<T> items);
        void AddByIndex(int index, IEnumerable<T> items);
    }
}