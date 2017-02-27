using UnityEngine;

namespace ProjectTrain
{
    public class NormalMonster : MonsterBase
    {
        public override void Initialize()
        {
            base.Initialize();
            Initialize(10, new MovementBase(transform, 0.3f),new MonsterAnimation(animator),1,0.5f,0.1f);
        }
    }
}