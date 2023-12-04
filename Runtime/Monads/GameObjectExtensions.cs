using UnityEngine;

namespace Utilities.Monads
{
    public static class GameObjectExtensions
    {
        public static IMaybe<T> GetComponentOrEmpty<T>(this GameObject gameObject)
        {
            return gameObject.GetComponent<T>().ToMaybe();
        }
    }
}