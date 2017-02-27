using UnityEngine;
using System.Collections.Generic;

namespace ProjectTrain
{
    public partial class GameObjectPool
    {
        List<GameObject> pool;
        GameObject obj;
        Transform parent;

        bool isGrow;
        public int size { get { return pool.Count; } }

        private void Remove(int amount = 1, bool active = true)
        {
            GameObject target;
            for (int i = 0; i < size; ++i)
            {
                target = pool[i];
                if (target.activeInHierarchy == active)
                {
                    if (amount < 0) return;
                    --amount;
                    pool.Remove(target);
                }
            }
        }
        private void Append(int amount = 1, bool active = false)
        {
            GameObject instance;
            for (int i = 0; i < amount; ++i)
            {
                instance = GameObject.Instantiate(obj, parent) as GameObject;
                instance.SetActive(active);
                pool.Add(instance);
            }

        }
    }
}