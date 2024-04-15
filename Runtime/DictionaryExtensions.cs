using System.Collections.Generic;

namespace Utilities
{
    public static class DictionaryExtensions
    {
        public static void SafeAddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, TValue value)
        {
            if(!dic.ContainsKey(key))
                dic.Add(key, value);
            else
                dic[key] = value;
        }

        public static void SafeAddOrInc<TKey>(this IDictionary<TKey, float> dic, TKey key, float value)
        {
            if (!dic.ContainsKey(key))
                dic.Add(key, value);
            else
                dic[key] += value;
        }

        public static void SafeAddOrInc<TKey>(this IDictionary<TKey, double> dic, TKey key, double value)
        {
            if (!dic.ContainsKey(key))
                dic.Add(key, value);
            else
                dic[key] += value;
        }

        public static void SafeAddOrInc<TKey>(this IDictionary<TKey, int> dic, TKey key, int value)
        {
            if (!dic.ContainsKey(key))
                dic.Add(key, value);
            else
                dic[key] += value;
        }
         
        public static void SafeAddOrInc<TKey>(this IDictionary<TKey, long> dic, TKey key, long value)
        {
            if (!dic.ContainsKey(key))
                dic.Add(key, value);
            else
                dic[key] += value;
        }

        public static TValue SafeGet<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key)
        {
            if(dic == null)
                return default(TValue);
            TValue value;
            return !dic.TryGetValue(key, out value) ? default(TValue) : value;
        }

        public static TValue SafeGet<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, TValue defaultReturnValue)
        {
            if(dic == null)
                return defaultReturnValue;
            TValue value;
            return !dic.TryGetValue(key, out value) ? defaultReturnValue : value;
        }
    }
}