using System.Collections;
namespace Entity
{
    public interface IAttackBehavior
    {
        void Attack();
    }
}
namespace Entity
{
    using Weapon;
    public class AttackWithWeapon : IAttackBehavior
    {
        //생성자
        public AttackWithWeapon(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        //인터페이스
        public IWeapon weapon { get; private set; }
        public void Attack()
        {
            if (weapon.isReadyForAttack)
            {
                weapon.Attack();
            }
        }
    }
}
