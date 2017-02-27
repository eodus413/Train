using UnityEngine;

namespace ProjectTrain
{
    public abstract partial class Unit : MonoBehaviour, IAttackable, IInitilaizable
    {
        public virtual void ComponentInitialize()
        {
            #region componentes
            renderer = GetComponent<SpriteRenderer>();
            if (renderer == null) Debug.Log("SpiretRenderer is Null");

            animator = GetComponent<Animator>();
            if (animator == null) Debug.Log("Animator is Null");

            collider = GetComponent<BoxCollider2D>();
            if (collider == null) Debug.Log("BoxCollider2D is Null");

            rigidbody = GetComponent<Rigidbody2D>();
            if (rigidbody == null) Debug.Log("Rigidbody2D is Null");
            #endregion
        }

        public abstract void Initialize();
        //무조건 override 한 함수에서 base를 호출해야함
        protected virtual void Initialize(int hp, MovementBase movement, UnitAnimation animation)
        {
            this._hp = hp;
            this.movement = movement;
            this.animation = animation;
        }
    }
}
