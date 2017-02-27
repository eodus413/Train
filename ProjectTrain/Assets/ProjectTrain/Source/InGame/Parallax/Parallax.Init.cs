using UnityEngine;

namespace ProjectTrain.InGame
{
    public partial class Parallax
    {
        public Parallax(Transform[] parallaxs)
        {
            this.parallaxs = parallaxs;
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