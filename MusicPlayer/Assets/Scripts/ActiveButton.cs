using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveButton : MonoBehaviour
{
    Image image;
    void Awake()
    {
        image = GetComponent<Image>();
    }
    bool active = false;
    public void SetActive()
    {
        active = !active;
        if (active) image.color = Color.red;
        else image.color = Color.white;
    }
}
