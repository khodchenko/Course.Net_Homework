using System.Collections.Generic;

namespace DataStructuresLibrary
{
    public interface IMyList
    {
        void AddBack(int itemToAdd);
        void AddFront(int itemToAdd);
        void AddByIndex(int index, int itemToAdd);
        int RemoveBack();
        int RemoveFront();
        int RemoveByIndex(int index);
        int[] RemoveNValuesBack(int n);
        int[] RemoveNValuesFront(int n);
        int[] RemoveNValuesByIndex(int index, int n);
        int Length { get; }
        int this[int index] { get; set; }
        int IndexOf(int element);
        void Reverse();
        int Max();
        int Min();
        int MaxIndex();
        int MinIndex();
        void Sort(bool ascending = true);
        int RemoveByValue(int value);
        int RemoveByValueAll(int value);
        void AddFront(IEnumerable<int> items);//foreach(var item in items){}
        void AddBack(IEnumerable<int> items);//items.Count()
        void AddByIndex(int index, IEnumerable<int> items);

    }
}