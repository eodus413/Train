using UnityEngine;
using Entity;
using System.Collections;

namespace Entity.Controller
{
    public partial class MonsterController : EntityController
    {
        public bool NoTarget { get { return sight.target == null; } }
        public bool isChasing
        {
            get
            {
                return !NoTarget && !isReadyForAttack;
            }
        }
        public bool isReadyForAttack
        {
            get
            {
                return sight.DistanceToTarget <= entity.attackRange;
            }
        }
        public override IEnumerator Start()
        {
            while (isActive)
            {
                if (NoTarget) yield return Targeting();
                else if (isChasing) yield return Chasing();
                else if (isReadyForAttack) yield return Attack();

                yield return new WaitForSeconds(routineDelay);
            }
        }
        

        private float reactionVelocity;
        private float targetingDelay
        {
            get { return reactionVelocity; }
        }
        private float checkTargetDelay
        {
            get { return reactionVelocity; }
        }


        IEnumerator Targeting()
        {
            yield return new WaitForSeconds(targetingDelay);
            sight.Seeing();
        }
        

        IEnumerator Chasing()
        {
            while (sight.targetIsInSight)
            {
                entity.Move(entityTransform.TargetLocation(sight.target));
                yield return new WaitForSeconds(moveRoutineDelay);
            }    
        }
        EntityBase targetEntity
        {
            get { return sight.target.GetComponent<EntityBase>(); }
        }
        IEnumerator Attack()
        {
            Debug.Log("A");
            yield return new WaitForSeconds(entity.attack.a);

            entity.attack.AttackTo(targetEntity);
        }
    }


    public partial class MonsterController : EntityController
    {
        EntitySight sight;
        public MonsterController(EntityBase entity,float reactionVelocity = 1f) : base(entity)
        {
            sight = entity.eye;
            this.reactionVelocity = reactionVelocity;
        }
    }
}
