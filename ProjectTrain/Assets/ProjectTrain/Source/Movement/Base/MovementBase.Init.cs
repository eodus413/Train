using UnityEngine;

namespace ProjectTrain
{
    public partial class MovementBase
    {
        public MovementBase(Transform transform,float speed = 1f)
        {
            this.transform = transform;
            this.speed = speed;
        }
    }
}