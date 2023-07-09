using System;

namespace Task3 {
    public static class QuickSorter
    {
        public static T[] Sort<T>(T[] array, SortingType sortingType, IComparer<T> comparer)
        {
            if (array.Length <= 1)
                return array;
            T[] sortedArray = (T[])array.Clone();
            QuickSortRecursive(sortedArray, 0, sortedArray.Length - 1, sortingType, comparer);
            return sortedArray;
        }

        private static void QuickSortRecursive<T>(T[] array, int left, int right, SortingType sortingType, IComparer<T> comparer)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right, sortingType, comparer);
                QuickSortRecursive(array, left, pivotIndex - 1, sortingType, comparer);
                QuickSortRecursive(array, pivotIndex + 1, right, sortingType, comparer);
            }
        }

        private static int Partition<T>(T[] array, int left, int right, SortingType sortingType, IComparer<T> comparer)
        {
            T pivotValue = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (SorterUtils.CompareValues(array[j], pivotValue, sortingType, comparer) <= 0)
                {
                    i++;
                    SorterUtils.Swap(array, i, j);
                }
            }
            SorterUtils.Swap(array, i + 1, right);
            return i + 1;
        }
    }
}