using System;

namespace Task3 {
    public static class InsertionSorter
    {
        public static T[] Sort<T>(T[] array, SortingType sortingType, IComparer<T> comparer)
        {
            if (array.Length <= 1)
                return array;
            T[] sortedArray = (T[])array.Clone();
            for (int i = 1; i < sortedArray.Length; i++)
            {
                T key = sortedArray[i];
                int j = i - 1;

                while (j >= 0 && SorterUtils.CompareValues(sortedArray[j], key, sortingType, comparer) > 0)
                {
                    sortedArray[j + 1] = sortedArray[j];
                    j--;
                }

                sortedArray[j + 1] = key;
            }
            return sortedArray;
        }
    }
}