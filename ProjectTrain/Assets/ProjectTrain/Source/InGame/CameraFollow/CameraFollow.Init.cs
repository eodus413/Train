using UnityEngine;

namespace ProjectTrain.InGame
{
    public partial class Camera2DFollow
    {
        public Camera2DFollow(Transform target)
        {
            this.target = target;

            this.damping = 0.3f;
            this.lookAheadFactor = 3f;
            this.lookAheadReturnSpeed = 0.5f;
            this.lookAheadMoveThreshold = 0.5f;

            this.current = Camera.main;

            this.transform = current.transform;

            this.lastTargetPosition = target.position;
            this.offsetZ = (current.transform.position - target.position).z;
            this.transform.parent = null;
        }
    }
}