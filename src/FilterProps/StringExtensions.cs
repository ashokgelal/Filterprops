using System;

namespace FilterProps
{
    public static class StringExtensions
    {
        // .net's built in contains doesn't support ignorecase. Hence, this extension.
        // see: http://stackoverflow.com/questions/444798/case-insensitive-containsstring
        public static bool ContainsIgnoreCase(this string source, string toCheck)
        {
            return source.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
