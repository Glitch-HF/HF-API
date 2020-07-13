using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HF_API.Helpers
{
    /// <summary>
    /// Helper class for Urls.
    /// </summary>
    internal static class UriHelper
    {
        /// <summary>
        /// Combines the list of urls into one.
        /// </summary>
        /// <param name="paths">The paths to combine.</param>
        /// <returns>The combined url.</returns>
        public static string Combine(params string[] paths) => string.Join('/', paths.Select(path => path?.Trim('/')));
    }
}
