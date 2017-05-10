namespace UI
{
    using UnityEngine;
    using UnityEngine.UI;
    using Entity;
    using Loaders;
    public class ChangeWeaponButton : MonoBehaviour
    {
        Image uiImage;

        private const int weaponAmount = 5;

        Sprite[] weaponImages = new Sprite[weaponAmount];
        void Start()
        {
            uiImage = GetComponent<Image>();

            MultiplySpriteLoader loader = new MultiplySpriteLoader("Sprites/UI/InGameUI");
            int lenght = loader.Lenght;
            for (int i = lenght - weaponAmount; i < lenght; ++i)
            {
                weaponImages[i] = loader.Sprites[i];
            }

            Button button = GetComponent<Button>();
            button.onClick.AddListener(ChangeWeapon);
        }
        void ChangeWeapon()
        {
            EntityManager.player.ChangeWeapon();
            uiImage.sprite =  
        }
    }

}