using UnityEngine;

namespace Entity
{
    using Factory;

    public partial class MonsterBase : EntityBase
    {
        //초기화
        protected override void Initialize()
        {
            base.Initialize();

            gameObject.layer = LayerManager.Layers.Monster;

            CreateTargetingArea();
        }
        protected override IEntityFactory SetFactory()
        {
            _entityType = EntityType.Monster;
            return EntityFactoryMethod.GetFactory(monsterType);
        }
        //필드, 컴포넌트 등
        [SerializeField]
        MonsterType _monsterType;
        [SerializeField]

       
        //인터페이스
        public MonsterType monsterType
        {
            get { return _monsterType; }
        }
    }
}

namespace Entity
{
    using Decoration;

    public partial class MonsterBase : EntityBase
    {
        Transform targetingAreaTransform;
        TargetingArea targetingArea;

        void CreateTargetingArea()
        {
            targetingAreaTransform = new GameObject().transform;
            targetingAreaTransform.SetParent(transform);
            targetingAreaTransform.localPosition = Vector2.zero;
            targetingArea = targetingAreaTransform.gameObject.AddComponent<TargetingArea>();
        }
    }
}