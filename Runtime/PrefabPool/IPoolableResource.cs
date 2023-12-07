namespace Utilities.Prefabs
{
    public interface IPoolableResource
    {
        void OnSpawn();
        void OnDespawn();
    }
}