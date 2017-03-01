using UnityEngine;

namespace ProjectTrain
{
    public partial class TurretBase : Unit
    {
        public override void Initialize()
        {
        }

        const string turretLayer = "Enemy";
        protected override void Initialize(int layer,int hp, MovementBase movement, UnitAnimation animation)
        {
            base.Initialize(LayerMask.NameToLayer(turretLayer), hp, new NoWayMovement(transform),new UnitAnimation(animator));
        }
    }
}