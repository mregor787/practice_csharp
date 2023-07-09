using System;

namespace Task3 
{
    public static class ArraySort
    {
        public static T[] Sort<T>(this T[] arr, SortingType st, Algorithm algorithm)
        {
            var comparer = Comparer<T>.Default;
            return arr.Sort(st, algorithm, comparer);
        }
        public static T[] Sort<T>(this T[] arr, SortingType st, Algorithm algorithm, IComparer<T> comparer)
        {
            switch (algorithm)
            {
                case Algorithm.QuickSort:
                    return QuickSorter.Sort(arr, st, comparer);
                case Algorithm.InsertionSort:
                    return InsertionSorter.Sort(arr, st, comparer);
                case Algorithm.MergeSort:
                    return MergeSorter.Sort(arr, st, comparer);
                case Algorithm.SelectionSort:
                    return SelectionSorter.Sort(arr, st, comparer);
                case Algorithm.HeapSort:
                    return HeapSorter.Sort(arr, st, comparer);
                default:
                    return QuickSorter.Sort(arr, st, comparer);
            }
        }
        public static T[] Sort<T>(this T[] arr, SortingType st, Algorithm algorithm, Comparison<T> comparison)
        {
            var comparer = Comparer<T>.Create(comparison);
            return arr.Sort(st, algorithm, comparer);
        }
    }
}