using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Utilities
{
    public static class ListExtensions
    {
        [CanBeNull]
        public static T GetElementByIndex<T>(this List<T> list, int index) where T : ScriptableObject
        {
            return list.Count > index ? list[index] : null;
        }

        public static string Stringify(this List<string> list, string separator = " ")
        {
            var result = "";
            list.ForEach(element =>
            {
                result += element + separator;
            });
            return result;
        }
    }  
};