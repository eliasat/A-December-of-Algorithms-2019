using System;
using System.Linq;
using System.Collections.Generic;

namespace A_December_of_Algorithms_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Input the sevenish number");
                var n = int.Parse(Console.ReadLine());
                var set = getSevenish(n).ToList();
                set.Sort();
                Console.WriteLine(set[n - 1]);
                Console.WriteLine(set.Count());
                Console.WriteLine("Press key to continue");
                Console.ReadLine();
            }
        }
        private static HashSet<int> getSevenish(int n)
        {
            var powers = new List<int>();
            var result = new HashSet<int>();
            var firstElement = (int)Math.Pow(7, 0);
            var secondElement = (int)Math.Pow(7, 1);

            powers.Add(firstElement);
            powers.Add(secondElement);

            result.Add(firstElement);
            result.Add(secondElement);

            var i = 2;
            while (powers.Count < n)
            {
                distinctSumSubsets(powers, result, powers.Last(), 0, (int)Math.Pow(7, i));
                powers.Add((int)Math.Pow(7, i));
                result.Add((int)Math.Pow(7, i));
                i++;
            }
            return result;
        }
        private static void distinctSumSubsets(List<int> powers, HashSet<int> result, int sum, int currIndex, int upperLimit)
        {
            if (sum >= upperLimit)
            {
                return;
            }
            if (currIndex == powers.Count - 1)
            {
                result.Add(sum);
                return;
            }
            distinctSumSubsets(powers, result, sum, currIndex + 1, upperLimit);
            distinctSumSubsets(powers, result, sum + powers.ElementAt(currIndex), currIndex + 1, upperLimit);
        }
    }
}
