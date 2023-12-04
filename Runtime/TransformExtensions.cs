using _Scripts.PrefabPool;
using UnityEngine;

namespace Utilities
{
    public static class TransformExtensions
    {
        public static void DespawnChildren(this Transform transform, IPrefabPool prefabPool)
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                prefabPool.Despawn(transform.GetChild(i).gameObject);
            }
        }
    }
}