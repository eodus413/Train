using UnityEngine;

namespace ProjectTrain
{
    public partial class MonsterBase : Unit
    {
        protected override bool isDoingAction()
        {
            return true;
        }
        protected override void Action()
        {
        }


        protected override bool isDoingAttack()
        {
            if (targeting.target == null) return false;
            
            return TargetIsInArea();
        }
        protected override void Attack()
        {
            state.Set(State.attack);

            animation.SetAttacking(true);


            if (targeting.target == null) return;
            targeting.target.GetComponent<Unit>().Attacked(damage);
        }
        protected override bool isIdle()
        {
            if (targeting.target != null) return false;

            return true;
        }
        protected override void Idle()
        {
            targeting.Execute(lookingDirection.DirToVec2());
            movement.Idle();
            state.SetIdle();
        }


        protected override bool isDoingMove()
        {
            if (targeting.target == null) return false;

            if (TargetIsInArea()) return false;

            if (targeting.TargetIsLeft())
            {
                lookingDirection = Direction.Left;
                moveDirection = Direction.Left;
            }
            else
            {
                lookingDirection = Direction.Right;
                moveDirection = Direction.Right;
            }
            return true;
        }
        protected override void Move()
        {
            if (state.Is(State.attack)) return;
            state.Set(State.move);
            
            movement.Move(moveDirection.DirToVec2());

            animation.SetMoving(true);
        }
    }
}