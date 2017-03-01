using UnityEngine;

namespace ProjectTrain.Weapon
{
    public abstract partial class WeaponBase : MonoBehaviour
    {
        protected virtual IAttackable GetTarget()     //타겟을 가져오는 방식은 모두 다르기 때문에 하위 클래스에서 정의
        {
            return null;
        }
        protected virtual void Attack(IAttackable target)
        {
            target.Attacked(new AttackData(damage,transform.right,owner));
        }
    }
}