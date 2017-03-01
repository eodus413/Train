using UnityEngine;

namespace ProjectTrain
{
    public class TimeSystem : MonoBehaviour
    {
        public static TimeSystem time;
        public float playTime { get; private set; }
        public float FlowTime(float lastTime)
        {
            return playTime - lastTime;
        }
        
        void Start()
        {
            time = this;
        }
        void FixedUpdate()
        {
            playTime += Time.deltaTime;
        }
    }    
}
