namespace ProjectCatMan
{
    public class PlayerFactory : IUnitFactory
    {
        public IAttackable attackable { get; private set; }
        public IKillable killable { get; private set; }
        public ISee see { get; private set; }
        public IMovable movable { get; private set; }

        public Team SetTeam()
        {
            return Team.Player;
        }
        public Friendly SetFriendly()
        {
            return Friendly.Hostile;
        }
        public IAttackable SetAttackable(UnitBase unit)
        {
            attackable = new AttackableUnit(100, 0, unit);
            return attackable;
        }
        public IKillable SetKillable(UnitBase unit)
        {
            killable = new Revivable(unit);
            return killable;
        }
        public ISee SetSee(UnitBase unit)
        {
            see = new CanSee();
            return see;
        }
        public IMovable SetMovable(UnitBase unit)
        {
            movable = new MovableUnit(unit,0.3f);
            return movable;
        }
        public IController SetController(UnitBase unit)
        {
            return new PlayerController(unit,unit.animator);
        }
    }
}