using UnityEngine;

namespace Entity
{
    //이동 인터페이스
    public interface IMoveBehavior
    {
        bool isMoving { get; }

        float speed { get; }
        Vector2 direction { get; }

        Transform transform { get; }

        void Move(Vector2 direction);
    }

    //기본 이동
    public class DefaultMove : IMoveBehavior
    {
        //생성자
        public DefaultMove(EntityBase entity,float speed)
        {
            isMoving = false;

            this.speed = speed;
            direction = Vector2.zero;

            this.transform = entity.transform;
            this.entity = entity;
        }


        //인터페이스
        public bool isMoving { get; private set; }

        public float speed { get; private set; }
        public Vector2 direction { get; private set; }

        public Transform transform { get; private set; }

        public void Move(Vector2 direction)
        {
            this.direction = direction;

            isMoving = direction != Vector2.zero;

            if (!isMoving) return;

            transform.Translate(this.direction * moveSpeed);
        }


        //구현
        private EntityBase entity;
        private float moveSpeed
        {
            get
            {
                return speed * Time.deltaTime;
            }
        }
    }
    public class NoWayToMove : IMoveBehavior
    {      
        //생성자
        public NoWayToMove(EntityBase entity)
        {
            this.transform = entity.transform;
            this.entity = entity;
        }


        //인터페이스
        public bool isMoving { get { return false; } }

        public float speed { get { return 0f; } }
        public Vector2 direction { get { return Vector2.zero; } }

        public Transform transform { get; private set; }

        public void Move(Vector2 direction)
        {
            //움직일 수 없음
        }

        //구현
        private EntityBase entity;
    }
}