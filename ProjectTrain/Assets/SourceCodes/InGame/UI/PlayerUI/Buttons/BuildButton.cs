namespace UI
{
    using UnityEngine;
    using UnityEngine.UI;
    using Entity;
    public class BuildButton : MonoBehaviour
    {
        void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }
        public void OnClick()
        {
        }
        void SettingBuildButtons()
        {

        }
    }
}