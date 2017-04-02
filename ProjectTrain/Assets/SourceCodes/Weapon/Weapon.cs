using UnityEngine;
using Entity;
using Raycast2DManager;

namespace Weapon
{
    public interface IWeapon
    {
        IAttackMethod attackMethod { get; }

        bool isReadyForAttack { get; }
        int damage { get; }
        float attackRange { get; }
        float attackDelay { get; }
        Transform transform { get; }

        void Attack();
    }
    public partial class Gun : IWeapon
    {
        public IAttackMethod attackMethod { get; private set; }

        public bool isReadyForAttack
        {
            get { return ammoAmount > 0; }
        }
        public int damage { get; private set; }
        public float attackRange { get; private set; }
        public float attackDelay { get; private set; }
        public Transform transform { get; private set;}

        public void Attack()
        {
            if(isReadyForAttack)
            attackMethod.Attack();
        }
    }
    public partial class Gun : IWeapon
    {
        public GunType gunType { get; private set; }
        public AmmoType ammoType { get; private set; }

        public int ammoAmount { get; private set; }
        public readonly int maxAmmoAmount;


        public Gun(GunType gunType,Transform transform)
        {
            this.gunType = gunType;
            this.transform = transform;

            IWeaponFactory factory = WeaponSetter.GetFactory(gunType);

            attackMethod = factory.SetAttackMethod(transform);

            damage = factory.SetDamage();
            attackRange = factory.SetAttackRange();
            attackDelay = factory.SetAttackDelay();

            ammoType = factory.SetAmmoType();
            maxAmmoAmount = factory.SetMaxAmmoAmount();
            ammoAmount = factory.SetMaxAmmoAmount();
        }
    }
}