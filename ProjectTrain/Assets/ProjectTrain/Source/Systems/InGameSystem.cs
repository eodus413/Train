using UnityEngine;
using System.Collections.Generic;

namespace ProjectTrain
{
    public class InGameSystem : IInitializeSystem, IExecuteSystem
    {
        public Transform inGameParent { get; private set; }
        UnitController units;

        public void Initialize()
        {
            inGameParent = GameObject.Find("InGame").transform;

            GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Stage/Tutorial"), inGameParent);
           
            units = new UnitController(inGameParent);

            units.Initialize();
        }
        public void Execute()
        {

        }
    }
}