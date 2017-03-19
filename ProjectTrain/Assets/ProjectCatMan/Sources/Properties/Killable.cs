namespace ProjectCatMan
{
    public interface IKillable 
    {
        bool isLive { get; }
        void Killed();
    }
    public class KillableUnit : IKillable
    {
        public KillableUnit(UnitBase unit)
        {
            this.unit = unit;
            this.attackable = unit.attackable;
        }
        public bool isLive
        {
            get { return attackable.hp > 0; }
        }
        public void Killed() { }

        public UnitBase unit { get; private set; }
        public IAttackable attackable { get; private set; }

        public override string ToString()
        {
            return "KillableUnit";
        }
    }

    //델리게이트를 써서 어떻게 할 수 없을까?
    //일정 타임이 되면 델리게이트 호출하게
    public class Revivable : IKillable
    {
        public Revivable(UnitBase unit)
        {
            this.unit = unit;
            this.attackable = unit.attackable;
        }

        public bool isLive
        {
            get { return attackable.hp > 0; }
        }
        public void Killed() { }

        public UnitBase unit { get; private set; }
        public IAttackable attackable;

        public override string ToString()
        {
            return "Revivable";
        }
    }

    public class UnKillable : IKillable
    {
        
        public UnKillable() 
        {

        }
        
        public bool isLive { get { return true; } }
        public void Killed()
        {
            return;
        }

        public override string ToString()
        {
            return "UnKillable";
        }
    }
}