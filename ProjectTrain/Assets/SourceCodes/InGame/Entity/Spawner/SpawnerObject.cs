using UnityEngine;
using System.Collections;
using ObjectPool;

namespace Entity
{
    public class SpawnerObject : MonoBehaviour
    {
        [SerializeField]
        private Team team = Team.Enemy;
        [SerializeField]
        private MonsterType monsterType;
        [SerializeField]
        int spawnAmount;
        [SerializeField]
        float spawnDelay;

        Spawner spawner;
        void Start()
        {
            gameObject.name = monsterType.ToString() + " : Spawner";

            GameObject prefab = GetMonsterPrefab(monsterType);

            spawner = new Spawner(prefab, spawnAmount, transform,team);

            StartCoroutine(spawner.DoSpawn(spawnAmount, spawnDelay));
        }
        GameObject GetMonsterPrefab(MonsterType type)
        {
            GameObject prefab = null;
            if (type == MonsterType.Bird)           prefab = Resources.Load<GameObject>("Prefabs/Entities/Monster/BirdMonster");
            else if (type == MonsterType.Bottle)    prefab = Resources.Load<GameObject>("Prefabs/Entities/Monster/BottleMonster");
            else if (type == MonsterType.Frog)      prefab = Resources.Load<GameObject>("Prefabs/Entities/Monster/FrogMonster");
            else if (type == MonsterType.GreenBird) prefab = Resources.Load<GameObject>("Prefabs/Entities/Monster/GreenBirdMonster");
            else if (type == MonsterType.Normal)    prefab = Resources.Load<GameObject>("Prefabs/Entities/Monster/NormalMonster");
            else if (type == MonsterType.Rat)       prefab = Resources.Load<GameObject>("Prefabs/Entities/Monster/RatMonster");

            return prefab;
        }
    }
}

namespace Entity
{
    using ObjectPool;
    public class Spawner
    {
        //생성자
        public Spawner(GameObject entityObject, int amount, Transform spawnPosition,Team team)
        {
            pool = new MonoPool<EntityBase>(entityObject, amount, null);

            int count = pool.Lenght;
            for(int i=0;i<count;++i)
            {
                pool.pool[i].team = team;
            }
            this.spawnPosition = spawnPosition;
        }
        //구현
        MonoPool<EntityBase> pool;
        Transform spawnPosition;
        public IEnumerator DoSpawn(int amount, float delay)
        {   
            EntityBase instance;
            for (int i = 0; i < amount; ++i)
            {
                yield return new WaitForSeconds(delay);
                instance = pool.Get(false);
                if (instance == null) Debug.Log("오브젝트가 없다");
                instance.gameObject.SetActive(true);
                instance.transform.position = spawnPosition.position;
            }
        }
    }
}