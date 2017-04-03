using UnityEngine;
using LayerManager;
using Entity;

namespace Weapon
{
    public static class WeaponSetter
    {
        public static PistolFactory pistol = new PistolFactory();
        public static ShotGunFactory shotgun = new ShotGunFactory();
        public static MachineGunFactory machineGun = new MachineGunFactory();


        public static IWeaponFactory GetFactory(GunType type)
        {
            if(type == GunType.Pistol)
            {
                return pistol;
            }
            else if(type == GunType.ShotGun)
            {
                return shotgun;
            }
            else if(type == GunType.MachineGun)
            {
                return machineGun;
            }
            return null;
        }
    }
    public interface IWeaponFactory
    {
        IAttackMethod SetAttackMethod(EntityBase entity);
        
        int SetDamage();
        float SetAttackRange();
        float SetAttackDelay();

        AmmoType SetAmmoType();
        int SetMaxAmmoAmount();
    }
    public class PistolFactory : IWeaponFactory
    {
        Vector2 shotPointPosition = new Vector2(0.06f,0.11f);
        public IAttackMethod SetAttackMethod(EntityBase entity)
        {
            GameObject shotPoint = new GameObject("ShotPoint");
            shotPoint.transform.SetParent(entity.transform);
            shotPoint.transform.localPosition = shotPointPosition;
            return new AttackToRaycast(entity,shotPoint.transform, SetAttackRange(), Layers.MonsterMask, Layers.GroundMask,SetDamage());
        }

        public int SetDamage()
        {
            return 1;
        }
        public float SetAttackRange()
        {
            return 1f;
        }
        public float SetAttackDelay()
        {
            return 0.1f;
        }

        public AmmoType SetAmmoType()
        {
            return AmmoType.Small;
        }
        public int SetMaxAmmoAmount()
        {
            return 8;
        }
    }
    public class ShotGunFactory : IWeaponFactory
    {
        public IAttackMethod SetAttackMethod(EntityBase entity)
        {
            return new AttackToRaycast(entity,entity.transform, SetAttackRange(), Layers.MonsterMask, Layers.GroundMask, SetDamage());
        }

        public int SetDamage()
        {
            return 10;
        }
        public float SetAttackRange()
        {
            return 0.5f;
        }
        public float SetAttackDelay()
        {
            return 1f;
        }

        public AmmoType SetAmmoType()
        {
            return AmmoType.Scatter;
        }
        public int SetMaxAmmoAmount()
        {
            return 8;
        }
    }
    public class MachineGunFactory : IWeaponFactory
    {
        public IAttackMethod SetAttackMethod(EntityBase entity)
        {
            return new AttackToRaycast(entity,entity.transform, SetAttackRange(), Layers.MonsterMask, Layers.GroundMask, SetDamage());
        }

        public int SetDamage()
        {
            return 2;
        }
        public float SetAttackRange()
        {
            return 3f;
        }
        public float SetAttackDelay()
        {
            return 0.1f;
        }

        public AmmoType SetAmmoType()
        {
            return AmmoType.Normal;
        }
        public int SetMaxAmmoAmount()
        {
            return 100;
        }
    }
}