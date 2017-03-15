using UnityEngine;

namespace ProjectCatMan
{
    public class MoveToTarget : IMovable
    {
        public MoveToTarget(UnitBase unit,float speed)
        {
            this.unit = unit;
            this.seeable = unit.seeable;
            this.transform = unit.transform;
            this.speed = speed;
        }
        public UnitBase unit { get; private set; }
        public Transform transform { get; private set; }
        private ISeeable seeable;
        public float speed { get; private set; }



        public void Move()
        {
            Vector3 direction = transform.HorizontalDirection(seeable.current);
            transform.position += direction * speed;
        }
    }
}