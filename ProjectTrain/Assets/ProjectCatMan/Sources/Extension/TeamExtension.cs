namespace ProjectCatMan
{
    public static class TeamExtension
    {
        public static int LayerMask(this Team team)
        {
            if(team == Team.Player)
            {
                return Layers.PlayerMask;
            }
            else if(team == Team.Monster)
            {
                return Layers.MonsterMask;
            }
            return Layers.Noting;
        }
    }
}