using System;

namespace Task3
{
    public static class SorterUtils
    {
        public static void Swap<T>(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        public static int CompareValues<T>(T value1, T value2, SortingType sortingType, IComparer<T> comparer)
        {
            return sortingType == SortingType.Ascending ? comparer.Compare(value1, value2) : comparer.Compare(value2, value1);
        }
    }
}