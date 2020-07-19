using System.Linq;

namespace HF_API.Extensions
{
    /// <summary>
    /// Extension methods for string objects.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Splits the separated list of integers into an integer array. Only the valid integers will be returned.
        /// </summary>
        /// <param name="input">The input <see cref="string"/>.</param>
        /// <param name="separator">A character array that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
        /// <returns>An array of all of the valid integers that were found.</returns>
        public static int[] SplitInts(this string input, params char[] separator) => input.Split(separator).TryParseInts();

        /// <summary>
        /// Attempts to parse the value as a long.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="failureDefault">The default value to return on failure.</param>
        /// <returns>The resulting long, or defaults to 0.</returns>
        public static long TryParseLong(this string input, long failureDefault = default) => long.TryParse(input, out long output) ? output : failureDefault;

        /// <summary>
        /// Attempts to parse the value as a boolean.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The resulting bool, or defaults to false.</returns>
        public static bool TryParseBoolean(this string input) => !string.IsNullOrWhiteSpace(input) && (bool.TryParse(input, out bool output) ? output : "tTyY1".Contains(input[0]));
    }
}
