using UnityEngine;
using LayerManager;
using Entity.Controller;

namespace Entity
{
    public abstract class EntityBase : MonoBehaviour
    {
        void Awake()
        {
            gameObject.name += EntityCategoryName;  //게임 오브젝트 이름에 (Entity) tag추가

            gameObject.layer = Layers.Entities;

            ComponentInitialize();
        }
        //초기화
        void OnEnable()
        {
            Initialize();
            EntityManager.AddEntity(this);
            controller.Active();
        }
        protected virtual void ComponentInitialize()
        {
            baseRenderer = GetComponent<SpriteRenderer>();
            if (baseRenderer == null) Debug.Log("SpriteRenderer 추가 못함");

            baseRigidbody = GetComponent<Rigidbody2D>();
            if (baseRigidbody == null) Debug.Log("Rigidbody2 추가 못함");
            baseRigidbody.freezeRotation = true;

            bodyCollider = GetComponent<Collider2D>();
            if (bodyCollider == null) Debug.Log("Collider2D 추가 못함");

            animator = GetComponent<Animator>();
            if (animator == null) Debug.Log("Animator 추가 못함");
        }
        protected virtual void Initialize()
        {
            Factory.IEntityFactory factory = SetFactory();

            moveBehavior = factory.GetMoveBehavior(this);
            controller = factory.GetController(this);

            baseHp = factory.GetHp;
            hp = factory.GetHp;

            if (transform.localScale.x < 0) lookDirection = Vector2.left;
            else lookDirection = Vector2.right;
        }
        protected abstract Factory.IEntityFactory SetFactory();

        //필드,컴포넌트등
        public int teamNumber { get; private set; }
        private int baseHp;
        [SerializeField]
        private int _hp;

        private EntityController controller;

        public IMoveBehavior moveBehavior { get; private set; }

        const string id_isLive = "IsLive";
        const string id_lookFoward = "LookFoward";
        const string id_isMoving = "IsMoving";


        public Collider2D bodyCollider { get; private set; }
        public Rigidbody2D baseRigidbody { get; private set; }
        public SpriteRenderer baseRenderer { get; private set; }
        public Animator animator { get; private set; }


        //인터페이스
        public EntityType entityType { get; protected set; }
        public int hp
        {
            get { return _hp; }
            private set
            {
                _hp = value;
                if (_hp <= 0)
                    Dead();
            }
        }
        public float remainHpPercent
        {
            get { return (float)baseHp / hp; }
        }
        
        public void Attacked(AttackData data)
        {
            hp -= data.damage;
        }

        bool _lookFoward;
        public bool lookFoward
        {
            get { return _lookFoward; }
            private set
            {
                _lookFoward = value;
                animator.SetBool(id_lookFoward, _lookFoward);
            }
        }

        Vector2 _lookDirection = Vector2.zero;
        public Vector2 lookDirection
        {
            get { return _lookDirection; }
            private set
            {
                _lookDirection = value;

                gameObject.Turn2D(_lookDirection);
            }
        }

        public void LookAt(Vector2 direction)
        {
            lookDirection = direction;
            lookFoward = lookDirection == moveBehavior.moveDirection;
        }

        public virtual void Move(Vector2 direction)
        {
            bool isMoving = direction != Vector2.zero;

            animator.SetBool(id_isMoving, isMoving);

            if (!isMoving) return;
            moveBehavior.Move(direction);
        }
        public void Stop()
        {
            Move(Vector2.zero);
        }
        public bool isClimbing { get; private set; }
        public void ClimbTheStair(bool isUp)
        {
            isClimbing = true;
            float fixX = transform.position.x;
            if (isUp) transform.position += Vector3.up;
            else transform.position += Vector3.down;
        }

        public void GetItem(Item item)
        {

        }
        //구현
        void Dead()
        {
            gameObject.layer = Layers.Dead;
            animator.Play("Dead");
            animator.SetBool(id_isLive, false);
            controller.Inactive();
        }

        const string EntityCategoryName = " (Entity)";

        //사용자 정의 연산자들
        public static implicit operator Transform(EntityBase entity)
        {
            return entity.transform;
        }
    }
}