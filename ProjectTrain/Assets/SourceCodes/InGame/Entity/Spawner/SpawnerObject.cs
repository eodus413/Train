using UnityEngine;
using System.Collections;
using ObjectPool;

namespace Entity
{
    public class SpawnerObject : MonoBehaviour
    {
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

            GameObject prefab = Loaders.PrefabLoader.GetMonsterPrefab(monsterType);

            spawner = new Spawner(prefab, spawnAmount, transform);

            StartCoroutine(spawner.DoSpawn(spawnAmount, spawnDelay));
        }
    }
}

namespace Entity
{
    public class Spawner
    {
        //생성자
        public Spawner(GameObject entityObject, int amount, Transform spawnPosition)
        {
            pool = new GameObjectPool(entityObject, amount, spawnPosition);
        }
        //구현
        GameObjectPool pool;
        public IEnumerator DoSpawn(int amount, float delay)
        {   
            GameObject instance;
            for (int i = 0; i < amount; ++i)
            {
                yield return new WaitForSeconds(delay);
                instance = pool.Get(false);
                if (instance == null) Debug.Log("오브젝트가 없다");
                instance.SetActive(true);
            }
        }
    }
}