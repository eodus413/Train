namespace ProjectCatMan
{
    public class PlayerFactory : IUnitFactory
    {
        public Team SetTeam()
        {
            return Team.Player;
        }
        public Friendly SetFriendly()
        {
            return Friendly.Hostile;
        }
        public ISee SetSee(UnitBase unit)
        {
            return new SeeMouse(unit.transform);
        }
        public IMovable SetMovable(UnitBase unit)
        {
            return new MoveToDirection(unit.transform, 0.3f);
        }
        public Life SetLife(UnitBase unit)
        {
            return new Life(10,);
        }
    }
}