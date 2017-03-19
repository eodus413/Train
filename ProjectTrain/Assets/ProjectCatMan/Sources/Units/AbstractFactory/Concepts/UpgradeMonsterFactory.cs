using UnityEngine;

namespace ProjectCatMan
{
    public class UpgradeMonsterFactory : IUnitFactory
    {
        public IAttackable attackable { get; private set; }
        public IKillable killable { get; private set; }
        public ISee see { get; private set; }
        public IMovable movable { get;  set; }

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
            attackable = new AttackableUnit(100,0, unit);
            return attackable;
        }
        public IKillable SetKillable(UnitBase unit)
        {
            killable = new Revivable(unit);
            return killable;
        } 
        public ISee SetSee(UnitBase unit)
        {
            see = new SeeForth(unit, 1.0f, Layers.UnitMask, Layers.GroundMask);
            return see;
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