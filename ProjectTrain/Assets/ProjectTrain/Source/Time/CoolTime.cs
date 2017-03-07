using UnityEngine;

namespace ProjectTrain
{
    public class CoolTime
    {
        public float startTime { get; private set; }
        public float coolTime { get; private set; }

        private float flowTime
        {
            get
            {
                return Time.realtimeSinceStartup - startTime;
            }

        }
        public bool isEnd
        {
            get
            {
                return (coolTime - flowTime) <= 0;
            }
        }

        public void Start()
        {
            if (!isEnd) return;

            startTime = Time.realtimeSinceStartup;
        }

        public CoolTime(float coolTime)
        {
            this.coolTime = coolTime;
        }       
    }
}