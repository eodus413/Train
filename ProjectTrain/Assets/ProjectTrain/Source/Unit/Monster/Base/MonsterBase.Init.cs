using UnityEngine;

namespace ProjectTrain
{
    public partial class MonsterBase : Unit
    {
        const float speed = 0.3f;
        public override void Initialize()
        { 
        }
        protected override void Initialize(int layer,int hp, MovementBase movement,UnitAnimation animation)
        {
            base.Initialize(layer, hp, movement,animation);
        }

        const string enemyLayer = "Enemy";
        protected void Initialize(int hp,MovementBase movement, UnitAnimation animation,int damage,float sight,float attackRange)
        {
            Initialize(LayerMask.NameToLayer(enemyLayer),hp, movement,animation);

            this.prevAttackData = new AttackData(damage, Vector2.zero, this);
            this.damage = damage;
            this.attackRange = attackRange;

            this.targeting = new Targeting(transform, 1 << LayerMask.NameToLayer("Player"), sight);
        }
    }
}