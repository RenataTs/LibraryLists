using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ListsLibrary
{
    public partial class ArrayList<T>
        : IList<T>,
            IEquatable<IList<T>> where T : IComparable<T>, new()
    {
        private const int DefaltItem = 1;
        private const int DefaultSize = 4;
        private const double Increment = 1.33;
        private int _currentCount;
        private T[] _array;
        private int DefaultNewSize => (int)(_array.Length * Increment);
        public int Count => _currentCount;
        public int Capacity => _array.Length;

        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        public ArrayList()
        {
            _array = new T[DefaultSize];

            _array[0] = (T)(object)DefaltItem;
            ++_currentCount;
        }

        public ArrayList(T element)
        {
            _array = new T[DefaultSize];

            _array[0] = element;
            ++_currentCount;
        }

        public ArrayList(IEnumerable<T> items)
        {
            var sourceArray = items.ToArray();

            _array = new T[(int)(DefaultSize + sourceArray.Length * Increment)];

            for (int i = 0; i < sourceArray.Length; i++)
            {
                _array[i] = sourceArray[i];
            }

            _currentCount = sourceArray.Length;
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

        protected void Swap(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }

        public void Sort(bool ascending = true)
        {
            var coef = ascending ? 1 : -1;
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    if (_array[i].CompareTo(_array[j]) == coef)
                    {
                        Swap(ref _array[i], ref _array[j]);
                    }
                }
            }
        }

        public int IndexByItem(T element)
        {
            int i = -1;

            for (int j = 0; j < Count; j++)
            {
                if (_array[j].CompareTo(element) == 0)
                {
                    i = j;
                    break;
                }
            }

            return i;
        }

        public void ReplaceByItem(T item, T newItem)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_array[i].CompareTo(item) == 0)
                {
                    _array[i] = newItem;
                    break;
                }
            }
        }

        public void ReplaceBy(int index, T newItem)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException("Index should be greater or equal to zero and less than array length!");
            }

            _array[index] = newItem;
        }

        public void Reverse()
        {
            for (int i = 0; i < Count / 2; i++)
            {
                Swap(ref _array[i], ref _array[Count - i - 1]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as IList);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals([AllowNull] IList<T> list)
        {
            bool result = true;
            if (list != null && list.Count == Count)
            {
                for (int i = 0; i < Count; ++i)
                {
                    if (this[i].CompareTo(list[i]) != 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        public IList<T> CreateInstance(IEnumerable<T> items)
        {
            return new ArrayList<T>(items);
        }
    }
}
