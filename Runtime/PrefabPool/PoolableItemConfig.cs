using UnityEngine;

namespace Utilities.Prefabs
{
    public class PoolableItemConfig : MonoBehaviour
    {
        [SerializeField] private bool persistantGroup;
        public bool PersistantGroup => persistantGroup;
    }
}