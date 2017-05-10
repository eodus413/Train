using UnityEngine;

namespace Entity
{
    //이동 인터페이스
    public interface IMoveBehavior
    {
        bool isMoving { get; }

        float speed { get; }
        Vector2 moveDirection { get; }

        Transform mover { get; }

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
            moveDirection = Vector2.zero;

            this.mover = entity.transform;
            this.entity = entity;
        }


        //인터페이스
        public bool isMoving { get; private set; }

        public float speed { get; private set; }
        public Vector2 moveDirection { get; private set; }

        public Transform mover { get; private set; }

        public void Move(Vector2 direction)
        {
            moveDirection = direction;

            isMoving = moveDirection != Vector2.zero;

            if (!isMoving) return;

            mover.Translate(moveDirection * moveSpeed);
        }


        //구현
        private EntityBase entity;
        private float moveSpeed
        {
            get
            {
                if (entity.lookDirection != moveDirection) return speed * Time.deltaTime * 0.5f;
                return speed * Time.deltaTime;
            }
        }
    }
    public class NoWayToMove : IMoveBehavior
    {      
        //생성자
        public NoWayToMove(EntityBase entity)
        {
            this.mover = entity.transform;
            this.entity = entity;
        }


        //인터페이스
        public bool isMoving { get { return false; } }

        public float speed { get { return 0f; } }
        public Vector2 moveDirection { get { return Vector2.zero; } }

        public Transform mover { get; private set; }

        public void Move(Vector2 direction)
        {
        }

        //구현
        private EntityBase entity;
    }
}