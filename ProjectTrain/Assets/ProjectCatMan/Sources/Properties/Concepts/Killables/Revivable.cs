namespace ProjectCatMan
{
    //델리게이트를 써서 어떻게 할 수 없을까?
    //일정 타임이 되면 델리게이트 호출하게
    public class Revivable : IKillable
    {
        public Revivable(UnitBase unit)
        {
            this.unit = unit;
        }
        public UnitBase unit { get; private set; }
        public bool isLive { get; private set; }
        public void Killed()
        {                    
        }
        public override string ToString()
        {
            return "Revivable";
        }
    }
}