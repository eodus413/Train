namespace UI
{
    using UnityEngine;
    using UnityEngine.UI;
    using Entity;

    public class HpBar : MonoBehaviour
    {
        PlayerBase player;
        Image UI;
        void Start()
        {
            player = EntityManager.player;
            UI = GetComponent<Image>();
            UI.fillMethod = Image.FillMethod.Horizontal;
        }

        void Update()
        {
            UI.fillAmount = player.remainHpPercent;
        }

    }
}