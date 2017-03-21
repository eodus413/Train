using System;
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
    public class MovableUnit : IMovable
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

        public void Move()
        {
            DoMove(transform.right);
        }
        public void Move(Direction direction)
        {
            DoMove(direction);
        }
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
        protected void DoMove(Vector3 direction)
        {
            isMoving = true;
            moveDirection = direction.Vec3ToDir();
            transform.position += direction * moveSpeed;
        }
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