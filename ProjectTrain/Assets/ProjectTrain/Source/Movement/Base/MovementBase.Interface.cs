using UnityEngine;

namespace ProjectTrain
{
    public partial class MovementBase
    {
        public float deltaSpeed
        {
            get { return speed * Time.deltaTime; }
        }
        public void Move(Vector2 direction)
        {
            Move(direction, deltaSpeed);
        }
        protected virtual void Move(Vector3 direction,float newSpeed)
        {
            if (direction == Vector3.zero) return;
            
            transform.position += direction * newSpeed;
        }
    }
}