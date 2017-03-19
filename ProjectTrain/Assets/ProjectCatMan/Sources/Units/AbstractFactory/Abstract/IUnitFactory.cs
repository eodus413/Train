using UnityEngine;

namespace ProjectCatMan
{
    public interface IUnitFactory
    {
        IAttackable attackable { get; }
        IKillable killable { get; }
        ISee see { get; }
        IMovable movable { get; }

        Team SetTeam();
        Friendly SetFriendly();
        IAttackable SetAttackable(UnitBase unit);
        IKillable SetKillable(UnitBase unit);
        ISee SetSee(UnitBase unit);
        IMovable SetMovable(UnitBase unit);

        IController SetController(UnitBase unit);
    }
}