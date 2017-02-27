using UnityEngine;
using System.Collections.Generic;

namespace ProjectTrain.InGame
{
    public partial class InGameSystem : MonoBehaviour
    {
        Transform[] parallaxs;
        void Awake()
        {
            this.parallax = new Parallax(FindParallax());
            
            Transform target = GameObject.Find("Player").transform;
            this.camera2D = new Camera2DFollow(target);
        }
        void Start()
        {

        }
        Transform[] FindParallax()
        {
            List<Transform> parallaxs = new List<Transform>();

            int number = 1;
            Transform parallax = transform;     //임시로 transform 대입해둠 new Transform 이 안되기 때문에

            do
            {
                parallax = transform.Find("Parallax " + '(' + number + ')');

                if(parallax) parallaxs.Add(parallax);       //if parallax is not null

                ++number;
            } while (parallax != null);

            int size = parallaxs.Count;

            this.parallaxs = new Transform[size];
            for (int i = 0; i < size; ++i)
            {
                this.parallaxs[i] = parallaxs[i];
            }
            
            return this.parallaxs;
        }
    }
}