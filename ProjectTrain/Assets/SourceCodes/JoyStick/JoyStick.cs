using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace VirtualJoyStick
{
    public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField]
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        [SerializeField]
        private bool isHorizontal = true;
        [SerializeField]
        private bool isVertical = true;


        private Image joyPadImage;
        private RectTransform joyPadRect;

        private Image joyStickImage;
        private RectTransform joyStickRect;

        private Vector3 inputVector = Vector3.zero;

        public bool isMoving { get; private set; }

        void Awake()
        {
            joyPadRect = GetComponent<RectTransform>();
            joyPadImage = GetComponent<Image>();

            joyStickRect = transform.GetChild(0).GetComponent<RectTransform>();
            joyStickImage = joyStickRect.GetComponent<Image>();

            JoyStickManager.AddJoyStick(this);
        }

        public virtual void OnPointerDown(PointerEventData ped)
        {
            OnDrag(ped);
        }
        public virtual void OnPointerUp(PointerEventData ped)
        {
            isMoving = false;
            inputVector = Vector3.zero;
            joyStickRect.anchoredPosition = Vector3.zero;
        }
        public virtual void OnDrag(PointerEventData ped)
        {
            isMoving = true;
            Vector2 pos;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joyPadRect, ped.position, ped.pressEventCamera, out pos))
            {
                pos.x = (pos.x / joyPadRect.sizeDelta.x);
                pos.y = (pos.y / joyPadRect.sizeDelta.y);

                inputVector = new Vector3(pos.x * 2, 0, pos.y * 2);
                inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

                if (!isHorizontal) inputVector.x = 0;
                if (!isVertical) inputVector.z = 0;

                joyStickRect.anchoredPosition = new Vector3(inputVector.x * joyPadRect.sizeDelta.x * 0.3f, inputVector.z * joyPadRect.sizeDelta.y * 0.3f);
            }
        }
        public float GetHorizontalValue()
        {
            return inputVector.x;
        }
        public float GetVerticalValue()
        {
            return inputVector.y;
        }
    }
}