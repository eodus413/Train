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
            Debug.Log("Type이 잘못됐습니다.");
            return null;
        }
    }

    public interface IEntityFactory
    {
        int hp { get; }
        float speed { get; }
        IMoveBehavior GetMoveBehavior(EntityBase mover);

        EntityController GetController(EntityBase entity);
    }
}

namespace Entity.Factory.Player
{
    using Weapon;
    using Weapon.Factory;
    public class PlayerCatFactory : IEntityFactory
    {
        public int hp { get { return 10; } }
        public float speed { get { return 0.3f; } }
        public IMoveBehavior GetMoveBehavior(EntityBase mover)
        {
            return new DefaultMove(mover, speed);
        }
        public EntityController GetController(EntityBase entity)
        {
            PlayerBase player = entity as PlayerBase;
            if (player != null)
                return new PlayerController(player, 0.02f);

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
        public int hp { get { return 10; } }
        public float speed { get { return 0.1f; } }

        public IMoveBehavior GetMoveBehavior(EntityBase mover)
        {
            return new DefaultMove(mover, speed);
        }
        public EntityController GetController(EntityBase entity)
        {
            return new MonsterController(entity);
        }
    }

    public class BirdMonsterFactory : IEntityFactory
    {
        public int hp { get { return 20; } }
        public float speed { get { return 0.1f; } }
        public IMoveBehavior GetMoveBehavior(EntityBase mover)
        {
            return new DefaultMove(mover, speed);
        }
        public EntityController GetController(EntityBase entity)
        {
            return new MonsterController(entity);
        }
    }
    
    public class GreenMonsterFactory : IEntityFactory
    {
        public int hp { get { return 30; } }
        public float speed { get { return 0.2f; } }

        public IMoveBehavior GetMoveBehavior(EntityBase mover)
        {
            return new DefaultMove(mover, speed);
        }
        public EntityController GetController(EntityBase entity)
        {
            return new MonsterController(entity);
        }
    }


    public class FrogMonsterFactory : IEntityFactory
    {
        public int hp { get { return 15; } }
        public float speed { get { return 0.3f; } }

        public IMoveBehavior GetMoveBehavior(EntityBase mover)
        {
            return new DefaultMove(mover, speed);
        }
        public EntityController GetController(EntityBase entity)
        {
            return new MonsterController(entity);
        }
    }
    public class RatMonsterFactory : IEntityFactory
    {
        public int hp { get { return 50; } }
        public float speed { get { return 0.5f; } }
        public IMoveBehavior GetMoveBehavior(EntityBase mover)
        {
            return new DefaultMove(mover, speed);
        }
        public EntityController GetController(EntityBase entity)
        {
            return new MonsterController(entity);
        }
    }
}