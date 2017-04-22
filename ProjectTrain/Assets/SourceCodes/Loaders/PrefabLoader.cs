namespace Loaders
{
    using UnityEngine;
    public static partial class PrefabLoader
    {
        public static GameObject playerPrefab = Resources.Load<GameObject>("Prefabs/Entities/Player");
        public static GameObject birdMonsterPrefab = Resources.Load<GameObject>("Prefabs/Entities/BirdMonster");
        public static GameObject greenBirdMonsterPrefab = Resources.Load<GameObject>("Prefabs/Entities/GreenBirdMonster");
        public static GameObject normalMonsterPrefab = Resources.Load<GameObject>("Prefabs/Entities/NormalMonster");
        public static GameObject ratMonsterPrefab = Resources.Load<GameObject>("Prefabs/Entities/RatMonster");
        public static GameObject frogMonsterPrefab = Resources.Load<GameObject>("Prefabs/Entities/FrogMonster");
    }

}
namespace Loaders
{
    using Entity;
    using UnityEngine;
    public static partial class PrefabLoader
    {
        public static GameObject GetMonsterPrefab(MonsterType type)
        {
            if (type == MonsterType.Bird) return birdMonsterPrefab;
            else if (type == MonsterType.Frog) return frogMonsterPrefab;
            else if (type == MonsterType.GreenBird) return greenBirdMonsterPrefab;
            else if (type == MonsterType.Normal) return normalMonsterPrefab;
            else if (type == MonsterType.Rat) return ratMonsterPrefab;
            return null;
        }
    }
}