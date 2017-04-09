using UnityEngine;
using System.Collections.Generic;

namespace ObjectPool
{
    public class GameObjectPool
    {
        public GameObjectPool(GameObject prefab,int amount,Transform parent = null,bool isGrow = false)
        {
            this.isGrow = isGrow;
            ChangeObject(prefab, amount, parent);
        }

        bool isGrow;    //isGrow == true 라면 오브젝트를 가져올 때, 가져올 오브젝트가 없다면 새로 생성을 하고 가져옴
        private List<GameObject> pool = new List<GameObject>();   //오브젝트를 담는 List
        GameObject poolingPrefab;
        Transform parent;

        public void ChangeObject(GameObject newPrefab,int amount,Transform parent = null)
        {
            if (newPrefab == null) return;


            this.poolingPrefab = newPrefab;
            this.parent = parent;

            GameObject instance;
            for (int i = 0; i < amount; ++i)
            {
                instance = GameObject.Instantiate(newPrefab, parent);

                pool.Add(instance);
            }
        }
        public GameObject Get(bool isActive)
        {
            int count = pool.Count;
            for(int i =0; i < count; ++i)
            {
                if(pool[i].activeInHierarchy == isActive)
                {
                    return pool[i];
                }
            }

            if (isGrow) return Add();
            else return null;
        }
        
        private GameObject Add()
        {
            GameObject instance = GameObject.Instantiate(poolingPrefab, parent);

            pool.Add(instance);

            return instance;
        }

    }
}