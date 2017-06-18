using UnityEngine;
using LayerManager;
using Entity.Controller;
using System.Collections;

namespace Entity
{
    public abstract class EntityBase : MonoBehaviour
    {
        void Awake()
        {
            gameObject.name += EntityCategoryName;  //게임 오브젝트 이름에 (Entity) tag추가

            gameObject.layer = Layers.Entities;

            ComponentInitialize();

            Initialize();
        }
        //초기화
        void OnEnable()
        {
            isLive = true;
            baseRenderer.color = Color.white;
            gameObject.layer = Layers.Entities;

            hp = baseHp;

            EntityManager.Add(this);
            controller.Active();
        }
        protected virtual void ComponentInitialize()
        {
            baseRenderer = GetComponent<SpriteRenderer>();
            if (baseRenderer == null) baseRenderer = gameObject.AddComponent<SpriteRenderer>();

            baseRigidbody = GetComponent<Rigidbody2D>();
            if (baseRigidbody == null) baseRigidbody = gameObject.AddComponent<Rigidbody2D>();
            baseRigidbody.freezeRotation = true;

            bodyCollider = GetComponent<Collider2D>();
            if (bodyCollider == null) bodyCollider = gameObject.AddComponent<BoxCollider2D> ();

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
        private int baseHp;
        [SerializeField]
        private int _hp;

        private EntityController controller;

        IMoveBehavior moveBehavior { get; set; }

        const string id_isLive = "IsLive";
        const string id_lookFoward = "LookFoward";
        const string id_isMoving = "IsMoving";


        public Collider2D bodyCollider { get; private set; }
        public Rigidbody2D baseRigidbody { get; private set; }
        public SpriteRenderer baseRenderer { get; private set; }
        public Animator animator { get; private set; }


        //인터페이스
        public EntityType type { get; protected set; }
        [SerializeField]
        private Team _team;
        public Team team
        {
            get { return _team; }
            set { _team = value; }
        }

        public delegate void DataUpdate();

        private event DataUpdate hpUpdate;
        public void AddHpUpdateEvent(DataUpdate update)
        {
            if (update == null) return;
            hpUpdate += update;
        }
        public int hp
        {
            get { return _hp; }
            private set
            {
                _hp = value;
                if(hpUpdate != null) hpUpdate();
                if (_hp <= 0)
                    StartCoroutine(Dead());
            }
        }
        public float remainHpPercent
        {
            get { return (float)hp / baseHp; }
        }
        public bool isAttacked { get; private set; }
        public void Attacked(AttackData data)
        {
            if (!isLive) return;
            hp -= data.damage;

            animator.Play("Attacked");
            KnockBack(data.direction, data.damage);
            StartCoroutine(Attacked());
        }
        const float delayAfterDamaged = 0.5f;
        IEnumerator Attacked()
        {
            isAttacked = true;
            yield return new WaitForSeconds(delayAfterDamaged);
            isAttacked = false;
        }
        void KnockBack(Vector2 direction,float power)
        {
            baseRigidbody.AddForce(direction * power);
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
            if (!isLive) return;
            lookDirection = direction;
            lookFoward = lookDirection == moveBehavior.direction;
        }

        public virtual void Move(Vector2 direction)
        {
            if (!isLive) return;
            if (isAttacked) return; //공격받는 중이라면

            bool isMoving = direction != Vector2.zero;
                
            if (direction != Vector2.zero) LookAt(direction);

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
            if (!isLive) return;
            isClimbing = true;
            float fixX = transform.position.x;
            if (isUp) transform.position += Vector3.up;
            else transform.position += Vector3.down;
        }

        public void GetItem(Item item)
        {

        }
        //구현
        const float bodyRemainTime = 5f;
        private bool _isLive = true;
        public bool isLive
        {
            get { return _isLive; }
            private set { _isLive = value;}
        }
        IEnumerator Dead()
        {
            isLive = false;
            gameObject.layer = Layers.Dead;
            animator.Play("Dead");

            animator.SetBool(id_isLive, false);

            controller.Inactive();
            yield return new WaitForSeconds(bodyRemainTime);
            yield return FadeEffect.DoFadeOut(baseRenderer);

            gameObject.SetActive(false);
        }



        const string EntityCategoryName = " (Entity)";

        //사용자 정의 연산자들
        public static implicit operator Transform(EntityBase entity)
        {
            return entity.transform;
        }
    }
}