using UnityEngine;
using System.Collections;
using LayerManager;
using Entity.Controller;
using System.Collections.Generic;

namespace Entity
{
    public abstract class EntityBase : MonoBehaviour
    {
        void Awake()
        {
            gameObject.name += EntityCategoryName;  //게임 오브젝트 이름에 (Entity) tag추가

            gameObject.layer = entityType.GetLayer();
        }
        //초기화
        void OnEnable()
        {
            ComponentInitialize();
            Initialize();

            EntityManager.AddEntity(this);
            StartCoroutine(controller.Start());
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

            baseHp = factory.hp;
            hp = factory.hp;

            if (transform.localScale.x < 0) lookDirection = Direction.left;
            else lookDirection = Direction.right;
        }
        protected abstract Factory.IEntityFactory SetFactory();

        //필드,컴포넌트등
        protected EntityType _entityType;

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
        public EntityType entityType
        {
            get { return _entityType; }
        }
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

        public delegate void HpDelegate(EntityBase player);
        public event HpDelegate attackedEvent;
        public void Attacked(AttackData data)
        {
            hp -= data.damage;
            if(attackedEvent != null) attackedEvent(this);
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

        Direction _lookDirection = Direction.zero;
        public Direction lookDirection
        {
            get { return _lookDirection; }
            private set
            {
                _lookDirection = value;

                gameObject.Turn2D(_lookDirection);
            }
        }

        public void LookAt(Direction direction)
        {
            lookDirection = direction;
            lookFoward = lookDirection == moveBehavior.moveDirection;
        }

        public virtual void Move(Direction direction)
        {
            bool isMoving = direction != Direction.zero;

            animator.SetBool(id_isMoving, isMoving);

            if (!isMoving) return;
            moveBehavior.Move(direction);
        }
        public void Stop()
        {
            Move(Direction.zero);
        }
        public void ClimbTheStair(bool isUp)
        {
            float fixX = transform.position.x;
            if (isUp) transform.position += Vector3.up;
            else transform.position += Vector3.down;
        }
        //구현
        void Dead()
        {
            gameObject.layer = Layers.Dead;
            animator.Play("Dead");
            animator.SetBool(id_isLive, false);
            EntityManager.RemoveEntity(this);
            controller.Inactive();
            StartCoroutine(DoDead());
        }

        const float deadBodyRemainTime = 5f;
        IEnumerator DoDead()
        {
            yield return new WaitForSeconds(deadBodyRemainTime);
            Color c = Color.white;
            for (float i = 1f; i > 0f; i -= 0.1f)
            {
                c.a = i;
                baseRenderer.color = c;
                yield return new WaitForSeconds(0.1f);
            }
            gameObject.SetActive(false);
            //죽음 애니메이션
            //대기
            //사라짐
        }
        const string EntityCategoryName = " (Entity)";

        //사용자 정의 연산자들
        public static implicit operator Transform(EntityBase entity)
        {
            return entity.transform;
        }
    }
}