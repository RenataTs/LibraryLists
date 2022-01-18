using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryLists
{
    public partial class ArrayList<T>
    {
        public void Add(IList<T> array)
        {
            var newSize = Count + array.Count;
            if (newSize >= Capacity)
            {
                Resize(newSize);
            }

            for (int i = Count, j = 0; i < newSize; i++, j++)
            {
                _array[i] = array[j];
            }

            _currentCount = newSize;
        }

        public void AddFront(IList<T> array)
        {
            var newSize = Count + array.Count;
            if (newSize >= Capacity)
            {
                Resize(newSize);
            }

            for (int i = Count - 1; i >= 0; i--)
            {
                _array[i + Count] = _array[i];
            }

            for (int i = 0; i < Count; i++)
            {
                _array[i] = array[i];
            }

            _currentCount = newSize;
        }

        public void InsertByIndex(IList<T> array, int index)
        {
            var newSize = Count + array.Count;

            if (newSize >= Capacity)
            {
                Resize(newSize);
            }

            for (int i = newSize - 1; i > Count; i--)
            {
                _array[i] = _array[i - Count];
            }

            for (int i = Count - 1; i >= 0; i--)
            {
                _array[i + index] = array[i];
            }

            _currentCount = newSize;
        }

        public void Add(T element)
        {
            if (Count == Capacity)
            {
                Resize(DefaultNewSize);
            }

            _array[_currentCount++] = element;
        }

        public void Add(T[] array)
        {
            var newSize = Count + array.Length;

            if (newSize >= Capacity)
            {
                Resize(newSize);
            }

            for (int i = Count, j = 0; i < newSize; i++, j++)
            {
                _array[i] = array[j];
            }

            _currentCount = newSize;
        }

        public void AddFront(T element)
        {
            if (Count == Capacity)
            {
                Resize(DefaultNewSize);
            }

            for (int i = Count - 1; i >= 0; i--)
            {
                _array[i + 1] = _array[i];
            }

            _array[0] = element;
            ++_currentCount;
        }

        public void AddFront(T[] array)
        {
            var newSize = Count + array.Length;

            if (newSize >= Capacity)
            {
                Resize(newSize);
            }

            for (int i = Count - 1; i >= 0; i--)
            {
                _array[i + array.Length] = _array[i];
            }

            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }

            _currentCount = newSize;
        }

        public void InsertByIndex(T el, int index)
        {
            if (Count == Capacity)
            {
                Resize(DefaultNewSize);
            }
            else
            {
                for (int i = Count; i > index; i--)
                {
                    _array[i] = _array[i - 1];
                }

                _array[index] = el;
            }

            ++_currentCount;
        }

        public void InsertByIndex(T[] array, int index)
        {
            var newSize = Count + array.Length;

            if (newSize >= Capacity)
            {
                Resize(newSize);
            }

            for (int i = newSize - 1; i > array.Length; i--)
            {
                _array[i] = _array[i - array.Length];
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                _array[i + index] = array[i];
            }

            _currentCount = newSize;
        }
    }
}
