using UnityEngine;

namespace ProjectTrain
{
    public class PlayerSystem : IInitializeSystem
    {
        Transform inGameParent;
        GameObject playerPrefab;
        public Player player { get; private set; }
        readonly string playerName = "Player";
        public void Initialize()
        {
            playerPrefab = Resources.Load<GameObject>("Prefabs/Player/Player");

            GameObject instance = GameObject.Instantiate(playerPrefab, inGameParent) as GameObject;
            instance.name = "Player";
        }

        public PlayerSystem(Transform inGameParent/*SceneData sceneData*/)
        {
            this.inGameParent = inGameParent;
        }
    }
}