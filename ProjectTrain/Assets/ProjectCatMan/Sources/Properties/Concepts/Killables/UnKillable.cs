namespace ProjectCatMan
{
    public class UnKillable : IKillable
    {
        public UnKillable(UnitBase unit)
        {

        }
        public UnitBase unit { get; private set; }
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