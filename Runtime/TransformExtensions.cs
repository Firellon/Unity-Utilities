using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utilities
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Destroys all of the children of this Transform
        /// </summary>
        /// <param name="parentTransform"></param>
        // TODO: Add DespawnChildren method using PrefabPool
        public static void DestroyChildren(this Transform parentTransform)
        {
            foreach (Transform childTransform in parentTransform)
            {
                GameObject.Destroy(childTransform.gameObject);
            }
        }
        
        /// <summary>
        /// Destroys all of the children of this Transform immediately
        /// </summary>
        /// <param name="parentTransform"></param>
        // TODO: Add DespawnChildren method using PrefabPool
        public static void DestroyChildrenImmediate(this Transform parentTransform)
        {
            foreach (Transform childTransform in parentTransform)
            {
                GameObject.DestroyImmediate(childTransform.gameObject);
            }
        }
        
        /// <summary>
        /// Finds the Transform on the list whose position is the closest to the target position
        /// </summary>
        /// <param name="transforms"></param>
        /// <param name="targetPosition"></param>
        /// <returns>Index of the Transform closest to the targetPosition</returns>
        public static int FindClosestIndex(this List<Transform> transforms, Vector3 targetPosition)
        {
            if (transforms.Count == 0) return -1;
            if (transforms.Count == 1) return 0;
            var closestIndex = 0;
            var closestDistance = Vector3.Distance(transforms.First().position, targetPosition);
            for (var i = 1; i < transforms.Count; i++)
            {
                var pointDistance = Vector3.Distance(transforms[i].position, targetPosition);
                if (pointDistance < closestDistance)
                {
                    closestDistance = pointDistance;
                    closestIndex = i;
                }
            }

            return closestIndex;
        }
    }
}