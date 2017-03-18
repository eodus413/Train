using UnityEngine;

namespace ProjectCatMan
{
    public static class DirectionExtension
    {
        public static Vector2 DirToVec2(this Direction dir)
        {
            if (dir == Direction.Left) return Vector2.left;
            else if (dir == Direction.Right) return Vector2.right;


            return Vector2.zero;
        }
        public static Vector3 DirToVec3(this Direction dir)
        {
            if (dir == Direction.Left) return Vector3.left;
            else if (dir == Direction.Right) return Vector3.right;


            return Vector3.zero;
        }
        static Vector3 eulerLeft = new Vector3(0, 180, 0);
        static Vector3 eulerRight = new Vector3(0, 0, 0);
        public static Vector3 DirToEuler(this Direction dir)
        {
            if (dir == Direction.Left) return eulerLeft;
            else if (dir == Direction.Right) return eulerRight;

            return Vector3.zero;
        }
    }
}
