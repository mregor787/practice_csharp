using System;

namespace Task3
{
    public static class SelectionSorter
    {
        public static T[] Sort<T>(T[] array, SortingType sortingType, IComparer<T> comparer)
        {
            if (array.Length <= 1)
                return array;
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (SorterUtils.CompareValues(array[j], array[minIndex], sortingType, comparer) < 0)
                        minIndex = j;
                }
                SorterUtils.Swap(array, i, minIndex);
            }
            return array;
        }
    }
}