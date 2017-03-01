using UnityEngine;

namespace ProjectTrain
{
    public partial class UnitAnimation
    {
        public void SetIdle(bool value)
        {
            animator.SetBool(Moving, value);
            animator.SetBool(Attacking, value);
            animator.SetBool(Damaged, value);
        }

        public void SetIsDead(bool value)
        {
            animator.SetBool(IsDead,value);
        }
        public virtual void SetMoving(bool value)
        {
            animator.SetBool(Moving, value);
        }
        public void SetAttacking(bool value)
        {
            animator.SetBool(Attacking, value);
        }
        public void SetDamaged(bool value)
        {
            if (value) animator.Play(Damaged);
            else animator.Play(Idle);
        }
    }
}