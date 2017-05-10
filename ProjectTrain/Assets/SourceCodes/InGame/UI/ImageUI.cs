namespace UI
{
    using UnityEngine;
    using UnityEngine.UI;
    public class ImageUI
    {
        public ImageUI(string name)
        {
            UI = GameObject.Find(name).GetComponent<Image>();
        }
        public ImageUI(Image image)
        {
            UI = image;
        }

        public Image UI { get; private set; }

    }

    public class BarImageUI : ImageUI
    {
        public BarImageUI(string name) : base(name) { }
        public BarImageUI(Image image) : base(image)
        {
            UI.fillMethod = Image.FillMethod.Horizontal;
            UI.type = Image.Type.Filled;
        }

        public void SetValue(float value)
        {
            UI.fillAmount = value;
        }
    }
}