using System.Collections.Generic;

namespace Utilities.Maybe
{
    public static partial class DictionaryExtensions
    {
        public static IMaybe<TValue> GetValueOrEmpty<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.TryGetValue(key, out var value) 
                ? value.ToMaybe() 
                : Maybe.Empty<TValue>();
        }
    }
}