using UnityEngine;

namespace DebugManager
{
    public static class DebugHelper
    {
        public static void StartCount()
        {
            Debug.Log("Start : " + Time.realtimeSinceStartup);
        }
        public static void EndCount()
        {
            Debug.Log("End : " + Time.realtimeSinceStartup);
        }
    }
}