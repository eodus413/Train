using UnityEngine;

namespace ProjectCatMan
{
    public class MoveToTarget : MovableUnit
    {
        public MoveToTarget(UnitBase unit,float speed) : base(unit,speed)
        {
            this.targeting = unit.seeable;
        }
        private ISeeable targeting;

        public override void Move(Direction direction)
        {
            DoMove(direction);
        }
        public override void Move()
        {
            if (targeting.Nothing()) return;
            Direction direction = transform.Location(targeting.current);
            DoMove(direction);
        }
    }
}