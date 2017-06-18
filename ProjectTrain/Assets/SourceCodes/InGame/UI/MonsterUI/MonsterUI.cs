namespace UI
{
    using Entity;
    using UnityEngine;
    using UnityEngine.UI;
    public abstract class MonsterUI
    {
        public MonsterBase monster { get; private set; }
        public MonsterUI(MonsterBase monster) : base()
        {
            this.monster = monster;
        }
        public abstract void Update();
    }
    public class MonsterHPUI : MonsterUI
    {
        readonly Vector2 rectSize = new Vector2(100, 10);
        Image UI;
        public MonsterHPUI(MonsterBase monster) : base(monster)
        {
            GameObject hpBarObj = new GameObject("HpBar");
            UI = hpBarObj.AddComponent<Image>();
            UI.rectTransform.sizeDelta = rectSize;
            UI.color = Color.red;

            UI.fillMethod = Image.FillMethod.Horizontal;
            
        }
        public override void Update()
        {
            UI.fillAmount = monster.remainHpPercent;
        }
    }
}