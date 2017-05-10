using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace ObjectPool
{
    public class GameObjectPool
    {
        public GameObjectPool(GameObject prefab,int amount,Transform parent = null,bool isGrow = false)
        {
            this.isGrow = isGrow;
            Initialize(prefab, amount, parent);
        }

        public bool isGrow { get; private set; }    //isGrow == true 라면 오브젝트를 가져올 때, 가져올 오브젝트가 없다면 새로 생성을 하고 가져옴
        protected List<GameObject> pool = new List<GameObject>();   //오브젝트를 담는 List
        public GameObject poolingPrefab { get; private set; }
        public Transform parent { get; private set;}

        public void Initialize(GameObject newPrefab,int amount,Transform parent = null)
        {
            if (newPrefab == null) return;
            
            this.poolingPrefab = newPrefab;
            this.parent = parent;
            
            for (int i = 0; i < amount; ++i)
            {
                AddObject(newPrefab);
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
            Debug.Log("부족함");
            if (isGrow) return AddObject(poolingPrefab);
            else return null;
        }
        
        protected GameObject AddObject(GameObject newPrefab)
        {
            GameObject instance = GameObject.Instantiate(newPrefab, parent);
            if (parent) instance.transform.position = parent.position;
            instance.SetActive(false);
            pool.Add(instance);

            return instance;
        }
    }
}