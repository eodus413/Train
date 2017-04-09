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
        public static EntityBase player { get; private set; }
        // - Normal 몬스터들
        public static List<EntityBase> normalMonsters = new List<EntityBase>();
        // - Upgrade 몬스터들
        public static List<EntityBase> upgradeMonsters = new List<EntityBase>();
        

        public static void AddEntity(EntityBase entity)
        {
            if (entity == null) return;

            entities.Add(entity);
            SetDetailType(entity);
        }

        //구현
        const string EntityCategoryName = " (Entity)";
        static void SetDetailType(EntityBase entity)
        {
            entity.gameObject.name += EntityCategoryName;  //게임 오브젝트 이름에 (Entity) tag추가

            if (entity.type == EntityType.Player)
            {
                player = entity;
                entity.gameObject.tag = "Player";
            }
            else if (entity.type == EntityType.NormalMonster)
            {
                normalMonsters.Add(entity);
                entity.gameObject.tag = "Monster";
            }
            else if (entity.type == EntityType.UpgradeMonster)
            {
                upgradeMonsters.Add(entity);
                entity.gameObject.tag = "Monster";
            }
        }
    }
}