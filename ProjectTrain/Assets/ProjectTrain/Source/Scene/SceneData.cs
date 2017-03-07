using UnityEngine;

namespace ProjectTrain
{
    public class SceneData
    {
        public string name { get; private set; }
        public Vector2 spawnPosition { get; private set; }

        public SceneData(string name,Vector2 spawnPosition)
        {
            this.name = name;
            this.spawnPosition = spawnPosition;
        }
    }
}