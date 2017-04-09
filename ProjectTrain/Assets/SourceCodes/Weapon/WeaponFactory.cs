using UnityEngine;
using LayerManager;
using Entity;

namespace Weapon.Factory
{
    public static class WeaponGenerator
    {
        static PistolFactory pistolFactory = new PistolFactory();
        static ShotGunFactory shotgunFactroy = new ShotGunFactory();
        static MachineGunFactory machineGunFactory = new MachineGunFactory();

        public static Gun CreateGun(EntityBase owner,GunType type,string name)
        {
            IWeaponFactory factory;

            if (type == GunType.Pistol) factory = pistolFactory;
            else if (type == GunType.ShotGun) factory = shotgunFactroy;
            else if (type == GunType.MachineGun) factory = machineGunFactory;
            else return null;

            GunInfo info = new GunInfo(name, type, factory.ammoType, factory.maxAmmo);

            return new Gun(owner, factory.GetAttackMethod(owner), factory.damage, factory.range, factory.delay, info);
        }
    }
    internal interface IWeaponFactory
    {
        IAttackMethod GetAttackMethod(EntityBase entity);
        TargetingByRaycast GetTargetingMethod(EntityBase entity);
        
        int damage { get; }
        float range { get; }
        float delay { get; }

        AmmoType ammoType { get; }
        int maxAmmo { get; }
    }
    internal class PistolFactory : IWeaponFactory
    {
        public IAttackMethod GetAttackMethod(EntityBase entity)
        {
            return new DefaultAttack(entity,damage,delay,range);
        }
        Vector2 shotPointPosition = new Vector2(0.04f, 0.1f);
        public TargetingByRaycast GetTargetingMethod(EntityBase entity)
        {
            GameObject shotPoint = new GameObject(GunType.Pistol.ToString());
            shotPoint.transform.SetParent(entity);
            shotPoint.transform.localPosition = shotPointPosition;

            return new TargetingBlockedToGround(shotPoint.transform,range,entity.type);
        }

        public int damage { get { return 1; } }

        public float range { get { return 1f; } }

        public float delay { get { return 1f; } }

        public AmmoType ammoType { get { return AmmoType.Small; } }

        public int maxAmmo { get { return 8; } }
    }
    internal class ShotGunFactory : IWeaponFactory
    {
        public IAttackMethod GetAttackMethod(EntityBase entity)
        {
            return new DefaultAttack(entity,damage,delay,range);
        }
        Vector2 shotPointPosition = new Vector2(0.04f, 0.1f);
        public TargetingByRaycast GetTargetingMethod(EntityBase entity)
        {
            GameObject shotPoint = new GameObject(GunType.Pistol.ToString());
            shotPoint.transform.SetParent(entity);
            shotPoint.transform.localPosition = shotPointPosition;

            return new TargetingBlockedToGround(shotPoint.transform, range, entity.type);
        }

        public int damage { get { return 1; } }

        public float range { get { return 1f; } }

        public float delay { get { return 1f; } }

        public AmmoType ammoType { get { return AmmoType.Small; } }

        public int maxAmmo { get { return 8; } }
    }
    internal class MachineGunFactory : IWeaponFactory
    {
        public IAttackMethod GetAttackMethod(EntityBase entity)
        {
            return new DefaultAttack(entity,damage,range,delay);
        }
        Vector2 shotPointPosition = new Vector2(0.04f, 0.1f);
        public TargetingByRaycast GetTargetingMethod(EntityBase entity)
        {
            GameObject shotPoint = new GameObject(GunType.MachineGun.ToString());
            shotPoint.transform.SetParent(entity);
            shotPoint.transform.localPosition = shotPointPosition;

            return new TargetingBlockedToGround(shotPoint.transform, range, entity.type);
        }

        public int damage { get { return 1; } }

        public float range { get { return 1f; } }

        public float delay { get { return 1f; } }

        public AmmoType ammoType { get { return AmmoType.Small; } }

        public int maxAmmo { get { return 8; } }
    }
}