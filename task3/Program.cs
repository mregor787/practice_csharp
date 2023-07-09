using System;

namespace Task3 
{
    public enum SortingType 
    {
        Ascending,
        Descending
    }
    public enum Algorithm
    {
        QuickSort,
        InsertionSort,
        MergeSort,
        SelectionSort,
        HeapSort
    }

    public class MyComparer : Comparer<int>
    {
        public override int Compare(int x, int y)
        {
            return (x - y);
        }
    }

    class Program
    {
        public static int MyComparison(int x, int y)
        {
            return (x - y);
        }

        static void Main(string[] args)
        {
            int[] arr = {33, 123, -10, 0, 322, 777, -100, 87, 54, 42};
            Console.WriteLine("Unsorted array");
            Console.WriteLine(string.Join(", ", arr));

            Console.WriteLine("Quick sort; default");
            int[] quickSorted = arr.Sort(SortingType.Ascending, Algorithm.QuickSort);
            Console.WriteLine(string.Join(", ", quickSorted));

            Console.WriteLine("Insertion sort; default Comparer<int>");
            int[] insertionSorted = arr.Sort(SortingType.Ascending, Algorithm.InsertionSort, Comparer<int>.Default);
            Console.WriteLine(string.Join(", ", insertionSorted));

            Console.WriteLine("Merge sort; custom Comparer<int>");
            int[] mergeSorted = arr.Sort(SortingType.Ascending, Algorithm.MergeSort, new MyComparer());
            Console.WriteLine(string.Join(", ", mergeSorted));

            Console.WriteLine("Heap sort; custom Comparison; descending");
            int[] heapSorted = arr.Sort(SortingType.Descending, Algorithm.HeapSort, MyComparison);
            Console.WriteLine(string.Join(", ", heapSorted));
            
            Console.WriteLine("Selection sort; default; descending");
            int[] selectionSorted = arr.Sort(SortingType.Descending, Algorithm.SelectionSort);
            Console.WriteLine(string.Join(", ", selectionSorted));
        }
    }
}