using UnityEngine;
using System.Collections.Generic;

namespace ProjectTrain
{
    //unit system
    public class UnitController
    {
        public UnitController(Transform inGameParent)
        {
            this.inGameParent = inGameParent;
        }
        Transform inGameParent;
        List<Unit> units = new List<Unit>();
        public void Initialize()
        {
            Unit[] gets = inGameParent.GetComponentsInChildren<Unit>();

            for (int i = 0; i < gets.Length; ++i)
            {
                units.Add(gets[i]);
            }
            for (int i = 0; i < gets.Length; ++i)
            {
                units[i].ComponentInitialize();
            }
            for (int i = 0; i < gets.Length; ++i)
            {
                units[i].Initialize();
            }
        }
    }
}