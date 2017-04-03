using UnityEngine;

namespace Background
{
    public class Parallaxing : MonoBehaviour
    {
        public Transform[] backgrounds;
        private float[] parallaxScales;
        public float smooting = 1f;

        private Transform cam;
        private Vector3 previousCamPos;

        void Awake()
        {
            cam = Camera.main.transform;

            int lenght = transform.childCount;
            backgrounds = new Transform[lenght];
            for(int i=0;i< lenght;++i)
            {
                backgrounds[i] = transform.GetChild(i);
            }
        }

        void Start()
        {
            previousCamPos = cam.position;


            int lenght = backgrounds.Length;

            parallaxScales = new float[lenght];
            for(int i=0;i< lenght;++i)
            {
                parallaxScales[i] = backgrounds[i].position.z * -1;
            }
        }
        void Update()
        {
            for(int i=0;i<backgrounds.Length;++i)
            {
                float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

                float backgroundTargetPosX = backgrounds[i].position.x + parallax;

                Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

                backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smooting * Time.deltaTime);
            }
            previousCamPos = cam.position;
        }
    }
}