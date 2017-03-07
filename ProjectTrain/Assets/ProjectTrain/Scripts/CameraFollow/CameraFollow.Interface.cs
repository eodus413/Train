using UnityEngine;

namespace ProjectTrain.InGame
{
    public partial class Camera2DFollow
    {
        public float damping { get; set; }
        public float lookAheadFactor { get; set; }
        public float lookAheadReturnSpeed { get; set; }
        public float lookAheadMoveThreshold { get; set; }


        float offsetZ;
        Vector3 lastTargetPosition;
        Vector3 currentVelocity;
        Vector3 lookAheadPosition;

        public void Follow()
        {
            xMoveDelta = (target.position - lastTargetPosition).x;

            updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                lookAheadPosition = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
            }
            else
            {
                lookAheadPosition = Vector3.MoveTowards(lookAheadPosition, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
            }

            aheadTargetPos = target.position + lookAheadPosition + (Vector3.forward * offsetZ);
            newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

            newPos = MoveArea(newPos);
            transform.position = newPos;

            lastTargetPosition = target.position;
        }
    }
}