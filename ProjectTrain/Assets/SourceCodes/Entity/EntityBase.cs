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
            EntityData.AddEntity(this);
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
            factory = EntitySetter.GetFactory(_type);

            gameObject.name += EntityCategoryName;  //게임 오브젝트 이름에 (Entity) tag추가

            baseRigidbody = factory.SetRigidbody(this);
            bodyCollider = factory.SetCollider(this);

            animator = GetComponent<Animator>();
        }
    }

    public partial class EntityBase : MonoBehaviour
    {
        [SerializeField]
        EntityType _type;
        public EntityType type
        {
            get { return _type;}
        }

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
        Direction _moveDirection;
        public Direction moveDirection
        {
            get { return _moveDirection; }
            private set
            {
                _moveDirection = value;
                if (_moveDirection == Direction.zero)
                {
                    isMoving = false;
                }
                else
                {
                    isMoving = true;
                }
            }
        }
        private readonly string id_isMoving = "IsMoving";
        private bool _isMoving = false;
        public bool isMoving
        {
            get { return _isMoving; }
            private set
            {
                _isMoving = value;
                animator.SetBool(id_isMoving, isMoving);
            }
        }
        public void Move(Direction direction)
        {
            moveDirection = direction;
            transform.Translate(direction * moveSpeed);
        }
        #endregion

        #region Attacked
        public void Attacked(int damage)
        {
            hp -= damage;
        }
        #endregion

        #region Sight

        public EntitySight eye { get; private set; } //sight => eye

        private readonly string id_lookFoward = "LookFoward";
        private bool _lookFoward;
        public bool lookFoward
        {
            get { return _lookFoward; }
            private set
            {
                _lookFoward = value;
                animator.SetBool(id_lookFoward, _lookFoward);
            }
        }
        private Direction _lookDirection = Direction.zero;
        public Direction lookDirection
        {
            get { return _lookDirection; }
            private set
            {
                _lookDirection = value;

                gameObject.Turn2D(_lookDirection);
                lookFoward = _lookDirection == moveDirection;
            }
        }
        public void LookAt(Direction direction)
        {
            lookDirection = direction;
            gameObject.Turn2D(direction);
        }
        #endregion


        #region Initialize

        public void Initialize()
        {
            eye = factory.SetSight(this);

            //isAttacking = false;

            hp = factory.SetHp();
            //damage = factory.SetDamage();
            //attackRange = factory.SetAttackRange();
            speed = factory.SetSpeed();
            
            gameObject.layer = EntitySetter.GetLayer(_type);

            controller = EntitySetter.GetController(this,_type);
        }

        #endregion
        #region CallBacks

        void Dead()
        {
        }

        #endregion
    }
    public partial class EntityBase : MonoBehaviour
    {
        public readonly float attackRange = 0.1f;
        public bool isReadyForAttack
        {
            get
            {
                if (eye.target == null) return false;
                return eye.DistanceToTarget <= attackRange;
            }
        }
    }

    public partial class EntityBase : MonoBehaviour
    {
        public static implicit operator Transform(EntityBase entity)
        {
            return entity.transform;
        }
    }
}