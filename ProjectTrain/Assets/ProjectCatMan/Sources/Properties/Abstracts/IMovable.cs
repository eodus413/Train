using UnityEngine;

namespace ProjectCatMan
{
    public interface IMovable : IUnitProperty
    {
        bool isMoving { get; }
        Direction moveDirection { get; }
        float speed { get; }
        
        void Move();
        void Move(Direction direction);
        void Stop();
    }
}