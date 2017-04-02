using UnityEngine;
using Entity;
using Entity.Controller;
using LayerManager;

namespace Factory
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

        public static int GetLayer(EntityType type)
        {
            if (type == EntityType.NormalMonster)
            {
                return Layers.Monster;
            }
            else if (type == EntityType.UpgradeMonster)
            {
                return Layers.Monster;
            }
            else if(type == EntityType.Player)
            {
                return Layers.Player;
            }
            return Layers.Nothing;
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
        int SetHp();
        int SetDamage();
        float SetAttackRange();
        float SetSpeed();

        EntitySight SetSight(EntityBase entity);
        EntityAttack SetAttack(EntityBase entity);
        Collider2D SetCollider(EntityBase entity);
        Rigidbody2D SetRigidbody(EntityBase entity);
    }

    #region PlayerFactory
    public class PlayerFactory : IEntityFactory
    {
        public int SetHp() { return 10; }
        public int SetDamage() { return 1; }
        public float SetAttackRange() { return 0.2f; }
        public float SetSpeed() { return 0.3f; }

        //Attack
        public EntityAttack SetAttack(EntityBase entity)
        {
            return entity.gameObject.AddComponent<PlayerAttack>(); 
        }


        //Sight
        public EntitySight SetSight(EntityBase entity)
        {
            return new PlayerSight(entity.transform, 1f);
        }

        // Collider
        static Vector2 size = new Vector2(0.09f, 0.155f);
        public Collider2D SetCollider(EntityBase entity)
        {
            CapsuleCollider2D collider = entity.gameObject.AddComponent<CapsuleCollider2D>();

            collider.size = size;
            collider.isTrigger = false;

            return collider;
        }

        // Rigidbody
        public Rigidbody2D SetRigidbody(EntityBase entity)
        {
            Rigidbody2D rigidbody = entity.gameObject.GetComponent<Rigidbody2D>();
            rigidbody.freezeRotation = true;
            rigidbody.angularDrag = 1f;
            return rigidbody;
        }
    }
    #endregion

    #region NormalMonsterFactory
    public class NormalMonsterFactory : IEntityFactory
    {
        public int SetHp() { return 10; }
        public int SetDamage() { return 1; }
        public float SetAttackRange() { return 0.2f; }
        public float SetSpeed() { return 0.5f; }


        public EntityAttack SetAttack(EntityBase entity)
        {
            EntityAttack attack = entity.gameObject.AddComponent<MonsterAttack>();
            return attack;
        }

        static Vector2 eyePosition = new Vector2(0.02f, 0.04f);
        public EntitySight SetSight(EntityBase entity)
        {
            GameObject eye = new GameObject("Eye");
            eye.transform.SetParent(entity.transform);
            eye.transform.localPosition = eyePosition;
            EntitySight sight = new MonsterSight(eye.transform,0.5f,Layers.PlayerMask,Layers.GroundMask);

            return sight;
        }

        static float size = 0.05f;
        public Collider2D SetCollider(EntityBase entity)
        {
            CircleCollider2D collider = entity.gameObject.AddComponent<CircleCollider2D>();

            collider.radius = size;
            collider.isTrigger = false;

            return collider;
        }


        public Rigidbody2D SetRigidbody(EntityBase entity)
        {
            Rigidbody2D rigidbody = entity.gameObject.GetComponent<Rigidbody2D>();
            rigidbody.freezeRotation = true;
            rigidbody.angularDrag = 1f;
            return rigidbody;
        }
    }
    #endregion

    #region UpgradeMonsterFactory
    public class UpgradeMonsterFactory : IEntityFactory
    {
        public int SetHp() { return 10; }
        public int SetDamage() { return 1; }
        public float SetAttackRange() { return 0.2f; }
        public float SetSpeed() { return 0.1f; }

        public EntityAttack SetAttack(EntityBase entity)
        {
            EntityAttack attack = entity.gameObject.AddComponent<MonsterAttack>();
            return attack;
        }

        static Vector2 eyePosition = new Vector2(0.02f, 0.04f);
        public EntitySight SetSight(EntityBase entity)
        {
            GameObject eye = new GameObject("Eye");
            eye.transform.SetParent(entity.transform);
            eye.transform.localPosition = eyePosition;
            EntitySight sight = new MonsterSight(eye.transform, 0.5f, Layers.PlayerMask, Layers.GroundMask);

            return sight;
        }

        public Collider2D SetCollider(EntityBase entity)
        {
            return entity.gameObject.AddComponent<BoxCollider2D>();
        }


        public Rigidbody2D SetRigidbody(EntityBase entity)
        {
            Rigidbody2D rigidbody = entity.gameObject.GetComponent<Rigidbody2D>();
            rigidbody.freezeRotation = true;
            rigidbody.angularDrag = 1f;
            return rigidbody;
        }
    }
    #endregion
}