namespace ProjectCatMan
{
    public enum FSMState
    {
        Idle,
        Patrol,
        Move,
        Attack,
        Dead
    }
    public class MonsterFSM : UnitController
    {
        public MonsterFSM(UnitBase unit,MoveEvent Move,DeadEvent Dead) : base(unit)
        {
            this.Move += Move;
            this.Dead += Dead;
        }

        public delegate void MoveEvent();
        public event MoveEvent Move;

        public delegate void DeadEvent();
        public event DeadEvent Dead;
        

    }
}