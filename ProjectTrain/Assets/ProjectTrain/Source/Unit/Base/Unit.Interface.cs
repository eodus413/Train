using UnityEngine;
using System.Collections;
namespace ProjectTrain
{
    public abstract partial class Unit : MonoBehaviour, IAttackable, IInitilaizable
    {
        #region Direction
        public Direction moveDirection
        {
            get { return _moveDirection; }
            protected set
            {
                _moveDirection = value;
            }
        }
        public virtual Direction lookingDirection
        {
            get { return _lookingDirection; }
            protected set
            {
                _lookingDirection = value;
            }
        }
        #endregion

        #region IAttackable
        public bool isLive { get { return hp > 0; } }   //죽었는 살았는지
        
        protected virtual IEnumerator DoDead()
        {
            animation.SetIsDead(true);
            yield break;
        }


        public int hp       //체력 property
        {
            get { return _hp; }
            private set
            {
                _hp = value;
                if (hp < 0) Dead();
            }
        }               
        public void Attacked(int damage)                //공격 받음 함수
        {
            if (damage < 0) return;
            hp -= damage;
            animation.SetDamaged(true);
        }
        #endregion

        protected abstract bool isDoingAttack();
        protected abstract bool isDoingAction();
        protected abstract bool isIdle();
        protected abstract bool isDoingMove();

        protected abstract void Attack();           //공격
        protected abstract void Action();           //줍기등
        protected abstract void Idle();
        protected abstract void Move();             //움직임
        protected virtual void Flip(Direction direction)
        {
            if (direction == Direction.Left)
            {
                renderer.flipX = true;
            }
            else if (direction == Direction.Right)
            {
                renderer.flipX = false;
            }
        }
    }
}