using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public static class SceneController
{
    static TempCoroutine StartCoroutine = StaticCoroutine.Instance.StartCoroutine;

    static FadeEffect fadeEffect = new FadeEffect();

    public static bool isSceneMoving { get; private set; }
    public static void LoadScene(string scene)
    {
        if (isSceneMoving) return;
        StartCoroutine(DoLoadScene(scene));
    }
    public static void LoadInGameScene()
    {
        LoadScene("InGame");
    }
    public static void LoadMainScene()
    {
        LoadScene("Main");
    }

    static IEnumerator DoLoadScene(string scene)
    {
        isSceneMoving = true;
        yield return null;
        yield return StartCoroutine(fadeEffect.DoFadeIn());
        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            // [0, 0.9] > [0, 1]
            float progress = Mathf.Clamp01(ao.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");

            // Loading completed
            if (ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }

            yield return null;
        }
        yield return StartCoroutine(fadeEffect.DoFadeOut());
        isSceneMoving = false;
    }
}