namespace FieldObject
{
    using UnityEngine;
    using LayerManager;
    using Entity;
    public class ItemObject : FieldObjectBase
    {
        Item item;
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.layer == Layers.Entities)
            {
                EntityBase entity = other.GetComponent<EntityBase>();
                if (entity == EntityManager.player)
                {
                    entity.GetItem(item);
                }
            }
        }
    }
}