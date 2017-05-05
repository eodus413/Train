using System.Collections;
using System.Collections.Generic;

namespace Entity.Controller
{
    using UnityEngine;
    using Entity;
    public partial class PlayerController : EntityController
    {
        //생성자
        public PlayerController(PlayerBase player, float routineDelay) : base(player, routineDelay)
        {
            this.player = player; 
        }

        //인터페이스
        public PlayerBase player { get; private set; }

        public override IEnumerator Start()
        {
            DoInitialize();
            while (isActive)
            {
                GetInput();
                GetMoveInput();
                yield return new WaitForSeconds(routineDelay);
            }
        }

        //구현
        protected virtual void DoInitialize()
        {
            playerUI = new UI.PlayerUI(player);
        }
        protected virtual void GetInput()
        {
            if (Input.GetMouseButton(0)) player.Attack();
            if (Input.GetKeyDown(KeyCode.R)) player.Reload();
            
            if (Input.GetKeyDown("1")) player.ChangeWeapon(0);
            if (Input.GetKeyDown("2")) player.ChangeWeapon(1);
            if (Input.GetKeyDown("3")) player.ChangeWeapon(2);

            if (Input.GetKeyDown(KeyCode.Space)) player.Jump();
        }
        protected virtual void GetMoveInput()
        {
            Vector3 direction = Vector3.zero;
            if (Input.GetKey(KeyCode.A)) direction += Vector3.left;
            if (Input.GetKey(KeyCode.D)) direction += Vector3.right;
            
            if (direction != Vector3.zero) entity.Move(direction);
            else entity.Stop();
        }
    }
}

namespace Entity.Controller
{
    using Entity.UI;

    public partial class PlayerController : EntityController
    {
        PlayerUI playerUI;
    }
}