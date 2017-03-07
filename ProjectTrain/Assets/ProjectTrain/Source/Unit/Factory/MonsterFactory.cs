using UnityEngine;

namespace ProjectTrain
{
    public class MonsterFactory : Singleton<MonsterFactory>
    {
        public MonsterBase Create()
        {
            return new MonsterBase();
        }
    }
}