using UnityEngine;
using Entity;
using Entity.Controller;
using LayerManager;
using System.Collections.Generic;

namespace Entity.Factory
{
    using Entity.Factory.Player;
    using Entity.Factory.Monster;

    public static class EntityFactoryMethod
    {
        public static PlayerCatFactory playerCat = new PlayerCatFactory();


        public static NormalMonsterFactory normal = new NormalMonsterFactory();
        public static BirdMonsterFactory bird = new BirdMonsterFactory();
        public static GreenMonsterFactory greenBird = new GreenMonsterFactory();
        public static FrogMonsterFactory frog = new FrogMonsterFactory();
        public static RatMonsterFactory rat = new RatMonsterFactory();
        public static BottleMonsterFactory bottle = new BottleMonsterFactory();


        public static MachineGunTowerFactory machineGunTurret = new MachineGunTowerFactory();

        public static IEntityFactory GetFactory(PlayerType type)
        {
            if(type == PlayerType.Cat)
            {
                return playerCat;
            }
            Debug.Log("Type이 잘못됐습니다.");
            return null;    
        }
        public static IEntityFactory GetFactory(MonsterType type)
        {
            if (type == MonsterType.Normal)
            {
                return normal;
            }
            else if(type == MonsterType.Bird)
            {
                return bird;
            }
            else if(type == MonsterType.GreenBird)
            {
                return greenBird;
            }
            else if(type == MonsterType.Frog)
            {
                return frog;
            }
            else if(type == MonsterType.Rat)
            {
                return rat;
            }
            else if(type == MonsterType.Bottle)
            {
                return bottle;
            }

            Debug.Log("Type이 잘못됐습니다.");
            return null;
        }
        public static IEntityFactory GetFactory(TurretType type)
        {
            if (type == TurretType.MachineGun)
            {
                return machineGunTurret;
            }
            Debug.Log("Type이 잘못됐습니다.");
            return null;
        }
    }

    public interface IEntityFactory
    {
        int GetHp { get; }
        float GetSpeed { get; }
        IMoveBehavior GetMoveBehavior(EntityBase mover);

        EntityController GetController(EntityBase entity);
    }
}

namespace Entity.Factory.Player
{
    public class PlayerCatFactory : IEntityFactory
    {
        public int GetHp { get { return 30; } }
        public float GetSpeed { get { return 0.5f; } }
        public IMoveBehavior GetMoveBehavior(EntityBase mover)
        {
            return new DefaultMove(mover, GetSpeed);
        }
        public EntityController GetController(EntityBase entity)
        {
            PlayerBase player = entity as PlayerBase;
            if (player != null)
            {
                if (Platform.isPC()) return new PlayerController(player, 0.02f);
                else return new PlayerMobileController(player, 0.02f);
            }
            //else
            Debug.Log("Player 오류");
            return null;
        }
    }

}

namespace Entity.Factory.Monster
{
    using Weapon;
    public class NormalMonsterFactory : IEntityFactory
    {
        public int GetHp { get { return 10; } }
        public float GetSpeed { get { return 0.1f; } }

        public IMoveBehavior GetMoveBehavior(EntityBase mover)
        {
            return new DefaultMove(mover, GetSpeed);
        }
        public EntityController GetController(EntityBase entity)
        {
            MonsterBase monster = entity as MonsterBase;
            if(monster != null)
            {
                return new MonsterController(monster);
            }
            return null;
        }
    }

    public class BirdMonsterFactory : IEntityFactory
    {
        public int GetHp { get { return 20; } }
        public float GetSpeed { get { return 0.1f; } }
        public IMoveBehavior GetMoveBehavior(EntityBase mover)
        {
            return new DefaultMove(mover, GetSpeed);
        }
        public EntityController GetController(EntityBase entity)
        {
            MonsterBase monster = entity as MonsterBase;
            if (monster != null)
            {
                return new MonsterController(monster);
            }
            return null;
        }
    }
    
    public class GreenMonsterFactory : IEntityFactory
    {
        public int GetHp { get { return 30; } }
        public float GetSpeed { get { return 0.2f; } }

        public IMoveBehavior GetMoveBehavior(EntityBase mover)
        {
            return new DefaultMove(mover, GetSpeed);
        }
        public EntityController GetController(EntityBase entity)
        {
            MonsterBase monster = entity as MonsterBase;
            if (monster != null)
            {
                return new MonsterController(monster);
            }
            return null;
        }
    }


    public class FrogMonsterFactory : IEntityFactory
    {
        public int GetHp { get { return 15; } }
        public float GetSpeed { get { return 0.3f; } }

        public IMoveBehavior GetMoveBehavior(EntityBase mover)
        {
            return new DefaultMove(mover, GetSpeed);
        }
        public EntityController GetController(EntityBase entity)
        {
            MonsterBase monster = entity as MonsterBase;
            if (monster != null)
            {
                return new MonsterController(monster);
            }
            return null;
        }
    }
    public class RatMonsterFactory : IEntityFactory
    {
        public int GetHp { get { return 25; } }
        public float GetSpeed { get { return 0.75f; } }
        public IMoveBehavior GetMoveBehavior(EntityBase mover)
        {
            return new DefaultMove(mover, GetSpeed);
        }
        public EntityController GetController(EntityBase entity)
        {
            MonsterBase monster = entity as MonsterBase;
            if (monster != null)
            {
                return new MonsterController(monster);
            }
            return null;
        }
    }
    public class BottleMonsterFactory : IEntityFactory
    {
        public int GetHp { get { return 5; } }
        public float GetSpeed { get { return 0.5f; } }
        public IMoveBehavior GetMoveBehavior(EntityBase mover)
        {
            return new DefaultMove(mover, GetSpeed);
        }
        public EntityController GetController(EntityBase entity)
        {
            MonsterBase monster = entity as MonsterBase;
            if (monster != null)
            {
                return new MonsterController(monster);
            }
            return null;
        }
    }
}