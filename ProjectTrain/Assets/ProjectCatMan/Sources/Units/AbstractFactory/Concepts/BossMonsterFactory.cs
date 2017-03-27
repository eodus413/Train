using UnityEngine;

namespace ProjectCatMan
{
    public class BossMonsterFactory : IUnitFactory
    { 
        public Team SetTeam()
        {
            return Team.Monster;
        }
        public Friendly SetFriendly()
        {
            return Friendly.Hostile;
        }
        public ISee SetSee(UnitBase unit)
        {
            float sight = 1f;
            int detectMask = unit.team.AttackLayerMask();
            int denyMask = Layers.GroundMask;
            return new SeeFoward(unit.transform, sight, detectMask, denyMask);
        }
        public IMovable SetMovable(UnitBase unit)
        {
            return new MoveToDirection(unit.transform, 1f);
        }
    }
}