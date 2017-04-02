using UnityEngine;
using System.Collections;
using Factory;
using Entity.Controller;

namespace Entity
{
    #region RequireComponent

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    #endregion

    #region UnityEvent Functions
    public partial class EntityBase : MonoBehaviour
    {
        private EntityController controller;

        void Awake()
        {
            ComponentInitialize();
            Initialize();
            StartCoroutine(controller.Start());
        }
    }
    #endregion

    public partial class EntityBase : MonoBehaviour
    {
        #region Components

        public Collider2D bodyCollider { get; private set; }
        public Rigidbody2D baseRigidbody { get; private set; }
        public Animator animator { get; private set; }
        public SpriteRenderer baseRenderer { get; private set; }

        IEntityFactory factory;

        #endregion

        const string EntityCategoryName = " (Entity)";
        void ComponentInitialize()
        {
            factory = EntitySetter.GetFactory(type);

            gameObject.name += EntityCategoryName;  //게임 오브젝트 이름에 (Entity) tag추가

            baseRigidbody = GetComponent<Rigidbody2D>();
            baseRigidbody.freezeRotation = true;
            
            bodyCollider = factory.SetCollider(this);

            sight = factory.SetSight(this);
        }
    }

    public partial class EntityBase : MonoBehaviour
    {
        [SerializeField]
        EntityType type;

        [SerializeField]
        private int _hp;
        public int hp
        {
            get { return _hp; }
            private set
            {
                _hp = value;
                if (_hp <= 0) Dead();
            }
        }
        #region Move
        [SerializeField]
        private float _speed;
        public float speed
        {
            get
            {
                if (lookDirection != moveDirection) return _speed * 0.5f;
                return _speed;
            }
            private set
            {
                _speed = value;
            }
        }
        public float moveSpeed
        {
            get { return speed * Time.deltaTime; }
        }
        Direction moveDirection;
        public void Move(Direction direction)
        {
            moveDirection = direction;
            transform.Translate(direction * moveSpeed);
        }
        #endregion

        #region Attack
        public bool isAttacking { get; private set; }

        [SerializeField]
        private int _damage;
        public int damage
        {
            get { return _damage; }
            private set { _damage = value; }
        }

        [SerializeField]
        private float _attackRange;
        public float attackRange
        {
            get { return _attackRange; }
            private set
            {
                _attackRange = value;
            }
        }
        public void Attacked(int damage)
        {
            hp -= damage;
        }
        public void Attack()
        {
            if (sight.target == null) return;
            if (sight.DistanceToTarget > attackRange) return;
            if (isAttacking) return;

            StartCoroutine(DoAttack());
        }
        float attackDelay = 0.5f;
        IEnumerator DoAttack()
        {
            isAttacking = true;

            yield return new WaitForSeconds(attackDelay);

            if (sight.DistanceToTarget > attackRange) yield break;

            EntityBase entity = sight.target.GetComponent<EntityBase>();
            entity.Attacked(damage);

            isAttacking = true;
        }

        #endregion

        #region Sight
        [SerializeField]
        private EntitySight _sight; //sight => eye
        public EntitySight sight
        {
            get { return _sight; }
            private set { _sight = value; }
        }

        public Direction lookDirection { get; private set; }
        public void LookAt(Direction direction)
        {
            lookDirection = direction;
            gameObject.Turn2D(direction);
        }
        #endregion
        #region Initialize

        public void Initialize()
        {
            isAttacking = false;
            
            hp = factory.SetHp();
            damage = factory.SetDamage();
            attackRange = factory.SetAttackRange();
            speed = factory.SetSpeed();
            
            gameObject.layer = EntitySetter.GetLayer(type);

            controller = EntitySetter.GetController(this,type);
        }

        #endregion


        #region CallBacks

        void Dead()
        {

        }

        #endregion
    }
}