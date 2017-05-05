using UnityEngine;

namespace Entity
{
    public struct Direction
    {
        public static Direction left = new Direction(Vector3.left);
        public static Direction right = new Direction(Vector3.right);
        public static Direction zero = new Direction(Vector3.zero);
        private Vector3 direction;

        public Direction(Vector2 value)
        {
            if (value.x > 0) direction = Vector2.right;
            else if (value.x < 0) direction = Vector2.left;
            else direction = Vector2.zero;
        }
        public Direction(Vector3 value)
        {
            if (value.x > 0) direction = Vector2.right;
            else if (value.x < 0) direction = Vector2.left;
            else direction = Vector2.zero;
        }
        public bool isLeft
        {
            get { return direction == Vector3.left; }
        }
        public bool isRight
        {
            get { return direction == Vector3.right; }
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
            return lv.direction;
        }
        public static implicit operator Vector3(Direction lv)
        {
            return lv.direction;
        }
        public static Vector3 operator *(Direction direction,float value)
        {
            return direction.direction * value;
        }
        public static bool operator ==(Direction lv,Direction rv)
        {
            return lv.direction == rv.direction;
        }

        public static bool operator !=(Direction lv,Direction rv)
        {
            return lv.direction != rv.direction;
        }


        public override string ToString()
        {
            return direction.ToString();
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