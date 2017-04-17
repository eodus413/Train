namespace Weapon
{
    public enum MeleeWeaponType
    {
        Cannie,
        Talon,
        Aculeus
    }
}
namespace Weapon
{
    using Entity;
    //근접무기
    public class MeleeWeapon : IWeapon
    {
        //생성자
        public MeleeWeapon(EntityBase owner)
        {

        }
        //인터페이스
        public WeaponType weaponType { get { return WeaponType.Sword; } }

        public bool isReadyForAttack { get; private set; }

        public int damage { get; private set; }
        public float attackRange { get; private set; }
        public float startDelay { get; private set; }
        public float cooltime { get; private set; }

        public EntityBase owner { get; private set; }

        public void Attack()
        {

        }
        //구현
    }
}