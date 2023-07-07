using System;

namespace Task2 
{
    class Program
    {
        static void Main(string[] args)
        {
            // Combinations
            int[] arr = {1, 2, 3, 3}; // MyEqualityComparer detects: "An item with the same key has already been added. Key: 3"
            IEnumerable<int> collection = IEnumNumbers(arr);
            int k = 2;
            IEnumerable<IEnumerable<int>> combinations = ExtendEnum.GetCombinations(collection, k);
            Console.WriteLine("Combinations:");
            foreach (IEnumerable<int> combination in combinations)
            {
                Console.WriteLine("[" + string.Join(", ", combination) + "]");
            }
            // Subsets
            int[] arr1 = {1, 2}; // No warnings from Comparer
            IEnumerable<int> collection1 = IEnumNumbers(arr1);
            IEnumerable<IEnumerable<int>> subsets = ExtendEnum.GetSubsets(collection1);
            Console.WriteLine("Subsets:");
            foreach (IEnumerable<int> subset in subsets)
            {
                Console.WriteLine("[" + string.Join(", ", subset) + "]");
            }
            // Permutations
            int[] arr2 = {1, 2, 3, 2}; // Duplicate detected: "An item with the same key has already been added. Key: 2"
            IEnumerable<int> collection2 = IEnumNumbers(arr2);
            IEnumerable<IEnumerable<int>> permutations = ExtendEnum.GetPermutations(collection2);
            Console.WriteLine("Permutations:");
            foreach (IEnumerable<int> permutation in permutations)
            {
                Console.WriteLine("[" + string.Join(", ", permutation) + "]");
            }
        }
        static IEnumerable<int> IEnumNumbers(int[] numbers)
        {
            foreach (int number in numbers) { yield return number; }
        }
    }
}