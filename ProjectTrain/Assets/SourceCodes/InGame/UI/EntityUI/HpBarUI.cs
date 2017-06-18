namespace UI
{
    using UnityEngine;
    using Entity;   
    public class HpBarUI : EntityUI
    {
        SpriteRenderer renderer;
        public HpBarUI(EntityBase entity,Sprite sprite) : base(entity,"HpBar : " + entity.name)
        {
            entity.AddHpUpdateEvent(Update);
            renderer = transform.gameObject.AddComponent<SpriteRenderer>();
            renderer.sprite = sprite;
            renderer.sortingLayerID = SortingLayer.NameToID("UI");
            renderer.color = Color.red;
        }
        void Update()
        {
            float hpPercent = entity.remainHpPercent;
            float angle = Mathf.Lerp(0f, 90f, 1 - hpPercent);

            renderer.color = new Color(1f,1f - hpPercent, 0f);

            transform.localEulerAngles = (new Vector3(0,angle,0));
        }
    }
}