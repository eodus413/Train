using UnityEngine;
using System.Collections;
using ObjectPool;

namespace Entity
{
    public class Spawner
    {
        public Spawner(EntityBase entity,int amount,Transform spawnPosition)
        {
            pool = new GameObjectPool(entity.gameObject, amount, spawnPosition);
        }
        //구현
        GameObjectPool pool;
        IEnumerator DoSpawn(int amount,float delay)
        {
            GameObject instance;
            for(int i=0;i<amount;++i)
            {
                instance = pool.Get(false);
                instance.SetActive(true);
                yield return new WaitForSeconds(delay);
            }
        }
    }
}