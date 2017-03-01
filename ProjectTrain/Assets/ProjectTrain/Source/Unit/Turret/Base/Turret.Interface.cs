using System;
using System.Collections;
using UnityEngine;

namespace ProjectTrain
{
    public partial class TurretBase : Unit
    {
        protected override IEnumerator DoDead()
        {
            return base.DoDead();
        }
        
        protected override bool isDoingAttack()
        {
            return false;
        }
        protected override void Attack()
        {
        }

        protected override bool isDoingMove()
        {
            return false;
        }
        protected override void Move()
        {
        }

        protected override void Idle()
        {
        }
    }
}