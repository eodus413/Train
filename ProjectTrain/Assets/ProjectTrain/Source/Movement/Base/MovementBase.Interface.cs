using UnityEngine;

namespace ProjectTrain
{
    public partial class MovementBase
    {
        public void Idle()
        {
            isMoving = false;
            this.direction = Vector3.zero;
        }
        public virtual void Move(Vector3 direction)
        {
            if (direction == Vector3.zero) return;

            transform.position += direction * deltaSpeed;
            
            this.direction = direction;
            isMoving = true;
        }
        public virtual void MoveBack(Vector3 direction)
        {
            if (direction == Vector3.zero) return;

            transform.position += direction * (deltaSpeed * 0.5f);

            this.direction = direction;
            isMoving = true;
        }
    }
}