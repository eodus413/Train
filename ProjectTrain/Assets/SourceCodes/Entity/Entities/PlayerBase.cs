using UnityEngine;
using System.Collections.Generic;

namespace Entity
{
    using Weapon;
    using Weapon.Factory;
    using Factory;
    public class PlayerBase : EntityBase
    {
        //초기화
        protected override void Initialize()
        {
            base.Initialize();
            EntityManager.SetPlayer(this);
            weapons.Add(WeaponGenerator.CreateGun(this, GunType.Pistol, "DesertEagle"));
            weapons.Add(WeaponGenerator.CreateGun(this, GunType.ShotGun, "Winchester"));
            weapons.Add(WeaponGenerator.CreateGun(this, GunType.MachineGun, "MG3"));
            ChangeWeapon(0);
        }
        protected override IEntityFactory SetFactory()
        {
            _entityType = EntityType.Player;
            return EntityFactoryMethod.GetFactory(playerType);
        }

        //필드, 컴포넌트 등
        [SerializeField]
        PlayerType _playerType;

        private int currentNumber = 0;
        public IWeapon currentWeapon { get; private set; }
        List<IWeapon> weapons = new List<IWeapon>();

        //인터페이스
        public PlayerType playerType
        {
            get { return _playerType; }
        }

        private bool isAttacking = false;
        public void Attack()
        {
            if (currentWeapon.isReadyForAttack)
            {
                animator.Play("Attack");
                currentWeapon.Attack();
            }
        }
        public void Reload()
        {
            if (currentWeapon.weaponType != WeaponType.Gun) return;

            Gun gun = currentWeapon as Gun;
            if (gun != null)
            {
                animator.Play("Reload");
                gun.Reload();
            }
        }
        public void ChangeWeapon(int number)
        {
            if (number < 0) return;
            if (number >= weapons.Count) return;

            currentNumber = number;
            currentWeapon = weapons[number];
        }
        public void ChangeWeapon()
        {
            int num = ++currentNumber;
            num %= weapons.Count;

            ChangeWeapon(num);

            Debug.Log(currentWeapon.ToString());
        }
        public override void Move(Direction direction)
        {
            if(direction != Direction.zero)LookAt(direction);
            base.Move(direction);
        }


        Vector2 jumpVelocity = new Vector2(0, 100);
        public void Jump()
        {
            baseRigidbody.AddForce(jumpVelocity);
        }


        private float lookArea = Screen.height * 0.3f;
        private float screenHalf = Screen.width * 0.5f;
        void Look()
        {
            if (Input.mousePosition.y > lookArea)
            {
                if (Input.mousePosition.x < screenHalf)
                {
                    LookAt(Direction.left);
                }
                else
                {
                    LookAt(Direction.right);
                }
            }
        }
    }
}
