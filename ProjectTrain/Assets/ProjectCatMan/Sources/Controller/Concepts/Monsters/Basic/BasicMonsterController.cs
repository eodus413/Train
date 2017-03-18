namespace ProjectCatMan
{
    public class BasicMonsterController : UnitController
    {
        public BasicMonsterController(UnitBase unit) : base(unit)
        {

        }
        public override void Initialize()
        {
        }
        public override void Execute()
        {
            if (killable.isLive == false) return;

            seeable.Seeing();
        }
        public override void PhysicsExecute()
        {
            movable.Move();
        }
    }
}