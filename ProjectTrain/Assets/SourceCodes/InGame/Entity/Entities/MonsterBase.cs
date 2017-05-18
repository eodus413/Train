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
        const float attackRange = 0.1f;
        const float atttackCoolTime = 1f;
        const float startDelay = 0.1f;

        const float sight = 1f;

        Transform eye;
        Transform NewEye()
        {
            Transform newEye = new GameObject("Eye").transform;
            newEye.position = new Vector2(bodyCollider.offset.x,bodyCollider.offset.y);

            newEye.SetParent(transform);
            return newEye;
        }

        public EntityBase Targeting()
        {
            GameObject targetObj = Ray2DManager.StartCasting(eye.transform, sight, Layers.EntitiesMask, Layers.GroundMask);

            if (targetObj == null) return null;
            else return targetObj.GetComponent<EntityBase>();
        }
        public float DistanceToTarget(EntityBase target)
        {
            if (target == null) return float.Epsilon; 
            return Vector3.Distance(target.transform.position, transform.position);
        }
        public bool CanAttack(EntityBase target)
        {
            if (target == null) return false;       //타겟이 없거나
            if (DistanceToTarget(target) > attackRange) return false;    //타겟이 공격 사거리보다 밖에 있으면
            return true;
        }

        public IEnumerator AttackTarget(EntityBase target)
        {
            yield return new WaitForSeconds(startDelay);

            if (DistanceToTarget(target) <= attackRange) yield break;

            if (CanAttack(target) == false) yield break; 

            animator.Play("Attack");
            Attack.To(target, new AttackData(this, damage, lookDirection));

            yield return new WaitForSeconds(atttackCoolTime);
        }
    }
}