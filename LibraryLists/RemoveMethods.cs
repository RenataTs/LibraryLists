using System;
using System.Collections.Generic;
using System.Text;

namespace ListsLibrary
{
    public partial class ArrayList<T>
    {
        public void RemoveLastItem()
        {
            RemoveBy(_currentCount);
        }

        public void RemoveFirstItem()
        {
            RemoveBy(0);
        }

        public void RemoveBy(int index)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException("Index should be greater or equal to zero and less than array length!");
            }

            for (int i = index; i < Count - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            --_currentCount;
        }

        public void LastNItemsRemove(int n)
        {
            for (int i = 0; i < n; i++)
            {
                --_currentCount;
            }
        }

        public void FirstNItemsRemove(int n)
        {
            while (n > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    _array[i] = _array[i + 1];
                }

                --_currentCount;
                --n;
            }
        }

        public void NItemsDeleteBy(int n, int index)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException("Index should be greater or equal to zero and less than array length!");
            }

            while (n > 0)
            {
                for (int i = index; i < Count - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }

                --_currentCount;
                --n;
            }
        }

        public int RemoveItemByValue(T element)
        {
            int j;
            for (j = 0; j < Count - 1; j++)
            {
                if (_array[j].CompareTo(element) == 0)
                {
                    for (int i = j; i < Count - 1; i++)
                    {
                        _array[i] = _array[i + 1];
                    }

                    break;
                }
            }

            --_currentCount;

            return j;
        }

        public int RemoveAllItemsByValue(T element)
        {
            int i = 0;
            int count = 0;

            while (i < Count)
            {
                if (_array[i].CompareTo(element) == 0)
                {
                    for (int j = i; j < Count - 1; j++)
                    {
                        _array[j] = _array[j + 1];
                    }

                    ++i;
                    i = Math.Max(0, i - 1);
                    ++count;
                    --_currentCount;
                }
                else
                {
                    ++i;
                }
            }

            return count;
        }
    }
}
