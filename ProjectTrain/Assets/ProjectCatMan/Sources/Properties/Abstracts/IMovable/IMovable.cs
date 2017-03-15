using UnityEngine;

namespace ProjectCatMan
{
    public interface IMovable : IUnitProperty
    {
        float speed { get; }
        void Move();
    }
}