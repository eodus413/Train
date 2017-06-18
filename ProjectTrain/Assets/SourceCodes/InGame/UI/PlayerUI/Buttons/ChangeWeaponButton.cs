using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    using Entity;
    public partial class ChangeWeaponButton : MonoBehaviour
    {
        PlayerBase player;

        Image uiImage;

        private const int weaponAmount = 5;

        Sprite[] weaponImages = new Sprite[weaponAmount];
        void Start()
        {
            player = EntityManager.player;

            uiImage = GetComponent<Image>();

            Sprite[] loader = Resources.LoadAll<Sprite>("Sprites/UI/InGameUI");

            weaponImages[(int)Icon.Pistol]        = loader[(int)UISprite.ChangeWeapon_Pistol];
            weaponImages[(int)Icon.ShotGun]       = loader[(int)UISprite.ChangeWeapon_ShotGun];
            weaponImages[(int)Icon.Sniper]        = loader[(int)UISprite.ChangeWeapon_Sniper];
            weaponImages[(int)Icon.SubMachine]    = loader[(int)UISprite.ChangeWeapon_SubMachine];
            weaponImages[(int)Icon.Rifle]         = loader[(int)UISprite.ChangeWeapon_Rifle];

            Button button = GetComponent<Button>();
            button.onClick.AddListener(ChangeWeapon);
        }
        void SetImage(Icon icon)
        {
            uiImage.sprite = weaponImages[(int)icon];
        }
        enum Icon
        {
            Pistol,
            ShotGun,
            Sniper,
            SubMachine,
            Rifle
        }
    }
}
namespace UI
{
    using Weapon;
    public partial class ChangeWeaponButton : MonoBehaviour
    {
        void ChangeWeapon()
        {
            player.ChangeWeapon();


            IWeapon weapon = player.currentWeapon;
            if (weapon.weaponType == WeaponType.Gun)
            {
                Gun gun = weapon as Gun;
                GunType type = gun.gunType;
                if (type == GunType.Pistol)             SetImage(Icon.Pistol);
                else if (type == GunType.ShotGun)       SetImage(Icon.ShotGun);
                else if (type == GunType.SubMachine)    SetImage(Icon.SubMachine);
                else if (type == GunType.Rifle)         SetImage(Icon.Rifle);
                else if (type == GunType.Sniper)        SetImage(Icon.Sniper);
            }

            //else if(weapon.weaponType == WeaponType.Melee)
            //{
            //    MeleeWeapon melee = weapon as MeleeWeapon;

            //}
        }
    }
}