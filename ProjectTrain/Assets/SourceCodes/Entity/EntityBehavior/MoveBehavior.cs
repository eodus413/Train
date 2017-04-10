using UnityEngine;

namespace Entity
{
    //이동 인터페이스
    public interface IMoveBehavior
    {
        bool isMoving { get; }

        float speed { get; }
        Direction moveDirection { get; }

        Transform mover { get; }

        void Move(Direction direction);

    }

    //기본 이동
    public class DefaultMove : IMoveBehavior
    {
        //생성자
        public DefaultMove(EntityBase entity,float speed)
        {
            isMoving = false;

            this.speed = speed;
            moveDirection = Direction.zero;

            this.mover = entity.transform;
            this.entity = entity;
        }


        //인터페이스
        public bool isMoving { get; private set; }

        public float speed { get; private set; }
        public Direction moveDirection { get; private set; }

        public Transform mover { get; private set; }

        public void Move(Direction direction)
        {
            moveDirection = direction;

            isMoving = moveDirection != Direction.zero;

            if (!isMoving) return;

            mover.position += moveDirection * moveSpeed;
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
}