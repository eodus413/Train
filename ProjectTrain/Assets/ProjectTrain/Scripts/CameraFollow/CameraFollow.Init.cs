using UnityEngine;

namespace ProjectTrain.InGame
{
    public partial class Camera2DFollow
    {
        void Start()
        {
            target = GameObject.Find("Player").transform ;
            this.damping = 0.3f;
            this.lookAheadFactor = 3f;
            this.lookAheadReturnSpeed = 0.5f;
            this.lookAheadMoveThreshold = 0.5f;
            
            this.lastTargetPosition = target.position;
            this.offsetZ = (transform.position - target.position).z;
            this.transform.parent = null;
        }
    }
}