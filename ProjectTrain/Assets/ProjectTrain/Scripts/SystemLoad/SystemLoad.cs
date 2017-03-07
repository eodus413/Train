using UnityEngine;
using System.Collections.Generic;

namespace ProjectTrain
{
    public class SystemLoad : MonoBehaviour
    {
        Systems systems;
        InGameSystem inGame;
        void Awake()
        {
            systems = new Systems();

            systems.Add(inGame = new InGameSystem()).
                    Add(new SceneSystem()).
                    Add(new PlayerSystem(inGame.inGameParent));

            systems.Initialize();
        }
        void Update()
        {
            systems.Execute();
        }

    }
}