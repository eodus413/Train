using UnityEngine;
using Entity;
using System.Collections;

namespace Entity.Controller
{
    public partial class MonsterController : EntityController
    {
        //생성자
        public MonsterController(EntityBase entity) : base(entity)
        {
        }
        //인터페이스
        public override IEnumerator Start()
        {
            while (isActive)
            {
                yield return Move();
            }
        }
        //구현
        IEnumerator Move()
        {
            entity.moveBehavior.Move(Direction.right);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
