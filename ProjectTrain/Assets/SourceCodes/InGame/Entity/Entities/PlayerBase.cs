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

            AddWeapon(WeaponGenerator.CreateGun(this, GunType.Pistol));
            AddWeapon(WeaponGenerator.CreateGun(this, GunType.ShotGun));
            AddWeapon(WeaponGenerator.CreateGun(this, GunType.Rifle));
            AddWeapon(WeaponGenerator.CreateGun(this, GunType.Sniper));
            AddWeapon(WeaponGenerator.CreateGun(this, GunType.SubMachine));
            //AddWeapon(WeaponGenerator.CreateGun(this, GunType.MachineGun, "MG3"));

            ChangeWeapon(0);
            jumpBehavior = new JumpBehavior(transform, baseRigidbody, 100f);
        }
        protected override IEntityFactory SetFactory()
        {
            type = EntityType.Player;
            return EntityFactoryMethod.GetFactory(playerType);
        }

        //필드, 컴포넌트 등
        [SerializeField]
        PlayerType _playerType;

        private int currentNumber = 0;
        private IWeapon _currentWeapon;
        public IWeapon currentWeapon
        {
            get { return _currentWeapon; }
            private set
            {
                _currentWeapon = value;
            }
        }
        public Gun currentGun { get; private set; }
        List<IWeapon> weapons = new List<IWeapon>();

        //인터페이스
        public PlayerType playerType
        {
            get { return _playerType; }
        }
        
        public void UseWeapon()
        {
            if (!isLive) return;
            if (currentWeapon.isReadyForAttack)
            {
                animator.Play("Attack");
                currentWeapon.AttackTarget();
            }
        }
        public void Reload()
        {
            if (currentGun == null) return;

            currentGun.Reload();
        }

        //ChangeWeapon(int)로 구현
        public void ChangeWeapon()
        {
            if (!isLive) return;
            int num = ++currentNumber;
            num %= weapons.Count;

            ChangeWeapon(num);
        }
        public void ChangeWeapon(int number)
        {
            if (!isLive) return;
            if (number < 0) return;
            if (number >= weapons.Count) return;
            currentNumber = number;
            currentWeapon = weapons[number];
            if(currentWeapon.weaponType == WeaponType.Gun)
            {
                currentGun = currentWeapon as Gun;
            }
        }

        public void AddWeapon(IWeapon newWeapon)
        {
            if (!isLive) return;
            if (newWeapon == null) return;
            weapons.Add(newWeapon);
        }
        
        [SerializeField] JumpBehavior jumpBehavior;
        public void Jump()
        {
            jumpBehavior.Jump();
        }

        public void BuildTurret(TurretType turretType)
        {
            if(turretType == TurretType.MachineGun)
            {

            }
        }

        const string valueName = "WeaponNumber";
        void ChangeBody(IWeapon weapon)
        {
            if(weapon.weaponType == WeaponType.Gun)
            {
                if (currentGun.gunType == GunType.Pistol) animator.SetInteger(valueName, (int)GunType.Pistol);
                else if (currentGun.gunType == GunType.ShotGun) animator.SetInteger(valueName, (int)GunType.ShotGun);
                else if (currentGun.gunType == GunType.Rifle) animator.SetInteger(valueName, (int)GunType.Rifle);
                else if (currentGun.gunType == GunType.Sniper) animator.SetInteger(valueName, (int)GunType.Sniper);
                else if (currentGun.gunType == GunType.SubMachine) animator.SetInteger(valueName, (int)GunType.SubMachine);
            }
        }
    }
}
