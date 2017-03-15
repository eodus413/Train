using UnityEngine;

namespace ProjectCatMan
{
    public static class TransformExtension
    {
        public static bool isLeft(this Transform lv,Transform rv)
        {
            return lv.position.x < rv.position.y;
        }
        public static bool isLeft(this Transform lv,GameObject rv)
        {
            return lv.position.x < rv.transform.position.y;
        }
        public static Vector2 HorizontalDirection(this Transform lv,Transform rv)
        {
            if (lv.isLeft(rv)) return Vector2.left;
            else return Vector2.right;
        }
        public static Vector2 HorizontalDirection(this Transform lv, GameObject rv)
        {
            if (lv.isLeft(rv)) return Vector2.left;
            else return Vector2.right;
        }
    }
}