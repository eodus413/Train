namespace UI
{
    using Entity;
    using UnityEngine;
    public abstract class EntityUI
    {
        public EntityBase entity { get; private set; }
        public Transform transform { get; private set; }
        public EntityUI(EntityBase entity,string name)
        {
            this.entity = entity;
            transform = new GameObject(name).transform;
            transform.SetParent(entity);
            transform.localPosition = new Vector2(-0.03f,0.15f);
        }
    }
}