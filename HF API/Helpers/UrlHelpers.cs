using System.Linq;

namespace HF_API.Helpers
{
    /// <summary>
    /// Helper class for Uris.
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
