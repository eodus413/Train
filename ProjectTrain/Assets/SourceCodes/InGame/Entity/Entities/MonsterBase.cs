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
            CreateTargetingArea();
        }
        protected override IEntityFactory SetFactory()
        {
            entityType = EntityType.Monster;
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
    }
}

namespace Entity
{
    using Decoration;

    public partial class MonsterBase : EntityBase
    {
        Transform targetingAreaTransform;
        TargetingArea targetingArea;

        public bool isAbleToAttack { get { return targetingArea.isDetectedTarget; } }
        public EntityBase target { get { return targetingArea.target; } }

        void CreateTargetingArea()
        {
            targetingAreaTransform = new GameObject().transform;
            targetingAreaTransform.SetParent(transform);
            targetingAreaTransform.localPosition = Vector2.zero;
            targetingArea = targetingAreaTransform.gameObject.AddComponent<TargetingArea>();
        }
    }
}

namespace Entity
{
    using UnityEngine;
    using Weapon;
    using Weapon.Factory;
    public partial class MonsterBase : EntityBase
    {
        IWeapon currentWeaopn;
        void InitializeWeapon()
        { 
        }
        public void AttackTarget()
        {
        }
    }
}