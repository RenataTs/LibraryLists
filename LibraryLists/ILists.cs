using System;
using System.Collections.Generic;

namespace LibraryLists
{
    public interface IList<T> : IEnumerable<T> where T : IComparable<T>
    {
        void Add(T element);//to end
        void AddFront(T element);
        void Sort();
        int Count { get; }
        int Capacity { get; }
        T this[int index] { get; set; }
        IList<T> CreateInstance(IEnumerable<T> items);
        //T[] ToArray();
    }
}
