using System;
using Weapon;
using UnityEngine;

namespace Entity
{
    public abstract class EntityAttack
    {
        public EntityAttack(EntityBase entity,int damage,float delay,float range)
        {
            this.entity = entity;

            this.damage = damage;
            this.delay = delay;
            this.range = range;
        }
        public EntityBase entity { get; private set; }

        public int damage { get; private set; }
        public float delay { get; private set; }
        public float range { get; private set; }

        public abstract void Attack();
    }
    public class MonsterAttack : EntityAttack
    {
        public MonsterAttack(EntityBase entity,int damage,float delay,float range)
            :base(entity,damage,delay,range)
        {

        }
        public override void Attack()
        {
            GameObject target = entity.eye.target;
            if (target == null) return;
            if (entity.eye.DistanceToTarget > range) return;

            target.GetComponent<EntityBase>().Attacked(damage);
        }
    }
}