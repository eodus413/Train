using UnityEngine;

namespace Weapon
{
    using Entity;
    using Entity.Decoration;
    //근접무기
    public partial class MeleeWeapon : IWeapon
    {
        //생성자
        public MeleeWeapon(EntityBase owner,int damage,TargetingArea targetingArea)
        {
            this.owner = owner;
            this.damage = damage;

            this.targetingArea = targetingArea;
        }
        //인터페이스
        public WeaponType weaponType { get { return WeaponType.Sword; } }

        public bool isReadyForAttack { get; private set; }

        public int damage { get; private set; }
        public float attackRange { get { return 0.1f; } }
        public float startDelay { get; private set; }
        public float cooltime { get; private set; }

        public EntityBase owner { get; private set; }

        public void AttackTarget()
        {
            if (!isAttackableTarget()) return;  //공격가능한 타겟이 아니라면 종료
            Attack.To(targetingArea.target,new AttackData(owner,damage,owner.lookDirection));
        }
        //구현
        TargetingArea targetingArea;
    }
}

namespace Weapon
{
    using Raycast2DManager;
    using LayerManager;

    public partial class MeleeWeapon : IWeapon
    {
        bool isAttackableTarget()
        {
            if (targetingArea.target)
            {
                Vector2 targetPos = targetingArea.target.transform.position;

                Vector2 origin = owner.transform.position;
                Vector2 direction = (origin - targetPos).normalized;

                //Target과 Attacker 사이의 벽이 있는지 확인하기 위한 raycast
                //Ground Layer를 raycast함
                GameObject targetObj = Ray2DManager.StartCasting(origin, direction, attackRange,Layers.GroundMask);
                Debug.Log(direction);
                if (!targetObj) return true;    //만약 벽이 없다면 공격가능한 타겟
            }
            return false;
        }
    }
}