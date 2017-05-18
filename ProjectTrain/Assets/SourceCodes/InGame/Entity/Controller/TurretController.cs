using UnityEngine;
using Entity;
using System.Collections;

namespace Entity.Controller
{
    public partial class TurretController : EntityController
    {
        //생성자
        public TurretController(TurretBase turret) : base(turret)
        {
            this.turret = turret;
        }
        //Base 재정의
        protected override IEnumerator Inititliaze()
        {
            yield return null;
        }
        protected override IEnumerator Update()
        {
            turret.AttackTarget();
            yield return null;
        }
        protected override IEnumerator Release()
        {
            yield return null;
        }
        //구현
        TurretBase turret;
    }
}
