using UnityEngine;

namespace ProjectTrain
{
    public class PlayerAnimation : UnitAnimation
    {
        Player player;

        const string BackMoving = "BackMoving";
        public override void SetMoving(bool value)
        {
            if (player.lookingDirection == player.moveDirection)
            {
                base.SetMoving(value);
                animator.SetBool(BackMoving, false);
            }
            else 
            {
                animator.SetBool(BackMoving, value);
                base.SetMoving(false);
            }
        }
        public PlayerAnimation(Player player,Animator animator) : base(animator)
        {
            this.player = player;
        }
    }
}
