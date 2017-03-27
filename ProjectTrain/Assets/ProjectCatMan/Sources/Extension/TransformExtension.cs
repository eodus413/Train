using UnityEngine;

namespace ProjectCatMan
{
    public static class TransformExtension
    {
        public static bool isLeft(this Transform lv, Vector3 rv)
        {
            if (rv == null)
            {
                Debug.Log(rv + "is null, TransformExtension Direction return false");
                return false;
            }
            return lv.position.x < rv.x;
        }
        public static bool isLeft(this Transform lv,Transform rv)
        {
            if (rv == null)
            {
                Debug.Log(rv + "is null, TransformExtension Direction return false");
                return false;
            }
            return lv.position.x < rv.position.x;
        }
        public static bool isLeft(this Transform lv,GameObject rv)
        {
            if (rv == null)
            {
                Debug.Log(rv + "is null, TransformExtension Direction return false");
                return false;
            }
            return lv.position.x < rv.transform.position.x;
        }
        public static Direction LocationOf(this Transform lv, Vector3 rv)
        {
            if (lv.isLeft(rv)) return Direction.Right;
            else return Direction.Left;
        }
        public static Direction LocationOf(this Transform lv,Transform rv)
        {
            if (rv == null)
            {
                Debug.Log(rv + "is null, TransformExtension Direction return Vector2.zero");
                return Direction.None;
            }
            if (lv.isLeft(rv)) return Direction.Right;
            else return Direction.Left;
        }
        public static Direction LocationOf(this Transform lv, GameObject rv)
        {
            if(rv == null)
            {
                Debug.Log(rv + "is null, TransformExtension Direction return Vector2.zero");
                return Direction.None;
            }

            if (lv.isLeft(rv)) return Direction.Right;    //호출자가 타겟보다 왼쪽에 있으면 타겟의 위치는 오른쪽
            else return Direction.Left;
        }
    }
}