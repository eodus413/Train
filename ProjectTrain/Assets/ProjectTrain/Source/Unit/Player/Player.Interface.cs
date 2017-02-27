using UnityEngine;
using ProjectTrain.Weapon;

namespace ProjectTrain
{
    public partial class Player : Unit
    {
        float halfBar;
        public override Direction lookingDirection
        {
            get
            {
                halfBar = Camera.main.WorldToScreenPoint(transform.position).x;
                if(Input.mousePosition.x < halfBar)
                {
                    return Direction.Left;
                }
                return Direction.Right;
            }
            protected set
            {
                base.lookingDirection = value;
            }
        }

        int weaponNumber = 0;
        public WeaponBase currentWeapon
        {
            get { return weapons[weaponNumber]; }
        }


        #region Attack
        protected override bool isDoingAttack()
        {
            bool result;
            if (Input.GetMouseButtonDown(1) == false) result = false;
            else result = true;

            if (result) animation.SetAttacking(true);
            else animation.SetAttacking(false);

            return result;
        }
        protected override void Attack()
        {
            currentWeapon.Shot();
        }
        #endregion
        #region Action
        protected override bool isDoingAction()
        {
            bool result;
            //if(근처에 상호작용 오브젝트가 있다)
            if (Input.GetMouseButtonDown(0) == false) result = false;
            else result = true;

            return result;
        }
        protected override void Action()
        {
            //action
        }
        #endregion
        #region Move
        protected override bool isDoingMove()
        {
            bool result = false;
            if (Input.anyKey == false) result = false;

            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = Direction.Left;
                result = true;
            }

            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = Direction.Right;
                result = true;
            }

            if (!result) animation.SetMoving(false);

            return result;
        }
        protected override void Move()
        {
            animation.SetMoving(true);
            movement.Move(moveDirection.DirToVec2());
        }
        #endregion

        protected override void Flip(Direction direction)
        {
            base.Flip(direction);
            if (direction == Direction.Left) hand.transform.eulerAngles = new Vector3(0, 180, 0);
            else if (direction == Direction.Right) hand.transform.eulerAngles = new Vector3(0, 0, 0);

        }
    }
}
