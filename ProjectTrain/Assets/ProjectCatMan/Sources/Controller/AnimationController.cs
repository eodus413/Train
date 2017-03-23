using System;
using UnityEngine;

namespace ProjectCatMan
{
    public abstract class AnimationController : IController,IExecutableController
    {
        public AnimationController(Animator animator)
        {
            this.animator = animator;
        }
        
        public abstract void Execute();

        public readonly Animator animator;
    }
    public class UnitAnimationController : AnimationController
    {
        public UnitAnimationController(UnitBase unit,Animator animator) : base(animator)
        {
            this.unit = unit;

            isMoving = AnimationParameters.isMoving.Name();
            Attacking
        }

        public override void Execute()
        {
            animator.SetBool(,unit.isMoving);
            animator.SetBool(A, unit.isBackMoving);
            animator.
        }

        public readonly UnitBase unit;

        public readonly string isMoving;
        public readonly string Attacking;
        public readonly string isDead;
        public readonly string Damaged; 


    }
}