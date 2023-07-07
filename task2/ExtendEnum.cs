using System;

namespace Task2
{
    public static class ExtendEnum
    {
        public static IEnumerable<IEnumerable<int>> GetCombinations(
            IEnumerable<int> collection, int k)
        {
            CheckCollection(collection);
            List<int> combination = new List<int>(k);
            return GenerateCombinations(collection, k, 0, combination);
        }
        public static IEnumerable<IEnumerable<int>> GenerateCombinations(
            IEnumerable<int> collection, int k, int start, List<int> combination)
        {
            if (k == 0)
            {
                yield return new List<int>(combination);
                yield break;
            }
            for (int i = start; i < collection.Count(); i++)
            {
                combination.Add(collection.ElementAt(i));
                foreach (IEnumerable<int> subCombination in GenerateCombinations(collection, k - 1, i, combination))
                {
                    yield return subCombination;
                }
                combination.RemoveAt(combination.Count - 1);
            }
        }
        public static IEnumerable<IEnumerable<int>> GetSubsets(IEnumerable<int> collection)
        {
            CheckCollection(collection);
            List<int> numberList = new List<int>(collection);
            int totalSubsets = 1 << numberList.Count; // 1 << n == 2 ^ n
            for (int i = 0; i < totalSubsets; i++) // cycle from 0 to n in binary (e.g. 000 to 111)
            {
                List<int> subset = new List<int>();
                for (int j = 0; j < numberList.Count; j++)
                {
                    if ((i & (1 << j)) != 0) // check if we need to add a number with index j to current subset
                    {
                        subset.Add(numberList[j]);
                    }
                }
                yield return subset;
            }
        }
        public static IEnumerable<IEnumerable<int>> GetPermutations(IEnumerable<int> collection)
        {
            CheckCollection(collection);
            List<int> numberList = new List<int>(collection);
            int n = numberList.Count;
            int[] indexes = new int[n];
            yield return numberList;
            int j = 0;
            while (j < n)
            {
                if (indexes[j] < j)
                {
                    Swap(numberList, j % 2 == 0 ? 0 : indexes[j], j);
                    yield return numberList;
                    indexes[j]++;
                    j = 0;
                }
                else
                {
                    indexes[j] = 0;
                    j++;
                }
            }
        }
        static void Swap(List<int> list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        static void CheckCollection(IEnumerable<int> collection)
        {
            try
            {
                MyEqualityComparer comparer = new();
                Dictionary<int, int> dictCol = new(comparer);
                foreach (int item in collection) { dictCol.Add(item, item); }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}