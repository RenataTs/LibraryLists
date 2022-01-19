using System;
using System.Collections.Generic;
using System.Text;

namespace ListsLibrary
{
    public partial class ArrayList<T>
    {
        public void Add(T element)
        {
            AddBy(element, _currentCount);
        }

        public void Add(T[] array)
        {
            var newSize = Count + array.Length;

            if (newSize >= Capacity)
            {
                Resize(newSize);
            }

            AddBy(array, _currentCount);

            _currentCount = newSize;
        }

        public void AddFront(T element)
        {
            AddBy(element, 0);
        }

        public void AddFront(T[] array)
        {
            var newSize = Count + array.Length;

            if (newSize >= Capacity)
            {
                Resize(newSize);
            }

            AddBy(array, 0);

            _currentCount = newSize;
        }

        public void AddBy(T el, int index)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException("Index should be greater or equal to zero and less than array length!");
            }

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

        public void AddBy(T[] array, int index)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException("Index should be greater or equal to zero and less than array length!");
            }

            var newSize = Count + array.Length;

            if (newSize >= Capacity)
            {
                Resize(newSize);
            }

            AddBy(array, index);

            _currentCount = newSize;
        }

        public void Add(IList<T> array)
        {
            var newSize = Count + array.Count;

            if (newSize >= Capacity)
            {
                Resize(newSize);
            }

            AddBy(array, _currentCount);

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

        public void AddBy(IList<T> array, int index)
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

    }
}
