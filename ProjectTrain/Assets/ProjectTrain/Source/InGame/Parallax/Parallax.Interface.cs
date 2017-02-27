using UnityEngine;

namespace ProjectTrain.InGame
{
    public partial class Parallax
    {
        float parallaxValue;
        Vector3 targetPosition;
        Vector3 backgroundTargetPosition;
        public void Parallaxing()
        {
            for (int i = 0; i < size; ++i)
            {
                parallaxValue = (prevCameraPosition.x - camera.position.x) * parallaxScales[i];

                targetPosition = parallaxs[i].position;

                backgroundTargetPosition.x = targetPosition.x + parallaxValue;
                backgroundTargetPosition.y = targetPosition.y;
                backgroundTargetPosition.z = targetPosition.z;

                parallaxs[i].position = Vector3.Lerp(parallaxs[i].position, backgroundTargetPosition, smoothing * Time.deltaTime);
            }
            prevCameraPosition = camera.position;
        }
    }
}