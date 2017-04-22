using UnityEngine;
using Entity;

namespace Weapon
{
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
}
namespace Weapon
{
    using LayerManager;
    using System.Collections;
    using Raycast2DManager;
    public class Gun : IWeapon
    {
        //생성자
        public Gun(EntityBase owner, int damage, float distance, float startDelay, float cooltime, float reloadDelay, int maxAmmo, GunInfo info, Transform shotPoint)
        {
            this.owner = owner;
            this.damage = damage;
            this.distance = distance;
            this.startDelay = startDelay;
            this.cooltime = cooltime;

            this.reloadDelay = reloadDelay;
            this.info = info;

            this.maxAmmo = maxAmmo;
            ammoAmount = maxAmmo;

            this.shotPoint = shotPoint;

            detect = owner.entityType.GetEnemyLayerMask();
            deny = Layers.GroundMask;
        }

        //IWeapon 인터페이스
        public WeaponType weaponType { get { return WeaponType.Gun; } }

        public bool isReadyForAttack
        {
            get
            {
                if (isShoting) return false;
                if (isReloading) return false;
                return !noAmmo;
            }
        }

        public int damage { get; private set; }
        public float distance { get; private set; }
        public float startDelay { get; private set; }
        public float cooltime { get; private set; }

        public EntityBase owner { get; private set; }

        public void Attack()
        {
            if (isReadyForAttack == false) return;
            owner.StartCoroutine(DoShot());
        }

        //Gun 인터페이스
        public float reloadDelay { get; private set; }

        public GunInfo info { get; private set; }

        public int ammoAmount { get; private set; }
        public readonly int maxAmmo;

        public Transform shotPoint { get; private set; }

        public void Reload()
        {
            if (isReloading) return;

            owner.StartCoroutine(DoReload());
        }

        //ToString
        public string GunInfosToString()
        {
            return "Name : " + info.name + " Type : " + info.gunType.ToString();
        }
        public override string ToString()
        {
            return base.ToString() + GunInfosToString();
        }


        //구현
        private bool noAmmo
        {
            get { return ammoAmount <= 0; }
        }

        private bool isReloading = false;
        private IEnumerator DoReload()
        {
            isReloading = true;
            Debug.Log("Reload Start");
            yield return new WaitForSeconds(reloadDelay);
            ammoAmount = maxAmmo;
            Debug.Log("Reload End");
            Debug.Log("Reload => ammo : " + ammoAmount);

            isReloading = false;
        }
        private bool isShoting = false;
        private IEnumerator DoShot()
        {
            isShoting = true;
            --ammoAmount;
            
            yield return new WaitForSeconds(startDelay);
            //Sound
            EntityBase target = TargetingTarget();
            if (target)
            {
                target.Attacked(new AttackData(owner, damage, owner.lookDirection));
            }
            yield return new WaitForSeconds(cooltime);
            isShoting = false;
        }
        LayerMask detect;
        LayerMask deny;
        private EntityBase TargetingTarget()
        {
            GameObject hitObj = Ray2DManager.StartCasting(shotPoint.position, owner.lookDirection, distance, detect, deny);

            if (hitObj == null) return null;

            return hitObj.GetComponent<EntityBase>();
        }
    }
}