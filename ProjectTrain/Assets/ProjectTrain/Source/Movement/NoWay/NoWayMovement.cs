using UnityEngine;

namespace ProjectTrain
{
    public class NoWayMovement : MovementBase
    {
        public NoWayMovement(Transform transform) : base(transform,0)
        {

        }
        protected override void Move(Vector3 direction,float newSpeed)
        {
            //No Way to move
        }
    }
}