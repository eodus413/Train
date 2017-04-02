using UnityEngine;
using System.Collections;

public class ApplicationSetting : MonoBehaviour
{
    void Awake()
    {
        Application.runInBackground = true;
    }
}
