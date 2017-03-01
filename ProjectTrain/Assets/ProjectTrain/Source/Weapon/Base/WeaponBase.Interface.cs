using UnityEngine;

namespace ProjectTrain.Weapon
{
    public abstract partial class WeaponBase  : MonoBehaviour
    { 
        public void Reload(int ammoAmount)
        {
            animator.Play(reloadAnimationName);
            magazine.Reload(ammoAmount);
        }

        IAttackable target;
        public virtual void Shot()
        {
            //currentCoolTime > 0 return;
            animator.Play(shotAnimationName);
            target = GetTarget();
            if (target == null) return;
            else Attack(target);

            target = null;
        }
    }
}
