using UnityEngine;
using Entity;

namespace Weapon.Factory
{
    public static class WeaponGenerator
    {
        static PistolFactory pistolFactory = new PistolFactory();
        static ShotGunFactory shotgunFactroy = new ShotGunFactory();
        static RifleFactory rifleFactory = new RifleFactory();
        static SniperFactory sniperFactory = new SniperFactory();
        static SubMachineFactory subMachineFactory = new SubMachineFactory();

        static MachineGunFactory machineGunFactory = new MachineGunFactory();

        public static Gun CreateGun(EntityBase owner,GunType gunType)
        {
            IGunFactory factory;

            if (gunType == GunType.Pistol) factory = pistolFactory;
            else if (gunType == GunType.ShotGun) factory = shotgunFactroy;
            else if (gunType == GunType.MachineGun) factory = machineGunFactory;
            else if (gunType == GunType.Rifle) factory = rifleFactory;
            else if (gunType == GunType.Sniper) factory = sniperFactory;
            else if (gunType == GunType.SubMachine) factory = subMachineFactory;
            else return null;

            GunInfo info = new GunInfo(gunType, factory.ammoType);

            return new Gun(
                owner,
                factory.damage, 
                factory.startDelay,
                factory.cooltime,
                factory.reloadDelay,
                factory.maxAmmo,
                info,
                GetShotPoint(owner,gunType,factory.shotPosition).transform
                );
        }
        static GameObject GetShotPoint(EntityBase owner,GunType gunType, Vector2 position)
        {
            GameObject instance = new GameObject(gunType.ToString());

            instance.transform.SetParent(owner);
            instance.transform.localPosition = position;

            return instance;
        }

        public static MeleeWeapon CreateMeleeWeapon(EntityBase owner)
        {
            return new MeleeWeapon(owner, 1);
        }

    }
    internal interface IWeaponFactory
    {    
        int damage { get; }
        float startDelay { get; }
        float cooltime { get; }

        AmmoType ammoType { get; }
        int maxAmmo { get; }
        
        Vector2 shotPosition { get; }
    }
}