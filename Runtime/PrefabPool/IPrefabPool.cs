using System;
using UnityEngine;
using Zenject;

namespace Utilities.Prefabs
{
    public interface IPrefabPool
    {
        GameObject Spawn(GameObject prefab, Transform parent = null, Action<GameObject> onSpawn = null);
        GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null, Action<GameObject> onSpawn = null);
        void Despawn(GameObject instance);

        GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, DiContainer diContainer, Transform parent = null, Action<GameObject> onSpawn = null);
        void Despawn(GameObject instance, DiContainer diContainer);
    }
}