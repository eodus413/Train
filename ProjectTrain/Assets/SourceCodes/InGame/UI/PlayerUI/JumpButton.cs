namespace UI
{
    using UnityEngine;
    using UnityEngine.UI;
    using Entity;
    public class JumpButton : MonoBehaviour
    {
        void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(EntityManager.player.Jump);
        }
    }

}