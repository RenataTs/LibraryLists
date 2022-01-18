using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryLists
{
    public partial class ArrayList<T>
    {
        public T MaxValue()
        {
            T max = _array[MaxValueIndex()];

            return max;
        }

        public T MinValue()
        {
            T min = _array[MinValueIndex()];

            return min;
        }

        public int MaxValueIndex()
        {
            int maxI = 0;

            for (int i = 1; i < Count; i++)
            {
                if (_array[i].CompareTo(_array[maxI]) == 1)
                {
                    maxI = i;
                }
            }

            return maxI;
        }

        public int MinValueIndex()
        {
            int minI = 0;

            for (int i = 1; i < Count; i++)
            {
                if (_array[i].CompareTo(_array[minI]) == -1)
                {
                    minI = i;
                }
            }

            return minI;
        }
    }
}
