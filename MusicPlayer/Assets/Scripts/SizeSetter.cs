using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeSetter : MonoBehaviour
{
    Image image;
    RectTransform rect;
    void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();

        float width = image.sprite.rect.width;
        float height = image.sprite.rect.height;

        Vector2 size = new Vector2(width,height);
        rect.sizeDelta = size;
    }


}
