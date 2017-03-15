namespace ProjectCatMan
{
    public class KillableUnit : IKillable
    {
        public KillableUnit(UnitBase unit)
        {
            this.unit = unit;
            this.damageable = unit.damageable;
        }
        public UnitBase unit { get; private set; }
        public IDamageable damageable { get; private set; }
        public bool isLive
        {
            get
            {
                return damageable.hp > 0;
            }
        }
        public void Killed()
        {
        }
        public override string ToString()
        {
            return "KillableUnit";
        }
    } 
}