namespace UI
{
    using UnityEngine;
    using UnityEngine.UI;
    using Entity;
    using UnityEngine.EventSystems;

    public class AttackButton : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
    {
        System.Action attack;

        bool isButtonDown;
        void Start()
        {
            isButtonDown = false;
            attack = EntityManager.player.UseWeapon;
        }
        
        void Update()
        {
            if (isButtonDown) attack();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isButtonDown = false;
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            isButtonDown = true;
        }

    }
}