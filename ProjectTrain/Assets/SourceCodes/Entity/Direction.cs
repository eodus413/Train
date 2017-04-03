using UnityEngine;

namespace Entity
{
    public struct Direction
    {
        public static Direction left = new Direction(Vector3.left);
        public static Direction right = new Direction(Vector3.right);
        public static Direction zero = new Direction(Vector3.zero);
        Vector3 value;

        public Direction(Vector2 value)
        {
            this.value = value;
        }
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

        public static implicit operator Direction(Vector2 value)
        {
            return new Direction(value);
        }
        public static implicit operator Direction(Vector3 value)
        {
            return new Direction(value);
        }
        public static implicit operator Vector2(Direction lv)
        {
            return lv.value;
        }
        public static implicit operator Vector3(Direction lv)
        {
            return lv.value;
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


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}