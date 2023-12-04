using UnityEngine;

namespace Utilities.Colliders
{
    public static class CircleCollider2DExtensions
    {
        public static bool IsOutsideBounds(this CircleCollider2D collider, Bounds bounds)
        {
            var reducedSize = bounds.size - new Vector3(1, 1, 0) * collider.radius;
            var reducedBounds = new Bounds(bounds.center, reducedSize);

            return !reducedBounds.Contains(collider.transform.position);
        }
    }
}