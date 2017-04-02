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
            if (Input.GetKey(KeyCode.A)) entity.Move(Vector3.left);
            if (Input.GetKey(KeyCode.D)) entity.Move(Vector3.right);
        }
        void Look()
        {
            if(Input.mousePosition.x < Camera.main.WorldToViewportPoint(transform.position).x)
            {
                entity.LookAt(Vector3.left);
            }
            else
            {
                entity.LookAt(Vector3.right);
            }
        }
    }


    public partial class PlayerController : EntityController
    {
        public PlayerController(EntityBase entity,float routineDelay) : base(entity,routineDelay)
        {

        }
    }
}
