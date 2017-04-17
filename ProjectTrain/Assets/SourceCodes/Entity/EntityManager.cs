using System.Collections.Generic;

namespace Entity
{
    public static class EntityManager
    {
        //인터페이스

        //모든 개체들
        public static List<EntityBase> entities = new List<EntityBase>();

        //세부 리스트
        // - 플레이어
        public static PlayerBase player { get; private set; }
        

        public static void AddEntity(EntityBase entity)
        {
            if (entity == null) return;

            entity.gameObject.name += EntityCategoryName;  //게임 오브젝트 이름에 (Entity) tag추가

            entity.gameObject.layer = entity.entityType.GetLayer();

            entities.Add(entity);
        }
        public static void RemoveEntity(EntityBase entity)
        {
            entities.Remove(entity);
        }
        public static void SetPlayer(PlayerBase newPlayer)
        {
            player = newPlayer;
        }

        //구현
        const string EntityCategoryName = " (Entity)";
    }
}