using UnityEngine;

namespace ProjectTrain.InGame
{
    public partial class Parallax
    {
        Transform[] parallaxs;
        float[] parallaxScales;

        float smoothing = 1f;

        int size;                       //backgrounds.Lenght

        Transform camera;                  //Current Camera
        Vector2 prevCameraPosition;
    }
}