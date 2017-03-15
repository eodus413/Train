using UnityEngine;
using System.Collections.Generic;

namespace ProjectTrain
{
    public class SystemLoad : MonoBehaviour
    {
        Systems systems;
        void Awake()
        {
            systems = new Systems();

            systems.Initialize();
        }
        void Update()
        {
            systems.Execute();
        }

    }
}