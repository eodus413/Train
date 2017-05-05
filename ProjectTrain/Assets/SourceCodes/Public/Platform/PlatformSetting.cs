using UnityEngine;
using Singleton;

public class PlatformSetting : MonoSingleton<PlatformSetting>
{
    [SerializeField]
    private bool isPC;
    [SerializeField]
    private float width;
    [SerializeField]
    private float height;

    void Start()
    {
        if (isPC) Platform.SetPC();
        else Platform.SetMobile();

        width = Screen.width;
        height = Screen.height;
    }
}