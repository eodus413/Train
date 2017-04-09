using UnityEngine;
using System.Collections;
using LayerManager;
using Entity.Controller;
using System.Collections.Generic;

namespace Entity
{
    public class EntityBase : MonoBehaviour
    {
        //필드,컴포넌트등
        [SerializeField]
        EntityType _type;

        IEntityFactory factory;

        private EntityController controller;

        public IHealth health { get; private set; }

        public IMoveBehavior moveBehavior { get; private set; }
        public List<IAttackBehavior> attackBehaviors { get; private set; }

        const string id_isLive = "IsLive";
        const string id_lookFoward = "LookFoward";
                

        public Collider2D       bodyCollider    { get; private set; }
        public Rigidbody2D      baseRigidbody   { get; private set; }
        public SpriteRenderer   baseRenderer    { get; private set; }
        public Animator         animator        { get; private set; }

        

        //인터페이스
        public EntityType type
        {
            get { return _type;}
        }
        
        
        public void Attacked(AttackData data)
        {
            health.TakeDamage(data.damage);
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
            gameObject.Turn2D(direction);
        }
        public void Dead()
        {
            gameObject.layer = Layers.Dead;
            animator.Play("Dead");
            animator.SetBool(id_isLive, false);
        }

        //구현
        void OnEnable()
        {
            ComponentInitialize();

            Initialize();

            StartCoroutine(controller.Start());

            EntityManager.AddEntity(this);
        }
        void ComponentInitialize()
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
        void Initialize()
        {
            factory = EntitySetter.GetFactory(type);

            health = factory.GetNewHealth();
            moveBehavior = factory.GetNewMoveBehavior(this);
            attackBehaviors = factory.GetNewAttackBehavior(this);

            gameObject.layer = EntitySetter.GetLayer(_type);

            controller = EntitySetter.GetController(this,_type);

        }

        //사용자 정의 연산자들
        public static implicit operator Transform(EntityBase entity)
        {
            return entity.transform;
        }
    }
}