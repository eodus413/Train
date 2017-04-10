using UnityEngine;
using Entity;

namespace Weapon
{
    using LayerManager;
    public struct GunInfo
    {
        //생성자
        public GunInfo(string name, GunType gunType, AmmoType ammoType)
        {
            this.name = name;
            this.gunType = gunType;
            this.ammoType = ammoType;

            infoToString = " Name : " + name + " Type : " + gunType.ToString() + " AmmoType : " + ammoType.ToString();
        }
        //인터페이스
        public string name;
        public GunType gunType;
        public AmmoType ammoType;

        string infoToString;

        public override string ToString()
        {
            return infoToString;
        }
    }

    public class Gun : IWeapon
    {
        //생성자
        public Gun(EntityBase owner, IAttackMethod attackMethod, int damage, float attackRange, float startDelay/*float recharge delay*/,int maxAmmo, GunInfo info, Transform shotPoint)
        {
            this.owner = owner;
            this.attackMethod = attackMethod;
            this.damage = damage;
            this.attackRange = attackRange;
            this.startDelay = startDelay;
            
            this.info = info;
            this.maxAmmo = maxAmmo;
            ammoAmount = maxAmmo;

            targetingMethod = new TargetingToLookDirection
                (shotPoint.transform
                , attackRange
                , owner.type
                , Layers.GroundMask,
                owner);
        }

        //IWeapon 인터페이스
        public IAttackMethod attackMethod { get; private set; }

        public bool isReadyForAttack
        {
            get { return !noAmmo; }
        }

        public int damage { get; private set; }
        public float attackRange { get; private set; }
        public float startDelay { get; private set; }

        public EntityBase owner { get; private set; }

        public void Attack()
        {
            DoShot();
            targetingMethod.Targeting();
            Debug.Log("ammo : " + ammoAmount);
            if (targetEntity == null) return;
            owner.StartCoroutine(attackMethod.Attack(targetEntity));
        }

        //Gun 인터페이스
        public GunInfo info { get; private set; }

        public int ammoAmount { get; private set; }
        public readonly int maxAmmo;

        public ITargetingMethod targetingMethod { get; private set; }

        public void Reload()
        {
            ammoAmount = maxAmmo;
            Debug.Log("ammo : " + ammoAmount);
        }

        //ToString
        public string GunInfosToString()
        {
            return " Type : " + info.gunType.ToString();
        }
        public override string ToString()
        {
            return base.ToString() + GunInfosToString();
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
            --ammoAmount;
            //Sound
        }
        private bool noAmmo
        {
            get { return ammoAmount <= 0; }
        }
    }
}