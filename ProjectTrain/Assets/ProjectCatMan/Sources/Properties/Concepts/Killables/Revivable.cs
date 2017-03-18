namespace ProjectCatMan
{
    //델리게이트를 써서 어떻게 할 수 없을까?
    //일정 타임이 되면 델리게이트 호출하게
    public class Revivable : IKillable
    {
        public Revivable(UnitBase unit)
        {
            this.unit = unit;
            this.damageable = unit.damageable;
        }
        public UnitBase unit { get; private set; }

        public IDamageable damageable;
        public bool isLive { get { return damageable.hp > 0; } }
        public void Killed()
        {                    
        }
        public override string ToString()
        {
            return "Revivable";
        }
    }
}