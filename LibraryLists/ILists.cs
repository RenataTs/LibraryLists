using System;
using System.Collections.Generic;

namespace ListsLibrary
{
    public interface IList<T> : IEnumerable<T> where T : IComparable<T>
    {
        void Add(T element);
        void Add(T[] array);
        void AddFront(T element);
        void AddFront(T[] array);
        void AddBy(T element, int index);
        void AddBy(T[] array, int index);
        void RemoveLastItem();
        void RemoveFirstItem();
        void RemoveBy(int index);
        void LastNItemsRemove(int n);
        void FirstNItemsRemove(int n);
        void NItemsDeleteBy(int n, int index);
        void Sort(bool ascending = true);
        void Reverse();
        T MaxValue();
        T MinValue();
        int MaxValueIndex();
        int MinValueIndex();
        int RemoveItemByValue(T element);
        int RemoveAllItemsByValue(T element);
        int IndexByItem(T element);
        void ReplaceByItem(T item, T newItem);
        void ReplaceBy(int index, T newItem);
        void Add(IList<T> array);
        void AddFront(IList<T> array);
        void AddBy(IList<T> array, int index);
        int Count { get; }
        int Capacity { get; }
        T this[int index] { get; set; }
        IList<T> CreateInstance(IEnumerable<T> items);
    }
}
