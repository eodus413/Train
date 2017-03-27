using System;
using UnityEngine;
//movable클래스가 어떤 동작만 정의하는지 (동작 클래스)
//아니면 다른 객체의 상태를 체크해 다른 동작을 실행하는지
//확실히 하도록
namespace ProjectCatMan
{
    public interface IMovable
    {
        Transform transform { get; }

        bool isMoving { get; }
        Direction moveDirection { get; }
        float speed { get; }

        void Move(Vector3 direction);
        void Stop();
    }
    #region MovableUnit
    public class MoveToDirection : IMovable
    {
        public MoveToDirection(Transform transform, float speed)
        {
            this.transform = transform;

            this.isMoving = false;
            this.moveDirection = Direction.None;
            this.speed = speed;
        }

        public Transform transform { get; private set; }

        public bool isMoving { get; private set; }
        public Direction moveDirection { get; private set; }
        public float speed { get; private set; }

        public void Move(Vector3 direction)
        {
            DoMove(direction);
        }
        public void Stop()
        {
            isMoving = false;
            moveDirection = Direction.None;
        }

        public float moveSpeed
        {
            get { return speed * Time.deltaTime; }
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
        public UnMovable(Transform transform, float speed)
        {
            this.transform = transform;
            //this.isMoving = false;
            
            this.speed = 0;
        }

        public Transform transform { get; private set; }

        public bool isMoving
        {
            get { return false; }
        }
        public Direction moveDirection
        {
            get { return Direction.None; }
        }
        public float speed { get; private set; }

        public void Move(Vector3 direction) { }
        public void Stop() { }
    }
}