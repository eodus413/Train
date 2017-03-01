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
        public Direction lookingDirection
        {
            get { return _lookingDirection; }
            protected set
            {
                if (value == Direction.Left)
                {
                    renderer.flipX = true;
                }
                else if (value == Direction.Right)
                {
                    renderer.flipX = false;
                }
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
                if (hp <= 0) Dead();
            }
        }               
        public virtual void Attacked(AttackData data)
        {
            if (isLive == false) return;
            if (data.damage < 0) return;
            hp -= data.damage;
            animation.SetDamaged(true);
            
            KnockBack(data);
        }
        #endregion
        
        protected abstract bool isDoingAttack();
        protected abstract bool isDoingMove();

        protected abstract void Attack();           //공격
        protected abstract void Idle();
        protected abstract void Move();             //움직임
        
    }
}