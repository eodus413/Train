namespace UI
{
    using UnityEngine;
    using UnityEngine.UI;
    using System.Text;
    using Entity;

    public class AmmoText : MonoBehaviour
    {
        Text UI;
        StringBuilder builder;

        PlayerBase player;
        void Start()
        {
            UI = GetComponent<Text>();
            builder = new StringBuilder("0");

            player = EntityManager.player;
        }
        void Update()
        {
            if (player.currentGun == null) MeleeUpdate();
            else GunUpdate();
        }


        bool isGun = true;
        void MeleeUpdate()
        {
            if (isGun == false) return;
            isGun = false;
            UI.text = "None";
        }

        void GunUpdate()
        {
            isGun = true;
            builder.Remove(0, builder.Length);
            builder.Append(player.currentGun.ammoAmount.ToString()).Append("/").Append(player.currentGun.maxAmmo.ToString());
            UI.text = builder.ToString();
        }
    }
}