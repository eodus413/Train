using UnityEngine;

namespace ProjectCatMan
{
    public class UnMovable : IMovable
    {
        public UnMovable(UnitBase unit,float speed )
        {
            this.unit = unit;
            this.speed = 0;
        }
        public bool isMoving { get { return false; } }
        public Direction moveDirection { get; private set; }
        public UnitBase unit { get; private set; }
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