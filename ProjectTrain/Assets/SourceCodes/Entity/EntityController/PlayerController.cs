using UnityEngine;
using Entity;
using System.Collections;
using System.Collections.Generic;
using Weapon;
namespace Entity.Controller
{
    public class PlayerController : EntityController
    {
        //생성자
        public PlayerController(EntityBase entity, float routineDelay) : base(entity, routineDelay)
        {
            attackBehaviors = entity.attackBehaviors;
            ChangeWeapon(1);
        }

        //인터페이스
        public override IEnumerator Start()
        {
            while(isActive)
            {
                GetInput();
                Look();
                yield return new WaitForSeconds(routineDelay);
            }
        }

        //구현
        void GetInput()
        {
            Vector3 direction = Vector3.zero;
            if (Input.GetKey(KeyCode.A)) direction += Vector3.left;
            if (Input.GetKey(KeyCode.D)) direction += Vector3.right;
            if (Input.GetKeyDown(KeyCode.Space)) Jump();

            if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeWeapon(1);
            else if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeWeapon(2);
            else if (Input.GetKeyDown(KeyCode.Alpha3)) ChangeWeapon(3);

            if (Input.GetMouseButtonDown(0)) entity.currentAttack.Attack();
            
            entity.Move(direction);
        }
        void Look()
        {
            if(Input.mousePosition.x < Screen.width * 0.5f)
            {   
                entity.LookAt(Direction.left);
            }
            else
            {
                entity.LookAt(Direction.right);
            }
        }
        
        private List<IAttackBehavior> attackBehaviors;
        void ChangeWeapon(int number)
        {
            entity.ChangeAttackBehavior(--number);

            Debug.Log(entity.currentAttack);
        }
        
        Vector2 jumpVelocity = new Vector2(0, 100);
        void Jump()
        {
             entity.baseRigidbody.AddForce(jumpVelocity);
        }
    }
}
