using UnityEngine;

namespace ProjectTrain
{
    public partial class TurretBase : Unit
    {
        public override void Initialize()
        {
        }
        protected override void Initialize(int hp, MovementBase movement, UnitAnimation animation)
        {
            base.Initialize(hp, new NoWayMovement(transform),new UnitAnimation(animator));
        }
    }
}