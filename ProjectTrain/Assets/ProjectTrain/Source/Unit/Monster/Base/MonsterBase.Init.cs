using UnityEngine;

namespace ProjectTrain
{
    public partial class MonsterBase : Unit
    {
        const float speed = 0.3f;
        public override void Initialize()
        { 
        }
        protected sealed override void Initialize(int layer,int hp, MovementBase movement,UnitAnimation animation)
        {
            base.Initialize(layer, hp, movement,animation);
        }

        protected void Initialize(int hp,MovementBase movement, UnitAnimation animation,int damage,float sight,float attackRange,CoolTime startDelay,CoolTime attackCoolTime)
        {
            Initialize(Layers.Enemy,hp, movement,animation);
                        
            this.targeting = new TargettingInRect(transform,Layers.PlayerMask,Layers.Ground, sight);

            this.attack = new MonsterAttack(damage, attackRange, startDelay, attackCoolTime);
        }
    }
}