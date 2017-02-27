using UnityEngine;

namespace ProjectTrain.InGame
{
    public partial class InGameSystem : MonoBehaviour
    {
        Parallax parallax;
        Camera2DFollow camera2D;
        //Transform/Player player
            
        void FixedUpdate()
        {
            parallax.Parallaxing();
            camera2D.Follow();
        }
    }
}