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
            target = monster.Targeting();
            if (isAbleToAttack) yield return AttackTarget();
            else yield return Move();
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
        private EntityBase _target;
        private EntityBase target
        {
            get
            {
                if (monster.isInSight(_target) == false) _target = null;
                return _target;
            }
            set
            {
                if (monster.isInSight(value))
                {
                    _target = value;
                }
            }
        }
        private bool noTarget
        {
            get
            {
                return target == null;
            }
        }
        private bool isAbleToAttack
        {
            get
            {
                return monster.IsAbleToAttack(target);
            }
        }

        bool isAttacking = false;
        IEnumerator AttackTarget()
        {
            isAttacking = true;
            Debug.Log("AttackStart");
            yield return monster.AttackTarget(target);
            isAttacking = false;
        }
        IEnumerator Move()
        {
            if(noTarget)
            {
                entity.Move(Vector2.right);
            }
            else
            {
                if (target.transform.isLeftTo(entity)) entity.Move(Vector2.left);
                else if (target.transform.isRightTo(entity)) entity.Move(Vector2.right);
            }
            yield return null;
        }
    }
}
