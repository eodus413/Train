using UnityEngine;

namespace ProjectTrain
{
    public partial class MonsterBase : Unit
    {
        Targeting targeting;

        AttackData prevAttackData;
        int damage;
        float attackRange;

        CoolTIme attackCoolTime;

        //Hive ownerHive;   //이 몬스터의 하이브
        float respawnDelay; //부활 딜레이
    }
}