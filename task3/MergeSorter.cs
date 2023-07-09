using System;

namespace Task3
{
    public static class MergeSorter
    {
        public static T[] Sort<T>(T[] array, SortingType sortingType, IComparer<T> comparer)
        {
            if (array.Length <= 1)
                return array;
            int middleIndex = array.Length / 2;
            T[] leftArray = new T[middleIndex];
            T[] rightArray = new T[array.Length - middleIndex];

            Array.Copy(array, 0, leftArray, 0, middleIndex);
            Array.Copy(array, middleIndex, rightArray, 0, array.Length - middleIndex);

            leftArray = Sort(leftArray, sortingType, comparer);
            rightArray = Sort(rightArray, sortingType, comparer);
            return Merge(leftArray, rightArray, sortingType, comparer);
        }

        public static T[] Merge<T>(T[] leftArray, T[] rightArray, SortingType sortingType, IComparer<T> comparer)
        {
            int leftIndex = 0, rightIndex = 0, mergedIndex = 0;
            int mergedLength = leftArray.Length + rightArray.Length;
            T[] mergedArray = new T[mergedLength];
            while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
            {
                int comparisonResult = SorterUtils.CompareValues(leftArray[leftIndex], rightArray[rightIndex], sortingType, comparer);

                if (comparisonResult <= 0)
                {
                    mergedArray[mergedIndex] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    mergedArray[mergedIndex] = rightArray[rightIndex];
                    rightIndex++;
                }

                mergedIndex++;
            }
            while (leftIndex < leftArray.Length)
            {
                mergedArray[mergedIndex] = leftArray[leftIndex];
                leftIndex++;
                mergedIndex++;
            }
            while (rightIndex < rightArray.Length)
            {
                mergedArray[mergedIndex] = rightArray[rightIndex];
                rightIndex++;
                mergedIndex++;
            }
            return mergedArray;
        }
    }
}