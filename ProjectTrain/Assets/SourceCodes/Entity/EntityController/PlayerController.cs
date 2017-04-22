using System.Collections;
using System.Collections.Generic;

namespace Entity.Controller
{
    using UnityEngine;
    using Entity;
    public partial class PlayerController : EntityController
    {
        //생성자
        public PlayerController(PlayerBase entity, float routineDelay) : base(entity, routineDelay)
        {
            player = entity;
            animator = entity.animator;
            transform = entity.transform;
            rigidbody = entity.baseRigidbody;   
        }

        //인터페이스
        public PlayerBase player { get; private set; }

        public override IEnumerator Start()
        {
            InitializeJoyStick();
            while (isActive)
            {
                GetInput();
                yield return new WaitForSeconds(routineDelay);
            }
        }

        //구현
        void GetInput()
        {
            if (Input.GetMouseButton(0)) player.Attack();
            if (Input.GetKeyDown(KeyCode.R)) player.Reload();

            
            if (Input.GetKeyDown("1")) player.ChangeWeapon(0);
            if (Input.GetKeyDown("2")) player.ChangeWeapon(1);
            if (Input.GetKeyDown("3")) player.ChangeWeapon(2);


            Vector3 direction = Vector3.zero;
            if(Input.GetKey(KeyCode.A))direction += Vector3.left;
            if (Input.GetKey(KeyCode.D)) direction += Vector3.right;

            if (Input.GetKeyDown(KeyCode.Space)) player.Jump();
            entity.Move(direction);
        }
        
        private Animator animator;
        private Transform transform;
        private Rigidbody2D rigidbody;
    }
}

namespace Entity.Controller
{
    using VirtualJoyStick;
    public partial class PlayerController : EntityController
    {
        JoyStick joyStick;
        void InitializeJoyStick()
        {
            joyStick = JoyStickManager.GetJoyStick(0);
        }
    }
}