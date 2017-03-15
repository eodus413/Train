namespace ProjectCatMan
{
    public class SceneManager
    {
        public static void LoadScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

            InGameManager.SetFactory(sceneName);
        }
    }
}