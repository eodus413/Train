using UnityEngine;
using ProjectTrain.Weapon;
using System.Collections;

namespace ProjectTrain
{
    public partial class Player : Unit
    {
       int weaponNumber = 0;
        public WeaponBase currentWeapon
        {
            get { return weapons[weaponNumber]; }
        }
        #region Dead
        protected override IEnumerator DoDead()
        {
            //게임 시스템에 플레이어 사망에 대한 정보 넘기기
            return base.DoDead();
        }
        #endregion


        #region Attack
        protected override bool isDoingAttack()
        {
            if (Input.GetMouseButtonDown(1) == false) return false;
            
            return true;
        }
        protected override void Attack()
        {
            animation.SetAttacking(true);
            currentWeapon.Shot();
        }
        #endregion
        #region Action
        public bool isDoingAction()
        {
            bool result;
            //if(근처에 상호작용 오브젝트가 있다)
            if (Input.GetMouseButtonDown(0) == false) result = false;
            else result = true;

            return result;
        }
        public void Action()
        {
            //action
        }
        #endregion
        #region Idle
        protected override void Idle()
        {
            if (isDoingAction()) Action();
        }
        #endregion

        #region Move
        protected override bool isDoingMove()
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = Direction.Left;
                return true;
            }

            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = Direction.Right;
                return true;
            }
            else return false;
        }
        protected override void Move()
        {
            animation.SetMoving(true);
            movement.Move(moveDirection.DirToVec2());
        }
        #endregion
        
        public void Look(Direction direction)
        {
            lookingDirection = direction;
            if (direction == Direction.Left) hand.transform.eulerAngles = new Vector3(0, 180, 0);
            else if (direction == Direction.Right) hand.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
