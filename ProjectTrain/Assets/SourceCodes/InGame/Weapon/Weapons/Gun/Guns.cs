using UnityEngine;
using Entity;

namespace Weapon
{
    public struct GunInfo
    {
        //생성자
        public GunInfo(GunType gunType, AmmoType ammoType)
        {
            this.gunType = gunType;
            this.ammoType = ammoType;

            infoToString = " Type : " + gunType.ToString() + " AmmoType : " + ammoType.ToString();
        }
        //인터페이스
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
    using Projectile;
    using LayerManager;
    using System.Collections;
    using ObjectPool;
    public class Gun : IWeapon
    {
        //생성자
        public Gun(EntityBase owner, int damage, float startDelay, float cooltime, float reloadDelay, int maxAmmo, GunInfo info, Transform shotPoint)
        {
            this.owner = owner;
            this.damage = damage;
            this.startDelay = startDelay;
            this.cooltime = cooltime;

            this.reloadDelay = reloadDelay;
            this.info = info;

            this.maxAmmo = maxAmmo;
            ammoAmount = maxAmmo;

            this.shotPoint = shotPoint;

            magazine = new Magazine(this);
        }

        //IWeapon 인터페이스
        public WeaponType weaponType { get { return WeaponType.Gun; } }

        public bool isReadyForAttack
        {
            get
            {
                if (isShoting) return false;
                if (isReloading) return false;
                if (noAmmo)
                {
                    Reload();
                    return false;
                }
                return true;
            }
        }

        public int damage { get; private set; }
        public float startDelay { get; private set; }
        public float cooltime { get; private set; }

        public EntityBase owner { get; private set; }

        public void AttackTarget()
        {
            if (isReadyForAttack == false) return;
            owner.StartCoroutine(DoShot());
        }

        //Gun 인터페이스
        public Magazine magazine { get; private set; }

        public GunInfo info { get; private set; }

        public float reloadDelay { get; private set; }

        public int ammoAmount { get; private set; }
        public readonly int maxAmmo;

        public Transform shotPoint { get; private set; }

        public GunType gunType { get { return info.gunType; } }
        public AmmoType ammoType { get { return info.ammoType; } }

        public void Reload()
        {
            if (isReloading) return;

            owner.animator.Play("Reload");
            owner.StartCoroutine(DoReload());
        }

        public float remainAmmoPercent { get { return (float)ammoAmount / maxAmmo; } }
        
        //ToString
        public string GunInfosToString()
        {
            return " Type : " + gunType.ToString();
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

            isReloading = false;
            ammoAmount = maxAmmo;
            Debug.Log("Reload End");
            Debug.Log("Reload => ammo : " + ammoAmount);
        }


        private bool isShoting = false;
        private IEnumerator DoShot()
        {
            isShoting = true;
            --ammoAmount;
            
            yield return new WaitForSeconds(startDelay);
            //Sound
            Bullet bullet = magazine.GetBullet();

            bullet.gameObject.SetActive(true);
            bullet.Fire(owner.lookDirection);
            bullet.transform.position = shotPoint.position;

            yield return new WaitForSeconds(cooltime);
            isShoting = false;
        }
    }
}