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
        void Awake()
        {
            gameObject.name = monsterType.ToString() + " : Spawner";

            GameObject prefab = GetMonsterPrefab(monsterType);

            spawner = new Spawner(prefab, spawnAmount, transform,team);

            StartCoroutine(spawner.DoSpawn(spawnAmount, spawnDelay));
        }
        GameObject GetMonsterPrefab(MonsterType type)
        {
            GameObject prefab = null;
            if (type == MonsterType.Bird)           prefab = Resources.Load<GameObject>("Prefabs/Entities/BirdMonster");
            else if (type == MonsterType.Bottle)    prefab = Resources.Load<GameObject>("Prefabs/Entities/BottleMonster");
            else if (type == MonsterType.Frog)      prefab = Resources.Load<GameObject>("Prefabs/Entities/FrogMonster");
            else if (type == MonsterType.GreenBird) prefab = Resources.Load<GameObject>("Prefabs/Entities/GreenBirdMonster");
            else if (type == MonsterType.Normal)    prefab = Resources.Load<GameObject>("Prefabs/Entities/NormalMonster");
            else if (type == MonsterType.Rat)       prefab = Resources.Load<GameObject>("Prefabs/Entities/RatMonster");

            return prefab;
        }
    }
}

namespace Entity
{
    public class Spawner
    {
        //생성자
        public Spawner(GameObject entityObject, int amount, Transform spawnPosition,Team team)
        {
            pool = new GameObjectPool(entityObject, amount, null);

            int count = pool.Lenght;
            for(int i=0;i<count;++i)
            {
                pool.pool[i].GetComponent<EntityBase>().team = team;
            }

            this.spawnPosition = spawnPosition;
        }
        //구현
        GameObjectPool pool;
        Transform spawnPosition;
        public IEnumerator DoSpawn(int amount, float delay)
        {   
            GameObject instance;
            for (int i = 0; i < amount; ++i)
            {
                yield return new WaitForSeconds(delay);
                instance = pool.Get(false);
                if (instance == null) Debug.Log("오브젝트가 없다");
                instance.SetActive(true);
                instance.transform.position = spawnPosition.position;
            }
        }
    }
}