using UnityEngine;

namespace ProjectTrain.InGame
{
    public partial class Parallax : MonoBehaviour
    {
        Transform[] parallaxs;
        float[] parallaxScales;

        float smoothing = 1f;

        int size;                       //backgrounds.Lenght

        new Transform camera;                  //Current Camera
        Vector2 prevCameraPosition;

        void FixedUpdate()
        {
            Parallaxing();
        }
    }
}