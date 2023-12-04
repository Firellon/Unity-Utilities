using UnityEngine;

namespace Utilities
{
    public static class GameObjectExtensions
    {
        public static IMaybe<T> GetComponentOrEmpty<T>(this GameObject gameObject)
        {
            return gameObject.GetComponent<T>().ToMaybe();
        }
    }
}