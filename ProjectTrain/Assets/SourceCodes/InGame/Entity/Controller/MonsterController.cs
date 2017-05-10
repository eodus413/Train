using UnityEngine;
using System.Collections;

namespace Entity.Controller
{
    public partial class MonsterController : EntityController
    {
        //생성자
        public MonsterController(EntityBase entity) : base(entity)
        {
            monster = entity as MonsterBase;
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
            if (isAbleToAttack) yield return AttackTarget();

            else yield return Move();
        }
        protected override IEnumerator Release()
        {
            yield return null;
        }


        //구현
        private bool isAbleToAttack
        {
            get { return monster.isAbleToAttack; }
        }

        IEnumerator AttackTarget()
        {
            yield return null;
        }
        IEnumerator Move()
        {
            entity.moveBehavior.Move(Vector2.right);
            yield return new WaitForSeconds(moveRoutineDelay);
        }
    }
}
