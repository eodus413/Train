using UnityEngine;

namespace ProjectCatMan
{
    public class LookAtTheMouse
    {
        public LookAtTheMouse(GameObject gameObject)
        {
            this.gameObject = gameObject;
            this.transform = gameObject.transform;
        }
        private GameObject gameObject;
        private Transform transform;
        public Direction direction { get; private set; }

        public void Looking()
        {
            Vector3 positionAtView = Camera.main.WorldToScreenPoint(transform.position);

            Vector3 look = Input.mousePosition.LocationOf(positionAtView);
            direction = look.Vec3ToDir();
            gameObject.Turn2D(direction);
        }
    }
}