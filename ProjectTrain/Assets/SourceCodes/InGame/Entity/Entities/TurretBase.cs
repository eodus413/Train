using UnityEngine;
using System.Collections;
using Entity.Factory;

namespace Entity
{
    public partial class TurretBase : EntityBase
    {
        //초기화
        protected override void Initialize()
        {
            base.Initialize();
            InitializeGun();
            InitializeUI();
        }
        protected override IEntityFactory SetFactory()
        {
            type = EntityType.Tower;
            return EntityFactoryMethod.GetFactory(_turretType);
        }

        [SerializeField]
        TurretType _turretType;
    }
}
namespace Entity
{
    using Weapon;
    using Weapon.Factory;
    public partial class TurretBase : EntityBase
    {
        Gun gun;
        void InitializeGun()
        {
            gun = WeaponGenerator.CreateGun(this, GunType.MachineGun);
        }
        public void AttackTarget()
        {
            if (!gun.isReadyForAttack) return;
            gun.AttackTarget();
        }
    }
}

namespace Entity
{
    using UI;
    public partial class TurretBase : EntityBase
    {
        HpBarUI hpBarUI;
        void InitializeUI()
        {
            hpBarUI = new HpBarUI(this, ResourceLoad.hpBar);
        }
    }
}