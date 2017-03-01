using UnityEngine;

namespace ProjectTrain
{
    public partial class MonsterBase : Unit
    {
        private bool TargetIsInArea()   //타겟이 공격 유효 범위 안에 있ㅇ므
        {
            return targeting.DistanceToTarget() <= attackRange;
        }
        private void TargetingExecute()
        {
            targeting.Execute(lookingDirection.DirToVec2());

            LookTarget();
        }
        private void LookTarget()
        {
            if (targeting.target == null) return;
            Vector3 targetPos = targeting.target.transform.position;
            if (targetPos.isLeft(transform.position))
            {
                lookingDirection = Direction.Left;
            }
            else
            {
                lookingDirection = Direction.Right;
            }
        }
    }
}