using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace ProjectTrain
{
    public class SceneSystem : IExecuteSystem
    {
        SceneData[] sceneDatas =
            new SceneData[] {   new SceneData("Tutorial", new Vector2(-4f, 0.2f)),
                                new SceneData("China", new Vector2(-4f, 0.2f))
            };

        public SceneData sceneData(int index)
        {
            if (index < 0) return null;
            if (index > sceneDatas.Length) return null;

            return sceneDatas[index];
        }

        public void Execute()
        {
            if (!Input.GetKeyDown(KeyCode.R)) return;

            SceneManager.LoadScene("Scene");
        }
    }
}