using UnityEngine;

namespace ProjectCatMan
{
    public class BossMonsterFactory : IUnitFactory
    {
        public IDamageable damageable { get; private set; }
        public IKillable killable { get; private set; }
        public ISeeable seeable { get; private set; }
        public IMovable movable { get; private set; }

        private int armor = 1;
        public IDamageable SetDamageable(UnitBase unit)
        {
            return new DamageableHarder(unit,10,armor);
        }
        public IKillable SetKillable(UnitBase unit)
        {
            return new Revivable(unit);
        }
        public ISeeable SetSeeable(UnitBase unit)
        {
            return new SeeableFoward(unit, 0.5f);
        }
        public IMovable SetMovable(UnitBase unit)
        {
            return new UnMovable(unit.transform, 0);
        }
    }
}