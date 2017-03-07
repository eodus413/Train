using UnityEngine;

namespace ProjectTrain.InGame
{
    public partial class Camera2DFollow : MonoBehaviour
    {
        Transform target { get; set; }

        float xMoveDelta;
        bool updateLookAheadTarget;
        Vector3 aheadTargetPos;
        Vector3 newPos;

        [SerializeField] Vector2 minPos = new Vector2(-8.06f, -0.6f);
        [SerializeField] Vector2 maxPos = new Vector2(8.09f, 0.25f);
        Vector3 MoveArea(Vector3 pos)
        {
            if (pos.x < minPos.x) pos.x = minPos.x;
            if (pos.x > maxPos.x) pos.x = maxPos.x;
            if (pos.y < minPos.y) pos.y = minPos.y;
            if (pos.y > maxPos.y) pos.y = maxPos.y;
            return pos;
        }
        void FixedUpdate()
        {
            Follow();
        }
    }
}