using UnityEngine;
//using System.Reflection;
namespace ProjectTrain
{
    public class ArcherMonster : MonsterBase
    {
        const int orgHp = 10;
        const float orgSpeed = 0.1f;
        const int orgDamage = 0;
        const float orgSight = 1f;
        const float orgAttackRange = 0.5f;
        const float attackCoolTime = 1f;

        public override void Initialize()
        {
            //MethodInfo info = typeof(ArcherMonster).GetMethod("Initialize", BindingFlags.Instance | BindingFlags.NonPublic);
            //info.Invoke(this, )

            Initialize( orgHp,
                        new MovementBase(transform, orgSpeed),
                        new MonsterAnimation(animator),
                        orgDamage,
                        orgSight,
                        orgAttackRange,
                        new CoolTime(animator.GetClip("AttackReady").length),
                        new CoolTime(attackCoolTime)
                        );
        }
    }
}