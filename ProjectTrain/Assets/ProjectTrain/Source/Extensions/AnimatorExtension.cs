using UnityEngine;

namespace ProjectTrain
{
    public static class AnimatorExtension
    {
        public static AnimationClip GetClip(this Animator animator, string clipName)
        {
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;

            for (int i = 0; i < clips.Length; ++i)
            {
                if (clips[i].name == clipName) return clips[i];
            }
            return null;
        }
    }
}