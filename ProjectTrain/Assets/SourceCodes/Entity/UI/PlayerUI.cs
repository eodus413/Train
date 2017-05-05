namespace Entity.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    public class PlayerUI
    {
        //생성자
        public PlayerUI(PlayerBase player)
        {
            InitializeImage();

            player.attackedEvent += HpUIUpdate;
            player.reloadEvent += AmmoUIUpdate;
            player.attackEvent += AmmoUIUpdate;

            HpUIUpdate(player);
            AmmoUIUpdate(player);
        }

        //구현
        Image hpImage;
        Image ammoImage;

        void InitializeImage()
        {
            Transform parent = GameObject.Find("PlayerUI").transform;

            hpImage = parent.GetChild(0).GetChild(1).GetComponent<Image>();
            ammoImage = parent.GetChild(1).GetChild(1).GetComponent<Image>();

            hpImage.type = Image.Type.Filled;
            ammoImage.type = Image.Type.Filled;

            hpImage.fillMethod = Image.FillMethod.Horizontal;
            ammoImage.fillMethod = Image.FillMethod.Horizontal;
        }

        void HpUIUpdate(EntityBase player)
        {
            hpImage.fillAmount = player.remainHpPercent;
        }
        void AmmoUIUpdate(PlayerBase player)
        {
            if (player.currentWeapon.weaponType == Weapon.WeaponType.Gun)
            {
                Weapon.Gun gun = (Weapon.Gun)player.currentWeapon;
                ammoImage.fillAmount = gun.remainAmmoPercent;
            }
        }
    }
}