using UnityEngine;
using Entity;

namespace Weapon
{
    public struct GunInfo
    {
        //생성자
        public GunInfo(string name,GunType gunType,AmmoType ammoType,int maxAmmo)
        {
            this.name = name;
            this.gunType = gunType;
            this.ammoType = ammoType;
            this.maxAmmo = maxAmmo;

            infoToString = " Name : " + name + " Type : " + gunType.ToString() + " AmmoType : " + ammoType.ToString() + " MaxAmmo : " + maxAmmo.ToString();
        }
        //인터페이스
        public string name;
        public GunType gunType;
        public AmmoType ammoType;
        public int maxAmmo;

        string infoToString;

        public override string ToString()
        {
            return infoToString;
        }
    }

    public class Gun : IWeapon
    {
        //생성자
        public Gun(EntityBase owner,IAttackMethod attackMethod,int damage,float attackRange,float attackDelay,GunInfo info)
        {
            this.owner = owner;
            this.attackMethod = attackMethod;
            this.damage = damage;
            this.attackRange = attackRange;
            this.attackDelay = attackDelay;

            this.info = info;

            targetingMethod = new TargetingBlockedToGround(owner, attackRange, owner.type);
        }

        //IWeapon 인터페이스
        public IAttackMethod attackMethod { get; private set; }

        public bool isReadyForAttack
        {
            get { return ammoAmount > 0; }
        }

        public int damage { get; private set; }
        public float attackRange { get; private set; }
        public float attackDelay { get; private set; }

        public EntityBase owner { get; private set; }

        public void Attack()
        {
            if (targetEntity == null) return;
            if (isReadyForAttack)
            {
                DoShot();
            }
        }

        //Gun 인터페이스
        public GunInfo info { get; private set; }

        public int ammoAmount { get; private set; }
        public readonly int maxAmmoAmount;

        public ITargetingMethod targetingMethod { get; private set; }

        public void Reload()
        {
             
        }

        //ToString
        //고치기
        public string GunInfos()
        {
            return " Type : " + info.gunType.ToString();
        }
        public override string ToString()
        {
            return base.ToString() + GunInfos();
        }


        //구현
        private EntityBase targetEntity
        {
            get
            {
                if (targetingMethod.target == null) return null;
                return targetingMethod.target.GetComponent<EntityBase>();
            }
        }
        private void DoShot()
        {
            owner.StartCoroutine(attackMethod.Attack(targetEntity));
        }
    }
}