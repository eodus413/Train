using UnityEngine;
using Entity;
using System.Collections;

namespace Entity.Controller
{
    public partial class PlayerController : EntityController
    {
        public override IEnumerator Start()
        {
            while(isActive)
            {
                GetInput();
                Look();
                yield return new WaitForSeconds(routineDelay);
            }
        }
        void GetInput()
        {
            Vector3 direction = Vector3.zero;
            if (Input.GetKey(KeyCode.A)) direction += Vector3.left;
            if (Input.GetKey(KeyCode.D)) direction += Vector3.right;
            if (Input.GetMouseButtonDown(0)) Attack();
            entity.Move(direction);
        }
        void Look()
        {
            if(Input.mousePosition.x < Screen.width * 0.5f)
            {   
                entity.eye.LookAt(Vector3.left);
            }
            else
            {
                entity.eye.LookAt(Vector3.right);
            }
        }
        void Attack()
        {
            entity.attack.AttackTo();
        }
    }


    public partial class PlayerController : EntityController
    {
        public PlayerController(EntityBase entity,float routineDelay) : base(entity,routineDelay)
        {

        }
    }
}
