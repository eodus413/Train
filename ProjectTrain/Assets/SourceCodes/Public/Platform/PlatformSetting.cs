using UnityEngine;

public class PlatformSetting : MonoBehaviour
{
    [SerializeField]
    private bool isPC;
    [SerializeField]
    private float width;
    [SerializeField]
    private float height;

    void Awake()
    {
        if (isPC) Platform.SetPC();
        else Platform.SetMobile();

        width = Screen.width;
        height = Screen.height;
        DontDestroyOnLoad(gameObject);
    }
}