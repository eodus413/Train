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
        private float[] spawnDelay;

        Spawner spawner;
        void Awake()
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Monsters/" + monsterType.ToString());

            spawner = new Spawner(prefab,10,transform);

            gameObject.SetActive(false);
        }
        void OnEnable()
        {
            StartCoroutine(Spawning());
        }
        IEnumerator Spawning()
        {
            int count = spawnDelay.Length;
            for (int i = 0; i < count; ++i)
            {
                yield return spawner.DoSpawn(3 + i, spawnDelay[i]);
            }
        }
    }
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
                instance.SetActive(true);
            }
        }
    }
}