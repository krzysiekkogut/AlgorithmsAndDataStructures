using System.Collections.Generic;

namespace Implementations.Helpers
{
    public static class CollectionsHelper
    {
        public static bool Empty<T>(this IEnumerable<T> collection)
        {
            return !collection.GetEnumerator().MoveNext();
        }
    }
}
