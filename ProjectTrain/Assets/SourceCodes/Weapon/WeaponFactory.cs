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

        public static Gun CreateGun(EntityBase owner,GunType gunType,string name)
        {
            IWeaponFactory factory;

            if (gunType == GunType.Pistol) factory = pistolFactory;
            else if (gunType == GunType.ShotGun) factory = shotgunFactroy;
            else if (gunType == GunType.MachineGun) factory = machineGunFactory;
            else return null;

            GunInfo info = new GunInfo(name, gunType, factory.ammoType, factory.maxAmmo);

            return new Gun(
                owner,
                factory.GetAttackMethod(owner),
                factory.damage, 
                factory.range,
                factory.delay,
                info,
                GetShotPoint(owner,gunType,factory.shotPosition).transform);
        }
        static GameObject GetShotPoint(EntityBase owner,GunType gunType, Vector2 position)
        {
            GameObject instance = new GameObject(gunType.ToString());

            instance.transform.SetParent(owner);
            instance.transform.localPosition = position;

            return instance;
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
        
        Vector2 shotPosition { get; }
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

        readonly Vector2 _shotPosition = new Vector2(0.1f,0.04f);
        public  Vector2 shotPosition
        {
            get { return _shotPosition; }
        }
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

        
        readonly Vector2 _shotPosition = new Vector2(0.1f, 0.04f);
        public Vector2 shotPosition
        {
            get { return _shotPosition; }
        }
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


        readonly Vector2 _shotPosition = new Vector2(0.1f, 0.04f);
        public Vector2 shotPosition
        {
            get { return _shotPosition; }
        }
    }
}