using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class Vector3Extensions
    {
        public static float ToAngle(this Vector3 vector)
        {
            return Vector3.SignedAngle(vector, Vector3.right, Vector3.up);
        }

        public static float ToAngle(this Vector2 vector)
        {
            return Vector3.SignedAngle(vector, Vector3.right, Vector3.up);
        }
        
        public static float ToAngle(this Vector2Int vector)
        {
            return Vector3.SignedAngle(vector.ToVector3(), Vector3.right, Vector3.up);
        }

        private const float DistanceEqualityThreshold = 0.1f;

        public static bool IsSimilar(this Vector3 vectorA, Vector3 vectorB)
        {
            return Vector3.Distance(vectorA, vectorB) <= DistanceEqualityThreshold;
        }

        public static Quaternion ToQuaternion(this Vector2 direction)
        {
            return Quaternion.LookRotation(Vector3.forward, direction);
        }

        public static Quaternion ToQuaternion(this Vector3 direction)
        {
            return ((Vector2)direction).ToQuaternion();
        }

        public static Vector3 ToVector3(this Vector2 vector, float z = 0f)
        {
            return new Vector3(vector.x, vector.y, z);
        }
        
        public static Vector3 ToVector3(this Vector2Int vector)
        {
            return new Vector3(vector.x, vector.y, 0);
        }

        public static Vector2 ToVector2(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }
        
        public static float ToDegrees(this Vector3 vector)
        {
            return Vector3.SignedAngle(vector, Vector3.forward, Vector3.up);
        }

        public static Vector3 Sum(this List<Vector3> vectorList)
        {
            var result = Vector3.zero;
            foreach (var vector in vectorList)
            {
                result += vector;
            }

            return result;
        }

        public static Quaternion ToTargetRotation(this Vector3 targetVector)
        {
            var angle = Mathf.Atan2(targetVector.y, targetVector.x) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}