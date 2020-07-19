using System;
using System.Collections.Generic;

namespace HF_API.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IEnumerable{T}"/> objects.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Returns an array of integers that were able to be parsed from the input string list.
        /// </summary>
        /// <param name="input">The input string list.</param>
        /// <returns>An int[] array.</returns>
        public static int[] TryParseInts(this IEnumerable<string> input)
        {
            var result = new List<int>();
            foreach (string item in input)
            {
                if (int.TryParse(item, out int converted))
                {
                    result.Add(converted);
                }
            }
            return result.ToArray();
        }

        /// <inheritdoc cref="string.Join{T}(string, IEnumerable{T})"/>
        public static string JoinString<T>(this IEnumerable<T> input, string separator) => string.Join(separator, input ?? Array.Empty<T>());
    }
}
