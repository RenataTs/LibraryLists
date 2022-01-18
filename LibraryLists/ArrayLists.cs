using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace LibraryLists
{
    public partial class ArrayList<T>
        : IList<T>,
            IEquatable<IList<T>> where T : IComparable<T>
    {
        private const int DefaultSize = 4;
        private const double Increment = 1.33;
        private int _currentCount;
        private T[] _array;

        private int DefaultNewSize => (int)(_array.Length * Increment);
        public int Count => _currentCount;
        public int Capacity => _array.Length;

        public bool IsReadOnly => throw new NotImplementedException();

        public ArrayList(IEnumerable<T> items)
        {
            _array = new T[DefaultSize];
        }

        public ArrayList(int capacity)
        {
            _array = new T[capacity];
        }

        public ArrayList(T[] array)
        {
            _array = new T[(int)(DefaultSize + array.Length * Increment)];

            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }

            _currentCount = array.Length;
        }

        private void Resize(int newSize)
        {
            T[] arrayNew = new T[newSize];

            for (int i = 0; i < _array.Length; i++)
            {
                arrayNew[i] = _array[i];
            }

            _array = arrayNew;
        }

        public int LengthReturn()
        {
            return Count;
        }

        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentException();
                }

                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        public int IndexOf(T element)
        {
            if (Count == Capacity)
            {
                Resize(DefaultNewSize);
            }

            int i = 0;

            for (; i < Count; i++)
            {
                if (_array[i].CompareTo(element) == 0)
                {
                    break;
                }
            }

            return i;
        }

        public void Reverse()
        {
            for (int i = 0; i < Count / 2; i++)
            {
                T tmp = _array[i];
                _array[i] = _array[Count - i - 1];
                _array[Count - i - 1] = tmp;
            }
        }

        protected void Swap(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }

        public void Sort()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    if (_array[i].CompareTo(_array[j]) == -1)
                    {
                        Swap(ref _array[i], ref _array[j]);
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _array[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Equals([AllowNull] IList<T> other)
        {
            throw new NotImplementedException();
        }

        public IList<T> CreateInstance(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }
    }
}
