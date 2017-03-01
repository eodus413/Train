using UnityEngine;

namespace ProjectTrain
{
    public class PlayerMovement : MovementBase
    {
        Player player;
        float speedMinus = 0.5f;
        public override void Move(Vector3 direction)
        {
            if(player.lookingDirection == player.moveDirection)
            {
                Move(direction, deltaSpeed);
            }
            else
            {
                Move(direction, deltaSpeed * speedMinus);
            }
        }
        public PlayerMovement(Transform transform,Player player,float speed = 1f) : base(transform,speed)
        {
            this.player = player;
        }
    }
}