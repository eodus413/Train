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
            IGunFactory factory;

            if (gunType == GunType.Pistol) factory = pistolFactory;
            else if (gunType == GunType.ShotGun) factory = shotgunFactroy;
            else if (gunType == GunType.MachineGun) factory = machineGunFactory;
            else return null;

            GunInfo info = new GunInfo(name, gunType, factory.ammoType);

            return new Gun(
                owner,
                factory.damage, 
                factory.distance,
                factory.startDelay,
                factory.cooltime,
                factory.reloadDelay,
                factory.maxAmmo,
                info,
                GetShotPoint(owner,gunType,factory.shotPosition).transform,
                info.ammoType.GetBulletPrefab());
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
        int damage { get; }
        float distance { get; }
        float startDelay { get; }
        float cooltime { get; }

        AmmoType ammoType { get; }
        int maxAmmo { get; }
        
        Vector2 shotPosition { get; }
    }
    internal interface IGunFactory : IWeaponFactory
    {
        float reloadDelay { get; }
    }
    internal class PistolFactory : IGunFactory
    {
        public int damage { get { return 2; } }

        public float distance { get { return 1f; } }

        public float startDelay { get { return 0f; } }

        public float cooltime { get { return 1f; } }

        public AmmoType ammoType { get { return AmmoType.Small; } }

        public int maxAmmo { get { return 8; } }

        readonly Vector2 _shotPosition = new Vector2(0.05f,0.1f);
        public  Vector2 shotPosition
        {
            get { return _shotPosition; }
        }

        public float reloadDelay { get { return 1f; } }
    }
    internal class ShotGunFactory : IGunFactory
    {
        public int damage { get { return 25; } }

        public float distance { get { return 0.5f; } }

        public float startDelay { get { return 0.3f; } }

        public float cooltime { get { return 2f; } }

        public AmmoType ammoType { get { return AmmoType.Scatter; } }

        public int maxAmmo { get { return 4; } }

        
        readonly Vector2 _shotPosition = new Vector2(0.05f, 0.1f);
        public Vector2 shotPosition
        {
            get { return _shotPosition; }
        }

        public float reloadDelay { get { return 1f; } }
    }
    internal class MachineGunFactory : IGunFactory
    {
        public int damage { get { return 3; } }

        public float distance { get { return 1f; } }

        public float startDelay { get { return 0f; } }

        public float cooltime { get { return 0.1f; } }

        public AmmoType ammoType { get { return AmmoType.Small; } }

        public int maxAmmo { get { return 80; } }


        readonly Vector2 _shotPosition = new Vector2(0.05f, 0.1f);
        public Vector2 shotPosition
        {
            get { return _shotPosition; }
        }

        public float reloadDelay { get { return 1f; } }
    }
}