using UnityEngine;
using Entity;
using Entity.Controller;
using LayerManager;
using System.Collections.Generic;

namespace Entity
{
    public static class EntitySetter
    {
        #region Factorys

        static PlayerFactory player = new PlayerFactory();
        static NormalMonsterFactory normalMonster = new NormalMonsterFactory();
        static UpgradeMonsterFactory upgradeMonster = new UpgradeMonsterFactory();

        #endregion

        public static IEntityFactory GetFactory(EntityType type)
        {
            if(type == EntityType.Player)
            {
                return player;
            }
            else if(type == EntityType.NormalMonster)
            {
                return normalMonster;
            }
            else if(type == EntityType.UpgradeMonster)
            {
                return upgradeMonster;
            }
            return null;
        }


        public static EntityController GetController(EntityBase targetEntity,EntityType type)
        {
            if(type == EntityType.Player)
            {
                return new PlayerController(targetEntity,0.01f);
            }
            else if(type == EntityType.NormalMonster)
            {
                return new MonsterController(targetEntity);
            }
            else if(type == EntityType.UpgradeMonster)
            {
                return new MonsterController(targetEntity);
            }
            return null;   
        }
    }

    public interface IEntityFactory
    {
        IHealth health { get; }
        IMoveBehavior       moveBehavior(EntityBase mover);
        List<IAttackBehavior>     attackBehaviors(EntityBase attacker);
    }
}

namespace Entity
{
    using Weapon;
    using Weapon.Factory;
    public class PlayerFactory : IEntityFactory
    {
        const int hp = 10;
        const float speed = 0.2f;

        public IHealth health
        {
            get{ return new DefaultHealth(hp); }
        }
        public IMoveBehavior moveBehavior(EntityBase mover)
        {
            return new DefaultMove(mover, speed);
        }
        public List<IAttackBehavior> attackBehaviors(EntityBase attacker)
        {
            List<IAttackBehavior> attackBehaviors = new List<IAttackBehavior>();

            Gun pistol      = WeaponGenerator.CreateGun(attacker, GunType.Pistol, "DesertEagle");
            Gun shotgun     = WeaponGenerator.CreateGun(attacker, GunType.ShotGun, "Winchester");
            Gun machinegun  = WeaponGenerator.CreateGun(attacker, GunType.MachineGun, "M16");

            attackBehaviors.Add(new AttackWithWeapon(pistol));
            attackBehaviors.Add(new AttackWithWeapon(shotgun));
            attackBehaviors.Add(new AttackWithWeapon(machinegun));

            return attackBehaviors;
        }
    }
}

namespace Entity
{
    using Weapon;
    public class NormalMonsterFactory : IEntityFactory
    {
        const int hp = 10;
        const float speed = 5f;
        const int damage = 1;
        const float delay = 0.5f;
        const float range = 1f;

        public IHealth health
        {
            get { return new DefaultHealth(hp); }
        }
        public IMoveBehavior moveBehavior(EntityBase mover)
        {
            return new DefaultMove(mover, speed);
        }
        public List<IAttackBehavior> attackBehaviors(EntityBase attacker)
        {
            List<IAttackBehavior> attackBehaviors = new List<IAttackBehavior>();
            IWeapon weapon = new MeleeWeapon(attacker);

            attackBehaviors.Add(new AttackWithWeapon(weapon));

            return attackBehaviors;
        }
    }

    public class UpgradeMonsterFactory : IEntityFactory
    {
        const int hp = 10;
        const float speed = 5f;
        const int damage = 1;
        const float delay = 0.5f;
        const float range = 1f;

        public IHealth health
        {
            get { return new DefaultHealth(hp); }
        }
        public IMoveBehavior moveBehavior(EntityBase mover)
        {
            return new DefaultMove(mover, speed);
        }
        public List<IAttackBehavior> attackBehaviors(EntityBase attacker)
        {
            List<IAttackBehavior> attackBehaviors = new List<IAttackBehavior>();
            IWeapon weapon = new MeleeWeapon(attacker);

            attackBehaviors.Add(new AttackWithWeapon(weapon));

            return attackBehaviors;
        }
    }
}