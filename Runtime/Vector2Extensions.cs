using UnityEngine;

namespace Utilities
{
    public static class Vector2Extensions
    {
        /// <summary>
        /// Converts Vector2 to Vector2Int, rounding coordinates down
        /// </summary>
        /// <param name="vector2"></param>
        /// <returns>Vector2Int</returns>
        public static Vector2Int ToVector2Int(this Vector2 vector2)
        {
            return new Vector2Int((int) vector2.x, (int) vector2.y);
        }
        
        public static int ManhattanDistance(Vector2Int positionA, Vector2Int positionB)
        {
            return Mathf.Abs(positionB.x - positionA.x) + Mathf.Abs(positionB.y - positionA.y);
        }

        public static float ManhattanDistance(Vector2 positionA, Vector2 positionB)
        {
            return Mathf.Abs(positionB.x - positionA.x) + Mathf.Abs(positionB.y - positionA.y);
        }
        
        public static int ChebyshevDistance(Vector2Int positionA, Vector2Int positionB)
        {
            return Mathf.Max(Mathf.Abs(positionB.x - positionA.x), Mathf.Abs(positionB.y - positionA.y));
        }

        public static float ChebyshevDistance(Vector2 positionA, Vector2 positionB)
        {
            return Mathf.Max(Mathf.Abs(positionB.x - positionA.x), Mathf.Abs(positionB.y - positionA.y));
        }
        
        /// <summary>
        /// Returns true if provided positions are located on the same vertical or horizontal line (meaning that their X or Y positions are the same)
        /// </summary>
        /// <param name="positionA"></param>
        /// <param name="positionB"></param>
        /// <returns></returns>
        public static bool IsOnCardinalLineWith(this Vector2Int positionA, Vector2Int positionB)
        {
            return positionA.x == positionB.x || positionA.y == positionB.y;
        }

        /// <summary>
        /// Returns true if provided positions are located on the same diagonal line (meaning that their X and Y position differences are the same)
        /// </summary>
        /// <param name="positionA"></param>
        /// <param name="positionB"></param>
        /// <returns></returns>
        public static bool IsOnDiagonalLineWith(this Vector2Int positionA, Vector2Int positionB)
        {
            return Mathf.Abs(positionA.x - positionB.x) == Mathf.Abs(positionA.y - positionB.y);
        }

        public static Quaternion ToTargetRotation(this Vector2 targetVector)
        {
            return ((Vector3) targetVector).ToTargetRotation();
        }
    }
}