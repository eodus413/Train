using UnityEngine;

namespace ProjectTrain.InGame
{
    public partial class Camera2DFollow
    {
        Camera current;
        Transform transform;    //camera.transform
        Transform target;

        float offsetZ;
        Vector3 lastTargetPosition;
        Vector3 currentVelocity;
        Vector3 lookAheadPosition;
    }
}