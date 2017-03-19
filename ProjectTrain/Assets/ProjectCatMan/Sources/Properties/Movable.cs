using UnityEngine;

namespace ProjectCatMan
{
    public interface IMovable
    {
        bool isMoving { get; }
        Direction moveDirection { get; }
        float speed { get; }
        
        void Move();
        void Move(Direction direction);
        void Stop();
    }
    #region MovableUnit
    public abstract class MovableUnit : IMovable
    {
        public MovableUnit(UnitBase unit, float speed)
        {
            this.unit = unit;
            this.transform = unit.transform;
            this.speed = speed;
        }
        
        public bool isMoving { get; private set; }
        public Direction moveDirection { get; private set; }
        public float speed { get; private set; }

        public abstract void Move();
        public abstract void Move(Direction direction);
        public void Stop()
        {
            isMoving = false;
            moveDirection = Direction.None;
        }
        

        public UnitBase unit { get; private set; }
        public Transform transform { get; private set; }
        public float moveSpeed
        {
            get { return speed * Time.deltaTime; }
        }
       
        protected void DoMove(Direction direction)
        {
            isMoving = true;
            moveDirection = direction;
            transform.position += direction.DirToVec3() * moveSpeed;
        }
        
    }

    public class MoveToTarget : MovableUnit
    {
        public MoveToTarget(UnitBase unit, float speed) : base(unit, speed)
        {
            this.see = unit.see;
        }

        public override void Move(Direction direction)
        {
            DoMove(direction);
        }
        public override void Move()
        {
            if (see.Nothing()) return;
            Direction direction = transform.Location(see.current);
            DoMove(direction);
        }

        private ISee see;
    }
    #endregion
    public class UnMovable : IMovable
    {
        public UnMovable(float speed)
        {
            this.speed = 0;
        }

        public bool isMoving { get { return false; } }
        public Direction moveDirection { get; private set; }
        public float speed { get; private set; }

        public void Move(Direction direction) { }
        public void Move() { }
        public void Stop() { }

        public override string ToString()
        {
            return "UnMovable";
        }
    }
}