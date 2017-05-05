using UnityEngine;
using System.Collections.Generic;

namespace Entity
{
    using Weapon;
    using Weapon.Factory;
    using Factory;
    public class PlayerBase : EntityBase
    {
        [SerializeField]
        LayerMask layer;
        //초기화
        protected override void Initialize()
        {
            base.Initialize();

            EntityManager.SetPlayer(this);

            AddWeapon(WeaponGenerator.CreateGun(this, GunType.Pistol, "DesertEagle"));
            AddWeapon(WeaponGenerator.CreateGun(this, GunType.ShotGun, "Winchester"));
            AddWeapon(WeaponGenerator.CreateGun(this, GunType.MachineGun, "MG3"));

            ChangeWeapon(0);

            jumpBehavior = new JumpBehavior(transform, baseRigidbody, 100f);

            gameObject.layer = LayerManager.Layers.Player;
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

        public delegate void AmmoDelegate(PlayerBase player);
        public event AmmoDelegate attackEvent;
        public event AmmoDelegate reloadEvent;
        private bool isAttacking = false;
        public void Attack()
        {
            if (currentWeapon.isReadyForAttack)
            {
                animator.Play("Attack");
                currentWeapon.Attack();
                attackEvent(this);
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
            if(reloadEvent != null) reloadEvent(this);
        }
        public void ChangeWeapon()
        {
            int num = ++currentNumber;
            num %= weapons.Count;

            ChangeWeapon(num);

            Debug.Log(currentWeapon.ToString());
        }
        public void AddWeapon(IWeapon newWeapon)
        {
            weapons.Add(newWeapon);
        }

        public override void Move(Direction direction)
        {
            if(direction != Direction.zero)LookAt(direction);
            base.Move(direction);
        }
        
        JumpBehavior jumpBehavior;
        public void Jump()
        {
            jumpBehavior.Jump();
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
