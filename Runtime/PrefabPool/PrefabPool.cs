using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Utilities.Prefabs
{
    public class PrefabPool : MonoBehaviour, IPrefabPool
    {
        private Dictionary<int, IPrefabsGroup> cache;

        [Inject] private DiContainer container;

        [SerializeField] private Transform poolsTransform;

        public PrefabPool()
        {
            Instance = this;
        }

        public static IPrefabPool Instance { get; private set; }

        private void Awake()
        {
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
            cache = new Dictionary<int, IPrefabsGroup>();
        }

        public GameObject Spawn(GameObject prefab, Transform parent = null)
        {
            var resourceGroup = GetOrCreateGroup(prefab);
            return resourceGroup.Spawn(prefab, parent);
        }

        public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            var resourceGroup = GetOrCreateGroup(prefab);
            var instance = resourceGroup.Spawn(prefab, null);
            instance.transform.SetPositionAndRotation(position, rotation);

            return instance;
        }

        public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            var resourceGroup = GetOrCreateGroup(prefab);
            var instance = resourceGroup.Spawn(prefab, parent);
            instance.transform.SetPositionAndRotation(position, rotation);

            return instance;
        }

        public void Despawn(GameObject instance)
        {
            if (!instance.TryGetComponent<PoolableItemComponent>(out var component))
            {
                Debug.LogWarning($"Despawn > can't find PoolableItemComponent of {instance.name}, skipping!");
                return;
            }
            if (cache.TryGetValue(component.PrefabKey, out var resourceGroup))
                resourceGroup.Despawn(instance);
            else
                Destroy(instance);
        }

        private IPrefabsGroup GetOrCreateGroup(GameObject prefab)
        {
            var prefabKey = PrefabsGroup.GetPrefabKey(prefab);
            var resourceGroup = cache.SafeGet(prefabKey);
            if (resourceGroup != null) return resourceGroup;

            var prefabName = PrefabsGroup.GetPrefabName(prefab);
            resourceGroup = container.InstantiateComponentOnNewGameObject<PrefabsGroup>($"pool_{prefabName}");
            
            if (prefab.TryGetComponent<PoolableItemConfig>(out var poolableItemConfigComponent))
                resourceGroup.IsPersistantGroup = poolableItemConfigComponent.PersistantGroup;
            
            resourceGroup.SetParent(poolsTransform);
            cache.Add(prefabKey, resourceGroup);
            return resourceGroup;
        }

        public void FreeResources()
        {
            var disposedGroupIds = ListPool<int>.Instance.Spawn();

            foreach (var kvp in cache)
            {
                if (kvp.Value.IsPersistantGroup)
                    continue;
                kvp.Value.Dispose();
                disposedGroupIds.Add(kvp.Key);
            }

            foreach (var disposedGroupId in disposedGroupIds) 
                cache.Remove(disposedGroupId);
            
            ListPool<int>.Instance.Despawn(disposedGroupIds);
        }
    }
}