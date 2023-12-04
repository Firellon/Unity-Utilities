using UnityEngine;

namespace Utilities.Colliders
{
    public static class BoxCollider2DExtensions
    {
        public static bool IsOutsideBoundsLeft(this BoxCollider2D collider, Bounds bounds)
        {
            return collider.transform.position.x - collider.size.x / 2f < bounds.min.x;
        }

        public static bool IsOutsideBoundsRight(this BoxCollider2D collider, Bounds bounds)
        {
            return collider.transform.position.x + collider.size.x / 2f > bounds.max.x;
        }

        public static bool IsOutsideBoundsDown(this BoxCollider2D collider, Bounds bounds)
        {
            return collider.transform.position.y - collider.size.y / 2f < bounds.min.y;
        }

        public static bool IsOutsideBoundsUp(this BoxCollider2D collider, Bounds bounds)
        {
            return collider.transform.position.y + collider.size.y / 2f > bounds.max.y;
        }

        public static bool IsOutsideBounds(this BoxCollider2D collider, Bounds bounds)
        {
            return collider.IsOutsideBoundsLeft(bounds) || collider.IsOutsideBoundsRight(bounds) ||
                   collider.IsOutsideBoundsUp(bounds) || collider.IsOutsideBoundsDown(bounds);
        }
    }
}