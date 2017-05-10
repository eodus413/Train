namespace UI
{
    using UnityEngine;
    using UnityEngine.UI;
    using Entity;

    public class PlayerUI
    {
        //생성자
        public PlayerUI(PlayerBase player)
        {
            Transform parent = GameObject.Find("PlayerUI").transform;   //UI의 최상위 오브젝트를 가져옴

            Image image = parent.FindChild("HpBar").GetComponent<Image>();
            hpBar = new BarImageUI(image);

            Text[] text = parent.GetComponentsInChildren<Text>();
            hpkitText = new TextUI(text[0]);
            ammoText = new TextUI(text[1]);
        }

        //구현
        BarImageUI hpBar;
        TextUI hpkitText;
        TextUI ammoText;

        public void HpUIUpdate(EntityBase player)
        {
            hpBar.SetValue(player.remainHpPercent);
        }
        public void AmmoUIUpdate(PlayerBase player)
        {
            if (player.currentWeapon.weaponType == Weapon.WeaponType.Gun)
            {
                Weapon.Gun gun = (Weapon.Gun)player.currentWeapon;
                ammoText.SetText(gun.ammoAmount);
            }
        }
        public void HpKitUIUpdate(PlayerBase player)
        {   
        }
    }
}