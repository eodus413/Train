using UnityEngine;
using SingletonManager;

namespace ProjectCatMan
{
    public class RayManager
    {
        static RaycastHit2D hit;

        public static GameObject hitObj(Vector2 origin, Vector2 direction, float distance)
        {
            hit = Physics2D.Raycast(origin, direction, distance);
            if (!hit) return null;

            return hit.transform.gameObject;
        }
        public static GameObject hitObj(Vector2 origin,Vector2 direction,float distance,int layerMask)
        {
            hit = Physics2D.Raycast(origin,direction,distance,layerMask);
            if (!hit) return null;

            return hit.transform.gameObject;
        }
    }
}