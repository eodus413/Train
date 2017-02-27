using UnityEngine;

namespace ProjectTrain
{
    public abstract partial class Unit : MonoBehaviour, IAttackable, IInitilaizable
    {
        void Update()
        {
            if (isLive == false) return;

            if (isDoingAction()) Action();
            else { state.Remove(State.action); }

            if (isDoingAttack()) Attack();
            else { state.Remove(State.attack); }

            Flip(lookingDirection);
            
            

            //if(state is idle)
            // idle();
        }
        void FixedUpdate()
        {
            if (isLive == false) return;
            if (isDoingMove()) Move();
            else { state.Remove(State.move); }
        }

        private void Dead()
        {
            StartCoroutine(DoDead());
        }
    }
}