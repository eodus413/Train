using UnityEngine;

namespace Entity
{
    public struct Direction
    {
        Vector3 value;

        public Direction(Vector3 value)
        {
            this.value = value;
        }
        public bool isLeft
        {
            get { return value == Vector3.left; }
        }
        public bool isRight
        {
            get { return value == Vector3.right; }
        }

        public static implicit operator Direction(Vector3 value)
        {
            return new Direction(value);
        }
        public static Vector3 operator *(Direction direction,float value)
        {
            return direction.value * value;
        }
        public static bool operator ==(Direction lv,Direction rv)
        {
            return lv.value == rv.value;
        }

        public static bool operator !=(Direction lv,Direction rv)
        {
            return lv.value != rv.value;
        }
    }
}