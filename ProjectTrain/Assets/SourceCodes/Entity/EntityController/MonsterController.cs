using UnityEngine;
using Entity;
using System.Collections;

namespace Entity.Controller
{
    public partial class MonsterController : EntityController
    {
        public bool NoTarget { get { return sight.target == null; } }
        public bool AvalidTarget { get { return sight.target != null; } }
        public bool isReadyForChasing
        {
            get
            {
                if (NoTarget) return false;

                float distanceToTarget = sight.DistanceToTarget;

                Debug.Log(distanceToTarget);
                if (distanceToTarget <= attack.range)
                {
                    entity.Move(Direction.zero);
                    return false;
                }
                if (distanceToTarget > sight.distance)
                {
                    sight.ReleaseTarget();

                    entity.Move(Direction.zero);
                    return false;
                }
                return true;
            }
        }
        public bool notReadyForAttack
        {
            get
            {
                if (NoTarget) return true;
                return sight.DistanceToTarget > entity.attackRange;
            }
        }
        public bool isReadyForAttack
        {
            get
            {
                if (NoTarget) return false;
                return sight.DistanceToTarget <= entity.attackRange;
            }
        }

        public override IEnumerator Start()
        {
            while (isActive)
            {
                if (NoTarget) yield return Targeting();
                if (isReadyForChasing) yield return Chasing();
                if (isReadyForAttack) yield return Attack();

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
            while (isReadyForChasing)
            {
                yield return new WaitForSeconds(moveRoutineDelay);
                
               
                Direction targetLocation = entityTransform.TargetLocation(sight.target);
                entity.LookAt(targetLocation);
                entity.Move(targetLocation);
            }    
        }
        EntityBase targetEntity
        {
            get { return sight.target.GetComponent<EntityBase>(); }
        }

        EntityAttack attack;
        IEnumerator Attack()
        {
            yield return new WaitForSeconds(attack.delay);
            if(sight.targetIsInSight)
            {
                attack.Attack();
                entity.Move(Direction.zero);
            }
        }
    }


    public partial class MonsterController : EntityController
    {
        EntitySight sight;
        public MonsterController(EntityBase entity,float reactionVelocity = 1f) : base(entity)
        {
            sight = entity.eye;
            this.reactionVelocity = reactionVelocity;
            attack = new MonsterAttack(entity,1,1f,0.1f);
        }
    }
}
