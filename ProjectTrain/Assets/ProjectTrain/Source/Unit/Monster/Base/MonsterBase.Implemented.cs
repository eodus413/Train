using UnityEngine;

namespace ProjectTrain
{
    public partial class MonsterBase : Unit
    {
        private bool TargetIsInArea()   //타겟이 공격 유효 범위 안에 있ㅇ므
        {
            return targeting.DistanceToTarget() <= attackRange;
        }
    }
}