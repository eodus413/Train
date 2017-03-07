using UnityEngine;

namespace ProjectTrain.InGame
{
    public partial class Parallax : MonoBehaviour
    {
        void Start()
        {
            this.parallaxs = new Transform[transform.childCount];
            for (int i = 0; i < transform.childCount; ++i)
            {
                this.parallaxs[i] = transform.GetChild(i);
            }
            this.size = this.parallaxs.Length;
            this.camera = Camera.main.transform;

            this.prevCameraPosition = camera.position;

            this.parallaxScales = new float[size];

            for (int i = 0; i < size; ++i)
            {
                this.parallaxScales[i] = this.parallaxs[i].position.z * -1;
            }
        }
    }
}