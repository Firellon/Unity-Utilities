using System.Collections;
using UnityEngine;

namespace Utilities
{
    public static class GameObjectExtensions
    {
        public static void SetMaterialTextureRecursively(this GameObject gameObject, Texture texture)
        {
            foreach (var renderer in gameObject.GetComponentsInChildren<MeshRenderer>())
            {
                var materials = renderer.materials;

                for (var i = 0; i < renderer.materials.Length; i++) materials[i].SetTexture("_MainTex", texture);

                renderer.materials = materials;
            }
        }

        public static void SetLayerRecursively(this GameObject gameObject, int layerNumber)
        {
            if (gameObject == null) return;
            foreach (var trans in gameObject.GetComponentsInChildren<Transform>(true)) trans.gameObject.layer = layerNumber;
        }

        public static int ToLayer(this LayerMask layerMask)
        {
            var layerNumber = 0;
            var layer = layerMask.value;

            while (layer > 0)
            {
                layer = layer >> 1;
                layerNumber++;
            }

            return layerNumber - 1;
        }

        public static void WaitForEffectEndAndDestroy(this MonoBehaviour behaviour, GameObject effect)
        {
            var effectParticle = effect.GetComponent<ParticleSystem>();

            behaviour.StartCoroutine(WaitForEffectEndAndDestroy(effectParticle));
        }

        private static IEnumerator WaitForEffectEndAndDestroy(ParticleSystem effect)
        {
            yield return new WaitForSeconds(effect.main.duration);

            GameObject.Destroy(effect.gameObject);
        }

        /// <summary>
        /// Checks if a GameObject has been destroyed.
        /// </summary>
        /// <param name="gameObject">GameObject reference to check for destructedness</param>
        /// <returns>If the game object has been marked as destroyed by UnityEngine</returns>
        public static bool IsDestroyed(this GameObject gameObject)
        {
            // UnityEngine overloads the == operator for the GameObject type
            // and returns null when the object has been destroyed, but 
            // actually the object is still there but has not been cleaned up yet
            // if we test both we can determine if the object has been destroyed.
            return gameObject == null && !ReferenceEquals(gameObject, null);
        }
    }
}