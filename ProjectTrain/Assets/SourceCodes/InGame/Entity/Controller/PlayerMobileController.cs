namespace Entity.Controller
{
    using UnityEngine;
    using UI;
    public class PlayerMobileController : PlayerController
    {
        public PlayerMobileController(PlayerBase player,float routineDelay) :base(player,routineDelay) { }

        protected override void GetInput()
        {
        }
        protected override void GetMoveInput()
        {
            float value = JoyStickManager.GetJoyStick(0).GetHorizontalValue();

            if (value > 0) entity.Move(Vector2.right);
            else if (value < 0) entity.Move(Vector2.left);
            else entity.Stop();
        }
    }
}