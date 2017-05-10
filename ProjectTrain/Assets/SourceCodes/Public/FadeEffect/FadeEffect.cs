using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeEffect
{
    public GameObject fadeObj { get; private set; }
    Image fadeImage;

    public FadeEffect()
    {
        GameObject imageObj = new GameObject("FadeImage");
        fadeObj = imageObj;
        imageObj.transform.SetParent(GameObject.Find("FadeCanvas").transform);
        imageObj.transform.localPosition = Vector2.zero;
        imageObj.AddComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        fadeImage = imageObj.AddComponent<Image>();
        fadeImage.color = new Color(0f,0f,0f,0f);
    }

    public IEnumerator DoFadeIn()
    {
        Color color = fadeImage.color;
        for (float i = 0; i <= 1; i += 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
            color.a = i;
            fadeImage.color = color;
        }
    }
    public IEnumerator DoFadeOut()
    {
        Color color = fadeImage.color;
        for (float i = 1; i >= 0; i -= 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
            color.a = i;
            fadeImage.color = color;
        }
    }
    public static IEnumerator DoFadeIn(SpriteRenderer renderer)
    {
        Color color = renderer.color;
        for (float i = 0; i <= 1; i += 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
            color.a = i;
            renderer.color = color;
        }
    }
    public static IEnumerator DoFadeOut(SpriteRenderer renderer)
    {
        Color color = renderer.color;
        for (float i = 1; i >= 0; i -= 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
            color.a = i;
            renderer.color = color;
        }
    }
}
