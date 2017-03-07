using UnityEngine;
using System.Collections.Generic;

namespace ProjectTrain
{
    public class UnitControlSystem : IInitializeSystem,IExecuteSystem
    {
        public UnitControlSystem(Player player)
        {
            monsters = new List<MonsterBase>();
        }
        List<MonsterBase> monsters;
        Player player;

        public void Initialize()
        {

        }
        public void Execute()
        {

        }
    }
}