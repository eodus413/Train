using System.Collections;
using System.Collections.Generic;

namespace Entity.Controller
{
    using UnityEngine;
    using Entity;
    public partial class PlayerMobileController : EntityController
    {
        //생성자
        public PlayerMobileController(PlayerBase entity, float routineDelay) : base(entity, routineDelay)
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
            Vector3 direction = Vector3.zero;
            if (joyStick.isMoving)
            {
                if (joyStick.GetHorizontalValue() < 0) direction += Vector3.left;
                else direction += Vector3.right;
            }
            
            player.Move(direction);
        }
        private Animator animator;
        private Transform transform;
        private Rigidbody2D rigidbody;
    }
}

namespace Entity.Controller
{
    using VirtualJoyStick;
    public partial class PlayerMobileController : EntityController
    {
        JoyStick joyStick;
        void InitializeJoyStick()
        {
            joyStick = JoyStickManager.GetJoyStick(0);
        }
    }
}