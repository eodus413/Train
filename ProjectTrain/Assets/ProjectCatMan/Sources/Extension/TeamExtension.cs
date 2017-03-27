namespace ProjectCatMan
{
    public static class TeamExtension
    {
        public static int AttackLayerMask(this Team team)
        {
            if(team == Team.Player)
            {
                return Layers.MonsterMask;
            }
            else if(team == Team.Monster)
            {
                return Layers.PlayerMask;
            }
            return Layers.Noting;
        }
    }
}