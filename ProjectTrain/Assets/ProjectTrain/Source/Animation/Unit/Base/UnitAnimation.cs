using UnityEngine;

namespace ProjectTrain
{
    public partial class UnitAnimation
    {
        private Animator _animator;
        public Animator animator
        {
            get { return _animator; }

            private set { _animator = value; }
        }
        
        const string IsDead = "IsDead";
        const string Moving = "Moving";
        const string Attacking = "Attacking";
        const string Damaged = "Damaged";
    }
}