using UnityEngine;

namespace ProjectCatMan
{
    public class BossMonsterFactory : IUnitFactory
    {
        public IAttackable attackable { get; private set; }
        public IKillable killable { get; private set; }
        public ISee see { get; private set; }
        public IMovable movable { get; private set; }

        public Team SetTeam()
        {
            return Team.Monster;
        }
        public Friendly SetFriendly()
        {
            return Friendly.Hostile;
        }
        public IAttackable SetAttackable(UnitBase unit)
        {
            int armor = 1;
            attackable = new AttackableUnit(100, armor, unit);
            return attackable;
        }
        public IKillable SetKillable(UnitBase unit)
        {
            killable = new Revivable(unit);
            return killable;
        }
        public ISee SetSee(UnitBase unit)
        {
            see = new SeeForth(unit.transform, 1.0f,Layers.PlayerMask,Layers.GroundMask);
            return see;
        }
        public IMovable SetMovable(UnitBase unit)
        {
            movable = new MovableUnit(unit, 1f);
            return movable;
        }
        public IController SetController(UnitBase unit)
        {
            return new BasicMonsterController(unit);
        }
    }
}