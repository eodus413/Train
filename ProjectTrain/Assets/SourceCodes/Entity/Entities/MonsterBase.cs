namespace Entity
{
    using UnityEngine;
    using Factory;

    public class MonsterBase : EntityBase
    {
        //초기화
        protected override IEntityFactory SetFactory()
        {
            _entityType = EntityType.Monster;
            return EntityFactoryMethod.GetFactory(monsterType);
        }
        //필드, 컴포넌트 등
        [SerializeField]
        MonsterType _monsterType;
       
        //인터페이스
        public MonsterType monsterType
        {
            get { return _monsterType; }
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                EntityBase entity = other.GetComponent<EntityBase>();
                entity.Attacked(new AttackData(entity, 10, entity.lookDirection));
            }
        }  
    }
}