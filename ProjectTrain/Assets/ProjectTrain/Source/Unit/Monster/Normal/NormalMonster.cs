using UnityEngine;

namespace ProjectTrain
{
    public class NormalMonster : MonsterBase
    {
        const int orgHp = 15;
        const float orgSpeed = 0.3f;
        const int orgDamage = 1;
        const float orgSight = 1.5f;
        const float orgAttackrange = 0.1f;
        public override void Initialize()
        {
            base.Initialize();
            Initialize(orgHp
                , new MovementBase(transform, orgSpeed)
                ,new MonsterAnimation(animator),
                orgDamage,orgSight,orgAttackrange);
        }
    }
}