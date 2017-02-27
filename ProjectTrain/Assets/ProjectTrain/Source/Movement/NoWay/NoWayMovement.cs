using UnityEngine;

namespace ProjectTrain
{
    public class NoWayMovement : MovementBase
    {
        public NoWayMovement(Transform transform) : base(transform,0)
        {

        }
        public override void Move(Vector3 direction)
        {
            //No Way to move
        }
        public override void MoveBack(Vector3 direction)
        {
            //No Way to move
        }
    }
}