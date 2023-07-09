using System;

namespace Task3 
{
    public static class HeapSorter 
    {
        public static T[] Sort<T>(T[] array, SortingType sortingType, IComparer<T> comparer)
        {
            if (array.Length <= 1)
                return array;
            BuildMaxHeap(array, sortingType, comparer);
            for (int i = array.Length - 1; i > 0; i--)
            {
                SorterUtils.Swap(array, 0, i);
                Heapify(array, 0, i, sortingType, comparer);
            }
            return array;
        }

        private static void BuildMaxHeap<T>(T[] array, SortingType sortingType, IComparer<T> comparer)
        {
            int heapSize = array.Length;
            for (int i = heapSize / 2 - 1; i >= 0; i--)
                Heapify(array, i, heapSize, sortingType, comparer);
        }

        private static void Heapify<T>(T[] array, int index, int heapSize, SortingType sortingType, IComparer<T> comparer)
        {
            int largestIndex = index;
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            if (leftChildIndex < heapSize && SorterUtils.CompareValues(array[leftChildIndex], array[largestIndex], sortingType, comparer) > 0)
                largestIndex = leftChildIndex;
            if (rightChildIndex < heapSize && SorterUtils.CompareValues(array[rightChildIndex], array[largestIndex], sortingType, comparer) > 0)
                largestIndex = rightChildIndex;

            if (largestIndex != index)
            {
                SorterUtils.Swap(array, index, largestIndex);
                Heapify(array, largestIndex, heapSize, sortingType, comparer);
            }
        }
    }
}