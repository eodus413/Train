using UnityEngine;
using System.Collections;

namespace Entity
{
    using Factory;

    public partial class MonsterBase : EntityBase
    {
        //초기화
        protected override void Initialize()
        {
            base.Initialize();
            if(eye == null) eye = NewEye();
            else eye = transform.GetChild(0);

            BoxCollider2D box = bodyCollider as BoxCollider2D;

            bodyWidth = box.size.x + box.offset.x;

            InitializeUI();
        }
        protected override IEntityFactory SetFactory()
        {
            type = EntityType.Monster;
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
    using Raycast2DManager;
    using LayerManager;

    public partial class MonsterBase : EntityBase
    {
        const int damage = 1;
        [SerializeField]
        float bodyWidth;
        public float attackRange
        {
            get
            {
                return bodyWidth ;
            }
        }
        
        const float atttackCoolTime = 1f;
        const float startDelay = 0.1f;

        public readonly float sight = 1f;

        Transform eye;
        Transform NewEye()
        {
            Transform newEye = new GameObject("Eye").transform;

            newEye.SetParent(transform);
            newEye.localPosition = new Vector2(bodyCollider.offset.x, bodyCollider.offset.y);
            return newEye;
        }

        public EntityBase Targeting()
        {
            GameObject targetObj = Ray2DManager.StartCasting(eye.transform, sight, Layers.EntitiesMask, Layers.GroundMask);

            if (targetObj == null) return null;

            EntityBase targetEntity = targetObj.GetComponent<EntityBase>();

            if (targetEntity.team == team) return null;
            
            return targetEntity;
        }
        public float DistanceTo(EntityBase target)
        {
            if (target == null) return float.Epsilon; 
            return Vector3.Distance(target.transform.position, transform.position);
        }
        public bool isInSight(EntityBase target)
        {
            if (target == null) return false;
            return DistanceTo(target) <= sight;
        }
        public bool IsAbleToAttack(EntityBase target)
        {
            if (target == null) return false;       //타겟이 없거나

            if (DistanceTo(target) > attackRange) return false;    //타겟이 공격 사거리보다 밖에 있으면
            
            return true;
        }

        public IEnumerator AttackTarget(EntityBase target)
        {
            yield return new WaitForSeconds(startDelay);
            
            if (IsAbleToAttack(target) == false) yield break; 

            animator.Play("Attack");
            Attack.To(target, new AttackData(this, target, damage, lookDirection));

            yield return new WaitForSeconds(atttackCoolTime);
        }
    }
}

namespace Entity
{
    using UI;
    public partial class MonsterBase : EntityBase
    {
        HpBarUI hpBarUI;
        void InitializeUI()
        {
            Debug.Log(ResourceLoad.hpBar);
            hpBarUI = new HpBarUI(this,ResourceLoad.hpBar);
        }
    }
}