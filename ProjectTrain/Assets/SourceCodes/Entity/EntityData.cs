using System.Collections.Generic;

namespace Entity
{
    public static class EntityData
    {
        public static EntityBase player { get; private set; }
        public static void SetPlayer(EntityBase entity)
        {
            if (entity == null) return;
            if (entity.type != EntityType.Player) return;
            player = entity;
        }

        public static Dictionary<EntityBase, EntityBase> entityList = new Dictionary<EntityBase, EntityBase>();
        public static void AddEntity(EntityBase entity)
        {
            entityList.Add(entity,entity);
            if (entity.type == EntityType.Player) SetPlayer(entity);
        }
    }
}