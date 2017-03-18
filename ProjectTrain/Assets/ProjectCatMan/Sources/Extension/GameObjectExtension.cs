using UnityEngine;

namespace ProjectCatMan
{
    public static class GameObjectExtension
    {
        private static Vector3 turnLeft = new Vector3(0, 180, 0);
        private static Vector3 turnRight = new Vector3(0, 0, 0);
        public static void Turn2D(this GameObject lv,Direction direction)
        {
            if(direction == Direction.Left)
            {
                lv.transform.eulerAngles = turnLeft;
            }
            else
            {
                lv.transform.eulerAngles = turnRight;
            }
        }
    }
}