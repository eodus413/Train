using UnityEngine;
using System.Collections.Generic;

namespace ProjectTrain
{
    public partial class GameObjectPool
    {
        private GameObject Create(bool active = false)
        {
            GameObject instance;
            instance = GameObject.Instantiate(obj, parent) as GameObject;
            instance.SetActive(active);
            pool.Add(instance);
            return instance;
        }
        public GameObjectPool(GameObject obj, int amount = 1, Transform parent = null,bool isGrow = false,bool active = false)
        {
            this.isGrow = isGrow;
            this.obj = obj;
            this.parent = parent;
            this.pool = new List<GameObject>();


            for (int i = 0; i < amount; ++i)
            {
                Create();
            }
            size = pool.Count;
        }
    }
}