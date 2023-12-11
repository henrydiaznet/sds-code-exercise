using System;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n) => Enumerable.Range(1, n).Aggregate(1, (x1, x2) => x1 * x2);

        public static string FormatSeparators(params string[] items) => string.Format("{0}, {1} and {2}", items);

        public static string[] RemoveSeparators(string input)
        {
            var separators = new[] { " ", ",", "and" };
            return input.Split(separators, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        }
    }
}