using HF_API.Extensions;
using System.Drawing;

namespace HF_API.Helpers
{
    /// <summary>
    /// Helper class to convert between custom types.
    /// </summary>
    public static class ConversionHelper
    {
        /// <summary>
        /// Converts the input size dimensions into a new <see cref="Size"/> struct.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="separator">The character separator.</param>
        /// <returns>A new <see cref="Size"/> struct from the given input.</returns>
        public static Size ParseSize(string input, char separator)
        {
            var dimensions = input.SplitInts(separator);
            return dimensions.Length == 2 ? new Size(dimensions[0], dimensions[1]) : default;
        }
    }
}
