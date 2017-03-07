using UnityEngine;

namespace ProjectTrain
{
    public abstract partial class Unit : MonoBehaviour, IAttackable, IInitilaizable
    {
        void Update()
        {
            if (isLive == false) return;

            if (isDoingAttack()) Attack();
            else animation.SetAttacking(false);
            
            Idle();
        }
        void FixedUpdate()
        {
            if (isLive == false) return;

            if (isDoingMove()) Move();
            else animation.SetMoving(false);
        }

        private void Dead()
        {


            gameObject.layer = Layers.Dead;
            StartCoroutine(DoDead());
        }
        const float knockBackVelocity = 40f;
        private void KnockBack(AttackData data)
        {
            rigidbody.AddForce(data.direction * knockBackVelocity);
        }
    }
}