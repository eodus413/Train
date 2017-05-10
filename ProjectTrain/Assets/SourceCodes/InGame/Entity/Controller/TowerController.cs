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
        //Base 재정의
        protected override IEnumerator Inititliaze()
        {
            yield return null;
        }
        protected override IEnumerator Update()
        {
            yield return null;
        }
        protected override IEnumerator Release()
        {
            yield return null;
        }
        //구현
    }
}
