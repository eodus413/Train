using UnityEngine;

namespace ProjectTrain
{
    public class TargetingHorizontal : Targeting
    {
        public override bool TargetIsInSight()
        {
            return Mathf.Abs(_target.transform.position.x - owner.position.x) < sight;
        }
        public TargetingHorizontal(Transform owner,LayerMask mask,LayerMask denyMask,float sight) : base(owner,mask, denyMask, sight)
        {

        }
    }
}