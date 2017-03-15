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
        public UnitBase unit { get; private set; }
        public float speed { get; private set; }
        public void Move()
        {
            return;
        }
        public override string ToString()
        {
            return "UnMovable";
        }
    }
}