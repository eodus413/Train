using UnityEngine;

namespace ProjectTrain
{
    public partial class MovementBase
    {

        public float deltaSpeed
        {
            get { return speed * Time.deltaTime; }
        }

        public virtual void Move(Vector3 direction)
        {
            if (direction == Vector3.zero) return;

            transform.position += direction * deltaSpeed;
            
            this.direction = direction;
        }
        public void Move(Vector3 direction,float newSpeed)
        {
            if (direction == Vector3.zero) return;

            transform.position += direction * newSpeed;

            this.direction = direction;
        }
    }
}