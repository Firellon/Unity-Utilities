using _Scripts.WizardsVGoblins.Battle.Cards;
using UnityEngine;

namespace Utilities
{
    public static class Vector2Extensions
    {
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
        
        public static bool IsOnCardinalLineWith(this Vector2Int positionA, Vector2Int positionB)
        {
            return positionA.x == positionB.x || positionA.y == positionB.y;
        }

        public static bool IsOnDiagonalLineWith(this Vector2Int positionA, Vector2Int positionB)
        {
            return Mathf.Abs(positionA.x - positionB.x) == Mathf.Abs(positionA.y - positionB.y);
        }
    }
}