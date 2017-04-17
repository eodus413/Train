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
            weapons.Add(WeaponGenerator.CreateGun(this,GunType.Pistol,"DesertEagle"));
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

        public IWeapon currentWeapon { get; private set; }
        List<IWeapon> weapons = new List<IWeapon>();

        //인터페이스
        public PlayerType playerType
        {
            get { return _playerType; }
        }

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
            if(gun != null)
            {
                animator.Play("Reload");
                gun.Reload();
            }
        }
        public void ChangeWeapon(int number)
        {
            if (number < 0) return;
            if (number >= weapons.Count) return;

            currentWeapon = weapons[number];
        }
        public void Move(int num)
        {
            if (num == 1) Move(Direction.left);
            if (num == 2) Move(Direction.right);
        }
    }
}