namespace UI
{
    using UnityEngine;
    using UnityEngine.UI;
    public class TextUI
    {
        public TextUI(string name)
        {
            UI = GameObject.Find(name).GetComponent<Text>();
        }
        public TextUI(Text text)
        {
            this.UI = text;
        }

        public Text UI { get; private set; }
        
        public void SetText(int number)
        {
            UI.text = number.ToString();
        }
    }
}