using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities
{
    public static partial class EnumerableExtensions
    {
        public static IMaybe<T> FirstOrEmpty<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            return enumerable.FirstOrDefault(predicate).ToMaybe();
        }

        public static IMaybe<T> FirstOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.FirstOrDefault().ToMaybe();
        }
        
        public static IMaybe<T> FirstPresentOrEmpty<T>(this IEnumerable<IMaybe<T>> enumerable)
        {
            return enumerable.FirstOrDefault(optional => optional.IsPresent).ToMaybe().Flatten();
        }

        /// <summary>
        /// Filters the list of Maybe<T>s to only present values and returns the resulting list of Ts
        /// </summary>
        public static IEnumerable<T> WherePresent<T>(this IEnumerable<IMaybe<T>> enumerable)
        {
            return enumerable.Where(maybeT => maybeT.IsPresent).Select(maybeT => maybeT.ValueOrDefault());
        }
    }
}