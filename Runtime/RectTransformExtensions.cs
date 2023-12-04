using UnityEngine;

namespace Utilities
{
    public static class RectTransformExtensions
    {
        public static void SetAnchorY(this RectTransform rectTransform, Vector2 newAnchorY)
        {
            var anchorX = new Vector2(rectTransform.anchorMin.x, rectTransform.anchorMax.x);
            rectTransform.anchorMin = new Vector2(anchorX.x, newAnchorY.x);
            rectTransform.anchorMax = new Vector2(anchorX.y, newAnchorY.y);
        }

        public static void SetAnchorMinY(this RectTransform rectTransform, float newAnchorMinY)
        {
            rectTransform.anchorMin = new Vector2(rectTransform.anchorMin.x, newAnchorMinY);
        }
        
        public static void SetAnchorMaxY(this RectTransform rectTransform, float newAnchorMaxY)
        {
            rectTransform.anchorMax = new Vector2(rectTransform.anchorMax.x, newAnchorMaxY);
        }
        
        public static void SetCanvasPosition(this RectTransform rectTransform, Vector3 position)
        {
            rectTransform.anchoredPosition = position;
        }
    }
}