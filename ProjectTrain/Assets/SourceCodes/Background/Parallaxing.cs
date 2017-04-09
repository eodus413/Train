using UnityEngine;
using System.Collections.Generic;

namespace Background
{
    public class Parallaxing : MonoBehaviour
    {
        [SerializeField]
        private Stages stage;
        [SerializeField]
        private Transform[] fieldLayers;
        [SerializeField]
        private Transform[] overLayers;
        [SerializeField]
        private Transform[] backgrounds;
        [SerializeField]
        private float[] parallaxScales;
        [SerializeField]  
        private float smooting = 1f;

        int backgroundsCount;
        private Transform cam;
        private Vector3 previousCamPos;

        BackgroundLoader loader;
        void Awake()
        {
            cam = Camera.main.transform;
            loader = new BackgroundLoader(transform);

            fieldLayers = loader.CreateBackgrounds(stage, "FieldLayer");
            overLayers  = loader.CreateBackgrounds(stage, "OverLayer");
            backgrounds = loader.CreateBackgrounds(stage, "Background");
            
            backgroundsCount = backgrounds.Length;

            parallaxScales = new float[backgroundsCount];

            for (int i = 0; i < backgroundsCount; ++i)
            {
                backgrounds[i].position += (Vector3.forward * (i + 1));
                parallaxScales[i] = backgrounds[i].position.z * -1;
            }
        }
        void Update()
        {
            for(int i=0 ;i<backgroundsCount;++i)    // 0, 1은 over,field layer
            {
                float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

                float backgroundTargetPosX = backgrounds[i].position.x + parallax;

                Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

                backgrounds[i].localPosition = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smooting * Time.deltaTime);
            }
            previousCamPos = cam.position;
        }
    }
}