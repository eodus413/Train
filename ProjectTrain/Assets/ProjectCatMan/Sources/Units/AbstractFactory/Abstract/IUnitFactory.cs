using UnityEngine;

namespace ProjectCatMan
{
    public interface IUnitFactory
    {
        Team SetTeam();
        Friendly SetFriendly();
        ISee SetSee(UnitBase unit);
        IMovable SetMovable(UnitBase unit);
    }
}