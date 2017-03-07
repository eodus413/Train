using UnityEngine;

namespace ProjectTrain
{
    public class TargettingInRect : Targeting
    {
        public override bool TargetIsInSight()
        {
            Vector2 curPos = owner.position;
            float horizontalDistance = Mathf.Abs(owner.position.x - _target.transform.position.x);
            if (horizontalDistance > sight) return false;

            float verticalDistance = Mathf.Abs(owner.position.y - _target.transform.position.y);
            if (verticalDistance > 0.1f) return false;

            return true;
        }

        public TargettingInRect(Transform owner,LayerMask mask,LayerMask denyMask, float sight) : base(owner,mask,denyMask,sight)
        {
        }
    }
}