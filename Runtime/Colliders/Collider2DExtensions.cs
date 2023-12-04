using UnityEngine;

namespace Utilities.Colliders
{
    public static class Collider2DExtensions
    {
        public static bool IsOutsideBounds(this Collider2D collider, Bounds bounds)
        {
            switch (collider)
            {
                case BoxCollider2D boxCollider2D:
                    return boxCollider2D.IsOutsideBounds(bounds);
                case CircleCollider2D circleCollider2D:
                    return circleCollider2D.IsOutsideBounds(bounds);
                default:
                    Debug.LogError($"{nameof(IsOutsideBounds)} > collider type is not supported!");
                    return false;
            }
        }
    }
}