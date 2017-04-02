using System;
using UnityEngine;

namespace Entity
{
    public abstract class EntityAttack : EntityComponent
    {
        public int damage { get; private set; }
        public float delay { get; private set; }
        public float range { get; private set; }
        public abstract void AttackTo(EntityBase target);
    }
    public class MonsterAttack : EntityAttack
    {
        public override void AttackTo(EntityBase target)
        {
            target.Attacked(damage);
        }
    }
    public class PlayerAttack : EntityAttack
    {
        public override void AttackTo(EntityBase target)
        {
        }
    }
}