using System;
using UnityEngine;

namespace Utilities.Prefabs
{
    public interface IPrefabsGroup: IDisposable
    {
        GameObject Spawn(GameObject prefab, Transform parent, Action<GameObject> onSpawn = null);
        GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent, Action<GameObject> onSpawn = null);
        void Despawn(GameObject poolableResource);
        void SetParent(Transform parent);
        bool IsPersistantGroup { get; set; }
    }
}