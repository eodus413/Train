using UnityEngine;

namespace ProjectCatMan
{
    public abstract class MovableUnit : IMovable
    {
        public MovableUnit(UnitBase unit,float speed)
        {
            this.unit = unit;
            this.transform = unit.transform;
            this.speed = speed;
        }

        public UnitBase unit { get; private set; }
        public Direction moveDirection { get; private set; }
        public Transform transform { get; private set; }

        public float speed { get; private set; }
        float moveSpeed { get { return speed * Time.deltaTime; } }

        public bool isMoving { get; private set; }
        public abstract void Move();
        public abstract void Move(Direction direction);
        protected void DoMove(Direction direction)
        {
            isMoving = true;
            moveDirection = direction;
            transform.position += direction.DirToVec3() * moveSpeed;
        }
        public void Stop()
        {
            isMoving = false;
            moveDirection = Direction.None;
        }
    }
}