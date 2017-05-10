namespace UI
{
    using UnityEngine;
    using UnityEngine.UI;
    using Entity;
    public class ReloadButton : MonoBehaviour
    {
        void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(EntityManager.player.Reload);
        }
    }
}