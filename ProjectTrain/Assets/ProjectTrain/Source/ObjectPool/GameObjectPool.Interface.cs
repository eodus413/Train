using UnityEngine;
using System.Collections.Generic;

namespace ProjectTrain
{
    public partial class GameObjectPool
    {
        public GameObject Get(bool active)
        {
            for (int i = 0; i < size; ++i)
            {
                if (pool[i].activeInHierarchy == active)
                {
                    return pool[i];
                }
            }
            if(isGrow)
            {
                return Create();
            }
            return null;
        }
    }
}