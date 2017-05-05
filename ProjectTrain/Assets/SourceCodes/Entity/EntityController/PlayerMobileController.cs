using System.Collections;
using System.Collections.Generic;

namespace Entity.Controller
{
    using UnityEngine;
    using Entity;
    public partial class PlayerMobileController : PlayerController
    {
        public PlayerMobileController(PlayerBase player,float routineDelay) : base(player,routineDelay)
        {
        }
        //구현
        protected override void DoInitialize()
        {
            base.DoInitialize();
            InitializeButton();
            InitializeJoyStick();
        }
        protected override void GetInput()
        {
            //Buttons
        }
        protected override void GetMoveInput()
        {
            if (joyStick.GetHorizontalValue() > 0) entity.Move(Direction.right);
            else if (joyStick.GetHorizontalValue() < 0) entity.Move(Direction.left);
            else entity.Stop();
        }
    }
}



namespace Entity.Controller
{
    using VirtualJoyStick;
    public partial class PlayerMobileController : PlayerController
    {
        JoyStick joyStick;
        void InitializeJoyStick()
        {
            joyStick = JoyStickManager.GetJoyStick(0);
        }
    }
}

namespace Entity.Controller
{
    using UnityEngine;
    using UnityEngine.UI;
    public partial class PlayerMobileController : PlayerController
    {
        Button attackButton;
        Button reloadButton;
        Button changeWeaponButton;
        Button jumpButton;

        void InitializeButton()
        {
            Transform parent = GameObject.Find("Buttons").transform;

            attackButton        = parent.GetChild(0).GetComponent<Button>();
            reloadButton        = parent.GetChild(1).GetComponent<Button>();
            changeWeaponButton  = parent.GetChild(2).GetComponent<Button>();
            jumpButton          = parent.GetChild(3).GetComponent<Button>();

            attackButton.onClick.       AddListener(player.Attack);
            reloadButton.onClick.       AddListener(player.Reload);
            changeWeaponButton.onClick. AddListener(player.ChangeWeapon);
            jumpButton.onClick.         AddListener(player.Jump);

        }
    }
}
