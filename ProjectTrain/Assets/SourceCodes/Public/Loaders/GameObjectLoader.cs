using UnityEngine;

namespace Loaders
{
    //게임오브젝트 생성해서 번호 붙임
    public class GameObjectLoader
    {
        public GameObject[] gameObjects { get; private set; }
        public Transform[] transforms { get; private set; }
        public GameObjectLoader(string name, int amount,Transform parent)
        {
            gameObjects = new GameObject[amount];
            transforms = new Transform[amount];
            for (int i = 0; i < amount; ++i)
            {
                gameObjects[i] = new GameObject(name + '_' + (i + 1));
                transforms[i] = gameObjects[i].transform;

                transforms[i].SetParent(parent);
            }
        }
    }
}