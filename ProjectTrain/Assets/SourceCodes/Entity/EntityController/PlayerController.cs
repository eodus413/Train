using UnityEngine;
using Entity;
using System.Collections;
using System.Collections.Generic;
using Weapon;
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
            if (Input.GetKeyDown(KeyCode.Space)) Jump();
            if (Input.GetMouseButtonDown(0)) currentWeapon.Attack();
            if (Input.GetKeyDown(KeyCode.E)) OpenDoor();
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
        void ChangeWeapon()
        {

        }
        Vector2 jumpVelocity = new Vector2(0, 100);
        public void Jump()
        {
             entity.baseRigidbody.AddForce(jumpVelocity);
        }
        public void OpenDoor()
        {
            entity.eye.Seeing();
        }
    }


    public partial class PlayerController : EntityController
    {
        IWeapon currentWeapon;
        List<IWeapon> weapons = new List<IWeapon>();
        public PlayerController(EntityBase entity,float routineDelay) : base(entity,routineDelay)
        {
            weapons.Add(new Gun(GunType.Pistol, entity));
            weapons.Add(new Gun(GunType.ShotGun, entity));
            weapons.Add(new Gun(GunType.MachineGun, entity));

            currentWeapon = weapons[0];
        }
    }
}
