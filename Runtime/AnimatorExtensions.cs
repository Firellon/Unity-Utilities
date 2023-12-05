using UnityEngine;

namespace Utilities
{
    public static class AnimatorExtensions
    {
		/**
		* ???
		*/
        public static bool IsCurrentAnimationName(this Animator animator, string name)
        {
            return animator.GetCurrentAnimatorStateInfo(0).IsName(name);
        }
		/**
		*  Returns the length of an animation in the provided Animator by a provided name, seconds
		*/
        public static float GetAnimationLength(this Animator animator, string name)
        {
            var time = 0f;
            var controller = animator.runtimeAnimatorController;

            foreach (var clip in controller.animationClips)
                if (clip.name == name)
                    time = clip.length;

            return time;
        }
    }
}