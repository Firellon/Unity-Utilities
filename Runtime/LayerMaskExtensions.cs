using UnityEngine;

namespace Utilities
{
    public static class LayerMaskExtensions
    {
        /// <summary>
        /// Extension method to check if a layer is in a layermask
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static bool Contains(this LayerMask mask, int layer)
        {
            return mask == (mask | (1 << layer));
        }

        public static bool Contains(this int mask, int layer)
        {
            return mask == (mask | (1 << layer));
        }

        /// <summary> Converts given layermask to layer number </summary>
        /// <returns> Layer number </returns>
        /// <assert> Mask represents multiple layers </assert>
        private static int MaskToLayer(LayerMask mask)
        {
            var bitmask = mask.value;

            UnityEngine.Assertions.Assert.IsFalse((bitmask & ( bitmask - 1 )) != 0,
                "MaskToLayer() was passed an invalid mask containing multiple layers." );

            int result = bitmask > 0 ? 0 : 31;
            while(bitmask > 1)
            {
                bitmask >>= 1;
                result++;
            }

            return result;
        }

        /// <summary> Converts layermask to layer number </summary>
        public static int ToLayer(this LayerMask mask)
        {
            return MaskToLayer(mask);
        }
    }
}