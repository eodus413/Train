using UnityEngine;

namespace ProjectTrain
{
    public static class GameObjectExtension
    {
        public static Direction RelativeDirection(this GameObject lv, GameObject rv)
        {
            if (lv.transform.position.x < rv.transform.position.x) return Direction.Left;
            return Direction.Right;
        }
    }
}