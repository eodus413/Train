using UnityEngine;

namespace ProjectCatMan
{
    public class NormalMonsterFactory : IUnitFactory
    {
        public IDamageable damageable { get; private set; }
        public IKillable killable { get; private set; }
        public ISeeable seeable { get; private set; }
        public IMovable movable { get; private set; }

        public IDamageable SetDamageable(UnitBase unit)
        {
            damageable = new DamageableUnit(unit,10,0);
            return damageable;
        }
        public IKillable SetKillable(UnitBase unit)
        {
            killable = new Revivable(unit);
            return killable;
        }
        public ISeeable SetSeeable(UnitBase unit)
        {
            seeable = new SeeableForth(unit, 1.0f, Layers.PlayerMask, Layers.GroundMask);
            return seeable;
        }
        public IMovable SetMovable(UnitBase unit)
        {
            movable = new MoveToTarget(unit, 0.1f);
            return movable;
        }
        public IController SetController(UnitBase unit)
        {
            return new BasicMonsterController(unit);
        }
    }
}