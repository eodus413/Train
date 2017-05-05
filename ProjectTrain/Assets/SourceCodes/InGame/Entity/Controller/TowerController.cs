using UnityEngine;
using Entity;
using System.Collections;

namespace Entity.Controller
{
    public partial class TowerController : EntityController
    {
        //생성자
        public TowerController(EntityBase entity) : base(entity)
        {
        }
        //인터페이스
        public override IEnumerator Start()
        {
            while (isActive)
            {
                yield return null;
            }
        }
        //구현
    }
}
