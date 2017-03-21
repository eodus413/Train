using UnityEngine;

namespace ProjectCatMan
{
    public static class Vector3Extension
    {
        public static bool isLeft(this Vector3 lv, Transform rv)
        {
            if (rv == null)
            {
                Debug.Log(rv + "is null, Vector3Extension Direction return false");
                return false;
            }
            return lv.x < rv.position.y;
        }
        public static Vector3 LocationOf(this Vector3 lv,Vector3 rv)
        {
            if (lv.x < rv.x) return Vector3.left;
            return Vector3.right;
        }
        public static Direction Vec3ToDir(this Vector3 lv)
        {
            if (lv == Vector3.left) return Direction.Left;
            return Direction.Right;
        }
    }
}