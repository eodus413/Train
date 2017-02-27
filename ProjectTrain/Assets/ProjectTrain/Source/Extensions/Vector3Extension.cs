using UnityEngine;

namespace ProjectTrain
{
    public static class Vector3Extension
    {
        public static bool isLeft(this Vector3 lv,Vector3 rv)
        {
            if (lv.x < rv.x) return true;
            return false;
        }
    }
}