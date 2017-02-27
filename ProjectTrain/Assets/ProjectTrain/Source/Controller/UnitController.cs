using UnityEngine;
using System.Collections.Generic;

namespace ProjectTrain
{
    //unit system
    public class UnitController : MonoBehaviour
    {
        List<Unit> units = new List<Unit>();
        void Awake()
        {
            Unit[] gets = GetComponentsInChildren<Unit>();

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