using UnityEngine;

namespace ProjectCatMan
{
    public interface IUnitFactory
    {
        IDamageable damageable { get; }
        IKillable killable { get; }
        ISeeable seeable { get; }
        IMovable movable { get; }

        IDamageable SetDamageable(UnitBase unit);
        IKillable SetKillable(UnitBase unit);
        ISeeable SetSeeable(UnitBase unit);
        IMovable SetMovable(UnitBase unit);
    }
}