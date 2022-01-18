using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryLists
{
    public partial class ArrayList<T>
    {
        public void LastNItemsDelete(int n)
        {
            for (int i = 0; i < n; i++)
            {
                --_currentCount;
            }
        }

        public void FirstNItemsDelete(int n)
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

        public void NItemsDeleteByIndex(int n, int index)
        {
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

        public void RemoveItemByValue(T element)
        {
            for (int i = 0; i < Count - 1; i++)
            {
                if (_array[i].CompareTo(element) == 0)
                {
                    for (; i < Count - 1; i++)
                    {
                        _array[i] = _array[i + 1];
                        break;
                    }
                }
            }

            --_currentCount;
        }

        public void RemoveAllItemsByValue(T element)
        {
            int i = 0;

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
                    --_currentCount;
                }
                else
                {
                    ++i;
                }
            }
        }
    }
}
