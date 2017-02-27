using UnityEngine;

namespace ProjectTrain.InGame
{
    public partial class Camera2DFollow
    {
        public float damping { get; set; }
        public float lookAheadFactor { get; set; }
        public float lookAheadReturnSpeed { get; set; }
        public float lookAheadMoveThreshold { get; set; }

        float xMoveDelta;
        bool updateLookAheadTarget;
        Vector3 aheadTargetPos;
        Vector3 newPos;

        Vector2 minPos = new Vector2(-8.06f,-0.1f);
        Vector2 maxPos = new Vector2(8.09f,1f);
        Vector3 MoveArea(Vector3 pos)
        {
            if (pos.x < minPos.x) pos.x = minPos.x;
            if (pos.x > maxPos.x) pos.x = maxPos.x;
            if (pos.y < minPos.y) pos.y = minPos.y;
            if (pos.y > maxPos.y) pos.y = maxPos.y;
            return pos;
        }
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