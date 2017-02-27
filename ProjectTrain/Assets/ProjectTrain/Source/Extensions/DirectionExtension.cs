using UnityEngine;

namespace ProjectTrain
{
    public static class DirectionExtension
    {
        public static Vector2 DirToVec2(this Direction dir)
        {
            if      (dir == Direction.Left)     return Vector2.left;
            else if (dir == Direction.Right)    return Vector2.right;


            return Vector2.zero;
        }
    }
}