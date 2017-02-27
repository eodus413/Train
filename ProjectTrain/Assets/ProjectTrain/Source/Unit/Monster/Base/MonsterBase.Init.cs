using UnityEngine;

namespace ProjectTrain
{
    public partial class MonsterBase : Unit
    {
        const float speed = 0.3f;
        public override void Initialize()
        {
        }
        protected override void Initialize(int hp, MovementBase movement,UnitAnimation animation)
        {
            base.Initialize(hp, movement,animation);
        }
        protected void Initialize(int hp,MovementBase movement, UnitAnimation animation,int damage,float sight,float attackRange)
        {
            Initialize(hp, movement,animation);

            this.damage = damage;
            
            this.attackRange = attackRange;

            this.targeting = new Targeting(transform, 1 << LayerMask.NameToLayer("Player"), sight);
        }
    }
}