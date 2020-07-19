using System;
using System.Collections.Generic;
using System.Text;

namespace HF_API.Extensions
{
    static class BaseExtensions
    {

        /// <summary>
        /// Attempts to parse the value as a boolean.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The resulting bool, or defaults to false.</returns>
        public static bool TryParseBoolean(this object input, bool defaultValue = false) => input?.ToString().TryParseBoolean(defaultValue) ?? defaultValue;
    }
}
