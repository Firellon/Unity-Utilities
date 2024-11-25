using System;
using UnityEngine;

namespace Utilities.Prefabs
{
    public interface IPrefabsGroup: IDisposable
    {
        GameObject Spawn(GameObject prefab, Transform parent);
        GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent);
        void Despawn(GameObject poolableResource);
        void SetParent(Transform parent);
        bool IsPersistantGroup { get; set; }
    }
}