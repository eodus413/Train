using UnityEngine;

namespace ProjectTrain
{
    public partial class MonsterBase : Unit
    {
        public override void Attacked(AttackData data)
        {
            base.Attacked(data);
            Vector3 attackerPos = data.attacker.transform.position;
            if (attackerPos.isLeft(transform.position))
            {
                lookingDirection = Direction.Left;
            }
            else
            {
                lookingDirection = Direction.Right;
            }
        }

        protected override bool isDoingAttack()
        {
            if (targeting.target == null) return false;
            if (TargetIsInArea() == false) return false;
            return true;
        }
        protected override void Attack()
        {
            prevAttackData.Set(damage, lookingDirection.DirToVec2(), this);

            animation.SetAttacking(true);
            
            targeting.target.GetComponent<Unit>().Attacked(prevAttackData);
        }

        protected override void Idle()
        {
            if (targeting.target != null) return;

            TargetingExecute();
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
            movement.Move(moveDirection.DirToVec2());

            animation.SetMoving(true);
        }
    }
}