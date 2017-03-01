using UnityEngine;

namespace ProjectTrain
{
    public class CoolTIme
    {
        public float percent
        {
            get
            {
                return coolTime / (TimeSystem.time.playTime - startTime);
            }
        }
        public bool isEnd()
        {
            return (coolTime - TimeSystem.time.playTime - startTime) <= 0;
        }
        public void Start()
        {
            startTime = TimeSystem.time.playTime;
        }
        private float startTime;
        readonly float coolTime;

        public CoolTIme(float coolTime)
        {
            this.coolTime = coolTime;
            startTime = TimeSystem.time.playTime;
        }       
    }
}