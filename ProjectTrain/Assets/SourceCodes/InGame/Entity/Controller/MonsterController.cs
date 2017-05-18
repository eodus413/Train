using UnityEngine;
using System.Collections;

namespace Entity.Controller
{
    public partial class MonsterController : EntityController
    {
        //생성자
        public MonsterController(MonsterBase monster) : base(monster)
        {
            this.monster = monster;
        }



        //멤버
        MonsterBase monster;



        //Base 재정의
        protected override IEnumerator Inititliaze()
        {
            yield return null;
        }
        protected override IEnumerator Update()
        {
            if (isAbleToMove) yield return Move();
            else if (isAbleToChase) yield return Chase();
            else if (isAbleToAttack) yield return AttackTarget();
        }
        protected override IEnumerator Release()
        {
            yield return null;
        }
    }
}

namespace Entity.Controller
{
    public partial class MonsterController : EntityController
    {
        //구현
        private EntityBase target;
        private bool noTarget { get { return target == null; } }

        private bool isAbleToAttack
        {
            get
            {
                if (noTarget) return false;
                return monster.CanAttack(target);
            }
        }
        private bool isAbleToMove
        {
            get
            {
                return noTarget;
            }
        }
        private bool isAbleToChase
        {
            get
            {
                if (noTarget) return false;
                return monster.CanAttack(target) == false;
            }
        }

        bool isAttacking = false;
        IEnumerator AttackTarget()
        {
            isAttacking = true;
            yield return monster.AttackTarget(target);
            isAttacking = false;
        }
        IEnumerator Move()
        {
            target = monster.Targeting();
            entity.Move(Vector2.right);
            yield return null;
        }
        IEnumerator Chase()
        {
            while (target != null)
            {
                float entityX = entity.transform.position.x;

                if (entityX > target.transform.position.x) entity.Move(Vector2.left);   //target 이 왼쪽
                else if (entityX < target.transform.position.x) entity.Move(Vector2.right);

                yield return null;
            }
        }
    }
}
