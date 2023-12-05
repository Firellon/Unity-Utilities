using UnityEngine;

namespace Utilities
{
    public static class AngleExtensions
    {
        /// <summary>
        /// Converts a float angle in degrees into a 2-dimensional Vector3
        /// </summary>
        /// <param name="angle">Angle in degrees</param>
        /// <returns>Vector3</returns>
        public static Vector3 ToVector3(this float angle)
        {
            return new Vector3(
                Mathf.Cos(angle * Mathf.Deg2Rad), 
                Mathf.Sin(angle * Mathf.Deg2Rad), 
                0);
        }
        
        /// <summary>
        /// Converts a float angle in degrees into a Vector2Int
        /// </summary>
        /// <param name="angle">Angle in degrees</param>
        /// <returns></returns>
        public static Vector2Int ToVector2Int(this int angle)
        {
            var directionRadians = Mathf.Deg2Rad * angle;
            return new Vector2Int(
                Mathf.RoundToInt(Mathf.Sin(directionRadians)),
                Mathf.RoundToInt(Mathf.Cos(directionRadians))
            );
        }
		
        /// <summary>
        /// Converts Vector2 to float angle in degrees between that vector and (1, 0)
        /// </summary>
        /// <param name="vector2"></param>
        /// <returns>Angle in degrees</returns>
        public static float ToAngle(this Vector2 vector2)
        {
            if (vector2.x < 0)
                return 360 - Mathf.Atan2(vector2.x, vector2.y) * Mathf.Rad2Deg * -1;
            return Mathf.Atan2(vector2.x, vector2.y) * Mathf.Rad2Deg;
        }
        /// <summary>
        /// Converts Vector2Int to float angle in degrees between that vector and (1, 0)
        /// </summary>
        /// <param name="vector"></param>
        /// <returns>Angle in degrees</returns>
        public static int ToAngle(this Vector2Int vector)
        {
            return Mathf.RoundToInt(Mathf.Atan2(vector.x, vector.y) * Mathf.Rad2Deg);
        }

        /// <summary>
        /// Bounds an angle into (-180, 180]
        /// </summary>
        /// <param name="angle">Angle in degrees</param>
        /// <returns>Same Angle in degrees within (-180,180]</returns>
        public static float NormalizeAngle(float angle)
        {
            angle %= 360;
            angle = angle > 180 ? angle - 360 : angle;

            return angle;
        }

        /// <summary>
        /// Bounds an angle into (-180, 180]
        /// </summary>
        /// <param name="angle">Angle in degrees</param>
        /// <returns>Same Angle in degrees within (-180,180]</returns>
        public static int NormalizeAngle(int angle)
        {
            var normalisedAngle = angle % 360;
            return normalisedAngle > 180 ? normalisedAngle - 360 : normalisedAngle;
        }
	
        /// <summary>
        /// Bounds an angle into [0, 360)
        /// </summary>
        /// <param name="angle">Angle in degrees</param>
        /// <returns>Same Angle in degrees within [0, 360)</returns>
        public static float NormalizeAngle360(float angle)
        {
            return (angle % 360 + 360) % 360;
        }
        /// <summary>
        /// Bounds an angle into [0, 360)
        /// </summary>
        /// <param name="angle">Angle in degrees</param>
        /// <returns>Same Angle in degrees within [0, 360)</returns>
        public static int NormalizeAngle360(int angle)
        {
            return (angle % 360 + 360) % 360;
        }

		/// <summary>
		/// Returns true if the provided angle in degrees is between the angle1 and angle2 in terms of its size
		/// </summary>
		/// <param name="angleToCheck"></param>
		/// <param name="angle1"></param>
		/// <param name="angle2"></param>
		/// <returns></returns>
        public static bool IsAngleBetween(float angleToCheck, float angle1, float angle2)
        {
            var smallestAngle = Mathf.Abs(Mathf.DeltaAngle(angle1, angle2));

            var angle1Delta = Mathf.Abs(Mathf.DeltaAngle(angleToCheck, angle1));
            var angle2Delta = Mathf.Abs(Mathf.DeltaAngle(angleToCheck, angle2));

            return angle1Delta + angle2Delta <= smallestAngle;
        }

		/// <summary>
		/// ???
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <param name="toCheck"></param>
		/// <returns></returns>
        public static float VectorDegreesNormalized(Vector3 left, Vector3 right, Vector3 toCheck)
        {
            var funnelAngle = Vector3.Angle(left, right);
            var checkAngle = Vector3.SignedAngle(left, toCheck, Vector3.Cross(left, right));
            return checkAngle / funnelAngle;
        }
    }
}