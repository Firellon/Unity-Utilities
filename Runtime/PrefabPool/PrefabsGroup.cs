using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Utilities.Prefabs
{
    public class PrefabsGroup : MonoBehaviour, IPrefabsGroup
    {
        [SerializeField] private bool isPersistantGroup;

        public bool IsPersistantGroup
        {
            get => isPersistantGroup;
            set => isPersistantGroup = value;
        }

        private readonly Stack<GameObject> pool = new Stack<GameObject>();
        [Inject] private DiContainer container;

        public GameObject Spawn(GameObject prefab, Transform parent)
        {
            GameObject instance;
            if (pool.Count > 0)
            {
                instance = pool.Pop();
                instance.transform.SetParent(parent);
                OnReinitialize(prefab, instance);
            }
            else
            {
                instance = container.InstantiatePrefab(prefab, new GameObjectCreationParameters
                {
                    ParentTransform = parent,
                    Name = GetPrefabName(prefab),
                });
                var poolableItemComponent = instance.AddComponent<PoolableItemComponent>();
                poolableItemComponent.PrefabKey = GetPrefabKey(prefab);
            }

            OnSpawned(instance);

            return instance;
        }

        public void Despawn(GameObject instance)
        {
            if (!this)
                return;
            
            OnDespawn(instance);
            instance.transform.SetParent(transform);
            pool.Push(instance);
        }

        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        public void Dispose()
        {
            if (!this)
                return;
            
            Destroy(gameObject);
            
            while (pool.Count > 0)
            {
                var instance = pool.Pop();
                Destroy(instance);
            }
        }

        private static void OnReinitialize(GameObject prefab, GameObject instance)
        {
            instance.transform.localPosition = prefab.transform.localPosition;
            instance.transform.localScale = prefab.transform.localScale;

            if (instance.transform is RectTransform rectTransform &&
                prefab.transform is RectTransform prefabRectTransform)
            {
                rectTransform.anchoredPosition = prefabRectTransform.anchoredPosition;
                rectTransform.sizeDelta = prefabRectTransform.sizeDelta;
            }
        }

        private static void OnDespawn(GameObject instance)
        {
            foreach (var resource in instance.GetComponentsInChildren<IPoolableResource>()) resource.OnDespawn();
            ResetAnimators(instance);

            instance.SetActive(false);
        }

        private static void ResetAnimators(GameObject instance)
        {
            foreach (var childAnimator in instance.GetComponentsInChildren<Animator>()) childAnimator.Rebind();
        }

        private static void OnSpawned(GameObject instance)
        {
            instance.SetActive(true);
            foreach (var resource in instance.GetComponentsInChildren<IPoolableResource>()) resource.OnSpawn();
        }

        public static string GetPrefabName(GameObject prefab)
        {
            return $"{prefab.name}_{prefab.GetInstanceID()}";
        }
        
        public static int GetPrefabKey(GameObject prefab)
        {
            return prefab.GetInstanceID();
        }
    }
}