using UnityEngine;
using System.Collections.Generic;

namespace ProjectTrain
{
    public partial class GameObjectPool
    {
        public GameObjectPool(GameObject obj, int amount = 1, Transform parent = null,bool isGrow = false,bool active = false)
        {
            this.isGrow = isGrow;
            this.obj = obj;
            this.parent = parent;
            this.pool = new List<GameObject>();

            GameObject instance;

            for (int i = 0; i < amount; ++i)
            {
                instance = GameObject.Instantiate(obj, parent) as GameObject;
                instance.SetActive(false);
                pool.Add(instance);
            }
            size = pool.Count;
        }
    }
}