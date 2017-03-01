namespace ProjectTrain
{
    public class UpgradeMonster : MonsterBase
    {
        const int orgHp = 50;
        const float orgSpeed = 0.5f;
        const int orgDamage = 2;
        const float orgSight = 2f;
        const float orgAttackrange = 0.2f;


        public override void Initialize()
        {
            base.Initialize();
            Initialize(orgHp,
                new MovementBase(transform, orgSpeed),
                new MonsterAnimation(animator),
                orgDamage, orgSight, orgAttackrange
                );
        }
    }
}